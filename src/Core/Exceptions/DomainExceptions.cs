using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class DomainExceptions : Exception
    {
        internal List<string> _erros;
        public IReadOnlyCollection<string> Erros => _erros;

        public DomainExceptions()
        {
        }

        public DomainExceptions(string message, List<string> erros) : base(message)
        {
            _erros = erros;
        }

        public DomainExceptions(string message) : base(message)
        { }

        public DomainExceptions(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
