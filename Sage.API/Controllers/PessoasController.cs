using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sage.Domain.Contracts.IServices;
using Sage.Domain.Entities;

namespace Sage.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : Controller
    {
        private readonly IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_pessoaService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var pessoa = _pessoaService.GetById(id);

                if (pessoa == null)
                {
                    return NotFound();
                }

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Add(Pessoa pessoa)
        {
            try
            {
                _pessoaService.Add(pessoa);
                return Created("api/Pessoas", pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Pessoa pessoa)
        {
            try
            {
                if (id != pessoa.Id)
                {
                    return BadRequest();
                }

                _pessoaService.Update(pessoa);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}