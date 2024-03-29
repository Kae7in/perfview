﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnostics.Tracing.StackSources;
using Xunit;

namespace LinuxTracing.Tests
{

	/// <summary>
	/// These tests are just here to determine whether or not big files fail at any point.
	/// </summary>
	public class XmlWriting
	{
		private static void Write(string source)
		{
			Constants.WaitUntilFileIsReady(source);

			var stackSource = new ParallelLinuxPerfScriptStackSource(source);
			XmlStackSourceWriter.WriteStackViewAsZippedXml(stackSource,
				Constants.GetOutputPath(Path.GetFileNameWithoutExtension(source) + ".perfView.xml.zip"));
		}

		[Fact(Skip = "TODO FIX NOW")]
		public void SpinningOnLinuxDump()
		{
			Write(Constants.GetTestingFilePath(@"C:\Users\t-lufern\Desktop\Luca\dev\helloworld.trace.zip"));
		}

		[Fact(Skip = "TODO FIX NOW")]
		public void BigDataDump()
		{
			Write(Constants.GetTestingFilePath(@"C:\Users\t-lufern\Desktop\Luca\dev\bigperf.data.dump"));
		}

		[Fact]
		public void ZipDump()
		{
			Write(Constants.GetTestingFilePath(@"symbol-tests.trace.zip"));
		}
	}
}
