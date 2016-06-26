using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamCityApi;

namespace TeamCityBot.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAlphaState()
        {
            var teamCityListener = new TeamCityListener();
            var state = teamCityListener.GetState(Projects.Alpha);
            state.Wait();
            Assert.IsNotNull(state.Result);
        }
    }
}
