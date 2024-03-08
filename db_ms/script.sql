USE [master]
GO
CREATE DATABASE [test] ;
GO

-------------------------------------------------------------------------
-- CATEGORY
-------------------------------------------------------------------------
CREATE TABLE test.dbo.Category (
        id INT IDENTITY(1,1) NOT NULL,
        category_name NVARCHAR(40) NOT NULL ,
        category_description NVARCHAR(225) NOT NULL ,
        PRIMARY KEY (id)
);

INSERT INTO test.dbo.Category (category_name, category_description)
VALUES ('Hair Salon', 'Hair Salon'),
       ('Nail Salon', 'Nail Salon'),
       ('SPA Center', 'SPA Center');
GO
-------------------------------------------------------------------------
-- STORE
-------------------------------------------------------------------------
CREATE TABLE test.dbo.Store (
        id INT IDENTITY(1,1) NOT NULL,
        store_name NVARCHAR(100) NOT NULL ,
        store_adress NVARCHAR(225) NOT NULL ,
        store_owner NVARCHAR(225) NOT NULL ,
        PRIMARY KEY (id)
);

INSERT INTO test.dbo.Store (store_name, store_adress, store_owner)
VALUES ('HS 1', 'Adresa 1', 'Osoba 1'),
       ('Mime', 'Adresa 2', 'Osoba 2'),
       ('Marvi', 'Adresa 3', 'Osoba 3');
GO
-------------------------------------------------------------------------
-- StoreCategory
-------------------------------------------------------------------------
CREATE TABLE test.dbo.StoreCategory (
        id INT IDENTITY(1,1) NOT NULL,
        store_id INT NOT NULL ,
        category_id INT NOT NULL ,
        PRIMARY KEY (id),
        FOREIGN KEY (store_id) REFERENCES test.dbo.Store(id),
        FOREIGN KEY (category_id) REFERENCES test.dbo.Category(id)
);

INSERT INTO test.dbo.StoreCategory (store_id, category_id)
VALUES (1,1),
       (1,2),
       (2,2),
       (3,3);
GO
-------------------------------------------------------------------------
-- Service
-------------------------------------------------------------------------
CREATE TABLE test.dbo.Service (
        id INT IDENTITY(1,1) NOT NULL,
        service_name NVARCHAR(50) NOT NULL,
        service_description NVARCHAR(512),
        service_price FLOAT,
        duration_time INT,
        store_category_id INT NOT NULL ,
        PRIMARY KEY (id),
        FOREIGN KEY (store_category_id) REFERENCES test.dbo.StoreCategory(id)
);

INSERT INTO test.dbo.Service (service_name, service_description, service_price,duration_time, store_category_id)
VALUES  ("Muško šišanje",       "muško šišanje u trajanju od 30min",    8.2,    30,     1),
        ("Muško brijanje",      "muško brijanje u trajanju od 15min",   6,      15,     1),
        ("Trajni lak manikura", "Izdrada trajnog laka za ruke",         20,     30,     2),
        ("Trajni lak pedikura", "Izdrada trajnog laka za noge",         25,     15,     3),
        ("Masaža čokolada",     "Masaža čokladom u trajanju 1h",        45,     60,     4);
GO

-------------------------------------------------------------------------
-- Calendar
-------------------------------------------------------------------------
CREATE TABLE test.dbo.Calendar (
        id INT IDENTITY(1,1) NOT NULL,
        user_id NVARCHAR NOT NULL,
        store_id INT NOT NULL,
        time_start DATETIME NOT NULL,
        time_end DATETIME NOT NULL,
        active BOOLEAN NOT NULL,
        comment NVARCHAR(512),
        PRIMARY KEY (id),
        FOREIGN KEY (user_id) REFERENCES auth.dbo.AspNetUsers(Id)
        FOREIGN KEY (store_id) REFERENCES test.dbo.Store(id)
);