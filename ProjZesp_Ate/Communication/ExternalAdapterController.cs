using ProjZesp_Ate.Controllers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TechnikiInternetowe.Communication
{
    public class ExternalAdapterController : Controller
    {
        public ExternalAdapterController() { }
        [HttpGet]
        [Route("test")]
        public string Index()
        {
            return "HelloWord";
        }

        [HttpPost]
        [Route("TryCreateUserAccount")]
        public async Task<bool> PermissionOnCreateFile(string userAccountCreateData)
        {
            return await Task.Run(() => HomeController.TryCreateUserAccount(userAccountCreateData));
        }
    }
}
