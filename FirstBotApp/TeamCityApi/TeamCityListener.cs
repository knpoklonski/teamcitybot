using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamCityApi
{
    public class TeamCityListener
    {
        private const string AlphaDeploymentBuildId = "AspireAdministration_TrunkAlphaDeploymentBuild";
        private const string Login = "konstantin.poklonskiy@arcadia.spb.ru";
        private const string Password = "";
        private const string BaseUrl = "http://acbc01.arcadia.intranet";
        private TeamCityUrlBuilder _teamCityUrlBuilder = new TeamCityUrlBuilder();
        public async Task<BuildStateResult> GetState(Projects project)
        {
            using (var httpClient = CreateHttpClient(Login, Password))
            {
                var result = await httpClient.GetAsync(_teamCityUrlBuilder.GetLastBuildByBuildType(AlphaDeploymentBuildId));
                var buildResponse = JsonConvert.DeserializeObject<BuildsResponse>(result.Content.ReadAsStringAsync().Result);
                var build = Enumerable.FirstOrDefault(buildResponse.Builds);

                var detailsBuildInfoResult = await httpClient.GetAsync(build.Href);
                var buildDetails = JsonConvert.DeserializeObject<Build>(detailsBuildInfoResult.Content.ReadAsStringAsync().Result);

                //parse model
                var buildStatus = (BuildStatus) Enum.Parse(typeof (BuildStatus), buildDetails.Status, true);
                var buildState = (BuildState) Enum.Parse(typeof (BuildState), buildDetails.State, true);

                DateTime startDate;
                TeamCityDateExtensions.TryParseDate(buildDetails.StartDate, out startDate);

                DateTime finishDate;
                TeamCityDateExtensions.TryParseDate(buildDetails.FinishDate, out finishDate);

                return new BuildStateResult(buildStatus, buildState, buildDetails.Triggered.User.Name, startDate, finishDate, buildDetails.StatusText);
            }
        }

        private HttpClient CreateHttpClient(string userName, string password)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", userName, password))));

            httpClient.BaseAddress = new Uri(BaseUrl);
            return httpClient;
        }
    }
}