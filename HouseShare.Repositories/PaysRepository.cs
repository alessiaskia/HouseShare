using HouseShare.DAL.Repositories;
using HouseShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseShare.Repositories
{
    public class PaysRepository : BaseRepository<PaysEntity>, IConcreteRepository<PaysEntity>
    {
        public PaysRepository(string connectionString) : base(connectionString)
        {

        }

        public List<PaysEntity> Get()
        {
            string requete = "Select * from Pays";

            return base.Get(requete);
        }

        public PaysEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PaysEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(PaysEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PaysEntity toDelete)
        {
            throw new NotImplementedException();
        }
    }
}
