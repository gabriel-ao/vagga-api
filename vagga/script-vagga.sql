-- ==================================== CRIAÇÃO DE TABELAS

create table VACANCY (
	ID uuid PRIMARY KEY,
	URLIMAGES VARCHAR(500),
	NAME VARCHAR(50),
	SERVICETYPE VARCHAR(20),
	DESCRIPTION VARCHAR(500),
	DIMENSIONX DECIMAL,
	DIMENSIONY DECIMAL,
	DIMENSIONZ DECIMAL,
	PRICE DECIMAL,
	ACTIVE BOOLEAN
);


create table VEHICLE (
	ID uuid PRIMARY KEY,
	URLIMAGES VARCHAR(500),
	BRAND VARCHAR(50),
	MODEL VARCHAR(50),
	DOORS REAL,
	NAME VARCHAR(50),
	AGE REAL,
	COLOR VARCHAR(30),
	PLATE VARCHAR(10),
	ACTIVE BOOLEAN
);


create table USERS (
	ID uuid PRIMARY KEY,
	FIRSTNAME VARCHAR(50),
	LASTNAME VARCHAR(50),
	EMAIL VARCHAR(100),
	PASSWORD VARCHAR(100),
	ACTIVE BOOLEAN
);


create table USER_VACANCY (
	ID uuid PRIMARY KEY,
	UserID uuid,
	VacancyID uuid,
	CONSTRAINT fk_Users FOREIGN KEY(UserID) REFERENCES USERS(ID),
	CONSTRAINT fk_Vacancy FOREIGN KEY(VacancyID) REFERENCES VACANCY(ID)
);


create table USER_VEHICLE (
	ID uuid PRIMARY KEY,
	UserID uuid,
	VehicleID uuid,
	CONSTRAINT fk_Users FOREIGN KEY(UserID) REFERENCES USERS(ID),
	CONSTRAINT fk_Vehicle FOREIGN KEY(VehicleID) REFERENCES VEHICLE(ID)
);


create table SERVICE (
	ID uuid PRIMARY KEY,
	UserVehicle uuid, 
	UserVacancy uuid,
	CONSTRAINT fk_UserVacancy FOREIGN KEY(UserVacancy) REFERENCES USER_VACANCY(ID),
	CONSTRAINT fk_UserVehicle FOREIGN KEY(UserVehicle) REFERENCES USER_VEHICLE(ID)
);


-- ==================================== INSERÇÃO DE DADOS


INSERT INTO USERS (ID, FIRSTNAME, LASTNAME, EMAIL, PASSWORD, ACTIVE)
VALUES('112C8DD8-346B-426E-B06C-75BBA97DCD63', 'Gabriel', 'de Oliveira', 'gabriel-ao@hotmail.com', 'gabigol10', true),
('61150667-6214-4b52-a13c-bfac0e360d18', 'Cassia', 'Matos', 'cassia-cma@hotmail.com', 'cassia05', true);

INSERT INTO VEHICLE (ID, URLIMAGES, BRAND, MODEL, DOORS, NAME, AGE, COLOR, PLATE, ACTIVE)
VALUES('6322d3ee-6ef9-4044-b357-9667a8955949', 'www.facebook.com, www.instagram.com', 'Yamaha', 'Fazer', 0, 'Fazer 250', 2012, 'preta', 'ESG3890', true);


INSERT INTO VACANCY (ID, URLIMAGES, NAME, SERVICETYPE, DESCRIPTION, DIMENSIONX, DIMENSIONY, DIMENSIONZ, PRICE, ACTIVE)
VALUES('7ef4fa65-de6f-4736-9acd-53cefe3d73c5', 'www.facebook.com, www.instagram.com', 'Vaga ap b104', 'avulso', 'Uma vaga de modelo teste',  2.0, 2.0, 2.0, 40.0, true);


INSERT INTO USER_VACANCY (ID, UserID, VacancyID)
VALUES('6af1843d-bbc0-4536-b290-4bee3e86faa8', '61150667-6214-4b52-a13c-bfac0e360d18', '7ef4fa65-de6f-4736-9acd-53cefe3d73c5');


INSERT INTO USER_VEHICLE (ID, UserID, VehicleID)
VALUES ('b8a219c6-5917-4917-9a14-e205783139fa', '112C8DD8-346B-426E-B06C-75BBA97DCD63', '6322d3ee-6ef9-4044-b357-9667a8955949');

INSERT INTO SERVICE (ID, UserVehicle, UserVacancy)
VALUES ('b8a219c6-5917-4917-9a14-e205783139fa', 'b8a219c6-5917-4917-9a14-e205783139fa', '6af1843d-bbc0-4536-b290-4bee3e86faa8');


-- ==================================== DELEÇÃO DE TABELAS

DROP TABLE VEHICLE
DROP TABLE VACANCY
DROP TABLE users



-- ==================================== CRIAÇÃO DE FUNÇÕES



-- ==================================== SELECT GERAL DE TABELAS

select * from USERS;

select * from VEHICLE;

select * from VACANCY;

select * from USER_VACANCY;

select * from USER_VEHICLE;

select * from SERVICE;



-- ==================================== SELECT INNER JOIN

select V.name, U.firstname, V.plate 
from USER_VEHICLE as UV

inner join vehicle as V 
on UV.userid = V.id

inner join users as U 
on UV.vehicleid = U.id

where V.id = '112c8dd8-346b-426e-b06c-75bba97dcd63';