using Microsoft.AspNetCore.Identity;

namespace WebApp.Models;

public class SiteProvider{
    UserRepository? user;
    IHttpContextAccessor accessor;

    public SiteProvider(IHttpContextAccessor accessor)=> this.accessor = accessor;


    public UserRepository User => user ??= new UserRepository(
        accessor.HttpContext!.RequestServices.GetRequiredService<UserManager<IdentityUser>>());
}