using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken();
    }
}
