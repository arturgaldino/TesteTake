using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teste_Take;

namespace TesteTakeAPI.Controllers
{
    public class RepositoryInfoController : ApiController
    {
        static readonly string TAKE_GIT_URL = "https://api.github.com/users/takenet/repos?sort=created&direction=asc";

        public string GetRepositoryDescription(int i)
        {
            List<GitRepositoryInfo> allRepoInfo = GetRepositoryInfo();
            return allRepoInfo[i].description;
        }

        public string GetRepositoryName(int i)
        {
            List<GitRepositoryInfo> allRepoInfo = GetRepositoryInfo();
            return allRepoInfo[i].full_name;
        }

        private List<GitRepositoryInfo> GetRepositoryInfo()
        {

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", "Only a test!");
                string urlResponse = client.DownloadString(TAKE_GIT_URL);
                return JsonConvert.DeserializeObject<List<GitRepositoryInfo>>(urlResponse);
            }

        }
    }
}
