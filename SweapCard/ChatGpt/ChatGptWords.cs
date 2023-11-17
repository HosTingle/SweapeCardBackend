using static System.Net.WebRequestMethods;
using System.Text.RegularExpressions;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Net.Http;
using SweapCard.Dtos.WordDtos;

namespace SweapCard.ChatGpt
{
    public class ChatGptWords
    {
        private HttpClient Http;
        public ChatGptWords(HttpClient _httpClient)
        {
            Http = _httpClient;
        }
        int patlama;
        int bitti = 0;
        int say = 0;
        int tay = 0;
        string pa;
        string pap;
        int or = 0;
        int hd = 0;
        string english;
        string turkish;
        string sentencethen = "";
        string sentence = "";
        string response = "";
        string sa = "";
        string ka = "";
        string kapa = "";
        string kapaz = "";
        Dictionary<string, string>? values;
        Dictionary<string, string>? sen;
        int hold = 0;
        bool kontrol = true;
        string desen = @"[\w'123456789]+";
        List<string> kelimeler = new List<string>();
        List<string> kelimelert = new List<string>();
        List<string> kelimeturing = new List<string>();
        List<string> cumleler = new List<string>();
        List<WordWithWordCounterDtos> creatWordDtos = new List<WordWithWordCounterDtos>();
        List<string> level = new List<string>()
        {
    "A1",
    "A2",
    "B1",
    "B2",
    "C1",
    "C2"
       };
        List<string> about = new List<string>
{
    "about astrophysics",
    "about school",
    "about science",
    "about computer",
    "about vocation",
    "about game term "
};
        public async Task<List<WordWithWordCounterDtos>> GenerateInstagramPost()
        {
            patlama = 0;
            say++;
            if (say % 3 == 0)
            {
                Thread.Sleep(30000);
            }
            bitti = 0;
            or = 0;
            kelimeler.Clear();
            cumleler.Clear();
            kontrol = true;
            var apiKey = "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";

            if (hold == 0)
                Http.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            hold++;
            string safsa = "Give me random 10 " + pa + " level english words " + pap + @" and translate them turkish, in json format. Sample format={""English Word"":""Turkish Word"",""English Word"":""Turkish Word""}";
            var jsonContent = new
            {
                prompt = safsa,
                model = "gpt-3.5-turbo-instruct",
                max_tokens = 4000,
            };
            var responseContent = await Http.PostAsync("https://api.openai.com/v1/completions", new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json"));
            var resContext = await responseContent.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(resContext);
            response = data.choices[0].text;
            string result = Regex.Replace(response, @"\.", "");
            System.Diagnostics.Debug.WriteLine(result);
            try
            {

                values = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            }
            catch
            {
                GenerateInstagramPost();
                patlama++;

            }
            if (patlama == 0)
            {
                foreach (string sa in values.Keys)
                {
                    
                    string kapa = Regex.Replace(sa, @"[\d\p{P}]", "");
                    kelimeler.Add(kapa);
                    
                }
                foreach (string sas in values.Values)
                {

                    string kapan = Regex.Replace(sas, @"[\d\p{P}]", "");
                    kelimelert.Add(kapan);

                }
                ka = "For every word I give you, just give me one short sentence,move to new line in each sentence." + string.Join(",", kelimeler);
                jsonContent = new
                {
                    prompt = ka,
                    model = "gpt-3.5-turbo-instruct",
                    max_tokens = 4000,
                };
                say++;
                if (say % 3 == 0)
                {
                    Thread.Sleep(30000);
                }
                responseContent = await Http.PostAsync("https://api.openai.com/v1/completions", new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json"));
                resContext = await responseContent.Content.ReadAsStringAsync();
                var mata = JsonConvert.DeserializeObject<dynamic>(resContext);
                sentencethen = mata.choices[0].text;
                string temizMetin = Regex.Replace(sentencethen, @"[\d\p{P}]", "");
                List<string> sentences = new List<string>(temizMetin.Split('\n'));
                if (sentences.Count() < 9)
                {
                    List<string> sentencest = new List<string>(temizMetin.Split('.'));
                    sentences = sentencest;
                }

                // Şimdi "sentences" adlı List<string> koleksiyonunda tüm cümlelere erişebilirsiniz.
                foreach (string sentence in sentences)
                {
                    if (sentence != "")
                        cumleler.Add(sentence);
                }
                if (cumleler.Count != 10)
                {
                    while (cumleler.Count <= 10)
                    {
                        cumleler.Add("");
                    }
                }

                sentence = sentencethen;

                // var eslesmeler = Regex.Matches(response, desen);
                // // Bulunan kelimeleri listeye ekleyin
                // foreach (Match eslesme in eslesmeler)
                // {
                //     kelimeler.Add(eslesme.Value);
                // }
            }
            for(int i = 0; i < 10; i++)
            {
                creatWordDtos.Add(new WordWithWordCounterDtos
                {
                    FirstWord = kelimeler[i],
                    SecondWord = kelimelert[i],
                    Sentence= cumleler[i]
                });
            }
            return creatWordDtos;

        }
        public async Task Searchword()
        {
            bitti++;
            if (bitti >= 21)
            {
                response = "Kelimeler bitti, yeni kelimeler talep edebilirsiniz";
                sentence = "";
            }
            else
            {
                if (kontrol)
                {

                    response = values.Keys.ElementAt(or);
                    response = Regex.Replace(response, @"[\d\p{P}]", "");
                    kontrol = false;

                    sentence = cumleler[or];
                }
                else
                {
                    kontrol = true;
                    response = values.Values.ElementAt(or);
                    response = Regex.Replace(response, @"[\d\p{P}]", "");
                    or++;
                }
            }

        }
    }
}
