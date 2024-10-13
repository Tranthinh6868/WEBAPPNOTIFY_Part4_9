using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class HomeController : BaseController{
    public IActionResult Index() => View();
}