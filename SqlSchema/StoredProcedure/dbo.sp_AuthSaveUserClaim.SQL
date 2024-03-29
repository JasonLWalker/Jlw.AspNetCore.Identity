DROP PROCEDURE IF EXISTS [dbo].[sp_AuthSaveUserClaim]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AuthSaveUserClaim]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_AuthSaveUserClaim] AS' 
END
GO

-- =============================================
-- Author:		Jason L Walker
-- Create date: 2019-04-04
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_AuthSaveUserClaim] 
	@id nvarchar(255),
	@normalizedClaimName nvarchar(255),
	@normalizedClaimValue nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @result varchar(255) = '';

    -- Get User Id 
    DECLARE @userId int = (SELECT Id FROM AuthBaseUsers WHERE Id = @id);

    -- Does User exist?
    IF(@userId > 0)
    BEGIN
        IF ((SELECT COUNT(Id) FROM AuthBaseUserClaims WHERE UserId = @userId AND ClaimName=@normalizedClaimName) = 0) 
        BEGIN
            INSERT INTO AuthBaseUserClaims ([UserId], [ClaimName], [ClaimValue]) VALUES(@userId, @normalizedClaimName, @normalizedClaimValue);
            SET @result = 'success';
        END
        ELSE
        BEGIN
            UPDATE AuthBaseUserClaims SET [ClaimValue] = @normalizedClaimValue WHERE [UserId] = @userId AND [ClaimName] = @normalizedClaimName;
            SET @result = 'success';
        END
    END
    ELSE
    BEGIN
        SET @result = 'user not found'
    END
	
	SELECT @result [Result];
END
GO
