CREATE DATABASE SmartAgricultureDB;
GO

USE SmartAgricultureDB;
GO

CREATE TABLE Farm (
    FarmID      INT             NOT NULL,
    Location    VARCHAR(255)    NOT NULL,
    TotalArea   DECIMAL(10,2)   NOT NULL,
    CONSTRAINT PK_Farm PRIMARY KEY (FarmID)
);

CREATE TABLE IrrigationSystem (
    SystemID    INT             NOT NULL,
    Type        VARCHAR(100)    NOT NULL,
    Capacity    DECIMAL(10,2)   NOT NULL,
    CONSTRAINT PK_IrrigationSystem PRIMARY KEY (SystemID)
);

CREATE TABLE Field (
    FieldNumber INT             NOT NULL,
    FarmID      INT             NOT NULL,
    SoilType    VARCHAR(100)    NOT NULL,
    Size        DECIMAL(10,2)   NOT NULL,
    SystemID    INT             NOT NULL,
    CONSTRAINT PK_Field PRIMARY KEY (FieldNumber, FarmID),
    CONSTRAINT FK_Field_Farm FOREIGN KEY (FarmID)
        REFERENCES Farm(FarmID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT FK_Field_IrrigationSystem FOREIGN KEY (SystemID)
        REFERENCES IrrigationSystem(SystemID)
        ON DELETE NO ACTION
        ON UPDATE CASCADE
);

CREATE TABLE Crop (
    CropID          INT             NOT NULL,
    Name            VARCHAR(150)    NOT NULL,
    GrowthDuration  INT             NOT NULL,
    Season          VARCHAR(50)     NOT NULL,
    CONSTRAINT PK_Crop PRIMARY KEY (CropID)
);

CREATE TABLE FieldCrop (
    FieldNumber     INT             NOT NULL,
    FarmID          INT             NOT NULL,
    CropID          INT             NOT NULL,
    PlantationDate  DATE            NOT NULL,
    HarvestDate     DATE            NULL,
    CONSTRAINT PK_FieldCrop PRIMARY KEY (FieldNumber, FarmID, CropID),
    CONSTRAINT FK_FieldCrop_Field FOREIGN KEY (FieldNumber, FarmID)
        REFERENCES Field(FieldNumber, FarmID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT FK_FieldCrop_Crop FOREIGN KEY (CropID)
        REFERENCES Crop(CropID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE Sensor (
    SensorID            INT             NOT NULL,
    Type                VARCHAR(100)    NOT NULL,
    InstallationDate    DATE            NOT NULL,
    FieldNumber         INT             NOT NULL,
    FarmID              INT             NOT NULL,
    CONSTRAINT PK_Sensor PRIMARY KEY (SensorID),
    CONSTRAINT FK_Sensor_Field FOREIGN KEY (FieldNumber, FarmID)
        REFERENCES Field(FieldNumber, FarmID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE SensorReading (
    ReadingID   INT             NOT NULL,
    Value       DECIMAL(15,4)   NOT NULL,
    Timestamp   DATETIME        NOT NULL,
    SensorID    INT             NOT NULL,
    CONSTRAINT PK_SensorReading PRIMARY KEY (ReadingID),
    CONSTRAINT FK_SensorReading_Sensor FOREIGN KEY (SensorID)
        REFERENCES Sensor(SensorID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE Expert (
    ExpertID        INT             NOT NULL,
    Name            VARCHAR(150)    NOT NULL,
    Specialization  VARCHAR(150)    NOT NULL,
    CONSTRAINT PK_Expert PRIMARY KEY (ExpertID)
);

CREATE TABLE SeniorExpert (
    ExpertID            INT             NOT NULL,
    ConsultationFee     DECIMAL(10,2)   NOT NULL,
    CONSTRAINT PK_SeniorExpert PRIMARY KEY (ExpertID),
    CONSTRAINT FK_SeniorExpert_Expert FOREIGN KEY (ExpertID)
        REFERENCES Expert(ExpertID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE Consultation (
    ConsultationID      INT             NOT NULL,
    ConsultationDate    DATE            NOT NULL,
    Notes               VARCHAR(MAX)    NULL,
    ExpertID            INT             NOT NULL,
    FieldNumber         INT             NOT NULL,
    FarmID              INT             NOT NULL,
    CONSTRAINT PK_Consultation PRIMARY KEY (ConsultationID),
    CONSTRAINT FK_Consultation_Expert FOREIGN KEY (ExpertID)
        REFERENCES Expert(ExpertID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT FK_Consultation_Field FOREIGN KEY (FieldNumber, FarmID)
        REFERENCES Field(FieldNumber, FarmID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

INSERT INTO Farm (FarmID, Location, TotalArea) VALUES
(1, 'Punjab, Pakistan', 500.00),
(2, 'Sindh, Pakistan', 300.00);

INSERT INTO IrrigationSystem (SystemID, Type, Capacity) VALUES
(1, 'Drip Irrigation', 1000.00),
(2, 'Sprinkler', 800.00),
(3, 'Flood Irrigation', 1500.00);

INSERT INTO Field (FieldNumber, FarmID, SoilType, Size, SystemID) VALUES
(1, 1, 'Clay', 50.00, 1),
(2, 1, 'Sandy', 75.00, 2),
(1, 2, 'Loam', 60.00, 3);

INSERT INTO Crop (CropID, Name, GrowthDuration, Season) VALUES
(1, 'Wheat', 120, 'Winter'),
(2, 'Rice', 150, 'Summer'),
(3, 'Maize', 90, 'Kharif');

INSERT INTO FieldCrop (FieldNumber, FarmID, CropID, PlantationDate, HarvestDate) VALUES
(1, 1, 1, '2024-11-01', '2025-03-01'),
(1, 1, 3, '2024-06-01', '2024-09-01'),
(2, 1, 2, '2024-06-15', '2024-11-15'),
(1, 2, 1, '2024-11-05', NULL);

INSERT INTO Sensor (SensorID, Type, InstallationDate, FieldNumber, FarmID) VALUES
(1, 'Soil Moisture', '2023-01-10', 1, 1),
(2, 'Temperature', '2023-02-15', 1, 1),
(3, 'Humidity', '2023-03-20', 2, 1),
(4, 'Soil Moisture', '2023-04-05', 1, 2);

INSERT INTO SensorReading (ReadingID, Value, Timestamp, SensorID) VALUES
(1, 45.30, '2024-12-01 08:00:00', 1),
(2, 22.50, '2024-12-01 08:00:00', 2),
(3, 60.10, '2024-12-01 08:05:00', 3),
(4, 38.90, '2024-12-01 09:00:00', 4);

INSERT INTO Expert (ExpertID, Name, Specialization) VALUES
(1, 'Dr. Ahmed Khan', 'Soil Science'),
(2, 'Ms. Sara Ali', 'Crop Management'),
(3, 'Mr. Usman Raza', 'Irrigation Engineering');

INSERT INTO SeniorExpert (ExpertID, ConsultationFee) VALUES
(1, 5000.00),
(3, 4500.00);

INSERT INTO Consultation (ConsultationID, ConsultationDate, Notes, ExpertID, FieldNumber, FarmID) VALUES
(1, '2024-12-05', 'Recommended adjusting soil pH levels', 1, 1, 1),
(2, '2024-12-10', 'Advised on crop rotation strategy', 2, 2, 1),
(3, '2024-12-12', 'Suggested upgrading drip lines', 3, 1, 2);

SELECT f.FarmID, f.Location, fi.FieldNumber, fi.SoilType, c.Name AS CropName,
       fc.PlantationDate, fc.HarvestDate
FROM Farm f
JOIN Field fi ON f.FarmID = fi.FarmID
JOIN FieldCrop fc ON fi.FieldNumber = fc.FieldNumber AND fi.FarmID = fc.FarmID
JOIN Crop c ON fc.CropID = c.CropID;

SELECT s.SensorID, s.Type, sr.Value, sr.Timestamp, fi.SoilType
FROM Sensor s
JOIN SensorReading sr ON s.SensorID = sr.SensorID
JOIN Field fi ON s.FieldNumber = fi.FieldNumber AND s.FarmID = fi.FarmID;

SELECT e.Name AS ExpertName, e.Specialization,
       CASE WHEN se.ExpertID IS NOT NULL THEN 'Senior Expert' ELSE 'Expert' END AS ExpertType,
       se.ConsultationFee,
       c.ConsultationDate, c.Notes,
       fi.FieldNumber, fi.FarmID
FROM Expert e
LEFT JOIN SeniorExpert se ON e.ExpertID = se.ExpertID
JOIN Consultation c ON e.ExpertID = c.ExpertID
JOIN Field fi ON c.FieldNumber = fi.FieldNumber AND c.FarmID = fi.FarmID;

SELECT ir.SystemID, ir.Type, ir.Capacity,
       COUNT(fi.FieldNumber) AS FieldsServed
FROM IrrigationSystem ir
LEFT JOIN Field fi ON ir.SystemID = fi.SystemID
GROUP BY ir.SystemID, ir.Type, ir.Capacity;