using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwordAndFather.Data;
using SwordAndFather.Models;
using SwordAndFather.Validators;

namespace SwordAndFather.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssassinController : ControllerBase
    {
        readonly CreateAssassinRequestValidator _validator;
        readonly AssaassinRepository _repository;

        public AssassinController()
        {
            _validator = new CreateAssassinRequestValidator();
            _repository = new AssaassinRepository();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult AddAssassin([FromBody]CreateAssassinRequest request)
        {
            if (!_validator.Validate(request))
            {
                return BadRequest(new { error = "Assassins must have a Codename, Catchphrase, and Preferred Weapon" });
            }

            var newAssassin = _repository.AddAssassin(request.CodeName, request.CatchPhrase, request.PreferredWeapon);

            return Created($"api/assassin/{newAssassin.Id}", newAssassin);

        }
    }
}