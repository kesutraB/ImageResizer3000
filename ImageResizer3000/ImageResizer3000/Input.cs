using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ImageResizer3000
{
	public enum Commands {Thumbs, Resize, Clean}

	public class Input
	{
		//public const string RegexConstant = "Regex.Replace(sub[0], @\"\\s+\",\"\"";
		public static string[] Commands = {"--thumbs", "-t", "--clean", "-c"};
		public string ImgPath = null;
		public string Command = null;
		public Commands CommandType { get; set; }

		public Input(string[] args)
		{
			string nullImgPath = null;
			string nullCommand = null;

			while (nullImgPath == null || nullCommand == null)
			{
				if (args.Length == 0)
				{
					if (nullImgPath == null)
						nullImgPath = GetImgPath();

					if (nullCommand == null)
						nullCommand = GetCommand();
				}

				if (args.Length > 0)
				{
					if ()
				}
			}
		}

		private string GetImgPath()
		{
			Console.Write("Enter image path: ");
			string inputPath = Console.ReadLine();

			if (Directory.Exists(inputPath))
				return inputPath;

			Helpers.PrintErrorMessage($"{ImgPath} is not a valid path.");
			Environment.Exit(0);
			return null;
		}

		private static string GetCommand()
		{
			Console.Write("Enter command: ");
			string inputCommand = Console.ReadLine();
			return CheckCommand(inputCommand);
		}

		private static Commands GetCommandType(string inputCommand)
		{
			if (inputCommand.Contains("-t"))
				return ImageResizer3000.Commands.Thumbs;

			if (inputCommand.Contains("="))
				return ImageResizer3000.Commands.Resize;

			if (inputCommand.Contains("-c"))
				return ImageResizer3000.Commands.Clean;

			return ImageResizer3000.Commands.Clean;
		}

		private static string CheckCommand(string inputCommand)
		{
			if (Regex.Replace(inputCommand, @"\s+", "") == "-r" || Regex.Replace(inputCommand, @"\s+", "") == "--resize")
			{
				Helpers.PrintErrorMessage("Width command");
				Console.Write("Enter width command: ");
				return IsCommandAWidthResizeCommand($"{inputCommand}{Console.ReadLine()}");
			}

			if (inputCommand.Contains("="))
				return IsCommandAWidthResizeCommand(inputCommand);

			if (Commands.Contains(inputCommand))
				return inputCommand;

			Helpers.PrintErrorMessage($"{inputCommand} is not a valid command.");
			Environment.Exit(0);
			return null;
		}

		private static string IsCommandAWidthResizeCommand(string inputCommand)
		{
			var sub = inputCommand.Split('=');
			var width = int.Parse(sub[1]);

			if (Regex.Replace(sub[0], @"\s+", "") == "-r-w"
			    || Regex.Replace(sub[0], @"\s+", "") == "-resize-w"
			    || Regex.Replace(sub[0], @"\s+", "") == "-r--width"
			    || Regex.Replace(sub[0], @"\s+", "") == "-resize--width"
			    && width > 100 && width < 1200)
				return inputCommand;

			Helpers.PrintErrorMessage($"{inputCommand} is not a valid command.");
			return null;
		}
	}
}