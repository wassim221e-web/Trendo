using Microsoft.AspNetCore.Mvc;

namespace Trendo.Api.Controllers;
public class CustomerController : Controller
{
    // GET
    public IActionResult GetAll()
    {
        return View();
    }
}