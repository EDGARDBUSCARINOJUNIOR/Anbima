using Microsoft.AspNetCore.Mvc;
using Anbima.Application.Services.Interfaces;

namespace Anbima.Api.Controllers
{
    //[Route("api/[controler]")]
    [ApiController]
    public class AnbimaController : ControllerBase
    {      
        private readonly ILogger<AnbimaController> _logger;
        private readonly IAnbimaService _iAnbimaService;

        public AnbimaController(ILogger<AnbimaController> logger, IAnbimaService iAnbimaService)
        {
            _logger = logger;
            _iAnbimaService = iAnbimaService;
        }
        /// <summary>
        /// GetAnbimaSeries
        /// </summary>       
        /// <returns></returns>        

        [HttpGet, Route("/GetAnbimaSerieHistorica")]
        public async Task<ActionResult<string>> GetParametrosEntrada()
        {
            var ret = "";
            try
            {
                _iAnbimaService.GetAnbimaSerieHistorica();
            }
            catch (Exception )
            {
                //gravar erro
            }
            return ret;
        }
    }
}
