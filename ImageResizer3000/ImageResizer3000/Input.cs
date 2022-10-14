using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace ImageResizer3000
{
	public enum Commands {thumbs, resize, clean}
	public class Input
	{
		public static string[] Commands = {"--thumbs", "-t", "--clean", "-c"};
		public string ImgPath = null;
		public string Command = null;
		public Commands CommandType { get; set; }

		public Input(string[] args)
		{

		}

		private static string IsCommandAWidthResizeCommand(string inputCommand)
		{
			string[] sub = inputCommand.Split('=');
			int width = int.Parse(sub[1]);

			if (   Regex.Replace(sub[0],@"\s+", "") == "-r-w"
			    || Regex.Replace(sub[0], @"\s+", "") == "-resize-w"
			    || Regex.Replace(sub[0], @"\s+", "") == "-r--width"
			    || Regex.Replace(sub[0], @"\s+", "") == "-resize--width"
			    && width > 100 && width < 1200)
				return inputCommand;

			Helpers.Error($"{inputCommand} is not a valid command.");
			return null;
		}

		private static Commands GetCommandType(string inputCommand)
		{
			if (inputCommand.Contains("-t"))
				return ImageResizer3000.Commands.thumbs;

			if(inputCommand.Contains("="))
				return ImageResizer3000.Commands.resize;

			if(inputCommand.Contains("-c"))
				return ImageResizer3000.Commands.clean;

			return ImageResizer3000.Commands.clean;
		}

		private string GetImgPath()
		{
			Console.Write("Enter image path: ");
			string inputPath = Console.ReadLine();

			if(Directory.Exists(inputPath))
				return inputPath;

			Helpers.Error($"{ImgPath} is not a valid path.");
			Environment.Exit(0);
			return null;
		}
	}
}