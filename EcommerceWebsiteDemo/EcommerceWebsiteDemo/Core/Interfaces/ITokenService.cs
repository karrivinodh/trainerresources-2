using EcommerceWebsiteDemo.Core.Entities.Identity;

namespace EcommerceWebsiteDemo.Core.Interfaces

{ 
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}

