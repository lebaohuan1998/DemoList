using Microsoft.AspNetCore.Identity;

namespace DemoList.Data
{
    public class ApiUser : IdentityUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
