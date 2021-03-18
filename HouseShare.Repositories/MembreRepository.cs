﻿using HouseShare.DAL.Repositories;
using HouseShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseShare.Repositories
{
    public class MembreRepository : BaseRepository<MembreEntity>, IConcreteRepository<MembreEntity>
    {
        public MembreRepository(string ConnectionString) : base(ConnectionString)
        {

        }

        public List<MembreEntity> Get()
        {
            throw new NotImplementedException();
        }

        public MembreEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        //inscription nouvel utilisateur
        public bool Insert(MembreEntity toInsert)
        {
            string requete = @"INSERT INTO [dbo].[Membre]
            ([Nom]
            ,[Prenom]
            ,[Email]
            ,[Pays]
            ,[Telephone]
            ,[Login]
            ,[Password])
            VALUES
            (@Nom
            ,@Prenom 
            ,@Email 
            ,@Pays
            ,@Telephone
            ,@Login
            ,@Password)";

            return base.Insert(toInsert, requete);
        }

        public bool Update(MembreEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(MembreEntity toDelete)
        {
            throw new NotImplementedException();
        }
    }
}