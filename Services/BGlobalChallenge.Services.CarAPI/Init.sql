CREATE TABLE IF NOT EXISTS Cars (
    id serial PRIMARY KEY,
    Plate varchar(8),
    Brand varchar,
    ModelCar varchar,
    Doors smallint,
    OwnerCar varchar
);