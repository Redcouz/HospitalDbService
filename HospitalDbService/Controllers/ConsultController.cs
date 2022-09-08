using Microsoft.AspNetCore.Mvc;
using HospitalDbService.Core.Interfaces.IService;
using HospitalDbService.Core.Models;

namespace HospitalDbService.Controllers
{
  public class ConsultController : Controller
  {
    private readonly IConsultService _iConsultService;

    public ConsultController(IConsultService iConsultService)
    {
      _iConsultService = iConsultService;
    }

    // GET: Consult/Details
    [HttpGet("consult")]
    public async Task<IActionResult> GetAllConsults()
    {
      return View("Index", await _iConsultService.GetConsults());
    }

    // GET: Consult/Details/{id}
    [HttpGet("consult/{id}")]
    public async Task<IActionResult> GetConsultById(int id)
    {
      if (id == null || _iConsultService.EntityExists(id) == null)
      {
        return NotFound();
      }
      return View("Details", await _iConsultService.GetConsultById(id));
    }

    // GET: Consult/Create
    [HttpGet("consult/create")]
    public IActionResult CreateConsult()
    {
      return View("Create");
    }

    // POST: Consult/Create
    [HttpPost("consult/create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostConsult([FromForm] ConsultModel consultModel)
    {
      try
      {
        await _iConsultService.Post(consultModel);

        return View("Index", await _iConsultService.GetConsults());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    // GET: consult/Edit/5
    [HttpGet("consult/edit/{id}")]
    public async Task<IActionResult> EditConsult([FromForm] ConsultModel consultModel, int id)
    {
      try
      {
        var consultExists = await _iConsultService.GetConsultById(id);

        if (consultExists == null)
        {
          return NotFound("Consult inexistent");
        }
        else
        {

          return View("Edit", consultExists);

        }
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT: consult/Edit
    [HttpPost("consult/edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PutConsult([FromForm] ConsultModel consultModel, int id)
    {
      try
      {
        bool consultExists = _iConsultService.EntityExists(id);

        if (!consultExists)
        {
          return NotFound("Consult inexistent");
        }
        else
        {
          await _iConsultService.Put(consultModel);

          return View("Index", await _iConsultService.GetConsults());

        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET: consult/Delete/{id}
    [HttpGet("consult/delete/{id}")]
    public async Task<IActionResult> GetConsultDelete(int id)
    {
      if (id == null || _iConsultService.EntityExists(id) == null)
      {
        return NotFound();
      }

      var consultModel = await _iConsultService.GetConsultById(id);

      return View("Delete", consultModel);
    }

    // POST: consult/Delete/{id}
    [HttpDelete("consult/delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConsult(int id)
    {
      if (_iConsultService.EntityExists(id))
      {
        await _iConsultService.DeleteConsult(id);
      }
      return View("Index", await _iConsultService.GetConsults());
    }
  }
}
