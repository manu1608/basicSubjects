using System;
using System.Collections.Generic;
using System.Text;

namespace EZCode
{
    public interface IDatabaseHelper
    {
        string GetLocalFilePath(string fileName);

        void CopyDatabaseToLocal(string dbPath);
    }
}
