using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atletica_BD;
using Atletica_Back_End.Data;
using Atletica_Back_End.Services;


namespace Atletica_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MatchesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatchs()
        {
            return await _context.Matchs.ToListAsync();
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(Guid id)
        {
            var match = await _context.Matchs.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }
        [HttpPost("{matchId}")]
        public async Task<ActionResult<Match>> postMatch(Match matches, string matchId)
        {
            List<Match> matchInfo = new List<Match>();
            HttpClient httpClient = new HttpClient();
            RiotApi riotApi = new RiotApi(httpClient);
            // CRIAR UM GERADOR/VERIFICADOR DE DEVKEY DA API DA RIOT - 25/02/2025
            string match =  riotApi.getRiotMatch(matchId, "RGAPI-00f443dd-924c-45b8-84e7-8e9ae2f00bf7").Result;

            
            string[] matchDetails =  riotApi.getMatchDetails(match);
            /*
             0- gameDuration
             1- totalKills  
             2- totalDamageDealtToChampions
             3- totalGoldEarned
             */
             matchInfo.Add( new Match() {Id = Guid.NewGuid(),
                 duration = Double.Parse(matchDetails[0]),
                 totalKills = Int32.Parse(matchDetails[1]),
                 totalDamage = Int32.Parse(matchDetails[2]),
                 totalGold = Int32.Parse(matchDetails[3])
             }) 
            ;

            _context.Matchs.AddRange(matchInfo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("postMatch",matchInfo);
        }
        // PUT: api/Matches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(Guid id, Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        // POST: api/Matches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            _context.Matchs.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatch", new { id = match.Id }, match);
        }

        // DELETE: api/Matches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(Guid id)
        {
            var match = await _context.Matchs.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Matchs.Remove(match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchExists(Guid id)
        {
            return _context.Matchs.Any(e => e.Id == id);
        }
    }
}
