using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
     public class DefaultController : Controller
    {
        [Route("/")]
        [Route("/docs")]
        [Route("/swagger")]
        public IActionResult Index()
        {
            return new RedirectResult("/WebAPI/swagger/index.html");
        }
    } 
}