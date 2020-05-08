INSERT INTO Patient
    (
        FirstName,
        MiddleName,
        LastName
    )

    VALUES
        ('John', '', 'Doe'),
        ('Sarah', '', 'Lee'),
        ('Michael', '', 'Jones')
;


INSERT INTO Manufacturer
    (
        Name
    )

    VALUES
        ('Eli Lilly and Co'),
        ('Bayer AG'),
        ('AbbVie Inc')
;


INSERT INTO Medication
    (
        ManufacturerId,
        Name
    )

    SELECT
        manufacturer.Id,
        'alitretinoin'

        FROM Manufacturer AS manufacturer
        WHERE manufacturer.Name = 'Eli Lilly and Co'
;

INSERT INTO Medication
    (
        ManufacturerId,
        Name
    )

    SELECT
        manufacturer.Id,
        'alprazolam'

        FROM Manufacturer AS manufacturer
        WHERE manufacturer.Name = 'Bayer AG'
;

INSERT INTO Medication
    (
        ManufacturerId,
        Name
    )

    SELECT
        manufacturer.Id,
        'alfuzosin hcl'

        FROM Manufacturer AS manufacturer
        WHERE manufacturer.Name = 'Bayer AG'
;


INSERT INTO Prescription
    (
        PrescribedDateUtc,
        StartDateUtc,
        EndDateUtc,
        PatientId,
        Text
    )

    SELECT
        STR_TO_DATE('1,16,2020','%m,%d,%Y'),
        STR_TO_DATE('1,18,2020','%m,%d,%Y'),
        STR_TO_DATE('4,18,2020','%m,%d,%Y'),
        patient.Id,
        CONCAT('2 mg of {medication#', medication.Id, '} per day')

        FROM Patient AS patient
        JOIN Medication AS medication ON
            medication.Name = 'alitretinoin'
        WHERE patient.FirstName = 'John'
;

INSERT INTO Prescription
    (
        PrescribedDateUtc,
        StartDateUtc,
        EndDateUtc,
        PatientId,
        Text
    )

    SELECT
        STR_TO_DATE('1,17,2020','%m,%d,%Y'),
        STR_TO_DATE('1,19,2020','%m,%d,%Y'),
        STR_TO_DATE('7,19,2020','%m,%d,%Y'),
        patient.Id,
        CONCAT('1.5 mg of {medication#', medication.Id, '} per day')

        FROM Patient AS patient
        JOIN Medication AS medication ON
            medication.Name = 'alprazolam'
        WHERE patient.FirstName = 'Sarah'
;
