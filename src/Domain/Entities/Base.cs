using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }

        internal List<string> _erros;

        public IReadOnlyCollection<string> Erros => _erros;

        public abstract bool Validate();


    }

}
