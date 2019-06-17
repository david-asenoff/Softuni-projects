using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PersonInfo
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }
    }
}
