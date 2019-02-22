using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;

namespace SteamAccCreator.Web
{
    public class MailHandler
    {
        private static readonly Random Random = new Random();
        private readonly RestClient _client = new RestClient();
        private readonly RestRequest _request = new RestRequest();
        public static int GetRandomNumber(int min, int max)
        {
            lock (Random) // synchronize
            {
                return Random.Next(min, max);
            }
        }
     
        
        private static readonly Uri MailboxUri = new Uri("https://newdedsecmail.now.sh");
        private static readonly Uri MailUri = new Uri("https://no.nope/");
        private static readonly Uri SteamUri = new Uri("https://store.steampowered.com/account/newaccountverification?");


        //private static readonly Regex FromRegex = new Regex(@".Steam.*");
        private static readonly Regex ConfirmMailRegex = new Regex("stoken=([^&]+).*creationid=([^\"]+)");

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }
        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }
        private string GetMD5()
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.IO.FileStream stream = new System.IO.FileStream(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            md5.ComputeHash(stream);

            stream.Close();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < md5.Hash.Length; i++)
                sb.Append(md5.Hash[i].ToString("x2"));

            return sb.ToString().ToUpperInvariant();
        }
        public void ConfirmMail(string address)
        {
            System.Threading.Thread.Sleep(5000);
            _client.BaseUrl = MailboxUri;


            _request.Method = Method.GET;
            dynamic jsonResponse;
            string b1gdata = address;
            _request.AddParameter("e", b1gdata);

        
        
            //_request.AddOrUpdateParameter("maxTimestamp", DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            var response = _client.Execute(_request);
            try
            {
                jsonResponse = JsonConvert.DeserializeObject(response.Content);
            }catch(Exception)
            {
              //  MessageBox.Show(e.ToString());
                //bloody server...
                jsonResponse = "";
               // MessageBox.Show(response.Content);

            }
            _request.Parameters.Clear();
            try
            {
                string dataxx = jsonResponse.First.ToString();
                string[] words = (Regex.Split(dataxx, "stoken="));
                string[] words9 = (Regex.Split(words[1], "&"));
                string[] words1 = (Regex.Split(dataxx, "creationid="));
                string[] words2 = Regex.Split(words1[1], " ");
                var tokenUri = "stoken=" + words9[0] + "&creationid=" + words2[0];
                ConfirmSteamAccount(new Uri(SteamUri + tokenUri));
    

            }
            catch (Exception)
            {
               // MessageBox.Show(e.ToString());
               // MessageBox.Show(response.Content);

            }
        }

        private string ReadMail(string mailId)
        {
            _client.BaseUrl = MailUri;
            _request.Method = Method.GET;
            _request.AddParameter("locale", "en");
            _request.AddParameter("id", mailId);
            var response = _client.Execute(_request);
            _request.Parameters.Clear();

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            return jsonResponse.bodyHtmlStrict;
        }

        private void ConfirmSteamAccount(Uri uri)
        {
            _client.BaseUrl = uri;
            _request.Method = Method.GET;
            _client.Execute(_request);
            _request.Parameters.Clear();
           
        }
    }
}