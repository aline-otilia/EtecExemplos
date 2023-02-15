using InfraStructure.DataAcessSingleton;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SigletonController : Controller
    {
        private IActionResult _viewModel;

        [HttpGet(Name = "Singleton")]
        public IActionResult Index()
        {
            SingletonResponse sResponse = new SingletonResponse();

            PessoaDAO pDAO = PessoaDAO.Instance;
            PessoaDAO pDAO2 = PessoaDAO.Instance;
            PessoaDAO pDAO3 = PessoaDAO.Instance;

/*
            PessoaDAO pessoaDAO = new PessoaDAO();
            PessoaDAO pessoaDAO2 = new PessoaDAO();
*/
            sResponse.NomeObjeto = "PessoaDAO";
            sResponse.QtdeInstancias = pDAO.QtdeInstancias;

            return this.Ok(sResponse);
        }
    }
}
