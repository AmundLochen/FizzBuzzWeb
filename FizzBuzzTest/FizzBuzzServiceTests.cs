using FizzBuzz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace FizzBuzzTest
{
    [TestClass]
    public class FizzBuzzServiceTests
    {
        private string[] ExpectedResults { get; set; }
        private string[] ExpectedFuzzResults { get; set; }
        private string[] ExpectedJazzResults { get; set; }

        public FizzBuzzServiceTests()
        {
            try
            {
                ExpectedResults = File.ReadAllLines("FizzBuzz.txt");

                var expectedFuzzResults = new string[ExpectedResults.Length];
                var expectedJazzResults = new string[ExpectedResults.Length];

                foreach (var result in ExpectedResults)
                {
                    int i = 1;
                    int.TryParse(result, out int n);

                    if (n != null)
                    {
                        if (n % 4 == 0)
                        {
                            expectedFuzzResults[i] = "Fuzz";
                            expectedJazzResults[i] = result;
                        }
                        else if (n % 9 == 0)
                        {
                            expectedFuzzResults[i] = result;
                            expectedJazzResults[i] = "Jazz";
                        }
                        else
                        {
                            expectedFuzzResults[i] = result;
                            expectedJazzResults[i] = result;
                        }
                    }
                    if (expectedFuzzResults[i] == null)
                    {
                        expectedFuzzResults[i] = result;
                        expectedJazzResults[i] = result;
                    }
                        
                    i++;
                }
                ExpectedFuzzResults = expectedFuzzResults;
                ExpectedJazzResults = expectedJazzResults;
            }
            catch(FileNotFoundException e)
            {
                throw;
            }
            
        }

        [TestMethod]
        public void TestStandardFizzBuzz()
        {
            //Arrange
            int Length = 100;
            FizzBuzzService fizzBuzz = new FizzBuzzService(Length);

            //Act
            var results = fizzBuzz.GetFizzBuzzResult();

            //Assert
            Assert.AreEqual(ExpectedResults.ToString(), results.ToString());
        }
        
        [TestMethod]
        public void TestBackwardsFizzBuzz()
        {
            //Arrange
            int Length = 100;
            bool Backwards = true;
            string[] expected = ExpectedResults.Reverse().ToArray();
            FizzBuzzService fizzBuzz = new FizzBuzzService(Length, false, false, Backwards);

            //Act
            var results = fizzBuzz.GetFizzBuzzResult();

            //Assert
            Assert.AreEqual(expected.ToString(), results.ToString());
        }
        [TestMethod]
        public void TestFuzzFizzBuzz()
        {
            //Arrange
            int Length = 100;
            bool Fuzz = true;
            FizzBuzzService fizzBuzz = new FizzBuzzService(Length, Fuzz);

            //Act
            var results = fizzBuzz.GetFizzBuzzResult();

            //Assert
            Assert.AreEqual(ExpectedFuzzResults.ToString(), results.ToString());
        }
        [TestMethod]
        public void TestJazzFizzBuzz()
        {
            //Arrange
            int Length = 100;
            bool Jazz = true;
            FizzBuzzService fizzBuzz = new FizzBuzzService(Length, false, Jazz);

            //Act
            var results = fizzBuzz.GetFizzBuzzResult();

            //Assert
            Assert.AreEqual(ExpectedJazzResults.ToString(), results.ToString());
        }

    }
}
