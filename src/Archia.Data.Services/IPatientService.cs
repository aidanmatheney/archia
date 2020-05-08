namespace Archia.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Entities;

    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync(CancellationToken cancellationToken = default);
        Task<Patient?> FindPatientByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreatePatientAsync(Patient patient, CancellationToken cancellationToken = default);
        Task UpdatePatientAsync(Patient patient, CancellationToken cancellationToken = default);
        Task DeletePatientAsync(Patient patient, CancellationToken cancellationToken = default);
    }
}