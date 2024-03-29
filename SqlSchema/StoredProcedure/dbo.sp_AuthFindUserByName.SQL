DROP PROCEDURE IF EXISTS [dbo].[sp_AuthFindUserByName]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AuthFindUserByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_AuthFindUserByName] AS' 
END
GO
-- =============================================
-- Author:		Jason L Walker
-- Create date: 2020-10-01
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_AuthFindUserByName] 
	-- Add the parameters for the stored procedure here
	@normalizedUserName nvarchar(256)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT TOP (1) 
		[Id]
		,[UserName]
		,[NormalizedUserName]
		,[Email]
		,[NormalizedEmail]
		,[EmailConfirmed]
		,[PasswordHash]
		,[PhoneNumber]
		,[PhoneNumberConfirmed]
		,[TwoFactorEnabled]
		,[AccessFailedCount]
		,1 as LockoutEnabled
		,[LockoutEnd]
		,[SecurityStamp]
		,[ConcurrencyStamp]
	FROM 
		[AuthBaseUsers]
	WHERE
		NormalizedUserName = @normalizedUserName;
    
END
GO
