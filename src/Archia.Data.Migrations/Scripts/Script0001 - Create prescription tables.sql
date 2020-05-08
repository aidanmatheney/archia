CREATE TABLE Patient(
    Id int AUTO_INCREMENT PRIMARY KEY,
    FirstName varchar(32) NOT NULL,
    MiddleName varchar(32) NOT NULL,
    LastName varchar(32) NOT NULL
);

CREATE TABLE Manufacturer(
    Id int AUTO_INCREMENT PRIMARY KEY,
    Name varchar(128) NOT NULL
);

CREATE TABLE Medication(
    Id int AUTO_INCREMENT PRIMARY KEY,
    ManufacturerId int NOT NULL,
    FOREIGN KEY (ManufacturerId)
        REFERENCES Manufacturer(Id)
        ON DELETE CASCADE,
    Name varchar(128)
);

CREATE TABLE Prescription(
    Id int AUTO_INCREMENT PRIMARY KEY,
    PrescribedDateUtc datetime NOT NULL,
    StartDateUtc datetime NOT NULL,
    EndDateUtc datetime NOT NULL,
    PatientId int NOT NULL,
    FOREIGN KEY (PatientId)
        REFERENCES Patient(Id)
        ON DELETE CASCADE,
    Text text NOT NULL
);
