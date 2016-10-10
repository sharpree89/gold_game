using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gold.Controllers
{
 public class GoldController : Controller                             
 {
    [HttpGet]
    [Route("/")]
    public IActionResult Gold()
    {
        if(HttpContext.Session.GetInt32("gold") == null && HttpContext.Session.GetString("log") == null)
        {
            HttpContext.Session.SetInt32("gold", 0);
            HttpContext.Session.SetString("log", "");
        }

        ViewBag.gold = HttpContext.Session.GetInt32("gold");
        ViewBag.log = HttpContext.Session.GetString("log");
        
        return View("gold"); 
    }

    [HttpPost]
    [Route("/process_money")]
    public IActionResult Process_Money()
    {   
        Random rnd = new Random();
        string building = Request.Form["building"];     

        if(building == "farm")
        {
            int farmGold = (int)rnd.Next(10,21);
            HttpContext.Session.SetInt32("gold", (int)HttpContext.Session.GetInt32("gold") + farmGold);
            HttpContext.Session.SetString("log", (string)HttpContext.Session.GetString("log") + $"<p>You found " + farmGold + " gold on the farm!<p>");
        } 
        if(building == "cave") 
        {
            int caveGold = (int)rnd.Next(10,21);
            HttpContext.Session.SetInt32("gold", (int)HttpContext.Session.GetInt32("gold") + caveGold);
            HttpContext.Session.SetString("log", (string)HttpContext.Session.GetString("log") + $"<p>You found " + caveGold + " gold in the cave!<p>");
        } 
        if(building == "house")
        {
            int houseGold = (int)rnd.Next(10,21);
            HttpContext.Session.SetInt32("gold", (int)HttpContext.Session.GetInt32("gold") + houseGold);
            HttpContext.Session.SetString("log", (string)HttpContext.Session.GetString("log") + $"<p>You found " + houseGold + " gold in the house!</p>");
        } 
        if(building == "casino"){
            int casinoGold = (int)rnd.Next(-50,51);
            if(casinoGold > 0)    
            {
                HttpContext.Session.SetInt32("gold", (int)HttpContext.Session.GetInt32("gold") + casinoGold);
                HttpContext.Session.SetString("log", (string)HttpContext.Session.GetString("log") + $"<p>You won " + casinoGold + " gold at the casino!</p>");
            }
            else if(casinoGold < 0)    
            {
                HttpContext.Session.SetInt32("gold", (int)HttpContext.Session.GetInt32("gold") + casinoGold);
                HttpContext.Session.SetString("log", (string)HttpContext.Session.GetString("log") + $"<p>You lost " + casinoGold + " gold at the casino!</p>");
            }
            else if(casinoGold == 0)
            {
                HttpContext.Session.SetString("log", (string)HttpContext.Session.GetString("log") + $"<p>You broke even at the casino!<p>");
            }
        }
        return RedirectToAction("Gold");    
    }

    [HttpPost]
    [Route("/clear")]
    public IActionResult Clear()
    { 
      HttpContext.Session.Clear();
      return RedirectToAction("Gold");
    }
  }
}
