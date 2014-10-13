using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_dotNet
{
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; } 
    }
}
