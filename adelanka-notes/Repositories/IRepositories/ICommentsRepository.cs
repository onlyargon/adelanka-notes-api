using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adelanka_notes.DbEntities;
using adelanka_notes.Models;

namespace adelanka_notes.Repositories.IRepositories
{
    public interface ICommentsRepository
    {
        Task<Dictionary<string, object>> CreateComment(Comment _input);
        Task<Dictionary<string, object>> GetAllCommentForNote(CommonRequest _input);
        Task<Dictionary<string, object>> EditComment(Comment _input);
        Task<Dictionary<string, object>> DeleteComment(CommonRequest _input);
    }
}
