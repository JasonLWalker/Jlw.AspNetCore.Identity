DROP PROCEDURE IF EXISTS [dbo].[sp_AuthIsUserInRole]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AuthIsUserInRole]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_AuthIsUserInRole] AS' 
END
GO

-- =============================================
-- Author:		Jason L Walker
-- Create date: 2019-04-04
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_AuthIsUserInRole] 
	@id nvarchar(255),
	@normalizedRoleName nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
        IIF (COUNT(uc.Id) > 0, 1, 0) as InRole
    FROM 
        AuthBaseUserClaims uc
    INNER JOIN
        AuthBaseUsers u
        ON
        uc.UserId = u.Id
        AND
        uc.ClaimName = 'ROLE'
        AND
        uc.ClaimValue = @normalizedRoleName
        AND 
        u.Id = @id

        
END
GO
