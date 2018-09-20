using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1CSharp.Interfaces
{
    /// <summary>
    /// Common interface to union methods from IShape and IFileManeger
    /// </summary>
    public interface IFigure : IShape, IFileManager
    {
    }
}
