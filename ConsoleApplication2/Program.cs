using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;



namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "";
            var request = WebRequest.Create(url);
            string text;
            Response steamGames;
            var response = (HttpWebResponse)request.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                steamGames = js.Deserialize<Response>(sr.ReadToEnd());

            }
            Game[] krisGames = steamGames.games.ToArray();
            Console.WriteLine(krisGames[1]);
        }
    }

    public class Game
    {
        public int appid { get; set; }
        public string name { get; set; }
        public int playtime_forever { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
        public bool has_community_visible_stats { get; set; }
    }

    public class Response
    {
        public int game_count { get; set; }
        public List<Game> games { get; set; }
    }

    public class RootObject
    {
        public Response response { get; set; }
    }
}
