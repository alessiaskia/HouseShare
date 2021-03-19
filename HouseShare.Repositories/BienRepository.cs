using HouseShare.DAL.Repositories;
using HouseShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseShare.Repositories
{
    public class BienRepository : BaseRepository<BienEntity>, IConcreteRepository<BienEntity>
    {
        public BienRepository(string connectionString) : base(connectionString)
        {

        }

        public List<BienEntity> Get()
        {
            string requete = "Select * from BienEchange";

            return base.Get(requete);
        }

        public List<BienEntity> GetBiensFromMembre(int idMembre)
        {
            string requete = $"exec [dbo].[sp_RecupBienMembre]" + idMembre;
            return base.Get(requete);
        }

        public BienEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BienEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BienEntity toDelete)
        {
            throw new NotImplementedException();
        }
    }
}
