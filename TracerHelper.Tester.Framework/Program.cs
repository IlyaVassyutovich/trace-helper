using System;

namespace IV.TraceHelper.Tester.Framework
{
	internal static class Program
	{
		public static void Main()
		{
			TraceHelper.Configure(
				TraceDestinations.Debug
				| TraceDestinations.Trace
				| TraceDestinations.ConsoleError
				| TraceDestinations.ConsoleOut);

			Console.WriteLine("From Framework with love!");

			TraceHelper.WriteLine("<<<TRACER BULLET>>>");

			Console.WriteLine("Bye!");
		}
	}
}
