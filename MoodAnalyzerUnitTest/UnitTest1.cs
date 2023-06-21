using MoodAnalyzerProblemMSTest;

namespace MoodAnalyzerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //TC-1.1
        public void GivenSadMood_WhenAnalyze_ShouldReturnSad()
        {
            string message = "I am in Sad Mood";
            Mood mood1 = new Mood();
            string result=mood1.AnalyzeMood(message);
            Assert.AreEqual("SAD", result);
        }
        [TestMethod]
        //TC-1.2
        public void GivenAnyMood_WhenAnalyze_ShouldReturnHappy()
        {
            string message = "I am in Any Mood";
            Mood mood2 = new Mood();
            string result= mood2.AnalyzeMood(message);
            Assert.AreEqual("HAPPY", result);
        }
    }
}