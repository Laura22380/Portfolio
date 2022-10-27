using CCAPL.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAPL.Data.Interfaces
{
    interface IMembersRepository
    {
        List<Members> GetAll();
    }
}
