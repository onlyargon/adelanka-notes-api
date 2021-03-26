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
    public class CommentController : Controller
    {
        ICommentsRepository repository = new CommentsRepository();

        #region CreateComment
        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(Comment _input)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Task.Run(() => repository.CreateComment(_input)));
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

        #region GetAllCommentForNote
        [HttpPost("GetAllCommentForNote")]
        public async Task<IActionResult> GetAllCommentForNote(CommonRequest _input)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Task.Run(() => repository.GetAllCommentForNote(_input)));
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