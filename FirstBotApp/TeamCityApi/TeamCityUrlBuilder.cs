namespace TeamCityApi
{
    public class TeamCityUrlBuilder
    {
        private string baseApiUrl = "httpAuth/app/rest/";

        public string GetLastBuildByBuildType(string buildtType)
        {
            return string.Format("{0}builds/?locator=buildType:{1},start:0,count:1", baseApiUrl, buildtType);
        }
    }
}