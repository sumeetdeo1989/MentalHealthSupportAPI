using System.ComponentModel.DataAnnotations;

namespace mentalhealthapi.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set;}
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Qualification { get; set; }
        public string? Speciality { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
