using Archia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Archia.Data.Services
{
    public interface IPatientService
    {
        Task<int> CreatePatientAsync(Patient patient, CancellationToken cancellationToken = default);

        Task<IEnumerable<Patient>> GetPatientsAsync(CancellationToken cancellationToken = default);
        Task<Patient> GetPatientAsync(int id, CancellationToken cancellationToken = default);

        Task UpdatePatientAsync(int id, Patient patient, CancellationToken cancellationToken = default);

        Task DeletePatientAsync(int id, CancellationToken cancellationToken = default);
    }
}
