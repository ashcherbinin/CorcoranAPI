using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorcoranAPI.Repository
{
    public interface IPresidentRepository
    {

        Task <IEnumerable> getPresidentList(bool? sortorder );  
    }
}