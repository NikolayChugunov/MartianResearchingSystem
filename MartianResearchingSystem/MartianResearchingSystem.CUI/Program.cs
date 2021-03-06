﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianResearchingSystem.Core;
using MartianResearchingSystem.Core.Parsers;
using MartianResearchingSystem.Core.Robots;
using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.CUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Martian Researching System!");
			Console.WriteLine("Please, type your input and press TAB when complete");

			var userInput = new StringBuilder();

			do
			{
				var line = Console.ReadLine();

				if (!line.IsNullOrWhiteSpace())
				{
					userInput.AppendLine(line);
				}
			}
			while (Console.ReadKey(true).Key != ConsoleKey.Tab);

			var lines = userInput
				.ToString()
				.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

			Console.WriteLine();
			Console.Write("Creating Mars Surface...");

			var marsSurfaceDataParser = new MarsSurfaceDataParser();
			var marsSurface = marsSurfaceDataParser.ParseMarsSurface(lines.First());

			Console.WriteLine("OK");
			Console.WriteLine();

			Console.WriteLine("Deploying robots...");

			var robotDataParser = new RobotDataParser();
			var commandsParser = new CommandsParser();

			var thingsToDo = new Dictionary<SimpleMartianRobot, List<Command>>();

			for(var i = 1; i < lines.Length - 1; i += 2)
			{
				var newRobot = robotDataParser.ParseRobotData(lines[i]);
				var commandsForRobot = commandsParser.ParseCommandString(lines[i + 1]);

				thingsToDo.Add(newRobot, commandsForRobot);

				Console.WriteLine($"Robot {newRobot.Id} deployed!");
			}

			Console.WriteLine();
			Console.WriteLine("Starting Reseacrch Session...");

			var researchSession = new ResearchSession
			{
				MarsSurface = marsSurface,
				Operands = thingsToDo
			};

			researchSession.Execute();

			foreach(var robot in researchSession.Operands.Keys)
			{
				Console.WriteLine(robot);
			}

			Console.ReadLine();
		}
	}
}
