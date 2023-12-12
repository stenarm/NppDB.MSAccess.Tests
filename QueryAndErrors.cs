using System;
using System.Collections.Generic;
using System.Linq;

namespace NppDB.MSAccess.Tests
{
    public class QueryAndErrors
    {
        public String Query { get; set; }
        public List<String> Errors { get; set; }

        public override string ToString()
        {
            return "Query: " + Query + "\nExpected errors: " + String.Join(", ", Errors.OrderBy(e => e).ToList()); ;
        }
    }
}
