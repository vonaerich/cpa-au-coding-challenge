using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CPA.Part1
{
    public class Printer : IPrinter
    {
        private readonly TextWriter _textWriter;

        public Printer(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void Print(IEnumerable<IGrouping<int, string>> groupedResults)
        {
            foreach (var grouping in groupedResults)
            {
                _textWriter.WriteLine($"{grouping.Key}");
                foreach (var item in grouping)
                {
                    _textWriter.WriteLine($"{item}");
                }
            }
        }
    }

    public interface IPrinter
    {
        void Print(IEnumerable<IGrouping<int, string>> groupedResults);
    }
}
