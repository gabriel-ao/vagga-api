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
INSERT INTO VEHICLE (ID, URLIMAGES, BRAND, MODEL, DOORS, NAME, AGE, COLOR, PLATE, ACTIVE)
VALUES('b8935bea-afbb-4478-af22-9469fc5da273', 'www.facebook.com, www.instagram.com', 'GM Chevrolet', 'Corsa', 0, 'Classic', 2002, 'vermelho', 'HVR4618', true);


INSERT INTO VACANCY (ID, URLIMAGES, NAME, SERVICETYPE, DESCRIPTION, DIMENSIONX, DIMENSIONY, DIMENSIONZ, PRICE, ACTIVE)
VALUES('7ef4fa65-de6f-4736-9acd-53cefe3d73c5', 'www.facebook.com, www.instagram.com', 'Vaga ap b104', 'avulso', 'Uma vaga de modelo teste',  2.0, 2.0, 2.0, 40.0, true);


INSERT INTO USER_VACANCY (ID, UserID, VacancyID)
VALUES('6af1843d-bbc0-4536-b290-4bee3e86faa8', '61150667-6214-4b52-a13c-bfac0e360d18', '7ef4fa65-de6f-4736-9acd-53cefe3d73c5');


INSERT INTO USER_VEHICLE (ID, UserID, VehicleID)
VALUES ('b8a219c6-5917-4917-9a14-e205783139fa', '112C8DD8-346B-426E-B06C-75BBA97DCD63', '6322d3ee-6ef9-4044-b357-9667a8955949');
INSERT INTO USER_VEHICLE (ID, UserID, VehicleID)
VALUES ('218fcd2b-4d55-4956-904a-d4da8b7101f7', '112C8DD8-346B-426E-B06C-75BBA97DCD63', 'b8935bea-afbb-4478-af22-9469fc5da273');


INSERT INTO SERVICE (ID, UserVehicle, UserVacancy)
VALUES ('b8a219c6-5917-4917-9a14-e205783139fa', 'b8a219c6-5917-4917-9a14-e205783139fa', '6af1843d-bbc0-4536-b290-4bee3e86faa8');


-- ==================================== DELEÇÃO DE TABELAS

DROP TABLE VEHICLE
DROP TABLE VACANCY
DROP TABLE users



-- ==================================== CRIAÇÃO DE FUNÇÕES



-- auth
		-- FUNCTION: public.auth(text, text)

		-- DROP FUNCTION IF EXISTS public.auth(text, text);

		CREATE OR REPLACE FUNCTION public.auth(
			emailinput text,
			passwordinput text)
			RETURNS TABLE(id uuid, firstname character varying, lastname character varying, email character varying, password character varying, active boolean) 
			LANGUAGE 'plpgsql'
			COST 100
			VOLATILE PARALLEL UNSAFE
			ROWS 1000

		AS $BODY$

		BEGIN
			--select Id, firstname, lastname, email, password, active from users
			--where email = 'gabriel-ao@hotmail.com' and password = 'gabigol10';

			RETURN QUERY 
			select * from public.users as U
			where U.email = emailInput and U.password = passwordInput;
			
		END;

		$BODY$;

		ALTER FUNCTION public.auth(text, text)
			OWNER TO postgres;
-- auth

-- get_vehicle_by_userid
		create or replace function get_vehicle_by_userid(
			useridInput uuid
		)
		returns table (
			name character varying(50), 
			firstname character varying(50), 
			plate character varying(50)
		) AS $$

		BEGIN

			RETURN QUERY 
			select V.name, U.firstname, V.plate 
			from USER_VEHICLE as UV

			inner join vehicle as V 
			on UV.vehicleid = V.id

			inner join users as U 
			on UV.userid = U.id

			where UV.userid = useridInput;

		END;

		$$ LANGUAGE plpgsql;

		select * from public.get_vehicle_by_userid('112c8dd8-346b-426e-b06c-75bba97dcd63')
-- get_vehicle_by_userid



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
on UV.vehicleid = V.id

inner join users as U 
on UV.userid = U.id

where UV.userid = '112c8dd8-346b-426e-b06c-75bba97dcd63';