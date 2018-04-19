using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojo_League.Models;
using Microsoft.EntityFrameworkCore;

namespace Dojo_League.Controllers
{
    public class LeagueController : Controller
    {
        private DojoLeagueContext _context;

        public LeagueController(DojoLeagueContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        [Route("Ninjas")]
        public IActionResult Ninjas()
        {
            return View(new NinjaBundle(_context));
        }

        [HttpGet]
        [Route("Dojos")]
        public IActionResult Dojos()
        {
            return View(new DojoBundle(_context));
        }

        [HttpPost]
        [Route("CreateNinja")]
        public IActionResult CreateNinja(Ninja ninja)
        {
            if(!ModelState.IsValid)
            {
                return View("Ninjas", new NinjaBundle(_context, ninja));
            }else{

                _context.ninjas.Add(ninja);
                _context.SaveChanges();

                return RedirectToAction("Ninjas");
            }
        }

        [HttpPost]
        [Route("CreateDojo")]
        public IActionResult CreateDojo(Dojo dojo)
        {
            if(!ModelState.IsValid)
            {
                return View("Dojos", new DojoBundle(_context, dojo));
            }else{

                _context.dojos.Add(dojo);
                _context.SaveChanges();

                return RedirectToAction("Dojos");
            }
        }

        [HttpGet]
        [Route("Ninja/{id}")]
        public IActionResult Ninja(int id)
        {
            Ninja ninja = _context.ninjas.Where(n => n.Id == id).Include(d => d.Dojo).SingleOrDefault();
            return View(ninja);
        }

        [HttpGet]
        [Route("Dojo/{id}")]
        public IActionResult Dojo(int id)
        {
            return View(new DojoBundle(_context, id));
        }

        [HttpGet]
        [Route("Recruite/{id}/{dojoId}")]
        public IActionResult Recruite(int id, int dojoId)
        {
            Ninja ninja = _context.ninjas.Where(n => n.Id == id).SingleOrDefault();
            ninja.DojoId = dojoId;
            _context.SaveChanges();

            return RedirectToAction("Dojo", new{ id = dojoId });
        }
        
        [HttpGet]
        [Route("Banish/{id}/{dojoId}")]
        public IActionResult Banish(int id, int dojoId)
        {
            Ninja ninja = _context.ninjas.Where(n => n.Id == id).SingleOrDefault();
            ninja.DojoId = 0;
            _context.SaveChanges();
            
            return RedirectToAction("Dojo", new{ id = dojoId });
        }
    }
}
