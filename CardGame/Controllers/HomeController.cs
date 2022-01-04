using CardGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.Controllers
{
    public class HomeController : Controller
    {
        CardDAL game = new CardDAL();
        
        public IActionResult Index()
        {            
            return View();
        }
        public IActionResult StartGame()
        {
            Deck deck = game.GetDeck();
            return RedirectToAction("Play", "Home", deck);
        }
        public IActionResult Play(Deck deck)
        {            
            Deck hand = game.DrawCards(deck.deck_id, 5);
            return View(hand);
        }
        public IActionResult GetNewCards(Deck deck)
        {
            Deck hand = game.DrawCards(deck.deck_id, 5);
            return RedirectToAction("Play", "Home", hand);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
