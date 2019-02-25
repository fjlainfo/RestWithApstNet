using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithApstNet.Business;
using RestWithApstNet.Data.VO;
using RestWithApstNet.Model;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace RestWithApstNet.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginService)
        {
            _loginBusiness = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody] User user)
        {
            if (user == null) return BadRequest();
            return _loginBusiness.FindByLogin(user);
        }

    }
}
