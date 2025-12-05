namespace Smab.Helpers;

/// <summary>
/// Provides extended functionality for console operations, including advanced cursor control,  text formatting, and
/// keyboard input handling.
/// </summary>
/// <remarks>The <see cref="ConsoleX"/> class enhances the standard <see cref="System.Console"/> functionality  by
/// offering additional methods for manipulating the console output, such as cursor positioning,  screen clearing, and
/// color management. It also includes utilities for reading keyboard input  asynchronously and applying text effects
/// like bold or underline.  This class is particularly useful for creating rich console-based user interfaces or tools 
/// that require precise control over the console's appearance and behavior.</remarks>
public static partial class ConsoleX {

	//private const int COLOURS_8BIT = 5;
	private const int COLOURS_ALL = 2;
	private const char ESCAPE = '\u001b';

	private static readonly string BOLD = $"{ESCAPE}[{(int)FontEffect.Bold}m";
	private static readonly string RESET = $"{ESCAPE}[{(int)FontEffect.None}m";

	/// <summary>
	/// Provides functionality for reading a key press from the console asynchronously, with optional timeout support.
	/// </summary>
	/// <remarks>This class allows for non-blocking key reading by running a background thread that listens for key
	/// presses. The <see cref="ReadKey(int)"/> method can be used to retrieve a key press with a specified
	/// timeout.</remarks>
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
		/// <remarks>This method blocks until a key is pressed or the timeout period elapses. If the timeout is set to
		/// <see cref="System.Threading.Timeout.Infinite"/>, the method will wait indefinitely for a key press.</remarks>
		/// <param name="timeOutMillisecs">The maximum time, in milliseconds, to wait for a key press. Use <see cref="System.Threading.Timeout.Infinite"/> 
		/// to wait indefinitely.</param>
		/// <returns>The key pressed by the user as a <see cref="ConsoleKey"/> value. If no key is pressed within the timeout period, 
		/// returns <see cref="ConsoleKey.Zoom"/>.</returns>
		public static ConsoleKey ReadKey(int timeOutMillisecs = Timeout.Infinite) {
			getKey.Set();
			bool success = gotKey.WaitOne(timeOutMillisecs);
			return success ? key : ConsoleKey.Zoom;
		}
	}

	/// <summary>
	/// Listens for keyboard input and reports detected key presses asynchronously.
	/// </summary>
	/// <remarks>This method continuously monitors for keyboard input until the provided <paramref name="token"/> is
	/// canceled. Detected key presses are reported through the <paramref name="progress"/> parameter. If no key is
	/// available, the method waits for the specified delay before checking again.</remarks>
	/// <param name="token">A <see cref="CancellationToken"/> used to signal the cancellation of the listener.</param>
	/// <param name="progress">An <see cref="IProgress{T}"/> instance used to report detected <see cref="ConsoleKey"/> values.</param>
	/// <param name="millisecondsDelay">The delay, in milliseconds, between checks for key presses when no key is available. The default is 20
	/// milliseconds.</param>
	/// <returns></returns>
	public static async Task KeyboardListener(CancellationToken token, IProgress<ConsoleKey> progress, int millisecondsDelay = 20) {
		while (!token.IsCancellationRequested) {
			if (Console.KeyAvailable) {
				progress.Report(Console.ReadKey(true).Key);
			} else {
				await Task.Delay(millisecondsDelay);
			}
		}
	}

	/// <summary>
	/// Writes a message to the console at the specified column and row, with optional formatting and clearing behavior.
	/// </summary>
	/// <remarks>After writing the message, the cursor position is restored to the specified or current column and
	/// row. If a custom color is specified, the console's foreground color is reset to its original value after writing
	/// the message.</remarks>
	/// <param name="message">The message to write to the console.</param>
	/// <param name="col">The zero-based column position where the message should start. If <see langword="null"/>, the current cursor column
	/// is used.</param>
	/// <param name="row">The zero-based row position where the message should start. If <see langword="null"/>, the current cursor row is
	/// used.</param>
	/// <param name="clearToEndOfRow">A value indicating whether to clear the remainder of the row before writing the message. Defaults to <see
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

	/// <summary>
	/// Moves the console cursor up by the specified number of lines.
	/// </summary>
	/// <remarks>If <paramref name="n"/> is 0, the cursor remains in its current position.  This method does not
	/// perform bounds checking; ensure the cursor does not move beyond the top of the console window.</remarks>
	/// <param name="n">The number of lines to move the cursor up. Must be a non-negative integer.</param>
	public static void CursorUp(int n) => Console.Write($"{ESCAPE}[{n}A");
	public static void CursorDown(int n) => Console.Write($"{ESCAPE}[{n}B");
	public static void CursorRight(int n) => Console.Write($"{ESCAPE}[{n}C");
	public static void CursorLeft(int n) => Console.Write($"{ESCAPE}[{n}D");


	public static void CursorNextLine(int n) => Console.Write($"{ESCAPE}[{n}E");
	public static void CursorPrevLine(int n) => Console.Write($"{ESCAPE}[{n}F");


	public static void SetColumn(int column) => Console.Write($"{ESCAPE}[{column}G");
	public static void SetPosition(int row, int column) => Console.Write($"{ESCAPE}[{row};{column}H");


	public static void ClearFromCursorToEndOfScreen() => Console.Write($"{ESCAPE}[0J");
	public static void ClearFromCursorToBeginningOfScreen() => Console.Write($"{ESCAPE}[1J");
	public static void ClearEntireScreen() => Console.Write($"{ESCAPE}[2J");


	public static void ClearFromCursorToEndOfLine() => Console.Write($"{ESCAPE}[0K");
	public static void ClearFromCursorToBeginningOLine() => Console.Write($"{ESCAPE}[1K");
	public static void ClearEntireLine() => Console.Write($"{ESCAPE}[2K");


	public static void ScrollUp(int n) => Console.Write($"{ESCAPE}[{n}S");
	public static void ScrollDown(int n) => Console.Write($"{ESCAPE}[{n}T");


	public static void RestorePosition() => Console.Write($"{ESCAPE}[u");
	public static void SavePosition() => Console.Write($"{ESCAPE}[s");


	public static void Reset() => Console.Write(RESET);
	public static void SetBold() => Console.Write(BOLD);


	public static void SetColours(int rgbForeground, int rgbBackground) => Console.Write($"{ESCAPE}[38;{COLOURS_ALL};{(rgbForeground >> 16) & 255};{(rgbForeground >> 8) & 255};{rgbForeground & 255};48;{COLOURS_ALL};{(rgbBackground >> 16) & 255};{(rgbBackground >> 8) & 255};{rgbBackground & 255}m");


	public static void SetForegroundColour(int red, int green, int blue) => Console.Write($"{ESCAPE}[38;{COLOURS_ALL};{red};{green};{blue}m");
	public static void SetBackgroundColour(int red, int green, int blue) => Console.Write($"{ESCAPE}[48;{COLOURS_ALL};{red};{green};{blue}m");


	public static void SetForegroundColour(int rgbColour) => Console.Write($"{ESCAPE}[38;{COLOURS_ALL};{(rgbColour >> 16) & 255};{(rgbColour >> 8) & 255};{rgbColour & 255}m");
	public static void SetBackgroundColour(int rgbColour) => Console.Write($"{ESCAPE}[48;{COLOURS_ALL};{(rgbColour >> 16) & 255};{(rgbColour >> 8) & 255};{rgbColour & 255}m");

	/// <summary>
	/// Specifies text formatting effects that can be applied to or removed from font rendering.
	/// </summary>
	/// <remarks>The <see cref="FontEffect"/> enumeration defines a set of constants representing visual effects 
	/// such as bold, italic, underline, and others. Each effect can be applied or removed, with the  "Off" variants
	/// indicating the removal of the corresponding effect.   This enumeration is typically used in text rendering or
	/// styling contexts where font appearance  needs to be dynamically adjusted.</remarks>
	public enum FontEffect {
		None = 0,

		Bold = 1,
		Dim = 2,
		Italic = 3,
		Underline = 4,
		Blink = 5,
		Reverse = 7,
		Hide = 8,

		BoldOff = 20 + Bold,
		DimOff = 20 + Dim,
		ItalicOff = 20 + Italic,
		UnderlineOff = 20 + Underline,
		BlinkOff = 20 + Blink,
		ReverseOff = 20 + Reverse,
		HideOff = 20 + Hide,
	}
}
