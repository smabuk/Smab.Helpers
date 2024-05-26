namespace Smab.Helpers;

public static partial class ConsoleX {

	//private const int COLOURS_8BIT = 5;
	private const int COLOURS_ALL  = 2;
	private const char ESCAPE  = '\u001b';

	private static readonly string BOLD  = $"{ESCAPE}[{(int)FontEffect.Bold}m";
	private static readonly string RESET = $"{ESCAPE}[{(int)FontEffect.None}m";

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

	public static async Task KeyboardListener(CancellationToken token, IProgress<ConsoleKey> progress, int millisecondsDelay = 20) {
		while (!token.IsCancellationRequested) {
			if (Console.KeyAvailable) {
				progress.Report(Console.ReadKey(true).Key);
			} else {
				await Task.Delay(millisecondsDelay);
			}
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


	public static void CursorUp(int n)    => Console.Write($"{ESCAPE}[{n}A");
	public static void CursorDown(int n)  => Console.Write($"{ESCAPE}[{n}B");
	public static void CursorRight(int n) => Console.Write($"{ESCAPE}[{n}C");
	public static void CursorLeft(int n)  => Console.Write($"{ESCAPE}[{n}D");


	public static void CursorNextLine(int n) => Console.Write($"{ESCAPE}[{n}E");
	public static void CursorPrevLine(int n) => Console.Write($"{ESCAPE}[{n}F");
	
	
	public static void SetColumn(int column)            => Console.Write($"{ESCAPE}[{column}G");
	public static void SetPosition(int row, int column) => Console.Write($"{ESCAPE}[{row};{column}H");


	public static void ClearFromCursorToEndOfScreen() => Console.Write($"{ESCAPE}[0J");
	public static void ClearFromCursorToBeginningOfScreen() => Console.Write($"{ESCAPE}[1J");
	public static void ClearEntireScreen() => Console.Write($"{ESCAPE}[2J");


	public static void ClearFromCursorToEndOfLine() => Console.Write($"{ESCAPE}[0K");
	public static void ClearFromCursorToBeginningOLine() => Console.Write($"{ESCAPE}[1K");
	public static void ClearEntireLine() => Console.Write($"{ESCAPE}[2K");


	public static void ScrollUp(int n)   => Console.Write($"{ESCAPE}[{n}S");
	public static void ScrollDown(int n) => Console.Write($"{ESCAPE}[{n}T");


	public static void RestorePosition() => Console.Write($"{ESCAPE}[u");
	public static void SavePosition()    => Console.Write($"{ESCAPE}[s");


	public static void Reset()   => Console.Write(RESET);
	public static void SetBold() => Console.Write(BOLD);
	

	public static void SetColours(int rgbForeground, int rgbBackground) => Console.Write($"{ESCAPE}[38;{COLOURS_ALL};{(rgbForeground >> 16) & 255};{(rgbForeground >> 8) & 255};{rgbForeground & 255};48;{COLOURS_ALL};{(rgbBackground >> 16) & 255};{(rgbBackground >> 8) & 255};{rgbBackground & 255}m");
	

	public static void SetForegroundColour(int red, int green, int blue) => Console.Write($"{ESCAPE}[38;{COLOURS_ALL};{red};{green};{blue}m");
	public static void SetBackgroundColour(int red, int green, int blue) => Console.Write($"{ESCAPE}[48;{COLOURS_ALL};{red};{green};{blue}m");


	public static void SetForegroundColour(int rgbColour) => Console.Write($"{ESCAPE}[38;{COLOURS_ALL};{(rgbColour >> 16) & 255};{(rgbColour >> 8) & 255};{rgbColour & 255}m");
	public static void SetBackgroundColour(int rgbColour) => Console.Write($"{ESCAPE}[48;{COLOURS_ALL};{(rgbColour >> 16) & 255};{(rgbColour >> 8) & 255};{rgbColour & 255}m");


	public enum FontEffect {
		None      = 0,

		Bold      = 1,
		Dim       = 2,
		Italic    = 3,
		Underline = 4,
		Blink     = 5,
		Reverse   = 7,
		Hide      = 8,

		BoldOff      = 20 + Bold,
		DimOff       = 20 + Dim,
		ItalicOff    = 20 + Italic,
		UnderlineOff = 20 + Underline,
		BlinkOff     = 20 + Blink,
		ReverseOff   = 20 + Reverse,
		HideOff      = 20 + Hide,
	}
}
