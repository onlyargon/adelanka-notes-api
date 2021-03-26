using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adelanka_notes.DbEntities;
using adelanka_notes.Models;
using adelanka_notes.Repositories.IRepositories;

namespace adelanka_notes.Repositories
{
    public class MyNotesRepository : IMyNotesRepository
    {
        public MyNotesRepository()
        {
        }

        public async Task<Dictionary<string, object>> CreateNote(Mynote _input)
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

                        _DbEntity.Mynotes.Add(_input);
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

        public async Task<Dictionary<string, object>> DeleteNote(CommonRequest _input)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, object>> GetAllNotes()
        {
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            try
            {
                using (var _DbEntity = new adelankanotesContext())
                {
                    var notes = _DbEntity.Mynotes.Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
                    if (notes != null)
                    {

                        jsonObj.Add("Code", 0);
                        jsonObj.Add("Status", "Success");
                        jsonObj.Add("Message", "Data fetched!");
                        jsonObj.Add("Data", notes);
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

        public async Task<Dictionary<string, object>> GetMyNotes(CommonRequest _input)
        {
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();
            try
            {
                using (var _DbEntity = new adelankanotesContext())
                {
                    var notes = _DbEntity.Mynotes.Where(x => x.UserId == _input.Id && x.IsDeleted == false && x.IsActive == true).ToList();
                    if (notes != null)
                    {

                        jsonObj.Add("Code", 0);
                        jsonObj.Add("Status", "Success");
                        jsonObj.Add("Message", "Data fetched!");
                        jsonObj.Add("Data", notes);
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

        public async Task<Dictionary<string, object>> UpdateNote(Mynote _input)
        {
            throw new NotImplementedException();
        }
    }
}
