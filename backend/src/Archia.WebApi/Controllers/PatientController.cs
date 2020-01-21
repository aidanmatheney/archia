using Archia.Data.Entities;
using Archia.Data.Services;
using Archia.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Archia.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public sealed class PatientController : ControllerBase
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
        /// Create a new patient. 
        /// </summary>
        /// <returns>The ID of the new patient.</returns>
        //[HttpPut(Name = nameof(CreatePatient))]
        [HttpPost]
        public async Task<int> CreatePatient(Patient patient, CancellationToken cancellationToken)
        {
            var id = await _patientService.CreatePatientAsync(patient, cancellationToken);
            return id;
        }

        /// <summary>
        /// Get all patients.
        /// </summary>
        //[HttpGet(Name = nameof(GetPatients))]
        [HttpGet]
        public async Task<IEnumerable<Patient>> GetPatients(CancellationToken cancellationToken)
        {
            var patients = await _patientService.GetPatientsAsync(cancellationToken);
            return patients;
        }

        /// <summary>
        /// Get a patient by ID.
        /// </summary>
        /// <returns>The patient, or null.</returns>
        [HttpGet("{id}")]
        public async Task<Patient> GetPatient(int id, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientAsync(id, cancellationToken);
            return patient;
        }

        /// <summary>
        /// Update a patient by ID
        /// </summary>
        [HttpPut("{id}")]
        public async Task UpdatePatient(int id, Patient patient, CancellationToken cancellationToken)
        {
            await _patientService.UpdatePatientAsync(id, patient, cancellationToken);
        }

        /// <summary>
        /// Delete a patient by ID.
        /// </summary>
        [HttpDelete]
        public async Task DeletePatient(int id, CancellationToken cancellationToken)
        {
            await _patientService.DeletePatientAsync(id, cancellationToken);
        }
    }
}
