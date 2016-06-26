using FirstBotApp.Engine;
using NUnit.Framework;

namespace TeamCityBotApp.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ShouldGetAlphaProject()
        {
            var teamCityListener = new TeamCityListener();
            var state = teamCityListener.GetState(Projects.Alpha);
            Assert.IsNotNull(state);
        }
    }
}
 