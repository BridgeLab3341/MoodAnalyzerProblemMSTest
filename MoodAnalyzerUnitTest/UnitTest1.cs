using MoodAnalyzerProblemMSTest;

namespace MoodAnalyzerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //TC-1.1 Refactor
        public void GivenSadMood_WhenAnalyze_ShouldReturnSad()
        {
            Mood mood1 = new Mood("I am in Sad Mood");
            string result=mood1.AnalyzeMood();
            Assert.AreEqual("SAD",  result);
        }
        [TestMethod]
        //TC-1.2 Refactor
        public void GivenAnyMood_WhenAnalyze_ShouldReturnHappy()
        {
            Mood mood2 = new Mood("I am in Happy Mood");
            string result= mood2.AnalyzeMood();
            Assert.AreEqual("HAPPY", result);
        }
        [TestMethod]
        //TC-2.1 Handle Exception
        public void GivenNullMood_WhenAnalyze_ShouldReturnHappy()
        {
            Mood mood3 = new Mood("I am in Null Mood");
            string result= mood3.AnalyzeMood();
            Assert.AreEqual("HAPPY", result);
        }
    }
}