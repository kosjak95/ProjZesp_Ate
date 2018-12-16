using Entity.Model;
using ProjZesp_Ate.Controllers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TechnikiInternetowe.Communication
{
    public class ExternalAdapterController : Controller
    {
        public ExternalAdapterController() { }

        [HttpPost]
        [Route("TryCreateUserAccount")]
        public async Task<bool> PermissionOnCreateFile(User data)
        {
            return await Task.Run(() => HomeController.TryCreateUserAccount(data));
        }
    }
}
