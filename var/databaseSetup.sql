CREATE DATABASE city_metadata
GO

USE city_metadata
GO

CREATE TABLE city_metadata (id int identity(1,1), name varchar(64) not null unique, country varchar(64))
GO

INSERT INTO city_metadata (name, country) VALUES ("London", "United Kingdom")
GO

INSERT INTO city_metadata (name, country) VALUES ("Paris", "France")
GO

INSERT INTO city_metadata (name, country) VALUES ("Munich", "Germany")
GO


