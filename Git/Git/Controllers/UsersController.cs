using Git.DataForm;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Index");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginDataForm dataForm)
        {

        }
    }
}
