using Newtonsoft.Json.Linq;

namespace Atletica_Back_End.Services
{
    public class RiotApi
    {
        private readonly HttpClient _httpClient;
        public RiotApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // CRIAR UM GERADOR/VERIFICADOR DE DEVKEY DA API DA RIOT - 25/02/2025
        public async Task<string> getRiotMatch(string matchId,string devKey) {
            var response = await _httpClient.GetAsync($"https://americas.api.riotgames.com/lol/match/v5/matches/{matchId}?api_key={devKey}");
            //response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            //var result = JObject.Parse(content)["metadata"];
            //var gameduration = JObject.Parse(content)["info"]["gameDuration"]; 
            //var participants = JObject.Parse(content)["info"]["participants"][1]["kills"];  
            return content;
        }
        public string[] getMatchDetails(string content)
        {
            //REFATORAR CÓDIGO DEPOIS

            List<string> matchInfo = new List<string>();

            //string[] arrayMatchInfo = new string[] {};
            int totalKills = 0, totalDamageDealtToChampions = 0,totalGoldEarned = 0;

            matchInfo.Add(JObject.Parse(content)["info"]["gameDuration"].ToString());

            for (int i = 0; i <9; i++)
            {
                totalKills += (int)JObject.Parse(content)["info"]["participants"][i]["kills"];
                totalDamageDealtToChampions += (int)JObject.Parse(content)["info"]["participants"][i]["totalDamageDealtToChampions"];
                totalGoldEarned += (int)JObject.Parse(content)["info"]["participants"][i]["goldEarned"];
                //Verificar qual fonte de gold puxar (goldEarned ou goldEarned)
            }

            matchInfo.Add(totalKills.ToString());
            matchInfo.Add(totalDamageDealtToChampions.ToString());  
            matchInfo.Add(totalGoldEarned.ToString());

            string[] matchArray = matchInfo.ToArray();
            return matchArray;
        }
        public async Task<string> getRiotAccount(string gameName,string tagLine,string devKey)
        {
            var response = await _httpClient.GetAsync($"https://americas.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}?api_key={devKey}");
            //response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> getRiotMatchByPuuid(string puuId, string devKey)//Devolve um JSON de partidas
        {
            var response = await _httpClient.GetAsync($"https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/{puuId}/ids?start=0&count=10&api_key={devKey}");
            //response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

    }
}
