--EXEC sp_MSForEachTable 'DISABLE TRIGGER ALL ON ?'
--GO
--EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
--GO
--EXEC sp_MSForEachTable 'SET QUOTED_IDENTIFIER ON; DELETE FROM ?'
--GO
--EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
--GO
--EXEC sp_MSForEachTable 'ENABLE TRIGGER ALL ON ?'
--GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'6E8C83BF-A029-4E32-AF75-8D950D94EE20', NULL, N'SuperAdmin', N'SuperAdmin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'8CA7BFA2-27AC-47AD-AE7B-47CB42ABA334', NULL, N'PatientAdmin', N'PatientAdmin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'D00442A9-8E71-4107-8919-F0E0DB95D4D7', NULL, N'TrustAdmin', N'TrustAdmin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'D19B13D8-9037-4B37-B368-14C684016B4E', NULL, N'Staff', N'Staff')
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'FBE19B08-3659-44C4-A69C-5E5A845E4F30', NULL, N'Patient', N'Patient')
GO

INSERT [dbo].[IdentityUser] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Discriminator], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [AddressId], [AlternativeTel], [DateOfBirth], [FirstName], [GenderId], [IsApproved], [IsResetPasswordRequired], [MobileNumber], [Surname]) VALUES (N'27b2879b-7f1b-4af7-814c-dd4a3b73ae4a', 0, N'42f5f456-df47-48f0-89fd-1ba985aa436b', N'ApplicationUser', N'staff@pharmix.co.uk', 0, 1, NULL, N'STAFF@PHARMIX.CO.UK', N'STAFF@PHARMIX.CO.UK', N'AQAAAAEAACcQAAAAEHZqDT9mz2yJYPIavAandUJRqbbNpaX6jx/GcIoUR4d/r3Q+edgAOqrCIPSCINutJA==', NULL, 0, N'244d4786-4ea5-441f-b86f-827359d2edd5', 0, N'staff@pharmix.co.uk', NULL, NULL, CAST(N'1980-07-30 00:00:00.0000000' AS DateTime2), N'Staff', 1, 1, NULL, NULL, N'Pharmix')
GO
INSERT [dbo].[IdentityUser] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Discriminator], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [AddressId], [AlternativeTel], [DateOfBirth], [FirstName], [GenderId], [IsApproved], [IsResetPasswordRequired], [MobileNumber], [Surname]) VALUES (N'bb0d67f8-f007-4d5f-8053-130defd97ba4', 0, N'b9a80aeb-ed54-430d-b4ce-595cc90aecac', N'ApplicationUser', N'trustadmin@pharmix.co.uk', 0, 1, NULL, N'TRUSTADMIN@PHARMIX.CO.UK', N'TRUSTADMIN@PHARMIX.CO.UK', N'AQAAAAEAACcQAAAAEHZqDT9mz2yJYPIavAandUJRqbbNpaX6jx/GcIoUR4d/r3Q+edgAOqrCIPSCINutJA==', NULL, 0, N'244d4786-4ea5-441f-b86f-827359d2edd5', 0, N'trustadmin@pharmix.co.uk', NULL, NULL, NULL, N'Admin', 1, 1, NULL, NULL, N'Trust')

GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bb0d67f8-f007-4d5f-8053-130defd97ba4', N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'27b2879b-7f1b-4af7-814c-dd4a3b73ae4a', N'D19B13D8-9037-4B37-B368-14C684016B4E')
GO

SET IDENTITY_INSERT [trusts].[Trusts] ON 
GO
INSERT [trusts].[Trusts] ([Id], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [FridayOpenTiming], [IsArchived], [LogoImage], [LogoImageName], [MondayOpenTiming], [Name], [SaturdayOpenTiming], [SundayOpenTiming], [ThursdayOpenTiming], [TuesdayOpenTiming], [UpdatedDate], [UpdatedUser], [WednesdayOpenTiming], [AppointmentIntervalMins], [FridayEndTiming], [MondayEndTiming], [SaturdayEndTiming], [SundayEndTiming], [ThursdayEndTiming], [TuesdayEndTiming], [WednesdayEndTiming]) VALUES (1, NULL, NULL, CAST(N'2018-01-01 00:00:00.0000000' AS DateTime2), N'admin', N'08:00', 0, NULL, NULL, N'08:30', N'NHS Trust', N'08:30', N'08:30', N'08:30', N'08:30', NULL, NULL, N'08:30', 15, N'17:30', N'17:30', N'17:30', N'17:30', N'17:30', N'17:30', N'17:30')
GO
SET IDENTITY_INSERT [trusts].[Trusts] OFF

GO
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (1, N'Male')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (2, N'Female')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (3, N'Transgender')
GO

SET IDENTITY_INSERT [dbo].[Module] ON
GO
INSERT [dbo].[Module] ([Id], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [Description], [IsArchived], [Name], [UpdatedDate], [UpdatedUser]) VALUES (1, NULL, NULL, CAST(N'2018-05-12 15:32:47.0200000' AS DateTime2), NULL, N'User', 0, N'User', NULL, NULL)
GO
INSERT [dbo].[Module] ([Id], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [Description], [IsArchived], [Name], [UpdatedDate], [UpdatedUser]) VALUES (2, NULL, NULL, CAST(N'2018-06-20 15:32:47.0200000' AS DateTime2), NULL, N'Patient', 0, N'Patient', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Module] OFF
GO

SET IDENTITY_INSERT [dbo].[TrustModule] ON 

GO
INSERT [dbo].[TrustModule] ([Id], [ModuleId], [TrustId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[TrustModule] ([Id], [ModuleId], [TrustId]) VALUES (2, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[TrustModule] OFF
GO

SET IDENTITY_INSERT [dbo].[Group] ON 
GO
INSERT [dbo].[Group] ([Id], [Name], [TrustId]) VALUES (4, N'Production Group', 1)
GO
INSERT [dbo].[Group] ([Id], [Name], [TrustId]) VALUES (5, N'Lookup Group', 1)
GO
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTrust] ON 

GO
INSERT [dbo].[UserTrust] ([Id], [TrustId], [UserId]) VALUES (1, 1, N'bb0d67f8-f007-4d5f-8053-130defd97ba4')
GO
INSERT [dbo].[UserTrust] ([Id], [TrustId], [UserId]) VALUES (3, 1, N'27b2879b-7f1b-4af7-814c-dd4a3b73ae4a')
GO
SET IDENTITY_INSERT [dbo].[UserTrust] OFF
GO
SET IDENTITY_INSERT [dbo].[Permission] ON 

GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (4, N'fa-users', N'', 1, N'User', 1, N'Users', 0, 0, N'#')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (5, N'fa-users text-success', N'', 1, N'User_Index', 1, N'User Master', 4, 1, N'/User/Index')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (6, N'fa-object-group text-primary', N'', 0, N'User_ManageModule', 1, N'Modules', 4, 2, N'/User/ManageModule')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (7, N'fa-user-secret', N'', 0, N'User_ManagePermission', 1, N'User ManagePermissions', 4, 2, N'/User/ManagePermission')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (8, N'fa-id-card text-primary', N'', 0, N'User_ManageUserRole', 1, N'User Roles', 4, 2, N'/User/ManageUserRole')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (9, N'fa-list text-primary', N'', 1, N'User_Roles', 1, N'Roles', 4, 2, N'/User/Roles')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (14, N'fa-user-plus text-primary', N'', 0, N'User_Create', 1, N'User Create', 4, 6, N'#')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (15, N'fa-user', N'', 0, N'User_Edit', 1, N'User Edit', 4, 6, N'#')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (16, N'fa-user-secret', N'Permission Group', 1, N'PermissionGroup_Index', 1, N'Permission Group', 4, 3, N'/PermissionGroup/Index')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (20, N'fa-user', NULL, 1, N'Patient', 2, N'Patient', 0, 0, N'#')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (22, N'fa-info-circle text-primary', NULL, 0, N'Patient_Detail', 2, N'Patient Detail', 20, 1, N'/Patient/Detail')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (23, N'fa-users text-primary', NULL, 1, N'Patient_Index', 2, N'Patient List', 20, 2, N'/Patient/Index')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (24, N'fa-calendar', N'', 1, N'Scheduler_INdex', 2, N'Schedule', 20, 3, N'/Scheduler/Index')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (43, N'fa-users text-primary', N'', 0, N'User_Delete', 1, N'User Delete', 4, 0, N'#')
GO
INSERT [dbo].[Permission] ([Id], [CssClass], [DisplayName], [IsShowMenu], [Key], [ModuleId], [Name], [ParentPermissionId], [Sort], [Url]) VALUES (44, N'fa-th-list', N'', 1, N'Departments', 1, N'Departments', 0, 0, N'/Department/Index')
GO
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO
SET IDENTITY_INSERT [dbo].[RolePermission] ON 

GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (9, NULL, 5, N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (10, NULL, 6, N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (11, NULL, 7, N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (12, NULL, 8, N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (13, NULL, 9, N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (14, NULL, 14, N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (15, NULL, 15, N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (16, NULL, 16, N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (20, NULL, 22, N'FBE19B08-3659-44C4-A69C-5E5A845E4F30')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (21, NULL, 23, N'8CA7BFA2-27AC-47AD-AE7B-47CB42ABA334')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (22, NULL, 24, N'D19B13D8-9037-4B37-B368-14C684016B4E')
GO
INSERT [dbo].[RolePermission] ([Id], [GroupId], [PermissionId], [RoleId]) VALUES (23, NULL, 44, N'D00442A9-8E71-4107-8919-F0E0DB95D4D7')
GO
SET IDENTITY_INSERT [dbo].[RolePermission] OFF
GO

SET IDENTITY_INSERT [pat].[Patient] ON 

GO
INSERT [pat].[Patient] ([Id], [AddressLine1], [AddressLine2], [AddressLine3], [AlternativeTel], [ArchivedDate], [ArchivedUser], [City], [County], [CreatedDate], [CreatedUser], [DateOfBirth], [EmailAddress], [FirstName], [GenderId], [IdNumber], [IsArchived], [LastVisitedDate], [MobileNumber], [NhsNumber], [PasNumber], [Postcode], [RegisteredDate], [RequiresPasswordReset], [Surname], [UpdatedDate], [UpdatedUser], [UserId]) VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-08-08 21:48:14.1145200' AS DateTime2), N'staff@pharmix.co.uk', CAST(N'1988-11-19 00:00:00.0000000' AS DateTime2), N'de@g.com', N'Robert', 1, NULL, 0, NULL, N'123', N'NHS456', N'PAS001', NULL, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, N'Clive', CAST(N'2018-08-08 21:50:33.9526963' AS DateTime2), N'staff@pharmix.co.uk', NULL)
GO
INSERT [pat].[Patient] ([Id], [AddressLine1], [AddressLine2], [AddressLine3], [AlternativeTel], [ArchivedDate], [ArchivedUser], [City], [County], [CreatedDate], [CreatedUser], [DateOfBirth], [EmailAddress], [FirstName], [GenderId], [IdNumber], [IsArchived], [LastVisitedDate], [MobileNumber], [NhsNumber], [PasNumber], [Postcode], [RegisteredDate], [RequiresPasswordReset], [Surname], [UpdatedDate], [UpdatedUser], [UserId]) VALUES (2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-08-08 21:50:34.1293440' AS DateTime2), N'staff@pharmix.co.uk', CAST(N'1992-02-13 00:00:00.0000000' AS DateTime2), N'depa12@g.com', N'Indiana', 2, NULL, 0, NULL, N'789', N'NHS456', N'PAS002', NULL, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, N'Jonse', NULL, NULL, NULL)
GO
INSERT [pat].[Patient] ([Id], [AddressLine1], [AddressLine2], [AddressLine3], [AlternativeTel], [ArchivedDate], [ArchivedUser], [City], [County], [CreatedDate], [CreatedUser], [DateOfBirth], [EmailAddress], [FirstName], [GenderId], [IdNumber], [IsArchived], [LastVisitedDate], [MobileNumber], [NhsNumber], [PasNumber], [Postcode], [RegisteredDate], [RequiresPasswordReset], [Surname], [UpdatedDate], [UpdatedUser], [UserId]) VALUES (3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-08-08 21:50:34.2044179' AS DateTime2), N'staff@pharmix.co.uk', CAST(N'1967-02-13 00:00:00.0000000' AS DateTime2), N'depa23@g.com', N'Bill', 2, NULL, 0, NULL, N'45464', N'NHS456', N'PAS003', NULL, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, N'Moore', NULL, NULL, NULL)
GO
INSERT [pat].[Patient] ([Id], [AddressLine1], [AddressLine2], [AddressLine3], [AlternativeTel], [ArchivedDate], [ArchivedUser], [City], [County], [CreatedDate], [CreatedUser], [DateOfBirth], [EmailAddress], [FirstName], [GenderId], [IdNumber], [IsArchived], [LastVisitedDate], [MobileNumber], [NhsNumber], [PasNumber], [Postcode], [RegisteredDate], [RequiresPasswordReset], [Surname], [UpdatedDate], [UpdatedUser], [UserId]) VALUES (4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-08-08 21:50:34.2340712' AS DateTime2), N'staff@pharmix.co.uk', CAST(N'1967-02-13 00:00:00.0000000' AS DateTime2), N'depa22@g.com', N'Test', 2, NULL, 0, NULL, N'45464', N'NHS456', N'PAS004', NULL, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, N'Patient', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [pat].[Patient] OFF
GO
SET IDENTITY_INSERT [PREG].[Pregnancy] ON 

GO
INSERT [PREG].[Pregnancy] ([Id], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [EDD], [IsArchived], [MaternityUnit], [NHSNumber], [PatientId], [UpdatedDate], [UpdatedUser]) VALUES (1, NULL, NULL, CAST(N'2018-08-08 21:48:14.1918076' AS DateTime2), N'staff@pharmix.co.uk', NULL, 0, NULL, N'NHS456', 1, CAST(N'2018-08-08 21:50:34.0901812' AS DateTime2), N'staff@pharmix.co.uk')
GO
INSERT [PREG].[Pregnancy] ([Id], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [EDD], [IsArchived], [MaternityUnit], [NHSNumber], [PatientId], [UpdatedDate], [UpdatedUser]) VALUES (2, NULL, NULL, CAST(N'2018-08-08 21:50:34.1714975' AS DateTime2), N'staff@pharmix.co.uk', NULL, 0, NULL, N'NHS456', 2, NULL, NULL)
GO
INSERT [PREG].[Pregnancy] ([Id], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [EDD], [IsArchived], [MaternityUnit], [NHSNumber], [PatientId], [UpdatedDate], [UpdatedUser]) VALUES (3, NULL, NULL, CAST(N'2018-08-08 21:50:34.2142054' AS DateTime2), N'staff@pharmix.co.uk', NULL, 0, NULL, N'NHS456', 3, NULL, NULL)
GO
INSERT [PREG].[Pregnancy] ([Id], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [EDD], [IsArchived], [MaternityUnit], [NHSNumber], [PatientId], [UpdatedDate], [UpdatedUser]) VALUES (4, NULL, NULL, CAST(N'2018-08-08 21:50:34.2419171' AS DateTime2), N'staff@pharmix.co.uk', NULL, 0, NULL, N'NHS456', 4, NULL, NULL)
GO
SET IDENTITY_INSERT [PREG].[Pregnancy] OFF
GO
SET IDENTITY_INSERT [trusts].[Department] ON 

GO
INSERT [trusts].[Department] ([DepartmentId], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [DepartmentName], [Description], [IsArchived], [TrustId], [UpdatedDate], [UpdatedUser]) VALUES (1, NULL, NULL, CAST(N'2018-08-11 01:20:52.2319057' AS DateTime2), N'trustadmin@pharmix.co.uk', N'Accident and emergency (A&E)', N'Accident and emergency (A&E)', 0, 1, CAST(N'2018-08-11 01:21:01.2638828' AS DateTime2), N'trustadmin@pharmix.co.uk')
GO
INSERT [trusts].[Department] ([DepartmentId], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [DepartmentName], [Description], [IsArchived], [TrustId], [UpdatedDate], [UpdatedUser]) VALUES (2, NULL, NULL, CAST(N'2018-08-11 01:21:15.6185846' AS DateTime2), N'trustadmin@pharmix.co.uk', N'Cardiology', N'Cardiology', 0, 1, NULL, NULL)
GO
INSERT [trusts].[Department] ([DepartmentId], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [DepartmentName], [Description], [IsArchived], [TrustId], [UpdatedDate], [UpdatedUser]) VALUES (3, NULL, NULL, CAST(N'2018-08-11 01:21:27.9133502' AS DateTime2), N'trustadmin@pharmix.co.uk', N'Critical care', N'Critical care', 0, 1, NULL, NULL)
GO
INSERT [trusts].[Department] ([DepartmentId], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [DepartmentName], [Description], [IsArchived], [TrustId], [UpdatedDate], [UpdatedUser]) VALUES (4, NULL, NULL, CAST(N'2018-08-11 01:21:40.9429668' AS DateTime2), N'trustadmin@pharmix.co.uk', N'Ear nose and throat (ENT)', N'Ear nose and throat (ENT)', 0, 1, NULL, NULL)
GO
INSERT [trusts].[Department] ([DepartmentId], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [DepartmentName], [Description], [IsArchived], [TrustId], [UpdatedDate], [UpdatedUser]) VALUES (5, NULL, NULL, CAST(N'2018-08-11 01:21:52.8281017' AS DateTime2), N'trustadmin@pharmix.co.uk', N'Gastroenterology', N'Gastroenterology', 0, 1, NULL, NULL)
GO
INSERT [trusts].[Department] ([DepartmentId], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [DepartmentName], [Description], [IsArchived], [TrustId], [UpdatedDate], [UpdatedUser]) VALUES (6, NULL, NULL, CAST(N'2018-08-11 01:22:04.0780462' AS DateTime2), N'trustadmin@pharmix.co.uk', N'General surgery', N'General surgery', 0, 1, NULL, NULL)
GO
INSERT [trusts].[Department] ([DepartmentId], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [DepartmentName], [Description], [IsArchived], [TrustId], [UpdatedDate], [UpdatedUser]) VALUES (7, NULL, NULL, CAST(N'2018-08-11 01:22:15.2593072' AS DateTime2), N'trustadmin@pharmix.co.uk', N'Maternity departments', N'Maternity departments', 0, 1, NULL, NULL)
GO
INSERT [trusts].[Department] ([DepartmentId], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [DepartmentName], [Description], [IsArchived], [TrustId], [UpdatedDate], [UpdatedUser]) VALUES (8, NULL, NULL, CAST(N'2018-08-11 01:22:26.7321980' AS DateTime2), N'trustadmin@pharmix.co.uk', N'Neurology', N'Neurology', 0, 1, NULL, NULL)
GO
INSERT [trusts].[Department] ([DepartmentId], [ArchivedDate], [ArchivedUser], [CreatedDate], [CreatedUser], [DepartmentName], [Description], [IsArchived], [TrustId], [UpdatedDate], [UpdatedUser]) VALUES (9, NULL, NULL, CAST(N'2018-08-11 01:22:38.4639246' AS DateTime2), N'trustadmin@pharmix.co.uk', N'Oncology', N'Oncology', 0, 1, NULL, NULL)
GO
SET IDENTITY_INSERT [trusts].[Department] OFF
GO