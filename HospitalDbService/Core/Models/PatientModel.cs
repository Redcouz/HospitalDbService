using HospitalDbService.Core.Models;
using HospitalDbService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalDBService
{
  public class PatientModel : PersonModel
  {
    public int MedicalHistoryNumber { get; set; }
    public virtual ICollection<ConsultModel> Consults { get; set; }
  }
}
