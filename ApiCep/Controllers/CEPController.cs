using ApiCep.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CEPController : ControllerBase
    {
        
        [HttpGet(Name = "SearchZipCode")]
        public async Task<ActionResult> GetAsync(string cep)
        {
            try
            {
                if (cep.Trim().Length != 8)
                {
                    var error = new ErrorModel();
                    error.Message = "Cep inválido";
                    error.InternalErrorCode = 100;
                    return BadRequest(error);
                }
                var result = await ViaCepRequest.CepRequest(cep);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
