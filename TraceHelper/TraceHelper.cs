using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EnumsNET;
using JetBrains.Annotations;

namespace IV.TraceHelper
{
	[PublicAPI]
	public static class TraceHelper
	{
		private static readonly object ConfigureLock = new object();
		private static bool configured;

		private static IReadOnlyCollection<Action<string>> tracers;

		public static void Configure(TraceDestinations traceDestinations)
		{
			if (!traceDestinations.IsValid())
				throw new ArgumentException($"Trace destinations configuration is invalid.", nameof(traceDestinations));

			lock (ConfigureLock)
			{
				if (configured)
					return;

				configured = true;

				Trace.Listeners.Add(new TextWriterTraceListener(Console.Error, name: "ConsoleError"));
				Trace.Listeners.Add(new TextWriterTraceListener(Console.Out, name: "ConsoleOut"));

				tracers = new (TraceDestinations TraceDestination, Action<string> Tracer)[]
					{
						(TraceDestinations.Debug, TraceToDebug),
						(TraceDestinations.Trace, TraceCore),
						(TraceDestinations.ConsoleOut, TraceToConsoleStdOut),
						(TraceDestinations.ConsoleError, TraceToConsoleStdErr)
					}
					.Where(configuration => traceDestinations.HasFlag(configuration.TraceDestination))
					.Select(configuration => configuration.Tracer)
					.ToList();
			}
		}

		public static void WriteLine(string message)
		{
			foreach (var tracer in tracers)
				tracer.Invoke(message);
		}


		private static void TraceCore(string message)
		{
			Trace.WriteLine($"T | {message}");
		}

		private static void TraceToConsoleStdOut(string message)
		{
			Console.WriteLine($"CO | {message}");
		}

		private static void TraceToConsoleStdErr(string message)
		{
			Console.Error.WriteLine($"CE | {message}");
		}

		private static void TraceToDebug(string message)
		{
			Debug.WriteLine($"D | {message}");
		}
	}
}