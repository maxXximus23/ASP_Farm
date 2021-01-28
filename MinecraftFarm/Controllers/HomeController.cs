using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinecraftFarm.DataAccessLayer.Contexts;
using MinecraftFarm.DataAccessLayer.Entities;
using MinecraftFarm.Models;

namespace MinecraftFarm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DatabaseContext _database;

        public HomeController(ILogger<HomeController> logger, DatabaseContext database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult FillDb()
        //{
        //    Resource resource1 = new Resource()
        //    {
        //        Description = "Some text",
        //        IconFileName = "",
        //        Name = "Coal"
        //    };

        //    Resource resource2 = new Resource()
        //    {
        //        Description = "Some text",
        //        IconFileName = "",
        //        Name = "Iron"
        //    };

        //    Player player1 = new Player()
        //    {
        //        Emeralds = 3,
        //        Login = "TestAlex@gmail.com",
        //        Nickname = "Suck",
        //        Password = "111"
        //    };

        //    Player player2 = new Player()
        //    {
        //        Emeralds = 1,
        //        Login = "Max@gmail.com",
        //        Nickname = "SER",
        //        Password = "322"
        //    };

        //    foreach (var player in new Player[] { player1, player2})
        //    {
        //        var playerCoal = new PlayerResource
        //        {
        //            Player = player,
        //            Quantity = new Random().Next(0,15),
        //            Resource = resource1
        //        };
        //        _database.PlayerResources.Add(playerCoal);

        //        var playerIron = new PlayerResource
        //        {
        //            Player = player,
        //            Quantity = new Random().Next(0, 15),
        //            Resource = resource2
        //        };
        //        _database.PlayerResources.Add(playerIron);
        //    }

        //    //_database.Resources.AddRange(resource1, resource2);
        //    //_database.Players.AddRange(player1, player2);
        //    _database.SaveChanges();

        //    return Ok();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
