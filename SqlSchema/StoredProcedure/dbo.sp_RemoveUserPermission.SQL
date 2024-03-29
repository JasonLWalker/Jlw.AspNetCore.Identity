DROP PROCEDURE IF EXISTS [dbo].[sp_RemoveUserPermission]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_RemoveUserPermission]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_RemoveUserPermission] AS' 
END
GO

-- =============================================
-- Author:		Jason L Walker
-- Create date: 2019-04-04
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_RemoveUserPermission] 
	@userid bigint,
	@claimid bigint,
	@changeby nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @result varchar(255) = '';
	DECLARE @claimName varchar(255) = '';
	DECLARE @claimValue varchar(255) = '';

    -- Get User Id 
    DECLARE @id int = (SELECT Id FROM AuthBaseUsers WHERE Id = @userid);

    -- Does User exist?
    IF(@result = '' AND @id > 0)
    BEGIN
        SELECT @claimName = ClaimName, @claimValue = ClaimValue FROM AuthAvailableClaims WHERE ClaimId=@claimid

        IF (LEN(@claimName) > 0 AND LEN(@claimValue) > 0) 
        BEGIN
            IF( (SELECT COUNT(*) FROM AuthBaseUserClaims WHERE ClaimName=@claimName AND ClaimValue=@claimValue AND UserId=@id) > 0 )
            BEGIN
                DELETE FROM AuthBaseUserClaims
                WHERE
                    UserId=@id
                    AND
                    ClaimName=@claimName
                    AND
                    ClaimValue=@claimValue

                SET @result='Success'
            END
            ELSE
            BEGIN
                SET @result = 'Claim Does Not Exist'
            END
        END
        ELSE
        BEGIN
            SET @result = 'Permission not found'
        END
    END
    ELSE
    BEGIN
        SET @result='User Not Found'
    END
        
    SELECT @result as [Result]
END
GO
