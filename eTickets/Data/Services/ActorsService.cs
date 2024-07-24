using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {

            _context = context;

        }
        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        async Task IActorsService.DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<Actor>> IActorsService.GetAllAsync()
        {
           var result=await _context.Actors.ToListAsync();
            return result;
        }

          async Task<Actor> IActorsService.GetByIdAsync(int id)
            {
                var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
                return result;
            }
        
         async Task<Actor> IActorsService.UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
