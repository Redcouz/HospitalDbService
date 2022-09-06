using HospitalDBervice;
using HospitalDbService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalDBService
{
  public class ConsultModel : EntityBase
  {
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal MaterialsCost { get; set; }
    public bool ConsultingRoom { get; set; }
    public DateTime ConsultDate { get; set; }

    [ForeignKey("DoctorId")]
    public virtual DoctorModel Doctor { get; set; }
    [ForeignKey("PatientId")]
    public virtual PatientModel Patient { get; set; }
  }
}
