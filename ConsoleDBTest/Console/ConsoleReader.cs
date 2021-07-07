using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleDBTest.Reader {
    public class ConsoleReader {
        public int ReadInt() {
            try {
                return Console.Read();
            }
            catch (Exception) {
                return 0;
            }
        }

        public int? ReadNullableInt() {
            try {
                return Console.Read();
            }
            catch (Exception) {
                return null;
            }
        }

        public DateTime? ReadNullableDate() => 
            ConsoleReader.ParseNullableDateTime(Console.ReadLine());
        
        public string ReadString() {
            try {
                return Console.ReadLine();
            }
            catch (Exception) {
                return null;
            }
        }

        public char ReadSymbol() {
            try {
                return Console.ReadLine()?.First() ?? char.MinValue;
            }
            catch (Exception) {
                return char.MinValue;
            }
        }

        public bool ReadBoolean() {
            try {
                return bool.Parse(Console.ReadLine() ?? "false");
            }
            catch (Exception) {
                return false;
            }
        }

        private static DateTime? ParseNullableDateTime(string dateTime) {
            try {
                var matches = Regex.Matches(dateTime, @"(\d\d).(\d\d).(\d\d\d\d)");
                return new DateTime
                    (int.Parse(matches.First().Groups[3].Value),
                     int.Parse(matches.First().Groups[2].Value),
                     int.Parse(matches.First().Groups[1].Value));
            }
            catch (Exception) {
                return null;
            }
        } 
    }
}
