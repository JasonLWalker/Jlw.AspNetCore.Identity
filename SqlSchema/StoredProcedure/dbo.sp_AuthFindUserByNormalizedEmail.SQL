DROP PROCEDURE IF EXISTS [dbo].[sp_AuthFindUserByNormalizedEmail]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AuthFindUserByNormalizedEmail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_AuthFindUserByNormalizedEmail] AS' 
END
GO
-- =============================================
-- Author:		Jason L Walker
-- Create date: 2020-09-28
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_AuthFindUserByNormalizedEmail] 
	-- Add the parameters for the stored procedure here
	@normalizedEmail nvarchar(256)
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
		NormalizedEmail = @normalizedEmail;
END
GO
