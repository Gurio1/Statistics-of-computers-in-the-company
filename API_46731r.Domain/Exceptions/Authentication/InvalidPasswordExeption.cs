using API_46731r.Domain.Exceptions.Authentication.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Domain.Exceptions.Authentication
{
    public class InvalidPasswordExeption : Exception, IAuthenticationExeption
    {
        public InvalidPasswordExeption(string msg) : base(msg)
        {
        }
    }
}
