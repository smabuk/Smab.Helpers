namespace Smab.Helpers;

[Obsolete("Moved to the ConsoleX class.")]
public class ConsoleHelpers {

	public static class KeyReader {
		private static readonly Thread inputThread;
		private static readonly AutoResetEvent getKey;
		private static readonly AutoResetEvent gotKey;
		private static ConsoleKey key;

		static KeyReader() {
			getKey = new AutoResetEvent(false);
			gotKey = new AutoResetEvent(false);
			inputThread = new Thread(Reader) {
				IsBackground = true
			};
			inputThread.Start();
		}

		private static void Reader() {
			while (true) {
				getKey.WaitOne();
				key = Console.ReadKey(true).Key;
				gotKey.Set();
			}
		}

		public static ConsoleKey ReadKey(int timeOutMillisecs = Timeout.Infinite) {
			getKey.Set();
			bool success = gotKey.WaitOne(timeOutMillisecs);
			return success ? key : ConsoleKey.Zoom;
		}
	}


	public static void WriteRow(string message, int? col = null, int? row = null, bool clearToEndOfRow = true, ConsoleColor? colour = null) {
		(int currentCol, int currentRow) = Console.GetCursorPosition();
		currentCol = col ?? currentCol;
		currentRow = row ?? currentRow;

		if (clearToEndOfRow) {
			Console.SetCursorPosition(currentCol, currentRow);
			Console.Write(new string(' ', Console.WindowWidth - 1 - currentCol));
		}

		if (colour is not null) {
			Console.ForegroundColor = (ConsoleColor)colour;
		}

		Console.SetCursorPosition(currentCol, currentRow);
		Console.Write(message);

		if (colour is not null) {
			Console.ResetColor();
		}
	}


}
