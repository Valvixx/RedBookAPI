﻿SELECT
    c.id          as "Id",
    c.element_id  as "ElementId",
    c.coordinates as "Coordinates"
FROM coordinates c
WHERE element_id = @ElementId