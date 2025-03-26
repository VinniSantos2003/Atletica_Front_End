// See https://aka.ms/new-console-template for more information

using Atletica_Back_End.Services;
var  devKey = "RGAPI-6b04a29e-4b1b-4e41-85cc-9b8bcd7e2e8a";
HttpClient httpClient = new HttpClient();
RiotApi riotApi = new RiotApi(httpClient);
//Console.WriteLine(riotApi.getRiotAccount("LUwUaana","br1",devKey).Result);
//Console.WriteLine(riotApi.getRiotMatch("n2WI-n0hNfj5Pz2HuQJkKIK_bPzGOr0pcqgEy3c45xOCfwolImmW-IxMpjaIEG3KRli96P4rjyNB5w", "RGAPI-4acde11c-9e53-4fd5-bfa6-3df021d181a9").Result);
//Console.WriteLine(riotApi.getRiotMatch("BR1_3070573250", devKey).Result);
var match = riotApi.getRiotMatch("BR1_3070573250", devKey).Result;
Console.WriteLine(riotApi.getMatchDetails(match)[3]);