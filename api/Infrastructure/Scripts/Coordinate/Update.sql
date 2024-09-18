UPDATE coordinates c
SET
    c.element_id    = @ElementId,
    c.coordinates   = @Coordinates
WHERE c.id = @Id
RETURNING
    c.id            as "Id",
    c.element_id    as "ElementId",
    c.coordinates   as "Coordinates"