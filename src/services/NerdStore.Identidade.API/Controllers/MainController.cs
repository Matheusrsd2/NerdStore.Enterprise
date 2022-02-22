using Microsoft.AspNetCore.Mvc;

namespace NerdStore.Identidade.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> erros = new List<string>();   
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens", erros.ToArray() }
            }));
        }

        protected bool OperacaoValida()
        {
            return !erros.Any();
        }

        protected void AdicionarErro(string erro)
        {
            erros.Add(erro);    
        }
    }
}
