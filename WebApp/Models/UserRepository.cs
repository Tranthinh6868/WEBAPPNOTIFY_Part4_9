using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApp.Models;

public class UserRepository{
    UserManager<IdentityUser> manager;
    public UserRepository(UserManager<IdentityUser> manager) => this.manager = manager;
    public async Task<IdentityResult> AddAsync(RegisterModel obj){
        //obj.Id = Guid.NewGuid().ToString();
        return await manager.CreateAsync(new IdentityUser{
            Email = obj.Email,
            PhoneNumber = obj.PhoneNumber,
            UserName = obj.Username 
            }, obj.Password);
    }
    public async Task<Tuple <bool,IdentityUser?>> LoginAsync(LoginModel obj){
        IdentityUser? user = await manager.FindByNameAsync(obj.Username);
        if(user is null){
            return new Tuple<bool, IdentityUser?>(false, null);
        }
        var result = await manager.CheckPasswordAsync(user, obj.Password);
        return new Tuple<bool, IdentityUser?>(result, user);
    }
    public List<IdentityUser> GetUsers(){
        return manager.Users.ToList();
    }
    public async Task<IdentityResult?> DeleteAsync(string id){
        var user = await manager.FindByIdAsync(id);
        if(user is null){
            return null;
        }
        return await manager.DeleteAsync(user);
    }
}