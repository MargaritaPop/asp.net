using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Services
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
