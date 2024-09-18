SELECT
    be.id          as "Id",
    be.type        as "Type",
    be.name        as "Name",
    be.description as "Description"
FROM book_elements be
WHERE LOWER(be.name) like LOWER(@NameSearch)