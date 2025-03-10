using ASPNET_PRACTICE.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET_PRACTICE.Pages.User
{
    public class IndexModel : PageModel
    {

        private readonly IConfiguration configuration;
        public List<Users> ListUsers = new List<Users>();
        public IndexModel(IConfiguration configuration) //ctor shrtcut for constructor
        {
            this.configuration = configuration;
        }    
        public void OnGet()
        {
            DAL dal = new DAL();
            ListUsers = dal.GetUsers(configuration);
        }
    }
}
