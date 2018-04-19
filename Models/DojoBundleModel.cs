using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dojo_League.Models
{
    public class DojoBundle
    {
        public Dojo Dojo { get; set; }

        public List<Dojo> Dojos { get; set; }

        public List<Ninja> Members { get; set; }

        public List<Ninja> Rogue { get; set; }
        

        public DojoBundle(DojoLeagueContext _context)
        {
            Dojo = new Dojo();
            Dojos = _context.dojos.Where(d => d.DojoId != 0).ToList();
        }

        public DojoBundle(DojoLeagueContext _context, Dojo dojo)
        {
            Dojo = dojo;
            Dojos = _context.dojos.Where(d => d.DojoId != 0).ToList();
        }

        public DojoBundle(DojoLeagueContext _context, int DojoId)
        {
            Dojo = _context.dojos.Where(d => d.DojoId == DojoId).SingleOrDefault();
            Members = _context.ninjas.Where(d => d.DojoId == DojoId).ToList();
            Rogue = _context.ninjas.Where(d => d.DojoId == 0).ToList();
        }
    }
}