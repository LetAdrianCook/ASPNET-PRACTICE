using ASPNET_PRACTICE.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET_PRACTICE.Pages.User
{
    public class IndexModel : PageModel
    {

        private readonly IConfiguration _configuration;
        public IndexModel(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }
        public List<Users> listUsers = new List<Users>();
        public void OnGet()
        {
            DAL dal = new DAL();
            listUsers = dal.GetUsers(_configuration);
        }
    }
}
