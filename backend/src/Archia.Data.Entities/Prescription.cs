namespace Archia.Data.Entities
{
    using System;

    public class Prescription
    {
        public int Id { get; set; }
        public DateTime PrescribedDateUtc { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public int PatientId { get; set; }
        public string Text { get; set; }
    }
}