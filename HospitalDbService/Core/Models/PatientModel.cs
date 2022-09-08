using HospitalDbService.Core.Models;

namespace HospitalDbService.Core.Models
{
  public class PatientModel : PersonModel
  {
    public int MedicalHistoryNumber { get; set; }
    public virtual ICollection<ConsultModel> Consults { get; set; }
  }
}
