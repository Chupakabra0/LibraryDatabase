using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDBTest {
    public enum ConsoleNoContextCommands : short {
        Back, Quit, Cls, Help, Online, Tables, Sql, Go
    }

    public enum ConsoleContextCommands : short {
        Show, Add, Edit, Remove, Duplicate
    }
}
