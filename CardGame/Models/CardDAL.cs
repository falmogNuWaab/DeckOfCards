using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace CardGame.Models
{
    public class CardDAL
    {
        public Deck GetDeck()
        {
            string url = "http://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string result = rd.ReadToEnd();
            rd.Close();

            Deck d = JsonConvert.DeserializeObject<Deck>(result);
            return d;
        }

        public Deck DrawCards(string deckID, int count)
        {
            string url = $"http://deckofcardsapi.com/api/deck/{deckID}/draw/?count={count}";
            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string result = rd.ReadToEnd();
            rd.Close();

            Deck d = JsonConvert.DeserializeObject<Deck>(result);
            return d;
        }
    }
}
