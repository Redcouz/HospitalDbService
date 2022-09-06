using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalDBervice;
using HospitalDbService.Infraestructure.Data;
using HospitalDBService;
using HospitalDbService.Core.Interfaces.IService;
using System.Numerics;
using Microsoft.CodeAnalysis.Differencing;

namespace HospitalDbService.Controllers
{
  public class DoctorController : Controller
  {
    private readonly IDoctorService _iDoctorService;

    public DoctorController(IDoctorService iDoctorService)
    {
      _iDoctorService = iDoctorService;
    }

    // GET: Consult/Details
    [HttpGet("doctor")]
    public async Task<IActionResult> GetAllDoctors()
    {
      return View("Index", await _iDoctorService.GetDoctors());
    }

    // GET: Consult/Details/{id}
    [HttpGet("doctor/{id}")]
    public async Task<IActionResult> GetDoctorById(int id)
    {
      if (id == null || _iDoctorService.EntityExists(id) == null)
      {
        return NotFound();
      }


      return View("Details", await _iDoctorService.GetDoctorById(id));
    }

    // GET: Consult/Create
    [HttpGet("doctor/create")]
    public IActionResult CreateDoctor()
    {
      return View("Create");
    }

    // POST: Consult/Create
    [HttpPost("doctor/create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDoctor([FromForm] DoctorModel doctorModel)
    {
      if (!ModelState.IsValid)
        return BadRequest();
      try
      {
        await _iDoctorService.Post(doctorModel);

        return View("Index", await _iDoctorService.GetDoctors());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    // GET: Doctor/Edit/5
    [HttpGet("doctor/edit/{id}")]
    public async Task<IActionResult> EditDoctor([FromForm] DoctorModel doctorModel, int id)
    {
      try
      {
        var doctorExists = await _iDoctorService.GetDoctorById(id);

        if (doctorExists == null)
        {
          return NotFound("doctor inexistent");
        }
        else
        {

          return View("Edit", doctorExists);

        }
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT: Doctor/Edit
    [HttpPost("doctor/edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PutDoctor([FromForm] DoctorModel doctorModel, int id)
    {
      try
      {
        bool DoctorExists = _iDoctorService.EntityExists(id);

        if (!DoctorExists)
        {
          return NotFound("Doctor inexistent");
        }
        else
        {
          await _iDoctorService.Put(doctorModel);

          return View("Index", await _iDoctorService.GetDoctors());

        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET: Doctor/Delete/{id}
    [HttpGet("doctor/delete/{id}")]
    public async Task<IActionResult> GetDoctorDelete(int id)
    {
      if (id == null || _iDoctorService.EntityExists(id) == null)
      {
        return NotFound();
      }

      var doctorModel = await _iDoctorService.GetDoctorById(id);

      return View("Delete", doctorModel);
    }

    // POST: Doctor/Delete/{id}
    [HttpDelete("doctor/delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
      if (_iDoctorService.EntityExists(id))
      {
        await _iDoctorService.DeleteDoctor(id);
      }
      return View("Index", await _iDoctorService.GetDoctors());
    }
  }
}
