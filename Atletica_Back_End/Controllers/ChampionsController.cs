using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atletica_BD;
using Atletica_Back_End.Data;

namespace Atletica_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ChampionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Champions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Champion>>> GetChampions()
        {
            return await _context.Champions.ToListAsync();
        }
        //POST ALL CHAMPIONS
        [HttpPost("all")]
        public async Task<ActionResult<IEnumerable<Champion>>> PostChampions(List<Champion> champions)
        {
            var campeao = "Aatrox; Ahri; Akali; Alistar; Amumu; Anivia; Annie; Aphelios; Ashe; Aurelion Sol; Azir; Bard; Blitzcrank; Brand; Braum; Caitlyn; Camille; Cassiopeia; Cho'Gath; Corki; Darius; Diana; Dr. Mundo; Draven; Ekko; Elise; Evelynn; Ezreal; Fiddlesticks; Fiora; Fizz; Galio; Gangplank; Garen; Gnar; Gragas; Graves; Gwen; Hecarim; Heimerdinger; Illaoi; Irelia; Janna; Jarvan IV; Jhin; Jinx; Kai'Sa; Kalista; Karma; Karthus; Kassadin; Katarina; Kayle; Kennen; Kha'Zix; Kindred; Kled; LeBlanc; Lee Sin; Leona; Lillia; Lucian; Lulu; Lux; Malphite; Miss Fortune; Mordekaiser; Nami; Nasus; Nautilus; Neeko; Nidalee; Nocturne; Nunu & Willump; Olaf; Orianna; Pantheon; Poppy; Pyke; Qiyana; Quinn; Rakan; Rammus; Rek'Sai; Rell; Renekton; Riven; Rumble; Ryze; Samira; Sejuani; Senna; Seraphine; Sett; Shaco; Shen; Sivir; Sona; Soraka; Swain; Sylas; Syndra; Tahm Kench; Taliyah; Talon; Taric; Teemo; Thresh; Tristana; Tryndamere; Twisted Fate; Udyr; Urgot; Varus; Vayne; Veigar; Vel'Koz; Vi; Viktor; Vladimir; Volibear; Warwick; Wukong; Xerath; Xin Zhao; Yasuo; Yone; Yuumi; Zac; Zed; Ziggs; Zilean; Zoe; Zyra";
            string[] campeoes = campeao.Split(";");

            List<Champion> listaDeBonecos = new List<Champion>();

            foreach (var c in campeoes)
            {
                var bonecos = new Champion() { Id = Guid.NewGuid(), name = c.Trim() };
                listaDeBonecos.Add(bonecos);
            }

            _context.Champions.AddRange(listaDeBonecos);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetChampions", listaDeBonecos);
        }
        
        // GET: api/Champions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Champion>> GetChampion(Guid id)
        {
            var champion = await _context.Champions.FindAsync(id);

            if (champion == null)
            {
                return NotFound();
            }

            return champion;
        }
        
        // PUT: api/Champions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChampion(Guid id, Champion champion)
        {
            if (id != champion.Id)
            {
                return BadRequest();
            }

            _context.Entry(champion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Champions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Champion>> PostChampion(Champion champion)
        {
            _context.Champions.Add(champion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChampion", new { id = champion.Id }, champion);
        }

        // DELETE: api/Champions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChampion(Guid id)
        {
            var champion = await _context.Champions.FindAsync(id);
            if (champion == null)
            {
                return NotFound();
            }

            _context.Champions.Remove(champion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChampionExists(Guid id)
        {
            return _context.Champions.Any(e => e.Id == id);
        }
    }
}
