SELECT
    u.user_id           as "UserId",
    u.user_name         as "UserName",
    u.email             as "Email",
    u.password          as "Password",
    u.created_date      as "CreatedDate",
    u.role              as "Role"
FROM users u