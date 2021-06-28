using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Absa.Infrastructure.Models;
using Absa.Logic.Entry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Absa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly IEntryLogic _entryLogic;

        public EntryController(IEntryLogic entryLogic)
        {
            _entryLogic = entryLogic;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Entry>> Create(Entry entry)
        {
            try
            {
                entry = await _entryLogic.CreateAsync(entry);

                return Ok(entry);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<Entry>> Update(Entry entry)
        {
            try
            {
                entry = await _entryLogic.UpdateAsync(entry);

                return Ok(entry);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IList<Entry>> GetAll()
        {
            try
            {
                var entries = _entryLogic.GetAll();

                return Ok(entries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetEntriesByPhonebookId/{phonebookId}")]
        public ActionResult<Entry> GetById(Guid phonebookId)
        {
            try
            {
                var entries = _entryLogic.GetItems(x => x.Phonebook.PhonebookId == phonebookId);

                return Ok(entries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetEntryById/{id}")]
        public ActionResult<Entry> GetEntryById(Guid id)
        {
            try
            {
                var entry = _entryLogic.GetItem(x => x.EntryId == id);

                return Ok(entry);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("Search/{searchText}")]
        public ActionResult<IList<Entry>> Search(string searchText)
        {
            try
            {
                var entries = _entryLogic.Search(searchText);

                return Ok(entries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}