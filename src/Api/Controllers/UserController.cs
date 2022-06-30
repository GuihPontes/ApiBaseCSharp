using Api.ViewModel;
using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices services;

        public UserController(IUserServices services)
        {
            this.services = services;
        }


        [HttpPost]
        [Route("/api/v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userCreate)
        {
            try
            {
               var create = await services.CreateAsync(userCreate);
                return Create(create);
            }
            catch (DomainExceptions ex)
            {

                return BadRequest();
            }
            catch(Exception)
            {
                return StatusCode(500, "Erro");
            }
        }

    }
}
