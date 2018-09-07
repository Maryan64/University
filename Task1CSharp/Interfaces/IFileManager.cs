using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1CSharp.Interfaces
{
    public interface IFileManager
    {
        void Write(StreamWriter sw);
        void Read(StreamReader sr);
    }
}
