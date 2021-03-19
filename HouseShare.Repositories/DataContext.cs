using HouseShare.DAL.Repositories;
using HouseShare.Models;
using HouseShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseShare.Repositories
{
    public class DataContext
    {
        IConcreteRepository<MembreEntity> _membreRepo;
        IConcreteRepository<PaysEntity> _paysRepo;
        IConcreteRepository<BienEntity> _bienRepo;

        public DataContext(string connectionString)
        {
            _paysRepo = new PaysRepository(connectionString);
            _membreRepo = new MembreRepository(connectionString);
            _bienRepo = new BienRepository(connectionString);
        }

        #region Biens
        public List<BienModel> GetAllBiens()
        {
            return _bienRepo.Get().Select(b => new BienModel()
            {
               IdBien = b.IdBien,
               IdMembre = b.IdMembre,
               NombrePerson = b.NombrePerson,
               Pays = b.Pays,
               Titre = b.Titre,
               DescCourte = b.DescCourte,
               DescLong = b.DescLong,
               Ville = b.Ville,
               Rue = b.Rue,
               Numero = b.Numero,
               CodePostal = b.CodePostal,
               Photo = b.Photo,
               Latitude = b.Latitude,
               Longitude = b.Longitude,
               DateCreation = b.DateCreation,
               IsEnabled = b.IsEnabled,
               DisabledDate = b.DisabledDate,
            }
            ).ToList();
        }

        //show all member's "biens"
        public List<BienModel> GetBiensOfMember(MembreModel mm)
        {
            List<BienModel> bmList = new List<BienModel>();
            List<BienEntity> membersBiens = ((BienRepository)_bienRepo).GetBiensFromMembre(mm.IdMembre);

            foreach (BienEntity item in membersBiens)
            {
                BienModel unBien = new BienModel();
                unBien.Titre = item.Titre;
                unBien.DescCourte = item.DescCourte;
                unBien.DateCreation = item.DateCreation;
                bmList.Add(unBien);
            }
            return bmList;

            //return ((BienRepository)_bienRepo).GetBiensFromMembre(idMembre)
            //    .Select(
            //    b => new BienModel()
            //    {
            //        IdBien = b.IdBien,
            //        IdMembre = b.IdMembre,
            //        NombrePerson = b.NombrePerson,
            //        Pays = b.Pays,
            //        Titre = b.Titre,
            //        DescCourte = b.DescCourte,
            //        DescLong = b.DescLong,
            //        Ville = b.Ville,
            //        Rue = b.Rue,
            //        Numero = b.Numero,
            //        CodePostal = b.CodePostal,
            //        Photo = b.Photo,
            //        Latitude = b.Latitude,
            //        Longitude = b.Longitude,
            //        DateCreation = b.DateCreation,
            //        IsEnabled = b.IsEnabled,
            //        DisabledDate = b.DisabledDate,
            //    }
            //    );
        }
        #endregion

        #region Inscription
        public bool CreateMember(MembreModel mm)
        {
            MembreEntity membreEntity = new MembreEntity()
            {
                Prenom = mm.Prenom,
                Nom = mm.Nom,
                Email = mm.Email,
                Pays = mm.Pays,
                Telephone = mm.Telephone,
                Login = mm.Login,
                Password = mm.Password,
            };
            return _membreRepo.Insert(membreEntity);
        }
        #endregion

        #region Login
        public MembreModel MemberAuth(LoginModel lm)
        {
            MembreEntity me = ((MembreRepository)_membreRepo).GetFromLogin(lm.Login);
            if (me == null)
            {
                return null;
            }
            else
            {
                return new MembreModel()
                {
                    IdMembre = me.IdMembre,
                    Prenom = me.Prenom,
                    Nom = me.Nom,
                    Email = me.Email,
                    Telephone = me.Telephone,
                    Login = me.Login
                };
            }
        }
        #endregion

        #region Pays

        public List<PaysModel> GetAllCountries()
        {
            return _paysRepo.Get().Select(p => new PaysModel()
            {
                IdPays = p.IdPays,
                Libelle = p.Libelle
            }
            ).ToList();
        }
        #endregion

        #region Member Info
        //get info to show
        public List<MembreModel> GetMembres()
        {
            return _membreRepo.Get().Select(m => new MembreModel()
            {
                IdMembre = m.IdMembre,
                Prenom = m.Prenom,
                Nom = m.Nom,
                Email = m.Email,
                Telephone = m.Telephone,
                Login = m.Login,
                Password = m.Password,
                Pays = m.Pays
            }
            ).ToList();
        }

        //update info
        public bool UpdateMemberInfo(MembreModel mm)
        {
            MembreEntity membreEntity = new MembreEntity()
            {
                Prenom = mm.Prenom,
                Nom = mm.Nom,
                Email = mm.Email,
                Pays = mm.Pays,
                Telephone = mm.Telephone,
                Login = mm.Login,
            };
            return _membreRepo.Update(membreEntity);
        }



        #endregion
    }
}
