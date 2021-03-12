/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: brokers
------------------------------------------------------------*/
CREATE TABLE brokers(
	idBroker      INT IDENTITY (1,1) NOT NULL ,
	lastname      VARCHAR (50) NOT NULL ,
	firstname     VARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL  ,
	CONSTRAINT brokers_PK PRIMARY KEY (idBroker)
);


/*------------------------------------------------------------
-- Table: Customers
------------------------------------------------------------*/
CREATE TABLE Customers(
	idCustomer    INT  NOT NULL ,
	customer      INT IDENTITY (1,1) NOT NULL ,
	lastname      VARCHAR (50) NOT NULL ,
	firstname     VARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL ,
	budget        INT  NOT NULL  ,
	CONSTRAINT Customers_PK PRIMARY KEY (idCustomer)
);


/*------------------------------------------------------------
-- Table: appointments
------------------------------------------------------------*/
CREATE TABLE appointments(
	idappointment   INT IDENTITY (1,1) NOT NULL ,
	dateHour        DATETIME  NOT NULL ,
	subject         TEXT  NOT NULL ,
	idBroker        INT  NOT NULL ,
	idCustomer      INT  NOT NULL  ,
	CONSTRAINT appointments_PK PRIMARY KEY (idappointment)

	,CONSTRAINT appointments_brokers_FK FOREIGN KEY (idBroker) REFERENCES brokers(idBroker)
	,CONSTRAINT appointments_Customers0_FK FOREIGN KEY (idCustomer) REFERENCES Customers(idCustomer)
);



