namespace Archia.Data.Services
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Entities;
    using Archia.Utils;

    using Dapper;

    public sealed class PatientService : IPatientService
    {
        private readonly IDbConnection _dbConnection;

        public PatientService(IDbConnection dbConnection)
        {
            ThrowIf.Null(dbConnection, nameof(dbConnection));

            _dbConnection = dbConnection;
        }

        public async Task<int> CreatePatientAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("firstName", patient.FirstName);
            parameters.Add("middleName", patient.MiddleName);
            parameters.Add("lastName", patient.LastName);

            await _dbConnection.ExecuteAsync(new CommandDefinition
            (
                commandText:
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

SET @id = LAST_INSERT_ID();
                ",
                parameters: parameters,
                cancellationToken: cancellationToken
            )).ConfigureAwait(false);

            return parameters.Get<int>("id");
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbConnection.QueryAsync<Patient>(new CommandDefinition
            (
                commandText:
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
            )).ConfigureAwait(false);
        }

        public async Task<Patient> GetPatientAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<Patient>(new CommandDefinition
            (
                commandText:
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
                parameters: new
                {
                    id
                },
                cancellationToken: cancellationToken
            )).ConfigureAwait(false);
        }

        public async Task UpdatePatientAsync(int id, Patient patient, CancellationToken cancellationToken = default)
        {
            await _dbConnection.ExecuteAsync(new CommandDefinition
            (
                commandText:
                @"
UPDATE Patient SET
    FirstName = @firstName,
    MiddleName = @middleName,
    LastName = @lastName

    WHERE Id = @id
;
                ",
                parameters: new
                {
                    id,
                    firstName = patient.FirstName,
                    middleName = patient.MiddleName,
                    lastName = patient.LastName
                },
                cancellationToken: cancellationToken
            )).ConfigureAwait(false);
        }

        public async Task DeletePatientAsync(int id, CancellationToken cancellationToken = default)
        {
            await _dbConnection.ExecuteAsync(new CommandDefinition
            (
                commandText:
                @"
DELETE FROM Patient
    WHERE Id = @id
;
                ",
                parameters: new
                {
                    id
                },
                cancellationToken: cancellationToken
            )).ConfigureAwait(false);
        }
    }
}