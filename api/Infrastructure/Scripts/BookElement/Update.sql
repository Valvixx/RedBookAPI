UPDATE book_elements be
SET
    be.type        = @Type,
    be.name        = @Name,
    be.description = @Description
WHERE id = @Id
RETURNING
    be.id          as "Id",
    be.type        as "Type",
    be.name        as "Name",
    be.description as "Description"