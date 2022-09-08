using HospitalDbService.Core.Models;

namespace HospitalDbService.Core.Models
{
  public class DoctorModel : PersonModel
  {
    public int RegistrationNumber { get; set; }
    public string Speciality { get; set; }
  }
}
