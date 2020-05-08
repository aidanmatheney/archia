namespace Archia.Data.Services
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Entities;

    using Microsoft.Extensions.Logging;

    using MySql.Data.MySqlClient;

    public sealed class PatientService : DbServiceBase, IPatientService
    {
        public PatientService(MySqlConnection dbConnection, ILogger<PatientService> logger) : base(dbConnection, logger) { }

        public async Task<int> CreatePatientAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            return await ExecuteScalarAsync<int>
            (
                @"
INSERT INTO Patient
    (
        FirstName,
        MiddleName,
        LastName
    )

    VALUES
        (@firstName, @middleName, @lastName)
;

SELECT LAST_INSERT_ID();
                ",
                new
                {
                    firstName = patient.FirstName,
                    middleName = patient.MiddleName,
                    lastName = patient.LastName
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync(CancellationToken cancellationToken = default)
        {
            return await QueryAsync<Patient>
            (
                @"
SELECT
    Id,
    FirstName,
    MiddleName,
    LastName

    FROM Patient
;
                ",
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<Patient> GetPatientAsync(int id, CancellationToken cancellationToken = default)
        {
            return await QuerySingleOrDefaultAsync<Patient>
            (
                @"
SELECT
    Id,
    FirstName,
    MiddleName,
    LastName

    FROM Patient

    WHERE Id = @id
;
                ",
                new { id },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task UpdatePatientAsync(int id, Patient patient, CancellationToken cancellationToken = default)
        {
            await ExecuteAsync
            (
                @"
UPDATE Patient SET
    FirstName = @firstName,
    MiddleName = @middleName,
    LastName = @lastName

    WHERE Id = @id
;
                ",
                new
                {
                    id,
                    firstName = patient.FirstName,
                    middleName = patient.MiddleName,
                    lastName = patient.LastName
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task DeletePatientAsync(int id, CancellationToken cancellationToken = default)
        {
            await ExecuteAsync
            (
                @"
DELETE FROM Patient
    WHERE Id = @id
;
                ",
                new { id },
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}