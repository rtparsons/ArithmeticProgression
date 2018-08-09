using System;
using System.Linq;
using Xunit;

namespace ArithmeticProgression.Tests
{
    public class ArithmeticProgressionTests
    {
        [Fact]
        public void AValidListIncrementingBy0_ReturnsAnEmptyArray()
        {
            var result = GetResultFromFindTheMissing(new int[] { 1, 1, 1});
            CheckArraysAreEqual(new int[] { }, result);
        }

        [Fact]
        public void AValidListIncrementingBy2_ReturnsAnEmptyArray()
        {
            var result = GetResultFromFindTheMissing(new int[] { 2, 4, 6 });
            CheckArraysAreEqual(new int[] { }, result);
        }

        [Fact]
        public void AListIncreamentingByOneMissingAValue_ReturnsThatValue()
        {
            var result = GetResultFromFindTheMissing(new int[] { 1, 2, 4 });
            CheckArraysAreEqual(new int[] {3}, result);
        }

        [Fact]
        public void AListIncreamentingByTwoMissingAValue_ReturnsThatValue()
        {
            var result = GetResultFromFindTheMissing(new int[] { 4, 8, 10 });
            CheckArraysAreEqual(new int[] { 6 }, result);
        }

        [Fact]
        public void ProvidedExampleCase_ReturnsExpectedValues()
        {
            //find_the_missing([1, 3, 5, 9, 11, 13,17]) == [7, 15]
            var result = GetResultFromFindTheMissing(new int[] { 1, 3, 5, 9, 11, 13, 17 });
            CheckArraysAreEqual(new int[] { 7, 15 }, result);
        }

        [Fact]
        public void ANegativeListDecreasingMissingValues_ReturnsCorrectValues()
        {
            var result = GetResultFromFindTheMissing(new int[] { -3, -9, -12, -18 });
            CheckArraysAreEqual(new int[] { -6, -15 }, result);
        }

        [Fact]
        public void AListWithNotEnoughValues_ThrowsProgressionTooSmallException()
        {
            ArithmeticProgression prog = new ArithmeticProgression();
            Assert.Throws<ArithmeticProgressionTooSmallException>(() => prog.FindTheMissing(new int[] { 1, 2 }));
        }

        private int[] GetResultFromFindTheMissing(int[] input)
        {
            ArithmeticProgression prog = new ArithmeticProgression();
            return prog.FindTheMissing(input);
        }

        private void CheckArraysAreEqual(int[] expected, int[] actual)
        {
            Assert.True(expected.SequenceEqual(actual));
        }
    }
}
