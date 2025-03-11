using ASPNET_PRACTICE.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET_PRACTICE.Pages.User
{
    public class CreateModel : PageModel
    {

        public Users user = new Users(); //pag nag redline ang User ctrl + space pra makita ang auto suggest ma import and User.cs sa model folder

        public string successMessage = String.Empty;
        public string errorMessage = String.Empty;

        private readonly IConfiguration configuration;
        public CreateModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            user.FirstName = Request.Form["FirstName"]; //gikan ni sa create.cshtml tung naa sa form POST murag mag request siya didto base sa name="FirstName"
            user.LastName = Request.Form["LastName"];

            if (user.FirstName.Length == 0 || user.LastName.Length == 0) //mao ni atoang form validation incase wala siya fill up tanan fields
            {
                errorMessage = "Please fill up all fields";
                return;
            }

            //call the DAL method to add user nata note that mag try and catch jd pag mag call sa add user incase magka error

            try
            {
                DAL dal = new DAL();
                int result = dal.AddUser(user, configuration);

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            user.FirstName = ""; user.LastName = ""; //clear ang mga textbox
            successMessage = "User added successfully";
            Response.Redirect("/User/Index"); //redirect to index page after maka create ug user


        }
    }
}
