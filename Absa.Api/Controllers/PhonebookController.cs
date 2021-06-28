using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Absa.Infrastructure.Models;
using Absa.Logic.Phonebook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Absa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhonebookController : ControllerBase
    {
        private readonly IPhonebookLogic _phonebookLogic;

        public PhonebookController(IPhonebookLogic phonebookLogic)
        {
            _phonebookLogic = phonebookLogic;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Phonebook>> Create(Phonebook phonebook)
        {
            try
            {
                phonebook = await _phonebookLogic.CreateAsync(phonebook);

                return Ok(phonebook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<Phonebook>> Update(Phonebook phonebook)
        {
            try
            {
                phonebook = await _phonebookLogic.UpdateAsync(phonebook);

                return Ok(phonebook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IList<Phonebook>> GetAll()
        {
            try
            {
                var phonebooks = _phonebookLogic.GetAll();

                return Ok(phonebooks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult<Phonebook> GetById(Guid id)
        {
            try
            {
                var phonebook = _phonebookLogic.GetItem(x => x.PhonebookId == id);

                return Ok(phonebook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}