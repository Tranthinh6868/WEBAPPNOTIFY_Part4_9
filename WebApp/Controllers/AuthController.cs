using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : BaseController{
    SignInManager<IdentityUser> manager;
    public AuthController(SignInManager<IdentityUser> manager) => this.manager = manager;
    [Authorize]
    public IActionResult Index() => View();
    public IActionResult Login() => View();
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel obj){
        if(ModelState.IsValid){
            (bool ret, IdentityUser? user) = await Provider.User.LoginAsync(obj);
            if(ret && user != null){
                await manager.SignInAsync(user, false, CookieAuthenticationDefaults.AuthenticationScheme);
                return Redirect("/auth");
            }
        }
        return View(obj);
    }
     public IActionResult Register() => View();
    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel obj){
        if(ModelState.IsValid){
            var result = await Provider.User.AddAsync(obj);
            if(result != null && result.Succeeded){
                return Redirect("/auth/login");
            }
            foreach(var item in result!.Errors){
                ModelState.AddModelError(item.Code, item.Description);
            }
        }
        return View(obj);
    }
}
