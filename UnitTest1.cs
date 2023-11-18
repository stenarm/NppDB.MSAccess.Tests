using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.IO;
using System;
using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using System.Collections.Generic;
using System.Collections;

namespace NppDB.MSAccess.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestQueriesGetCorrectWarnings()
        {
            MSAccessExecutor executor = new MSAccessExecutor(null);
            using (var sr = new StreamReader("Resources/msaccessQueryAndError.json"))
            {
                String jsonString;
                while ((jsonString = sr.ReadToEnd()) != "")
                {
                    List<QueryAndErrors> queriesAndErrors = JsonSerializer.Deserialize<List<QueryAndErrors>>(jsonString);
                    foreach (var queryAndErrors in queriesAndErrors)
                    {
                        output.WriteLine(queryAndErrors.Query);
                        Comm.ParserResult parserResult = executor.Parse(queryAndErrors.Query, new Comm.CaretPosition { Line = 0, Column = 0, Offset = 0 });
                        List<Comm.ParserWarning> warnings = new List<Comm.ParserWarning>();
                        foreach (var command in parserResult.Commands)
                        {
                            warnings.AddRange(command.Warnings);
                        }
                        foreach (var error in queryAndErrors.Errors)
                        {
                            output.WriteLine(error);
                            Assert.Contains(warnings, warning => warning.Type.ToString().Equals(error));
                        }
                        output.WriteLine("");
                    }
                }
            }
        }
    }
}
