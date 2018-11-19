using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MeshNetworkServer;
using System.Threading.Tasks;

namespace MeshNetworkServerGUI
{
    class ApplicationDbContext: DbContext
    {
        public DbSet<PackageModel> Packages { get; set; }

        public async Task<List<List<PackageModel>>> GetPackagesAsync()
        {
            var query =
                from pack in Packages
                group pack by pack.NodeId
                into packsQueryData
                let packs = (from data in packsQueryData
                             orderby data.Time
                             select data).ToList()
                select packs;

            return await query.ToListAsync();
        }
    }
}
