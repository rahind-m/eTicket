using eTicket.Data.Base;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Services;

public class ProducerService : EntityBaseRepository<Producer> ,IProducerService
{
    public ProducerService(AppDbcontext context) : base (context){}
}
