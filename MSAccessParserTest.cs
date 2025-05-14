using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using NppDB.Comm;
using Xunit;
using Xunit.Abstractions;

namespace NppDB.MSAccess.Tests
{
    public class MSAccessParserTest
    {
        private readonly ITestOutputHelper output;

        public MSAccessParserTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestQueriesGetCorrectWarnings()
        {
            MsAccessExecutor executor = new MsAccessExecutor(null);
            using (var sr = new StreamReader("Resources/msaccessQueryAndError.json"))
            {
                String jsonString;
                while ((jsonString = sr.ReadToEnd()) != "")
                {
                    List<QueryAndErrors> queriesAndErrors = JsonSerializer.Deserialize<List<QueryAndErrors>>(jsonString);
                    foreach (var queryAndErrors in queriesAndErrors)
                    {
                        output.WriteLine(queryAndErrors.ToString());
                        ParserResult parserResult = executor.Parse(queryAndErrors.Query, new CaretPosition { Line = 0, Column = 0, Offset = 0 });
                        List<String> warnings = new List<String>();
                        foreach (var command in parserResult.Commands)
                        {
                            foreach (var warning in command.Warnings)
                            {
                                warnings.Add(warning.Type.ToString());
                            }
                        }
                        warnings = warnings.OrderBy(w => w).ToList();
                        output.WriteLine("Errors present: " + String.Join(", ", warnings));
                        Assert.True(warnings.SequenceEqual(queryAndErrors.Errors.OrderBy(e => e).ToList()));
                        output.WriteLine("");
                    }
                }
            }
        }
    }
}
