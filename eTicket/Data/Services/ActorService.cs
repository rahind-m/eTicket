using eTicket.Data.Base;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Services;

public class ActorService : EntityBaseRepository<Actor> ,IActorsService
{
    public ActorService(AppDbcontext context) : base (context){}
}
