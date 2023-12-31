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
        [TestMethod]
        //TC3.1 (Null_Mood)throw exception
        public void GivenNullMood_WhenAnalyze_ShouldReturnMoodAnalysisException()
        {
            try
            {
                Mood mood4 = new Mood("Null Mood");
                string result= mood4.AnalyzeMood();
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "Message is Null");
            }
        }
        [TestMethod]
        //TC3.2 (Empty_Mood)throw Exception
        public void GivenEmptyMood_WhenAnalyze_ShouldReturnEmptyMood()
        {           
            try
            {
                string result = null;
                Mood mood = new Mood(" ");
                result = mood.AnalyzeMood();
            }
            catch(MoodAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "Message is Empty");
            }
        }
        [TestMethod]
        //TC4.1(ReurnMoodAnalyserObject)
        public void GivenMoodAnalyzerClassName_WhenAnalyze_SholudreturnMoodAnalyserObject()
        {
            object expected = new Mood();
            object factory = MoodAnalyzerReflector.CreateMoodAnalyser("MoodAnalyzerProblemMSTest.Mood");
            //Assert.AreEqual(expected, factory);
            expected.Equals(factory);
        }
        [TestMethod]
        //TC4.2(improperExceptionthrow)
        public void GivenMoodAnalyzerClassName_WhenImproper_SholudThrowMoodAnalysisException()
        {
            try
            {
                object expected = new Mood();
                object factory = MoodAnalyzerReflector.CreateMoodAnalyser("MoodAnalyzerProblemMSTest.Mood");
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "No Such Class");
            }
        }
        [TestMethod]
        //TC4.3(improperExceptionthrow)
        public void GivenClass_WhenContructorNotImproper_SholudThrowMoodAnalysisException()
        {
            try
            {
                string className = "MoodAnalyzerProblemMSTest.Mood";
                string constructorParameter = "InValidParameter";
                object factory = MoodAnalyzerReflector.CreateMoodAnalyzers(className,constructorParameter);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "No Such Method Error");
            }
        }
        [TestMethod]
        //5.1(Proper Return MoodAnalyzerObject)
        public void GivenMoodAnalyzer_WhenProper_ShouldReturn_MoodAnalyzerObject()
        {
            object expected = new Mood();
            object factory = MoodAnalyzerReflector.CreateMoodAnalyser("MoodAnalyzerProblemMSTest.Mood");
            Assert.AreEqual(expected.GetType(), factory.GetType());
        }
        [TestMethod]
        //5.2(ImProper Return MoodAnalyzerException)
        public void GivenClassName_WhenImProper_ShouldThrow_MoodAnalyzerException()
        {
            try
            {
                string className = "MoodAnalyzerProblemMSTest.Mood";
                object factory = MoodAnalyzerReflector.CreateMoodAnalyser(className);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "No Such Class Error");
            }
        }
        [TestMethod]
        //5.3(ImProper Return MoodAnalyzerException)
        public void GivenClass_WhenConstructorNotProper_ShouldThrow_MoodAnalyzerException()
        {
            try
            {
                string className = "MoodAnalyzerProblemMSTest.Mood";
                string constructor = "InValidParameter";
                object factory = MoodAnalyzerReflector.CreateMoodAnalyzers(className,constructor);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "No Such Method Error ");
            }
        }
        [TestMethod]
        //6.1(Happy message should return Happy Mood)
        public void GivenHappyMessage_WhenProper_ShouldReturnHappyMood()
        {
            string message = "I am Happy";
            string result=MoodAnalyzerReflector.InvokeAnalyzeMood(message);
            Assert.AreEqual("HAPPY", result);
        }
        [TestMethod]
        //6.2(Happy message should return Happy Mood)
        public void GivenHappyMessage_WhenImProperMethod_ShouldThrowMoodAnalysisException()
        {
            try
            {
                string message = "I am Happy";
                string result = MoodAnalyzerReflector.InvokeAnalyzeMood(message);

            }
            catch(MoodAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "No Such Method Error");
            }
        }
        [TestMethod]
        //TC7.1(6.1-Dynamicaly Invoked)(Set Happy Message Return HAPPY)
        public void SetHappyMessageWithReflector_WhenAnalyze_ShouldReturnHappy()
        {
            //Arrange
            string message = "I am Sad";
            Mood mood = new Mood(message);
            //Act
            MoodAnalyzerReflector.SetFieldValue(mood, "message", "Happy");
            string result = mood.AnalyzeMood();
            //Assert
            Assert.AreEqual("HAPPY", result);
        }
        [TestMethod]
        //TC7.2(6.2- Field Improper should throw No such field)
        public void SetField_WhenImproper_ShouldThrowExceptionWithNoSuchFeild()
        {
            try
            {
                string message = "I am Sad";
                Mood mood = new Mood(message);
                MoodAnalyzerReflector.SetFieldValue(mood, "", "Happy");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "No Such Field Found");
            }
        }
        [TestMethod]
        //TC7.3(6.3 Null Message Sholud throw Excption)
        public void SettingNullMessage_WithReflector_ShouldThrowException()
        {
            try
            {
                string message = "I am Sad";
                Mood mood = new Mood(message);
                MoodAnalyzerReflector.SetFieldValue(mood, "message", null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "No Such Field Found");
            }
        }
    }
}