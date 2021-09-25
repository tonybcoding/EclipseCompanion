--
-- Insert default user and general config information
--
INSERT INTO [dbo].[Users] (FirstName, LastName, LoginId, EmailAddress, Password, AccessLevel, Active, Locked, ForcePasswordChange, CreateDate, LastUpdated)
	VALUES('Primary', 'Account', 'admin', 'admin@email.com','?O??????k?w?????[??????%', 1, 1, 0, 0, getdate(), getdate());

INSERT INTO [dbo].[GeneralConfiguration]
	VALUES (0, getdate(), 0, 0, '##', 'Green', 'Yellow', 'Red', 'Low', 'Moderate', 'High',
	'Good', 'Managed', 'Will Be late', 'Healthy', 'Managed', 'Alert');