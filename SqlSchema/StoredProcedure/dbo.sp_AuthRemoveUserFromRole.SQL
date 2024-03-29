DROP PROCEDURE IF EXISTS [dbo].[sp_AuthRemoveUserFromRole]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AuthRemoveUserFromRole]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_AuthRemoveUserFromRole] AS' 
END
GO

-- =============================================
-- Author:		Jason L Walker
-- Create date: 2019-04-04
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_AuthRemoveUserFromRole] 
	-- Add the parameters for the stored procedure here
	@id int,
	@normalizedRoleName nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE
	FROM 
		[AuthBaseUserClaims]
	WHERE
		UserId = @id
        AND
        ClaimName = 'ROLE'
        AND
        ClaimValue = @normalizedRoleName;
END
GO
