DROP PROCEDURE IF EXISTS [dbo].[sp_AuthAddUserToRole]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AuthAddUserToRole]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_AuthAddUserToRole] AS' 
END
GO

-- =============================================
-- Author:		Jason L Walker
-- Create date: 2019-04-04
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_AuthAddUserToRole] 
	@id nvarchar(255),
	@normalizedRoleName nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @result varchar(255) = '';

    -- Get User Id 
    DECLARE @userId int = (SELECT Id FROM AuthBaseUsers WHERE Id = @id);

    -- Does User exist?
    IF(@result = '' AND @userId > 0)
    BEGIN
        IF ((SELECT COUNT(Id) FROM AuthBaseUserClaims WHERE UserId = @userId AND ClaimName='ROLE' AND ClaimValue = @normalizedRoleName) = 0) 
        BEGIN
            INSERT INTO AuthBaseUserClaims ([UserId], [ClaimName], [ClaimValue]) VALUES(@userId, 'ROLE', @normalizedRoleName);
            SET @result = 'success';
        END
        ELSE
        BEGIN
            SET @result = 'already in role';
        END
    END
    ELSE
    BEGIN
        SET @result = 'user not found'
    END

	
	SELECT @result;
END
GO
