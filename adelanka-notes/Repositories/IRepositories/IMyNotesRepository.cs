using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adelanka_notes.DbEntities;
using adelanka_notes.Models;

namespace adelanka_notes.Repositories.IRepositories
{
    public interface IMyNotesRepository
    {
        Task<Dictionary<string, object>> CreateNote(Mynote _input);
        Task<Dictionary<string, object>> GetAllNotes();
        Task<Dictionary<string, object>> GetMyNotes(CommonRequest _input);
        Task<Dictionary<string, object>> UpdateNote(Mynote _input);
        Task<Dictionary<string, object>> DeleteNote(CommonRequest _input);
    }
}
