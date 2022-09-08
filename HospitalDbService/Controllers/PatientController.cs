using Microsoft.AspNetCore.Mvc;
using HospitalDbService.Core.Models;
using HospitalDbService.Core.Interfaces.IService;

namespace HospitalDbService.Controllers
{
  public class PatientController : Controller
  {
    private readonly IPatientService _iPatientService;

    public PatientController(IPatientService iPatientService)
    {
      _iPatientService = iPatientService;
    }

    // GET: Patient/Details
    [HttpGet("patient")]
    public async Task<IActionResult> GetAllPatients()
    {
      return View("Index", await _iPatientService.GetPatients());
    }

    // GET: Patient/Details/{id}
    [HttpGet("patient/{id}")]
    public async Task<IActionResult> GetPatientById(int id)
    {
      if (id == null || _iPatientService.EntityExists(id) == null)
      {
        return NotFound();
      }
      return View("Details", await _iPatientService.GetPatientById(id));
    }

    // GET: patient/Create
    [HttpGet("patient/create")]
    public IActionResult CreatePatient()
    {
      return View("Create");
    }

    // POST: patient/Create
    [HttpPost("patient/create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostPatient([FromForm] PatientModel PatientModel)
    {
      try
      {
        await _iPatientService.Post(PatientModel);

        return View("Index", await _iPatientService.GetPatients());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    // GET: Patient/Edit/5
    [HttpGet("Patient/edit/{id}")]
    public async Task<IActionResult> EditPatient([FromForm] PatientModel PatientModel, int id)
    {
      try
      {
        var PatientExists = await _iPatientService.GetPatientById(id);

        if (PatientExists == null)
        {
          return NotFound("Patient inexistent");
        }
        else
        {

          return View("Edit", PatientExists);

        }
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT: Patient/Edit
    [HttpPost("Patient/edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PutPatient([FromForm] PatientModel PatientModel, int id)
    {
      try
      {
        bool PatientExists = _iPatientService.EntityExists(id);

        if (!PatientExists)
        {
          return NotFound("Patient inexistent");
        }
        else
        {
          await _iPatientService.Put(PatientModel);

          return View("Index", await _iPatientService.GetPatients());

        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET: Patient/Delete/{id}
    [HttpGet("Patient/delete/{id}")]
    public async Task<IActionResult> GetPatientDelete(int id)
    {
      if (id == null || _iPatientService.EntityExists(id) == null)
      {
        return NotFound();
      }

      var PatientModel = await _iPatientService.GetPatientById(id);

      return View("Delete", PatientModel);
    }

    // POST: Patient/Delete/{id}
    [HttpDelete("Patient/delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePatient(int id)
    {
      if (_iPatientService.EntityExists(id))
      {
        await _iPatientService.DeletePatient(id);
      }
      return View("Index", await _iPatientService.GetPatients());
    }
  }
}
