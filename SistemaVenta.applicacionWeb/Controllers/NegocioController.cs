using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using SistemaVenta.applicacionWeb.Models.ViewModels;
using SistemaVenta.applicacionWeb.Utilidades.Response;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.Entity;



namespace SistemaVenta.applicacionWeb.Controllers
{
    public class NegocioController : Controller
    {


        readonly private IMapper _mapper;
        readonly private INegocioService _negocioService;

        public NegocioController(IMapper mapper, INegocioService negocioService )
        {
            _mapper = mapper;
            _negocioService = negocioService;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult>Obtener ()
        {
            GenericResponse<VMNegocio> gResponse = new GenericResponse<VMNegocio> ();

            try {
                VMNegocio vnNegocio = _mapper.Map<VMNegocio>(await _negocioService.Obtener());
                gResponse.Estado = true;
                gResponse.Objeto = vnNegocio;
            }
            catch (Exception ex)
            {
                gResponse.Estado = false ;
                gResponse.Mensaje = ex.Message;

            }

            return  StatusCode(StatusCodes.Status200OK,gResponse);
        }




        [HttpPost]
        public async Task<IActionResult> GuardarCambios([FromForm]IFormFile Logo , [FromForm] string modelo )
        {
            GenericResponse<VMNegocio> gResponse = new GenericResponse<VMNegocio>();

            try
            {
                VMNegocio vnNegocio = JsonConvert.DeserializeObject<VMNegocio>(modelo);


                string nombreLogo = "";
                Stream LogoStream = null; 


                if(Logo != null)
                {
                    string nombre_en_codigo = Guid.NewGuid().ToString("N");
                    string extension = Path.GetExtension(Logo.FileName);
                    nombreLogo = string.Concat(nombre_en_codigo, extension);
                    LogoStream = Logo.OpenReadStream();
                }

                Negocio Negocio_editado = await _negocioService.GuardarCambios(_mapper.Map<Negocio>(vnNegocio), LogoStream, nombreLogo);

                vnNegocio = _mapper.Map<VMNegocio>(Negocio_editado); 



                gResponse.Estado = true;
                gResponse.Objeto = vnNegocio;
            }
            catch (Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje = ex.Message;

            }

            return StatusCode(StatusCodes.Status200OK, gResponse);
        }





    }
}
