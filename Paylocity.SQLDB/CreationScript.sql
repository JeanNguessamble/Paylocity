
CREATE TABLE [dbo].[CompanyBenefitDeductions](
	[BenefitContributionId] [int] IDENTITY(1,1) NOT NULL,
	[PaylocityCompanyId] [int] NULL,
	[EmployeeContributionAmount] [decimal](18, 2) NULL,
	[DependentContributionAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_CompanyBenefitContributions] PRIMARY KEY CLUSTERED 
(
	[BenefitContributionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyEmployeeDependents]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyEmployeeDependents](
	[EmployeeDependentId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyEmployeeId] [int] NULL,
	[DependentFirstName] [varchar](50) NULL,
	[DependentLastName] [varchar](50) NULL,
	[DependentRelationship] [varchar](50) NULL,
 CONSTRAINT [PK_CompanyEmployeeDependents] PRIMARY KEY CLUSTERED 
(
	[EmployeeDependentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyEmployees]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyEmployees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[EmployeeFirstName] [varchar](50) NULL,
	[EmployeeLastName] [varchar](50) NULL,
	[EmployeeUpdatedDate] [datetime] NULL,
	[EmployeeIsActive] [bit] NULL,
 CONSTRAINT [PK_CompanyEmployees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeePaychecks]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePaychecks](
	[PaycheckId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyEmployeeId] [int] NULL,
	[EmployeePaycheckAmount] [decimal](18, 2) NULL,
	[PaycheckUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_EmployeePaychecks] PRIMARY KEY CLUSTERED 
(
	[PaycheckId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogCompanyBenefitContributions]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogCompanyBenefitContributions](
	[LogCompanyBenefitContributionId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyEmployeeId] [int] NULL,
	[EmployeeBenefitContribution] [decimal](18, 2) NULL,
	[CompanyBenefitContributionDate] [datetime] NULL,
 CONSTRAINT [PK_LogCompanyBenefitContributions] PRIMARY KEY CLUSTERED 
(
	[LogCompanyBenefitContributionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogEmployeePaidChecksAmount]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogEmployeePaidChecksAmount](
	[LogPaidChecksAmountId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyEmployeeId] [int] NULL,
	[EmployeePaidCheckAmount] [decimal](18, 2) NULL,
	[PaidCheckCreatedDate] [datetime] NULL,
 CONSTRAINT [PK_CompanyCheckNumbers] PRIMARY KEY CLUSTERED 
(
	[LogPaidChecksAmountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaylocityCompanies]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaylocityCompanies](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[CompanyPayFreq] [int] NULL,
	[CompanyCreatedDate] [datetime] NULL,
	[CompanyIsActive] [bit] NULL,
 CONSTRAINT [PK_PaylocityCompanies] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CompanyEmployees] ADD  CONSTRAINT [DF_CompanyEmployees_EmployeeUpdatedId]  DEFAULT (getdate()) FOR [EmployeeUpdatedDate]
GO
ALTER TABLE [dbo].[CompanyEmployees] ADD  CONSTRAINT [DF_CompanyEmployees_EmployeeIsActive]  DEFAULT ((1)) FOR [EmployeeIsActive]
GO
ALTER TABLE [dbo].[EmployeePaychecks] ADD  CONSTRAINT [DF_EmployeePaychecks_BiweeklyUpdatedDate]  DEFAULT (getdate()) FOR [PaycheckUpdatedDate]
GO
ALTER TABLE [dbo].[LogCompanyBenefitContributions] ADD  CONSTRAINT [DF_LogCompanyBenefitContributions_CompanyBenefitContributionDate]  DEFAULT (getdate()) FOR [CompanyBenefitContributionDate]
GO
ALTER TABLE [dbo].[LogEmployeePaidChecksAmount] ADD  CONSTRAINT [DF_CompanyPaidChecksAmount_PaidCheckCreatedDate]  DEFAULT (getdate()) FOR [PaidCheckCreatedDate]
GO
ALTER TABLE [dbo].[PaylocityCompanies] ADD  CONSTRAINT [DF_PaylocityCompanies_CompanyPayFreq]  DEFAULT ((26)) FOR [CompanyPayFreq]
GO
ALTER TABLE [dbo].[PaylocityCompanies] ADD  CONSTRAINT [DF_PaylocityCompanies_CompanyCreatedDate]  DEFAULT (getdate()) FOR [CompanyCreatedDate]
GO
ALTER TABLE [dbo].[PaylocityCompanies] ADD  CONSTRAINT [DF_PaylocityCompanies_CompanyIsActive]  DEFAULT ((1)) FOR [CompanyIsActive]
GO
/****** Object:  StoredProcedure [dbo].[sprApplicationServices]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprApplicationServices] 

AS
BEGIN

	SET NOCOUNT ON;
SELECT PaylocityServiceId, PaylocityServiceName, PaylocityServiceIsActive, PaylocityServiceStatus, PaylocityServiceLastRun, PaylocityServiceNextRun
FROM     PaylocityApplicationServices
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompaniesBenefitAdd]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprCompaniesBenefitAdd] 
@companyId int, @employeeContribution decimal, @dependentContribution decimal
AS
BEGIN

	SET NOCOUNT ON;
	insert into [dbo].[CompanyBenefitDeductions]
	([PaylocityCompanyId], [EmployeeContributionAmount], [DependentContributionAmount]) 
	values
	(@companyId,@employeeContribution,@dependentContribution);

	Exec [dbo].[sprGetCompaniesBenefitById] @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompaniesBenefitDelete]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprCompaniesBenefitDelete]
@id int
AS
BEGIN

	SET NOCOUNT ON;
	Delete CompanyBenefitDeductions where BenefitContributionId = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompaniesBenefitGetSetup]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprCompaniesBenefitGetSetup] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT c.CompanyId, c.CompanyName, c.CompanyPayFreq, c.CompanyCreatedDate, c.CompanyIsActive, d.BenefitContributionId, d.EmployeeContributionAmount, d.DependentContributionAmount
FROM     PaylocityCompanies AS c INNER JOIN
   CompanyBenefitDeductions AS d ON c.CompanyId = d.PaylocityCompanyId
   where d.PaylocityCompanyId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompaniesBenefitUpdate]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprCompaniesBenefitUpdate]
@id int, @employeeContribution decimal, @dependentContribution decimal
AS
BEGIN

	SET NOCOUNT ON;
	Update CompanyBenefitDeductions set
	EmployeeContributionAmount = @employeeContribution, 
	DependentContributionAmount = @dependentContribution 
	where BenefitContributionId = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompanyEmployeeAdd]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprCompanyEmployeeAdd] 
@companyId int, @firstName varchar(50), @lastName varchar(50)
AS
BEGIN

	SET NOCOUNT ON;
	insert into [dbo].CompanyEmployees
	([CompanyId], [EmployeeFirstName], [EmployeeLastName]) 
	values
	(@companyId, @firstName, @lastName);

	exec  [dbo].[sprGetEmployeeById] @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompanyEmployeeContributionDelete]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprCompanyEmployeeContributionDelete] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
	delete [dbo].[LogEmployeePaidChecksAmount] where [CompanyEmployeeId] = @id;

	delete [dbo].[LogCompanyBenefitContributions] where [CompanyEmployeeId] = @id;

END
GO
/****** Object:  StoredProcedure [dbo].[sprCompanyEmployeeDelete]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprCompanyEmployeeDelete]
@id int
AS
BEGIN

	SET NOCOUNT ON;
	Delete CompanyEmployees where EmployeeId = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompanyEmployeeDependentAdd]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprCompanyEmployeeDependentAdd] 
@employeeId int, @firstName varchar(50), @lastName varchar(50), @relationship varchar(50)
AS
BEGIN

	SET NOCOUNT ON;
	insert into [dbo].CompanyEmployeeDependents
	([CompanyEmployeeId], [DependentFirstName], [DependentLastName], [DependentRelationship]) 
	values
	(@employeeId,@firstName, @lastName, @relationship);

	exec [dbo].[sprGetEmployeeDependentById] @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompanyEmployeeDependentDelete]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprCompanyEmployeeDependentDelete]
@id int
AS
BEGIN

	SET NOCOUNT ON;
	Delete CompanyEmployeeDependents where EmployeeDependentId = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompanyEmployeeDependentUpdate]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprCompanyEmployeeDependentUpdate]
@id int, @firstName varchar(50), @lastName varchar(50), @relationship varchar(50)
AS
BEGIN

	SET NOCOUNT ON;
	Update CompanyEmployeeDependents set
	DependentFirstName = @firstName, 
	DependentLastName = @lastName, 
	DependentRelationship = @relationship 
	where EmployeeDependentId = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sprCompanyEmployeeUpdate]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprCompanyEmployeeUpdate]
@id int, @firstName varchar(50), @lastName varchar(50), @active bit
AS
BEGIN

	SET NOCOUNT ON;
	Update CompanyEmployees set
	EmployeeFirstName = @firstName, 
	EmployeeLastName = @lastName, 
	EmployeeIsActive = @active 
	where EmployeeId = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sprEmployeeContributionDeductionAdd]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprEmployeeContributionDeductionAdd] 
@employeeId int, @payCheck decimal, @payContribution decimal
AS
BEGIN

	SET NOCOUNT ON;
	insert into [dbo].[LogEmployeePaidChecksAmount]
	([CompanyEmployeeId], [EmployeePaidCheckAmount]) 
	values
	(@employeeId,@payCheck);

	insert into [dbo].[LogCompanyBenefitContributions]
	([CompanyEmployeeId], [EmployeeBenefitContribution]) 
	values
	(@employeeId,@payContribution)

END
GO
/****** Object:  StoredProcedure [dbo].[sprEmployeePayCheckAdd]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprEmployeePayCheckAdd] 
@employeeId int, @amount decimal
AS
BEGIN

	SET NOCOUNT ON;
	insert into [dbo].EmployeePaychecks
	(CompanyEmployeeId, EmployeePaycheckAmount) 
	values
	(@employeeId, @amount);

	Exec [dbo].[sprGetEmployeePayCheckById] @id  = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[sprEmployeePayCheckDelete]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprEmployeePayCheckDelete]
@id int
AS
BEGIN

	SET NOCOUNT ON;
	Delete EmployeePaychecks where PaycheckId = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sprEmployeePayCheckUpdate]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprEmployeePayCheckUpdate]
@id int, @amount decimal
AS
BEGIN

	SET NOCOUNT ON;
	Update EmployeePaychecks set
	EmployeePaycheckAmount = @amount,
	PaycheckUpdatedDate = getdate()
	where PaycheckId = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetAllCompanyBenefits]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprGetAllCompanyBenefits] 

AS
BEGIN

	SET NOCOUNT ON;
SELECT c.CompanyId, c.CompanyName, c.CompanyPayFreq, c.CompanyCreatedDate, c.CompanyIsActive, 
d.BenefitContributionId, d.EmployeeContributionAmount, d.DependentContributionAmount
FROM     PaylocityCompanies AS c INNER JOIN
   CompanyBenefitDeductions AS d ON c.CompanyId = d.PaylocityCompanyId
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetCompaniesBenefitById]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprGetCompaniesBenefitById] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT c.CompanyId, c.CompanyName, c.CompanyPayFreq, c.CompanyCreatedDate, c.CompanyIsActive, d.BenefitContributionId, d.EmployeeContributionAmount, d.DependentContributionAmount
FROM     PaylocityCompanies AS c INNER JOIN
   CompanyBenefitDeductions AS d ON c.CompanyId = d.PaylocityCompanyId
   where d.BenefitContributionId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetEmployeeById]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprGetEmployeeById] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT e.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName, e.EmployeeIsActive, e.EmployeeUpdatedDate, 
c.CompanyName, c.CompanyPayFreq, c.CompanyCreatedDate, c.CompanyIsActive
FROM     PaylocityCompanies AS c INNER JOIN
                  CompanyEmployees AS e ON c.CompanyId = e.CompanyId
WHERE  (e.EmployeeId = @id)
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetEmployeeDependentById]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprGetEmployeeDependentById] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT e.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName, e.EmployeeIsActive, e.EmployeeUpdatedDate, 
d.EmployeeDependentId, d.DependentFirstName, d.DependentLastName, d.DependentRelationship
FROM     PaylocityCompanies AS c INNER JOIN
                  CompanyEmployees AS e ON c.CompanyId = e.CompanyId LEFT OUTER JOIN
                  CompanyEmployeeDependents AS d ON e.EmployeeId = d.CompanyEmployeeId
WHERE  (d.EmployeeDependentId = @id)
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetEmployeeDependents]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprGetEmployeeDependents] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT e.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName, e.EmployeeIsActive, e.EmployeeUpdatedDate, d.EmployeeDependentId, 
	d.DependentFirstName, d.DependentLastName, d.DependentRelationship
FROM     PaylocityCompanies AS c INNER JOIN
                  CompanyEmployees AS e ON c.CompanyId = e.CompanyId LEFT OUTER JOIN
                  CompanyEmployeeDependents AS d ON e.EmployeeId = d.CompanyEmployeeId
WHERE  (c.CompanyId = @id)
order by d.DependentLastName, d.DependentFirstName
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetEmployeeDependentsByEmployee]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprGetEmployeeDependentsByEmployee] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT e.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName, e.EmployeeIsActive, e.EmployeeUpdatedDate, 
d.EmployeeDependentId, d.DependentFirstName, d.DependentLastName, d.DependentRelationship
FROM     PaylocityCompanies AS c INNER JOIN
                  CompanyEmployees AS e ON c.CompanyId = e.CompanyId LEFT OUTER JOIN
                  CompanyEmployeeDependents AS d ON e.EmployeeId = d.CompanyEmployeeId
WHERE  (e.EmployeeId = @id)
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetEmployeePayCheckByEmployee]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprGetEmployeePayCheckByEmployee] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT e.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName, e.EmployeeIsActive, e.EmployeeUpdatedDate, 
p.PaycheckId, p.EmployeePaycheckAmount, p.PaycheckUpdatedDate
FROM     PaylocityCompanies AS c INNER JOIN
                  CompanyEmployees AS e ON c.CompanyId = e.CompanyId  JOIN
                  EmployeePaychecks AS p ON e.EmployeeId = p.CompanyEmployeeId
WHERE  (e.EmployeeId = @id)
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetEmployeePayCheckById]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprGetEmployeePayCheckById] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT e.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName, e.EmployeeIsActive, e.EmployeeUpdatedDate, p.PaycheckId, p.EmployeePaycheckAmount, p.PaycheckUpdatedDate
FROM     PaylocityCompanies AS c INNER JOIN
                  CompanyEmployees AS e ON c.CompanyId = e.CompanyId INNER JOIN
                  EmployeePaychecks AS p ON e.EmployeeId = p.CompanyEmployeeId
WHERE  (p.PaycheckId = @id)
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetEmployeePayChecks]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprGetEmployeePayChecks] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT e.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName, e.EmployeeIsActive, e.EmployeeUpdatedDate, 
p.PaycheckId, p.EmployeePaycheckAmount, p.PaycheckUpdatedDate, c.CompanyName, c.CompanyPayFreq, 
                  c.CompanyIsActive
FROM     PaylocityCompanies AS c INNER JOIN
                  CompanyEmployees AS e ON c.CompanyId = e.CompanyId LEFT OUTER JOIN
                  EmployeePaychecks AS p ON e.EmployeeId = p.CompanyEmployeeId
WHERE  (c.CompanyId = @id)
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetEmployees]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprGetEmployees] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT e.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName, e.EmployeeIsActive, e.EmployeeUpdatedDate
FROM     PaylocityCompanies AS c INNER JOIN
                  CompanyEmployees AS e ON c.CompanyId = e.CompanyId
WHERE  (c.CompanyId = @id)
order by e.EmployeeLastName, e.EmployeeFirstName
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetLogEmployeePaidCheckByCompany]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprGetLogEmployeePaidCheckByCompany] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
SELECT e.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName, e.EmployeeIsActive, e.EmployeeUpdatedDate, 
a.LogPaidChecksAmountId, a.EmployeePaidCheckAmount, a.PaidCheckCreatedDate
FROM     PaylocityCompanies AS c INNER JOIN
                  CompanyEmployees AS e ON c.CompanyId = e.CompanyId INNER JOIN
                  LogEmployeePaidChecksAmount AS a ON e.EmployeeId = a.CompanyEmployeeId
WHERE  (c.CompanyId = @id)
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetPaylocityCompanies]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprGetPaylocityCompanies] 

AS
BEGIN

	SET NOCOUNT ON;
select [CompanyId], [CompanyName], [CompanyPayFreq], [CompanyCreatedDate], [CompanyIsActive]
from PaylocityCompanies
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetPaylocityCompany]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprGetPaylocityCompany] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
select [CompanyId], [CompanyName], [CompanyPayFreq], [CompanyCreatedDate], [CompanyIsActive]
from PaylocityCompanies
where [CompanyId] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sprGetPaylocityCompanyById]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sprGetPaylocityCompanyById] 
@id int
AS
BEGIN

	SET NOCOUNT ON;
select [CompanyId], [CompanyName], [CompanyPayFreq], [CompanyCreatedDate], [CompanyIsActive]
from PaylocityCompanies where [CompanyId] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sprPaylocityCompanyAdd]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprPaylocityCompanyAdd] 
@name varchar(100), @pay_frequency int
AS
BEGIN

	SET NOCOUNT ON;
	insert into [dbo].PaylocityCompanies
	([CompanyName], [CompanyPayFreq]) 
	values
	(@name,@pay_frequency);

	select * from PaylocityCompanies where CompanyId = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[sprPaylocityCompanyDelete]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sprPaylocityCompanyDelete]
@id int
AS
BEGIN

	SET NOCOUNT ON;
	Delete PaylocityCompanies where CompanyId = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sprPaylocityCompanyUpdate]    Script Date: 12/12/2021 7:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sprPaylocityCompanyUpdate]
@id int, @name varchar(100), @pay_frequency int, @active bit
AS
BEGIN

	SET NOCOUNT ON;
	Update PaylocityCompanies set
	[CompanyName] = @name, 
	[CompanyIsActive] = @active, 
	[CompanyPayFreq] = @pay_frequency 
	where CompanyId = @id;
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pay Frequency biweekly = 26, weekly = 52' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PaylocityCompanies', @level2type=N'COLUMN',@level2name=N'CompanyPayFreq'
GO
USE [master]
GO
ALTER DATABASE [InterviewPaylocity] SET  READ_WRITE 
GO
