UPDATE users u
SET
    user_name       = @UserName,
    email           = @Email,
    password        = @Password,
    role            = @Role
WHERE user_id = @UserId
RETURNING
    u.user_id           as "UserId",
    u.user_name         as "UserName",
    u.email             as "Email",
    u.password          as "Password",
    u.created_date      as "CreatedDate",
    u.role              as "Role"
    