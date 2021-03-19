using HouseShare.DAL.Repositories;
using HouseShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseShare.Repositories
{
    public class AvisRepository : BaseRepository<AvisEntity>, IConcreteRepository<AvisEntity>
    {
        public AvisRepository(string connectionString) : base(connectionString)
        {

        }

        public List<AvisEntity> Get()
        {
            string requete = "Select Note from AvisMembreBien";

            return base.Get(requete);
        }

        public AvisEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public List<AvisEntity> BestRated()
        {
            string requete = "Select * from [dbo].[Vue_MeilleursAvis]";
            return base.Get(requete);
        }

        public bool Insert(AvisEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(AvisEntity toUpdate)
        {
            throw new NotImplementedException();
        }

         public bool Delete(AvisEntity toDelete)
        {
            throw new NotImplementedException();
        }
    }
}
