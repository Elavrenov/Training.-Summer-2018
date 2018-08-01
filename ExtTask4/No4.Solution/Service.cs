using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No4.Solution
{
    public class Service:IServise
    {
        private readonly IGenerator _generator;

        public Service(IGenerator generator)
        {
            _generator = generator;
        }

        public void GenerateFiles(int filesCount, int contentLength)
        {
            _generator.GenerateFiles(filesCount,contentLength);
        }
    }
}
