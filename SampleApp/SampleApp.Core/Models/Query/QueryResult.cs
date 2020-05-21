using System.Collections.Generic;

namespace SampleApp.Core.Models.Query
{
    public class QueryResult<T>
    {
        public IEnumerable<T> Data { get; set; }
    }
}
