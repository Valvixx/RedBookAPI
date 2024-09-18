UPDATE users u
SET
    u.user_name       = @UserName,
    u.email           = @Email,
    u.password        = @Password,
    u.role            = @Role
WHERE u.user_id = @UserId
RETURNING
    u.user_id           as "UserId",
    u.user_name         as "UserName",
    u.email             as "Email",
    u.password          as "Password",
    u.created_date      as "CreatedDate",
    u.role              as "Role"
    