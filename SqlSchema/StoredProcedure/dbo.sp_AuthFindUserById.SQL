DROP PROCEDURE IF EXISTS [dbo].[sp_AuthFindUserById]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AuthFindUserById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_AuthFindUserById] AS' 
END
GO
-- =============================================
-- Author:		Jason L Walker
-- Create date: 2019-04-04
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_AuthFindUserById] 
	-- Add the parameters for the stored procedure here
	@id int
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
		Id = @id;

END
GO
