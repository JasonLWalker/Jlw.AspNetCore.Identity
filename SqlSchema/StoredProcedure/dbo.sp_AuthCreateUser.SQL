DROP PROCEDURE IF EXISTS [dbo].[sp_AuthCreateUser]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AuthCreateUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_AuthCreateUser] AS' 
END
GO
-- =============================================
-- Author:		Jason L Walker
-- Create date: 2019-04-04
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[sp_AuthCreateUser] 
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

    
	IF(@result = '' AND (SELECT COUNT(Id) FROM AuthBaseUsers WHERE UserName = @userName) > 0)
	BEGIN
		SET @result = 'duplicate username'
	END

	IF(@result = '' AND (SELECT COUNT(Id) FROM AuthBaseUsers WHERE NormalizedUserName = @normalizedUserName) > 0)
	BEGIN
		SET @result = 'duplicate normalized username'
	END


	IF (@result = '')
	BEGIN

	INSERT 
	INTO
		[AuthBaseUsers]
	( 
		[UserName]
		,[NormalizedUserName]
		,[Email]
		,[NormalizedEmail]
		,[EmailConfirmed]
		,[PasswordHash]
		,[PhoneNumber]
		,[PhoneNumberConfirmed]
		,[TwoFactorEnabled]
		,[AccessFailedCount]
		,[LockoutEnabled]
		,[LockoutEnd]
		,[SecurityStamp]
		,[ConcurrencyStamp]
	)
	VALUES 
	(
		@userName,
		@normalizedUserName,
		@email,
		@normalizedEmail,
		@emailConfirmed,
		@passwordHash,
		@phoneNumber,
		@phoneNumberConfirmed,
		@twoFactorEnabled,
		@accessFailedCount,
		@lockoutEnabled,
		@lockoutEnd,
		@securityStamp,
		@concurrencyStamp
	)

	SET @result = SCOPE_IDENTITY();
	END
    
	SELECT @result;
END
GO
