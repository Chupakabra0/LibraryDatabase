

using System;

namespace ConsoleDBTest.Writer {
    public class ConsoleWriter {
        public void Write(string message) =>
            this.ColorWrapper(Console.Write, this.foregroundDefaultColor)(message);

        public void WriteInfo(string message) =>
            this.ColorWrapper(Console.WriteLine, this.foregroundDefaultColor)(message);

        public void WriteSuccess(string message) =>
            this.ColorWrapper(Console.WriteLine, this.successColor)(message);

        public void WriteError(string message) => 
            this.ColorWrapper(Console.WriteLine, this.errorColor)(message);

        public void WriteWarning(string message) =>
            this.ColorWrapper(Console.WriteLine, this.warningColor)(message);

        public void WriteNewLine() =>
            Console.Write('\n');

        public void WriteBlank() =>
            Console.Write(' ');

        public void Cls() =>
            Console.Clear();

        private Action<string> ColorWrapper(Action<string> function, ConsoleColor color) => 
            (str) => {
                Console.ForegroundColor = color;
                function?.Invoke(str);
                Console.ForegroundColor = this.foregroundDefaultColor;
            };

        private readonly ConsoleColor foregroundDefaultColor = Console.ForegroundColor;
        private readonly ConsoleColor backgroundDefaultColor = Console.BackgroundColor;

        private readonly ConsoleColor errorColor   = ConsoleColor.Red;
        private readonly ConsoleColor successColor = ConsoleColor.Green;
        private readonly ConsoleColor warningColor = ConsoleColor.DarkYellow;
    }
}
