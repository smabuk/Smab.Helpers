namespace Smab.Helpers;

/// <summary>
/// Provides utility methods for working with the console, including asynchronous key reading and formatted message
/// writing.
/// </summary>
/// <remarks>This class contains static methods for interacting with the console in advanced ways, such as reading
/// key presses asynchronously with optional timeouts and writing messages to specific console positions with formatting
/// options. Note that this class has been marked as obsolete and its functionality has been moved to the <see
/// cref="ConsoleX"/> class.</remarks>
[Obsolete("Moved to the ConsoleX class.")]
public class ConsoleHelpers {

	/// <summary>
	/// Provides functionality for reading a key press from the console asynchronously, with optional timeout support.
	/// </summary>
	/// <remarks>This class allows for non-blocking key reading by utilizing a background thread to monitor console
	/// input. The <see cref="ReadKey(int)"/> method can be used to retrieve a key press, with an optional timeout to
	/// prevent indefinite waiting.</remarks>
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

		/// <summary>
		/// Reads a key from the console input within the specified timeout period.
		/// </summary>
		/// <remarks>If no key is pressed within the specified timeout, the method returns <see
		/// cref="ConsoleKey.Zoom"/>.  This behavior can be used to detect timeout scenarios.</remarks>
		/// <param name="timeOutMillisecs">The maximum time, in milliseconds, to wait for a key press. Use <see cref="System.Threading.Timeout.Infinite"/> 
		/// to wait indefinitely.</param>
		/// <returns>The <see cref="ConsoleKey"/> that was pressed if a key is received within the timeout period;  otherwise, <see
		/// cref="ConsoleKey.Zoom"/>.</returns>
		public static ConsoleKey ReadKey(int timeOutMillisecs = Timeout.Infinite) {
			getKey.Set();
			bool success = gotKey.WaitOne(timeOutMillisecs);
			return success ? key : ConsoleKey.Zoom;
		}
	}

	/// <summary>
	/// Writes a message to the console at the specified column and row, with optional formatting and clearing behavior.
	/// </summary>
	/// <remarks>After writing the message, the cursor position is restored to the specified or current column and
	/// row. If a custom color is specified, the console's foreground color is reset to its original value after the
	/// message is written.</remarks>
	/// <param name="message">The message to write to the console.</param>
	/// <param name="col">The zero-based column position where the message should start. If <see langword="null"/>, the current cursor column
	/// is used.</param>
	/// <param name="row">The zero-based row position where the message should start. If <see langword="null"/>, the current cursor row is
	/// used.</param>
	/// <param name="clearToEndOfRow">A value indicating whether to clear the remainder of the row before writing the message. The default is <see
	/// langword="true"/>.</param>
	/// <param name="colour">The foreground color to use for the message. If <see langword="null"/>, the current console color is used.</param>
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
