using System;
using System.Collections.Generic;
using System.IO;

namespace ImageResizer3000
{
	internal class Helpers
	{
		public static void CreateDir(string dir)
		{
			if(DoesDirExist(dir) == false)
				Directory.CreateDirectory(dir);
		}

		public static bool DoesDirExist(string dir)
		{
			if (Directory.Exists(dir))
				return true;

			return false;
		}

		public static bool IsListEmpty(List<FileInfo> files)
		{
			return (files == null || files.Count == 0);
		}

		public static void PrintErrorMessage(string errorMessage)
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(errorMessage);
			Console.ResetColor();
		}
	}
}