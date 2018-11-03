using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorcoranAPI.Models;
using Microsoft.EntityFrameworkCore;
using static CorcoranAPI.Models.PresidentModel;

namespace CorcoranAPI.Repository
{
    public class PresidentRepository:IPresidentRepository
    {

        private readonly PresidentContext _presidentContext;

        public PresidentRepository(PresidentContext context)
        {
            _presidentContext = context;
        }


        public async Task <IEnumerable> getPresidentList(string sortorder)
        {

            var result = await _presidentContext.Presidents.Select(a => new {a.president, a.birthday, a.birthplace, a.deathday, a.Deathplace})
                                                .OrderByDescending(a=>a.president).ToListAsync();

            return result;
        }
    }
}
