using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaStore.Demo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediaStore.Demo.API.Controllers;

[Produces("application/json")]
[Route("api/Tracks")]
public class TracksController : Controller
{
    private readonly MediaStoreContext _context;

    public TracksController(MediaStoreContext context) => _context = context;

    // GET: api/Tracks
    [HttpGet]
    public IEnumerable<Tracks> GetTracks() => _context.Tracks;

    // GET: api/Tracks/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTracks([FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var playlistTrack = await _context.Tracks.SingleOrDefaultAsync(t => t.TrackId == id);

        if (playlistTrack == null)
        {
            return NotFound();
        }

        return Ok(playlistTrack);
    }

    // PUT: api/Tracks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTrack([FromRoute] long id, [FromBody] Tracks track)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != track.TrackId)
        {
            return BadRequest();
        }

        _context.Entry(track).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TracksExists(id))
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

    // POST: api/Tracks
    [HttpPost]
    public async Task<IActionResult> PostTrack([FromBody] Tracks tracks)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Tracks.Add(tracks);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (TracksExists(tracks.TrackId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            else
            {
                throw;
            }
        }

        return CreatedAtAction("GetTracks", new { id = tracks.TrackId }, tracks);
    }

    // DELETE: api/Tracks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrack([FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var track = await _context.Tracks.SingleOrDefaultAsync(t => t.TrackId == id);
        if (track == null)
        {
            return NotFound();
        }

        _context.Tracks.Remove(track);
        await _context.SaveChangesAsync();

        return Ok(track);
    }

    private bool TracksExists(long id) => _context.Tracks.Any(t => t.TrackId == id);
}