namespace Archia.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Data.Naming;
    using Archia.Entities;
    using Archia.Utils;

    using Microsoft.Extensions.Logging;

    using MySql.Data.MySqlClient;

    public sealed class PatientService : DbServiceBase, IPatientService
    {
        public PatientService(MySqlConnection dbConnection, ILogger<PatientService> logger) : base(dbConnection, logger) { }

        public async Task<IEnumerable<Patient>> GetPatientsAsync(CancellationToken cancellationToken = default)
        {
            return await QueryAsync<Patient>
            (
                $@"
SELECT
    Id,
    FirstName,
    MiddleName,
    LastName

    FROM {DbTable.Patient}
;
                ",
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<Patient?> FindPatientByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await QuerySingleOrDefaultAsync<Patient?>
            (
                $@"
SELECT
    Id,
    FirstName,
    MiddleName,
    LastName

    FROM {DbTable.Patient}

    WHERE Id = @id
;
                ",
                new { id },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task CreatePatientAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(patient, nameof(patient));

            await ExecuteAsync
            (
                $@"
INSERT INTO {DbTable.Patient}(
    Id,
    FirstName,
    MiddleName,
    LastName
) SELECT
    @id,
    @firstName,
    @middleName,
    @lastName
;
                ",
                new
                {
                    id = patient.Id,
                    firstName = patient.FirstName,
                    middleName = patient.MiddleName,
                    lastName = patient.LastName
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task UpdatePatientAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(patient, nameof(patient));

            await ExecuteAsync
            (
                $@"
UPDATE {DbTable.Patient} SET
    FirstName = @firstName,
    MiddleName = @middleName,
    LastName = @lastName

    WHERE Id = @id
;
                ",
                new
                {
                    id = patient.Id,
                    firstName = patient.FirstName,
                    middleName = patient.MiddleName,
                    lastName = patient.LastName
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task DeletePatientAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(patient, nameof(patient));

            await ExecuteAsync
            (
                $@"
DELETE
    FROM {DbTable.Patient}
    WHERE Id = @id
;
                ",
                new { id = patient.Id },
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}