using Microsoft.AspNetCore.Mvc;

namespace HospitalDbService.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
