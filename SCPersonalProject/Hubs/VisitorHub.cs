using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SC.DataLayer; // Veritabanı modelinizi içe aktardığınızdan emin olun
using SC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SCPersonalProject.Hubs
{
    public class VisitorHub : Hub
    {
        private readonly AppDbContext _appDbContext;

        public VisitorHub(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Katil()
        {
            var today = DateTime.Today;
            var visitorCount = await _appDbContext.VisitorCounts
                .Where(x => x.DataDate == today)
                .FirstOrDefaultAsync();

            if (visitorCount == null)
            {
                visitorCount = new VisitorCount { DataDate = today, Visitor = 1 };
                _appDbContext.VisitorCounts.Add(visitorCount);
            }
            else
            {
                visitorCount.Visitor++;
            }

            await _appDbContext.SaveChangesAsync();

            // Güncel ziyaretçi sayısını istemcilere gönderin
            await Clients.All.SendAsync("ZiyaretciSayisiGuncelle", visitorCount.Visitor);
        }
    }
}
