using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleDBTest.Reader {
    public class ConsoleReader {
        public ConsoleReader() { }

        public int ReadInt() {
            try {
                return Console.Read();
            }
            catch (Exception) {
                return 0;
            }
        }

        public DateTime ReadDate() {
            try {
                return ParseDateTime(Console.ReadLine());
            }
            catch (Exception) {
                return DateTime.MinValue;
            }
        }

        public string ReadString() {
            try {
                return Console.ReadLine();
            }
            catch (Exception) {
                return string.Empty;
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

        private static DateTime ParseDateTime(string dateTime) {
            try {
                var matches = Regex.Matches(dateTime, @"(\d\d).(\d\d).(\d\d\d\d)");
                return new DateTime
                    (int.Parse(matches[0].Result("0")),
                     int.Parse(matches[1].Result("0")),
                     int.Parse(matches[2].Result("0")));
            }
            catch (Exception) {
                return new DateTime();
            }
        } 
    }
}
