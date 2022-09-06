using HospitalDbService.Core.Models;
using HospitalDbService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalDBervice
{
  public class DoctorModel : PersonModel
  {
    public int RegistrationNumber { get; set; }
    public string Speciality { get; set; }
  }
}
