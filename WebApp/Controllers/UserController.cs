using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class UserController : BaseController{
    public IActionResult Index() => View(Provider.User.GetUsers());

    public async Task<IActionResult> Delete(string id){
        await Provider.User.DeleteAsync(id);
        return Redirect("/user");
    }
}