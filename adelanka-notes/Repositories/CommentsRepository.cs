using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adelanka_notes.DbEntities;
using adelanka_notes.Models;
using adelanka_notes.Repositories.IRepositories;

namespace adelanka_notes.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {

        public async Task<Dictionary<string, object>> CreateComment(Comment _input)
        {
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            try
            {
                using (var _DbEntity = new adelankanotesContext())
                {
                    if (_input != null)
                    {
                        _input.CreatedDate = DateTime.Now;
                        _input.ModifiedDate = DateTime.Now;

                        _DbEntity.Comments.Add(_input);
                        _DbEntity.SaveChanges();

                        jsonObj.Add("Code", 0);
                        jsonObj.Add("Status", "Success");
                        jsonObj.Add("Message", "Note Saved!");
                        jsonObj.Add("Data", null);
                    }
                    else
                    {
                        jsonObj.Add("Code", 1);
                        jsonObj.Add("Status", "Fail");
                        jsonObj.Add("Message", $"Something went wrong!");
                        jsonObj.Add("Data", null);
                    }
                }
            }
            catch (Exception ex)
            {
                jsonObj.Add("Code", 1);
                jsonObj.Add("Status", "Fail");
                jsonObj.Add("Message", $"{ex.InnerException?.Message}");
                jsonObj.Add("Data", null);
            }
            return await Task.FromResult(jsonObj);
        }

        public async Task<Dictionary<string, object>> DeleteComment(CommonRequest _input)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, object>> EditComment(Comment _input)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, object>> GetAllCommentForNote(CommonRequest _input)
        {
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            try
            {
                using (var _DbEntity = new adelankanotesContext())
                {
                    var comments = (from c in _DbEntity.Comments join u in _DbEntity.Users on c.UserId equals u.UserId
                                    where c.NoteId == _input.Id && c.IsDeleted == false
                                    select new { c.CommentContent, u.Username }
                                    ).ToList();

                    if (comments != null)
                    {

                        jsonObj.Add("Code", 0);
                        jsonObj.Add("Status", "Success");
                        jsonObj.Add("Message", "Data fetched!");
                        jsonObj.Add("Data", comments);
                    }
                    else
                    {
                        jsonObj.Add("Code", 1);
                        jsonObj.Add("Status", "Fail");
                        jsonObj.Add("Message", $"Something went wrong!");
                        jsonObj.Add("Data", null);
                    }
                }
            }
            catch (Exception ex)
            {
                jsonObj.Add("Code", 1);
                jsonObj.Add("Status", "Fail");
                jsonObj.Add("Message", $"{ex.InnerException?.Message}");
                jsonObj.Add("Data", null);
            }
            return await Task.FromResult(jsonObj);
        }
    }
}
