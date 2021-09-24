using EclipseCompanionControlLibrary;
using EclipseCompanionModelLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
// right-click on references and click Manage NuGet packages,
// then selected Browse and searched for Excel
using Excel = Microsoft.Office.Interop.Excel;

namespace EclipseCompanionView
{
    public partial class ExportForm : Form
    {

        private bool cancelExport { get; set; }
        private int excelRow { get; set; }
        private int progressBarValue { get; set; } = 0;
        private int projectCount { get; set; } = 0;

        public ExportForm()
        {
            InitializeComponent();
            sinceDateTimePicker.MaxDate = DateTime.Today;
            sinceDateTimePicker.Value = DateTime.Today;
        }

        private void ExportToExcel(IProgress<string> progress, IProgress<int> pbarperc, DateTime sinceDate, Excel.Application xlApp, Excel.Workbook xlWorkbook, Excel.Worksheet ws)
        {
            try
            {
                progress.Report($"Preparing export...");

                // will store column indexes of required fields
                int createdDateColIndex = 0;
                int modifiedDateColIndex = 0;
                int statusTypeIdColIndex = 0;
                int fullNotesColIndex = 0;

                // Populate list of projects and fldCols
                List<ProjectModel> projects = Linq2SqlProcessor.GetProjectsFromSql(EclipseCompanionModelLibrary.Filter.All);
                List<ColumnModel> fldCols = Linq2SqlProcessor.GetColumnConfigs();
                List<string> indicatorValues = Linq2SqlProcessor.GetIndicatorValues();

                // use reflection to get properties of ProjectModel class
                PropertyInfo[] properties = typeof(ProjectModel).GetProperties();

                // check for any donotdisplay fields that keep list from being continguous
                MakeToDisplaysContiguous();

                // add required fields if not already included in fldCols ToDisplay properties
                AddAncillaryFieldsIfNeeded();

                // Perform initial format of columns and return number of columns to export
                int numOfDisplayCols = AddColumnHeaderLables();

                // progress label and bar variables
                int pcount = 0;
                int numOfTouchPoints = projects.Count() * numOfDisplayCols;
                double percentRatio = 100.0 / numOfTouchPoints;

                progress.Report($"Exporting {projects.Count()} projects...");

                foreach (ColumnModel c in fldCols)
                {
                    if (!cancelExport && c.ToDisplay)
                    {
                        int eRow = 2; // first row is header labels
                        int disCol = c.DisplayColumn + 1;

                        foreach (ProjectModel p in projects)
                        {
                            // report percentage to upgrade progressbar
                            pcount++;
                            int sendToProgressBarUpdate = Convert.ToInt32(percentRatio * pcount) > 100 ? 100 : Convert.ToInt32(percentRatio * pcount);
                            pbarperc.Report(Convert.ToInt32(sendToProgressBarUpdate));

                            if (!cancelExport)
                            {
                                bool fieldFound = false;

                                // find project property name via reflection
                                foreach (PropertyInfo prop in properties)
                                {
                                    if (prop.Name == c.FieldName)
                                    {
                                        fieldFound = true;
                                        var value = prop.GetValue(p, null);

                                        // if DateTime, show short date only if date should be shown
                                        if (prop.PropertyType == typeof(DateTime))
                                        {
                                            if (ShowDate(p.StatusTypeId, prop.Name))
                                            {
                                                DateTime temp = (DateTime)value;
                                                ws.Cells[eRow, disCol] = temp.ToShortDateString();
                                                ws.Cells[eRow, disCol].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                            }
                                        }
                                        // if Decimal, treat as percentage and convert accordingly
                                        else if (prop.PropertyType == typeof(Decimal))
                                        {
                                            Decimal temp = (Decimal)value;
                                            ws.Cells[eRow, disCol] = Convert.ToString(Convert.ToInt32(temp * 100)) + "%";
                                            ws.Cells[eRow, disCol].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        }
                                        else
                                        {
                                            ws.Cells[eRow, disCol] = value;
                                        }
                                        // if reference cell, shade accordingly
                                        if (c.ReferenceOnly)
                                        {
                                            ws.Cells[eRow, disCol].Interior.Color = Color.Orange;
                                        }
                                        break; // can stop searching
                                    }
                                }

                                // if field not found, search through project indicators
                                if (!fieldFound)
                                {
                                    foreach (ProjectModel.Indicator i in p.ListOfStatusIndicators)
                                    {
                                        if (i.Name == c.FieldName)
                                        {
                                            bool isKnownIndicator = false;
                                            if (i.StateName != "Not Set")
                                            {
                                                Color shading = Color.White;
                                                string newValue = "";
                                                isKnownIndicator = GlobalCode.ProcessIndicator("Complexity", i, c, indicatorValues, 3, ref shading, ref newValue) ||
                                                     GlobalCode.ProcessIndicator("Schedule", i, c, indicatorValues, 6, ref shading, ref newValue) ||
                                                     GlobalCode.ProcessIndicator("Overall Project Health", i, c, indicatorValues, 9, ref shading, ref newValue);
                                                if (isKnownIndicator)
                                                {
                                                    //replace indicators and shade cells appropriately
                                                    Excel.Range cell = ws.Cells[eRow, disCol];
                                                    cell.Value = newValue;
                                                    cell.Interior.Color = shading;
                                                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                                }
                                            }
                                            break; // can stop searching
                                        }
                                    }
                                }
                            }
                            eRow++;
                        }
                    }
                }

                progress.Report($"Formatting primary sheet...");
                FormatFirstRow();
                GeneralFormatting();
                ws.UsedRange.Rows[1].AutoFilter();
                ws.Name = GlobalCode.ExportSheets[0];

                progress.Report($"Creating additional sheets...");
                pbarperc.Report(0);
                CreateAdditionalSheets();
                xlWorkbook.Sheets[1].Select();

                //////////////////////////////////////////////////
                // local functions
                //////////////////////////////////////////////////
                void CreateAdditionalSheets()
                {
                    string sinceDateString = sinceDate.ToShortDateString();
                    StringBuilder sb = new StringBuilder();
                    foreach (char c in sinceDateString)
                    {
                        sb.Append(c == '/' ? '-' : c);
                    }
                    sinceDateString = sb.ToString();
                    
                    // hide reference only cells
                    ws = xlWorkbook.Sheets[GlobalCode.ExportSheets[0]];
                    foreach (ColumnModel c in fldCols)
                    {
                        HideIfNeeded(c);
                    }

                    // create sheets (copy first to each)
                    ws = xlWorkbook.Sheets[GlobalCode.ExportSheets[0]];
                    for (int i = 1; i < GlobalCode.ExportSheets.Count(); i++)
                    {
                        ws.Copy(Type.Missing, xlWorkbook.Sheets[xlWorkbook.Sheets.Count]);
                        xlWorkbook.Sheets[xlWorkbook.Sheets.Count].Name = GlobalCode.ExportSheets[i];
                    }
                    AddRowCountToSheet();

                    // active sheet filtering
                    string[] active = new string[] { GlobalCode.ActiveQueuedStatusCategory.ToString(), GlobalCode.ActiveStatusCategory.ToString() };
                    ws = xlWorkbook.Sheets[GlobalCode.ExportSheets[1]];
                    ws.UsedRange.Rows[1].AutoFilter(
                        statusTypeIdColIndex,
                        active.ToArray(),
                        Excel.XlAutoFilterOperator.xlFilterValues,
                        Type.Missing,
                        true);
                    AddRowCountToSheet();

                    // suspended sheet filtering
                    ws = xlWorkbook.Sheets[GlobalCode.ExportSheets[2]];
                    ws.UsedRange.Rows[1].AutoFilter(
                        statusTypeIdColIndex,
                        $"={GlobalCode.SuspendedStatusCategory}",
                        Excel.XlAutoFilterOperator.xlFilterValues,
                        Type.Missing,
                        true);
                    AddRowCountToSheet();

                    // new since filtering
                    ws = xlWorkbook.Sheets[GlobalCode.ExportSheets[3]];
                    ws.UsedRange.Rows[1].AutoFilter(
                        createdDateColIndex,
                        $">={sinceDate}",
                        Excel.XlAutoFilterOperator.xlFilterValues,
                        Type.Missing,
                        true);
                    AddRowCountToSheet();

                    // closed since filtering
                    ws = xlWorkbook.Sheets[GlobalCode.ExportSheets[4]];
                    ws.UsedRange.Rows[1].AutoFilter(
                        modifiedDateColIndex,
                        $">={sinceDate}",
                        Excel.XlAutoFilterOperator.xlAnd,
                        Type.Missing,
                        true);
                    ws.UsedRange.Rows[1].AutoFilter(
                        statusTypeIdColIndex,
                        $"={GlobalCode.ClosedStatusCategory}",
                        Excel.XlAutoFilterOperator.xlFilterValues,
                        Type.Missing,
                        true);
                    AddRowCountToSheet();

                    ///////////////////////////////////////////////////
                    // local functions
                    ///////////////////////////////////////////////////
                    void AddRowCountToSheet()
                    {
                        double rowCount = xlApp.WorksheetFunction.Subtotal(3, ws.UsedRange.Columns[1]) - 1; // remove header row
                        ws.Name += (ws.Name == GlobalCode.ExportSheets[3] || ws.Name == GlobalCode.ExportSheets[4]) ? $" {sinceDateString} | {rowCount}" : ws.Name += $" | {rowCount}";
                    }
                    
                    void HideIfNeeded(ColumnModel cM)
                    {
                        if (cM.ReferenceOnly)
                        {
                            ws.Columns[cM.DisplayColumn + 1].Hidden = true;
                        }
                    }
                }

                void MakeToDisplaysContiguous()
                {
                    int lastColumn = fldCols.Count();
                    for (int i = 0; i < fldCols.Count() - 1; i++)
                    {
                        if (!fldCols[i].ToDisplay)
                        {
                            // move all positions up one
                            int position = fldCols[i].DisplayColumn;
                            for (int j = i + 1; j < fldCols.Count(); j++)
                            {
                                fldCols[j].DisplayColumn = position++;
                            }
                            fldCols[i].DisplayColumn = ++lastColumn;
                        }
                    }
                }

                void AddAncillaryFieldsIfNeeded()
                {
                    //find last display column while identifying if these required fields are present
                    bool createdExists = false;
                    bool modifiedExists = false;
                    bool fullNotesExists = false;
                    bool statusTypeIdExists = false;
                    List<int> colPositions = new List<int>();
                    foreach (ColumnModel c in fldCols)
                    {
                        if (c.ToDisplay)
                        {
                            colPositions.Add(c.DisplayColumn);
                            FieldFound(c, GlobalCode.FullNotesField, ref fullNotesExists, ref fullNotesColIndex);
                            FieldFound(c, GlobalCode.CreatedField, ref createdExists, ref createdDateColIndex);
                            FieldFound(c, GlobalCode.ModifiedField, ref modifiedExists, ref modifiedDateColIndex);
                            FieldFound(c, GlobalCode.StatusTypeIdField, ref statusTypeIdExists, ref statusTypeIdColIndex);
                        }
                    }
                    colPositions.Sort();
                    int lastUsedColumn = colPositions.Last();

                    AddToDisplayAsNeeded(ref fullNotesExists, GlobalCode.FullNotesField, ref fullNotesColIndex);
                    AddToDisplayAsNeeded(ref createdExists, GlobalCode.CreatedField, ref createdDateColIndex);
                    AddToDisplayAsNeeded(ref modifiedExists, GlobalCode.ModifiedField, ref modifiedDateColIndex);
                    AddToDisplayAsNeeded(ref statusTypeIdExists, GlobalCode.StatusTypeIdField, ref statusTypeIdColIndex);

                    /////////////////////////////////////////
                    // local functions
                    /////////////////////////////////////////
                    void AddToDisplayAsNeeded(ref bool exists, string gFieldName, ref int index)
                    {
                        foreach (ColumnModel c in fldCols)
                        {
                            if (!exists)
                            {
                                if (c.FieldName == gFieldName)
                                {
                                    c.ToDisplay = true;
                                    c.ReferenceOnly = true;
                                    c.DisplayColumn = ++lastUsedColumn;
                                    index = c.DisplayColumn + 1; // Excel is 1-based, whicle we store in object as 0-based (datagridview base)
                                    exists = true;
                                    break;
                                }
                            }
                        }
                    }

                    void FieldFound(ColumnModel cM, string gFieldName, ref bool exists, ref int index)
                    {
                        if (!exists && cM.FieldName == gFieldName)
                        {
                            exists = true;
                            index = cM.DisplayColumn + 1; // Excel is 1-based, whicle we store in object as 0-based (datagridview base)
                        }
                    }
                }

                bool ShowDate(int typeId, string fieldName)
                {
                    bool showIt = true;
                    if (typeId != GlobalCode.ActiveStatusCategory && (fieldName == GlobalCode.StartDateField || fieldName == GlobalCode.EndDateField))
                    {
                        showIt = false;
                    }
                    return showIt;
                }

                void FormatFirstRow()
                {
                    foreach (Excel.Range cell in ws.UsedRange.Rows[1].Cells)
                    {
                        cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        cell.Interior.Color = Color.Blue;
                        cell.Font.Color = Color.White;
                    }
                }

                void GeneralFormatting()
                {
                    ws.UsedRange.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                    ws.UsedRange.RowHeight = 15;
                    ws.UsedRange.Borders.LineStyle = Excel.XlBorderWeight.xlThin;
                    ws.UsedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    ws.UsedRange.Borders.Color = Color.Black;
                }

                int AddColumnHeaderLables()
                {
                    int count = 0;
                    foreach (ColumnModel c in fldCols)
                    {
                        if (c.ToDisplay)
                        {
                            int colIndex = c.DisplayColumn + 1;
                            if (c.ReferenceOnly)
                            {
                                ws.Cells[1, colIndex] = c.FieldName;
                            }
                            else
                            {
                                ws.Cells[1, colIndex] = c.DisplayName;
                            }
                            Excel.Range col = ws.Columns[colIndex];
                            col.ColumnWidth = Convert.ToInt32(c.ColumnWidth / 7.2); // 7.2 is an estimate of pixels to Excel column width
                            count++;
                        }
                    }
                    return count;
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.cancelExport = true;
            cancelButton.Enabled = false;
        }

        private async void exportButton_Click(object sender, EventArgs e)
        {
            exportButton.Enabled = false;
            sinceDateTimePicker.Enabled = false;
            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            if (!CheckIfExcelInstalled()) return;       // if Excel is not installed, clean up and exit method
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet ws = xlWorkbook.Worksheets[1];

            try
            {
                var progress = new Progress<string>(s => exportStatusLabel.Text = s);
                var pbarperc = new Progress<int>(i => exportProgressBar.Value = i);
                await System.Threading.Tasks.Task.Run(() => ExportToExcel(progress, pbarperc, this.sinceDateTimePicker.Value, xlApp, xlWorkbook, ws));
                exportStatusLabel.Text = "Closing Excel...";
            }
            catch (Exception ex)
            {
                exportStatusLabel.Text = "Export Failed.";
                GlobalCode.ExceptionHandler(ex);
            }

            ProperlyExitExcel();
            exportStatusLabel.Text = "Complete.";

            /////////////////////////////////////////////////////
            // local functions
            /////////////////////////////////////////////////////
            bool CheckIfExcelInstalled()
            {
                if (xlApp == null)
                {
                    cancelButton.Enabled = false;
                    MessageBox.Show("Excel is not properly installed, so an export to Excel is not possible",
                        "Unable to proceed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    xlApp.Quit();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(xlApp);
                    cancelButton.Hide();
                    closeButton.Show();
                    closeButton.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }

            void ProperlyExitExcel()
            {
                cancelButton.Enabled = false;
                if (!cancelExport)
                {
                    xlWorkbook.Close(true);
                }
                else
                {
                    xlWorkbook.Close(false, misValue, misValue);
                }
                xlApp.Quit();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(ws);
                Marshal.ReleaseComObject(xlApp);
                cancelButton.Hide();
                closeButton.Show();
                closeButton.Focus();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
