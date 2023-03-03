using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDD
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
      
        public String PatientName { get; set; }

        public String PhoneNumber { get; set; }

        public int Age { get; set; }

        public String Gender { get; set; }
    }
}