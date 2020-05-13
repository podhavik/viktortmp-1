using Firefly.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViktorDataModel;

namespace Viktor.Providers
{
    /// <summary>
    /// [Scoped]
    /// Main Srances data repository
    /// </summary>
    [RegisterScoped]
    public class SranecProvider
    {
        private readonly ApplicationDbContext db;
        private readonly TestProvider provider;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="db"></param>
        public SranecProvider(ApplicationDbContext db, TestProvider provider)
        {
            this.db = db;
            this.provider = provider;
        }

        /// <summary>
        /// Gets all Srances from DB
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Sranec>> LoadAllAsync()
        {
            return await db.Srances.ToListAsync();
        }

        public async Task<Sranec> AddSranec(string name)
        {
            var sranec = new Sranec { Name = name };

            db.Srances.Add(sranec);
            
            await db.SaveChangesAsync();

            return sranec;
        }
    }
}
