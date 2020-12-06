using System;

namespace IV.TraceHelper
{
	[Flags]
	public enum TraceDestinations
	{
		Debug = 0b_0001,
		Trace = 0b_0010,
		ConsoleOut = 0b_0100,
		ConsoleError = 0b_1000
	}
}