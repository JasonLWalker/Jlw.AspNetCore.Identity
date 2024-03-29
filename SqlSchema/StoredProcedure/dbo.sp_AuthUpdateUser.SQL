DROP PROCEDURE IF EXISTS [dbo].[sp_AuthUpdateUser]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AuthUpdateUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_AuthUpdateUser] AS' 
END
GO

-- =============================================
-- Author:		Jason L Walker
-- Create date: 2019-04-04
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_AuthUpdateUser] 
	@id int,
	@userName nvarchar(255),
	@normalizedUserName nvarchar(255),
	@email nvarchar(255) = null,
	@normalizedEmail nvarchar(255) = null,
	@emailConfirmed bit,
	@passwordHash nvarchar(MAX) = null,
	@phoneNumber nvarchar(50) = null,
	@phoneNumberConfirmed bit,
	@twoFactorEnabled bit,
	@accessFailedCount int,
	@lockoutEnabled bit,
	@lockoutEnd DateTime = NULL,
	@securityStamp nvarchar(MAX),
	@concurrencyStamp nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @result varchar(255) = '';

	IF(@result = '' AND (SELECT COUNT(Id) FROM AuthBaseUsers WHERE UserName = @userName AND Id <> @id) > 0)
	BEGIN
		SET @result = 'duplicate username'
	END

	IF(@result = '' AND (SELECT COUNT(Id) FROM AuthBaseUsers WHERE NormalizedUserName = @normalizedUserName AND Id <> @id) > 0)
	BEGIN
		SET @result = 'duplicate normalized username'
	END

	IF (@result = '')
	BEGIN
        UPDATE 
            [AuthBaseUsers]
        SET
            [UserName] = @userName,
            [NormalizedUserName] = @normalizedUserName,
            [Email] = @email,
            [NormalizedEmail] = @normalizedEmail,
            [EmailConfirmed] = @emailConfirmed,
            [PasswordHash] = @passwordHash,
            [PhoneNumber] = @phoneNumber,
            [PhoneNumberConfirmed] = @phoneNumberConfirmed,
            [TwoFactorEnabled] = @twoFactorEnabled,
            [AccessFailedCount] = @accessFailedCount,
            [LockoutEnabled] = @lockoutEnabled,
            [LockoutEnd] = @lockoutEnd,
						[SecurityStamp] = @securityStamp,
						[ConcurrencyStamp] = @concurrencyStamp
        
        WHERE
            Id=@id

        SET @result = 'success';
	END

	SELECT @result;
END
GO
