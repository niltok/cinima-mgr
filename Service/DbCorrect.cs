using cinima_mgr.Data;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Service;

public class DbCorrect : IAsyncDisposable
{
    private MgrContext _db = new ();
    private PeriodicTimer _timer = new(TimeSpan.FromMinutes(1));

    public DbCorrect()
    {
        Loop();
    }

    private async Task Loop()
    {
        while (await _timer.WaitForNextTickAsync())
        {
            (await _db.Shows.Where(s => s.Time < DateTime.Now)
                    .Include(s => s.Movie).ToListAsync())
                .Where(s => s.Time + s.Movie.Duration < DateTime.Now).ToList()
                .Select(s => s.Tickets
                    .Where(t => t.Status == 1)
                    .ToList()
                    .Select(t => t.Status = 3));
            await _db.SaveChangesAsync();
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _db.DisposeAsync();
        _timer.Dispose();
    }
}