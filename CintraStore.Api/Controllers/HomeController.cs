using Microsoft.AspNetCore.Mvc;

namespace CintraStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public string Get()
        {
            return "Hello World";
        }
    }
}
