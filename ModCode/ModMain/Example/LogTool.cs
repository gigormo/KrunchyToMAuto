using System;

namespace KrunchyToMAuto
{
	// Token: 0x02000005 RID: 5
	internal static class LogTool
	{
		// Token: 0x06000010 RID: 16 RVA: 0x0000262C File Offset: 0x0000082C
		public static void SetDebug(bool debug)
		{
			LogTool.isDebug = debug;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002634 File Offset: 0x00000834
		public static bool IsDebug()
		{
			return LogTool.isDebug;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000263B File Offset: 0x0000083B
		public static void Info(string msg)
		{
			LogTool.LogTitle();
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.White;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002655 File Offset: 0x00000855
		public static void Msg(string msg)
		{
			if (LogTool.isDebug)
			{
				LogTool.LogTitle();
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(msg);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002670 File Offset: 0x00000870
		public static void Warning(string msg)
		{
			if (!LogTool.isDebug)
			{
				return;
			}
			LogTool.LogTitle();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.White;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002693 File Offset: 0x00000893
		public static void Error(string msg)
		{
			LogTool.LogTitle();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.White;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000026B0 File Offset: 0x000008B0
		public static void LogTitle()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("[");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(DateTime.Now.ToString("hh:mm:ss.fff"));
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("] ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write(LogTool.Title);
		}

		// Token: 0x04000001 RID: 1
		private static bool isDebug = true;

		// Token: 0x04000002 RID: 2
		private static readonly string Title = "[自动战斗] ";
	}
}
