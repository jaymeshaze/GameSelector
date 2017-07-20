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
            string url = "http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=3B07BB25C9ED221917308FF0BB7139CD&steamid=76561198025052160&include_appinfo=1&format=json"; //insert steam api URL here
            var request = WebRequest.Create(url);
            string text;
            var response = (HttpWebResponse)request.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }


            JavaScriptSerializer js = new JavaScriptSerializer();
            Rootobject root = new Rootobject();
            root.response = js.Deserialize<Response>(text);

            Console.WriteLine(root.response.game_count);

        }
    }



    public class Rootobject
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public int game_count { get; set; }
        public Game[] games { get; set; }
    }

    public class Game
    {
        public int appid { get; set; }
        public string name { get; set; }
        public int playtime_forever { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
        public bool has_community_visible_stats { get; set; }
        public int playtime_2weeks { get; set; }
    }




}
