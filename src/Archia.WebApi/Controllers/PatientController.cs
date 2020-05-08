namespace Archia.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Data.Services;
    using Archia.Entities;
    using Archia.Utils;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public sealed class PatientController : HomeControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger _logger;

        public PatientController
        (
            IPatientService patientService,
            ILogger<PatientController> logger
        )
        {
            ThrowIf.Null(patientService, nameof(patientService));
            ThrowIf.Null(logger, nameof(logger));

            _patientService = patientService;
            _logger = logger;
        }

        /// <summary>
        ///     Get all patients.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Patient>> GetPatients(CancellationToken cancellationToken)
        {
            var patients = await _patientService.GetPatientsAsync(cancellationToken).ConfigureAwait(false);
            return patients;
        }

        /// <summary>
        ///     Get a patient by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<Patient> GetPatient(Guid id, CancellationToken cancellationToken)
        {
            var patient = await _patientService.FindPatientByIdAsync(id, cancellationToken).ConfigureAwait(false);
            return patient;
        }

        /// <summary>
        ///     Create a new patient.
        /// </summary>
        [HttpPost]
        public async Task CreatePatient(Patient patient, CancellationToken cancellationToken)
        {
            patient.Id = Guid.NewGuid();
            await _patientService.CreatePatientAsync(patient, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Update a patient by ID
        /// </summary>
        [HttpPut("{id}")]
        public async Task UpdatePatient(Guid id, Patient patient, CancellationToken cancellationToken)
        {
            patient.Id = id;
            await _patientService.UpdatePatientAsync(patient, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Delete a patient by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task DeletePatient(Guid id, CancellationToken cancellationToken)
        {
            var patient = new Patient { Id = id };
            await _patientService.DeletePatientAsync(patient, cancellationToken).ConfigureAwait(false);
        }
    }
}