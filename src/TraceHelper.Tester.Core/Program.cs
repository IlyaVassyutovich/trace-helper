using System;

namespace IV.TraceHelper.Tester.Core
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

			Console.WriteLine("From CORE with love!");

			TraceHelper.WriteLine("<<<TRACER BULLET>>>");

			Console.WriteLine("Bye!");
		}
	}
}