using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithApstNet.Data.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O orgin);
        List<D> ParseList(List<O> orgin);
    }
}
