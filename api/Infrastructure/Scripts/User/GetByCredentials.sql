SELECT
    u.user_id         as "UserId",
    u.display_name    as "DisplayName",
    u.user_name       as "UserName",
    u.email           as "Email",
    u.password        as "Password",
    u.created_date    as "CreatedDate"
FROM users u
WHERE email = 'admin@admin.com' AND password = 'AdMiN'