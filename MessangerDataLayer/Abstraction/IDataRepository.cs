using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerDataLayer.Abstraction
{
    public interface IDataRepository
    {
        DbSet<Message> Messages { get; set; }
        DbSet<User> Users { get; set; }
    }
}
