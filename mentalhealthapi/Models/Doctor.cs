using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mentalhealthapi.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set;}
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Qualification { get; set; }
        public string? Speciality { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
