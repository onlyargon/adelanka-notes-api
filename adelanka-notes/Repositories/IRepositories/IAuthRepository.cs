using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adelanka_notes.DbEntities;

namespace adelanka_notes.Repositories.IRepositories
{
    public interface IAuthRepository
    {
        Task<Dictionary<string, object>> LoginUser(User _input, string s);
    }
}
