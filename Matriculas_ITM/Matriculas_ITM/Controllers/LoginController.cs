using Matriculas_ITM.Models;
using Matriculas_ITM.Clases;
using System.Linq;
using System.Web.Http;

namespace Matriculas_ITM.Controllers
{
    [RoutePrefix("api/Login")]
    //[Authorize]: Directiva para obligar a que se tenga autorización usar al servicio
    //[AllowAnonymous]: Directiva para que se pueda usar el servicio sin autorización.
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar(Login login)
        {
            ClLogin _Login = new ClLogin();
            _Login.login = login;
            return _Login.Ingresar();
        }
    }
}