CREATE DATABASE holiday_metadata
GO

USE holiday_metadata
GO

CREATE TABLE holiday_metadata (id int identity(1,1), name varchar(64) not null unique, country varchar(64))
GO

INSERT INTO holiday_metadata (name, country) VALUES ("London", "United Kingdom")
GO

INSERT INTO holiday_metadata (name, country) VALUES ("Paris", "France")
GO

INSERT INTO holiday_metadata (name, country) VALUES ("Munich", "Germany")
GO


