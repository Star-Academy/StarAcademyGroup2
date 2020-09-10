using System;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;

namespace SourceReaderLib
{
    public class CsvToJson
    {
        public static string Convert(string[] csvLines)
        {
            var memberNames = csvLines[0].Split(',');
            var myObj = csvLines.Skip(1)
                                .Select((x) => x
                                    .Split(new string[] { ",\"" }, StringSplitOptions.None)
                                    .Select((y, i) => new
                                    {
                                        Key = memberNames[i].Trim('"'),
                                        Value = y.Trim('"')
                                    })
                                    .ToDictionary(d => d.Key, d => d.Value));
            return JsonConvert.SerializeObject(myObj, Formatting.Indented);
        }
    }
}
