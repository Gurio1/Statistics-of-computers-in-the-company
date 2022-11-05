using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Domain.Exceptions
{
    public class EmailNotFoundException : Exception
    {

        public EmailNotFoundException(string msg) : base(msg)
        {
        }
    }
}
