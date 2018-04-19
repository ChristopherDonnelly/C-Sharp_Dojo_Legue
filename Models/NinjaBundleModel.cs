using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dojo_League.Models
{
    public class NinjaBundle
    {
        public List<Ninja> Ninjas { get; set; }
        public Ninja Ninja { get; set; }

        public List<Dojo> Dojos { get; set; }

        public NinjaBundle(DojoLeagueContext _context)
        {
            Ninja = new Ninja();
            Ninjas = _context.ninjas.Include(d => d.Dojo).ToList();
            Dojos = _context.dojos.ToList();
        }

        public NinjaBundle(DojoLeagueContext _context, Ninja ninja)
        {
            Ninja = ninja;
            Ninjas = _context.ninjas.Include(d => d.Dojo).ToList(); 
            Dojos = _context.dojos.ToList();
        }
    }
}