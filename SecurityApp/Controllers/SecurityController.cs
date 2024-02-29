using Microsoft.AspNetCore.Mvc;
using SecurityApp.Domain;
using SecurityAPP.Service;

namespace SecurityApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _service;

        public SecurityController(ISecurityService service)
        {
            _service = service;
        }

        [HttpPost(Name = "Process")]
        public List<Security> Process(List<string> isins)
        {
            return _service.ProcessSecurityIsins(isins);
        }
    }
}