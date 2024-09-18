INSERT INTO coordinates (element_id, coordinates)
VALUES (@ElementId, @Coordinates)
RETURNING
    id          as "Id",
    element_id  as "ElementId",
    coordinates as "Coordinates"