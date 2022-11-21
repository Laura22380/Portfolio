using EmailAppV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAppV2.Data.Interfaces
{
    public interface IEmailRepository
    {
        void Create(EmailLog email);
    }
}
