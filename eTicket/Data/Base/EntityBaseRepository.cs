using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace eTicket.Data.Base;

public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbcontext _context;
    public EntityBaseRepository(AppDbcontext context)
    {
        _context = context;
    }
    //Get Methods-----------------------------------------------------------------------------------------------------
    public async Task<IEnumerable<T>> GetAllAsync() =>  await _context.Set<T>().ToListAsync();
    public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
    //---------------------------------------------------------------------------------------------------------------

    //Update Method--------------------------------------------------------------------------------------------------
    public async Task UpdateAsync(int id, T entity)
    {
        EntityEntry entityEntry = _context.Entry<T>(entity);
        entityEntry.State = EntityState.Modified;  
        await _context.SaveChangesAsync();
    }
    //---------------------------------------------------------------------------------------------------------------

    //Add Method--------------------------------------------------------------------------------------------------
    public async Task AddAsync(T entity) {
         await _context.Set<T>().AddAsync(entity);
         await _context.SaveChangesAsync();
    }
    //---------------------------------------------------------------------------------------------------------------

    //Delete Method--------------------------------------------------------------------------------------------------
    public async Task DeleteAsync(int id)
    {   
        var result =  await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        if (result != null)
        {
            EntityEntry entityEntry = _context.Entry<T>(result);
            entityEntry.State = EntityState.Deleted;  
            await _context.SaveChangesAsync();
        }
                
    }
    //---------------------------------------------------------------------------------------------------------------
}
