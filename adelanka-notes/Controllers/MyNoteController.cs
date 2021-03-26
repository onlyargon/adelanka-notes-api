using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adelanka_notes.DbEntities;
using adelanka_notes.Models;
using adelanka_notes.Repositories;
using adelanka_notes.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace adelanka_notes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MyNoteController : Controller
    {
        IMyNotesRepository repository = new MyNotesRepository();

        #region CreateNote
        [HttpPost("CreateNote")]
        public async Task<IActionResult> CreateNote(Mynote _input)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Task.Run(() => repository.CreateNote(_input)));
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("Response", "Error");
                data.Add("Code", "FCE00006");
                data.Add("Description", "Invalid JSON");
                data.Add("Data", null);
                return Ok(data);
            }
        }
        #endregion

        #region GetAllNotes
        [HttpGet("GetAllNotes")]
        public async Task<IActionResult> GetAllNotes()
        {
            if (ModelState.IsValid)
            {
                return Ok(await Task.Run(() => repository.GetAllNotes()));
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("Response", "Error");
                data.Add("Code", "FCE00006");
                data.Add("Description", "Invalid JSON");
                data.Add("Data", null);
                return Ok(data);
            }
        }
        #endregion


        #region GetMyNotes
        [HttpPost("GetMyNotes")]
        public async Task<IActionResult> GetMyNotes(CommonRequest _input)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Task.Run(() => repository.GetMyNotes(_input)));
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("Response", "Error");
                data.Add("Code", "FCE00006");
                data.Add("Description", "Invalid JSON");
                data.Add("Data", null);
                return Ok(data);
            }
        }
        #endregion
    }
}