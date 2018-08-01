using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No4.Solution
{
    public interface IGenerator
    {
        void GenerateFiles(int filesCount, int contentLength);
        string WorkingDirectory { get; }
        string FileExtension { get; }
    }

}
