
INSERT INTO [dbo].[CompanyBenefitDeductions]
           ([PaylocityCompanyId]
           ,[EmployeeContributionAmount]
           ,[DependentContributionAmount])
     VALUES
           (1,	'1000.00',	'500.00')
GO

INSERT INTO [dbo].[CompanyEmployeeDependents]
           ([CompanyEmployeeId]
           ,[DependentFirstName]
           ,[DependentLastName]
           ,[DependentRelationship])
     VALUES
           (1,'Aurora','Rogers','Wife'),
           (5,'Jane','Adams','Wife'),
           (4,'Mark','Lilley','Husband'),
           (1,'Jade','Rogers','Daughter'),
           (1,'Jack','Rogers','Son'),
           (1,'Jerry','Rogers','Son'),
           (6,'Sabrina','Dexter','Wife')	
GO
INSERT INTO [dbo].[CompanyEmployees]
           ([CompanyId]
           ,[EmployeeFirstName]
           ,[EmployeeLastName]
           ,[EmployeeUpdatedDate]
           ,[EmployeeIsActive])
     VALUES
           (1,'Oliver','Rogers', getdate(),1),
           (2,'Theodore','Ryan', getdate(),1),
           (1,'Violet','Paul', getdate(),1),
           (1,'Aurora','Lilley', getdate(),1),
           (1,'John','Adams', getdate(),1),
           (1,'Charlotte','Dexter', getdate(),1),
           (1,'Jasper','Silas', getdate(),1)
GO

INSERT INTO [dbo].[EmployeePaychecks]
           ([CompanyEmployeeId]
           ,[EmployeePaycheckAmount]
           ,[PaycheckUpdatedDate])
     VALUES
           (1 ,'2000.00', getDate()),
           (3 ,'2000.00', getDate()),
           (4 ,'2000.00', getDate()),
           (5 ,'2000.00', getDate())
GO

INSERT INTO [dbo].[PaylocityCompanies]
           ([CompanyName]
           ,[CompanyPayFreq]
           ,[CompanyCreatedDate]
           ,[CompanyIsActive])
     VALUES
           ('ADT Transport',26,getdate(),1),
           ('Wink Systems',52,getdate(),1)
GO