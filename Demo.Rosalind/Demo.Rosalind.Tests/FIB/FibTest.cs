﻿using Xunit;
using Xunit.Abstractions;

namespace Demo.Rosalind.Tests.FIB
{
	public class FibTest
	{
		private readonly ITestOutputHelper _output;
		private readonly Fib _sut;

		public FibTest(ITestOutputHelper output)
		{
			_output = output;
			_sut = new Fib();
		}

		[Theory]
		[InlineData(1, 1, 5, 5)]
		[InlineData(5, 3, 5, 19)]
		public void TestFibonacciWithSequenceSpecified(int sequence1, int sequence2, int maxIterations, int expected)
		{
			int actual = _sut.GetFibonacciSequence(sequence1, sequence2, maxIterations);

			Assert.Equal(expected, actual);
		}

	}

	public class Fib
	{
		public int GetFibonacciSequence(int sequence1, int sequence2, int maxIterations)
		{
			if (maxIterations <= 2) return 1;

			int nextValue = sequence1 + sequence2;
			for (int i = 3; i < maxIterations; i++)
			{
				sequence1 = sequence2;
				sequence2 = nextValue;

				nextValue = sequence1 + sequence2;
			}

			return nextValue;
		}
	}
}
