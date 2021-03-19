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
        IConcreteRepository<AvisEntity> _avisRepo;

        public DataContext(string connectionString)
        {
            _paysRepo = new PaysRepository(connectionString);
            _membreRepo = new MembreRepository(connectionString);
            _bienRepo = new BienRepository(connectionString);
            _avisRepo = new AvisRepository(connectionString);
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

        //show last 5 added
        public List<BienModel> GetLastFiveBiens()
        {
            List<BienModel> lastAddedList = new List<BienModel>();
            List<BienEntity> membersBiens = ((BienRepository)_bienRepo).LastFiveAdded();

            foreach (BienEntity item in membersBiens)
            {
                BienModel recentBien = new BienModel();
                recentBien.Titre = item.Titre;
                recentBien.Photo = item.Photo;
                recentBien.DescCourte = item.DescCourte;
                recentBien.DateCreation = item.DateCreation;
                lastAddedList.Add(recentBien);
            }
            return lastAddedList;
        }

        //show best rated (rating > 6)
        public List<BienModel> GetBestRated()
        {
            List<BienEntity> listBiens = _bienRepo.Get();

            List<BienModel> bestBiens = new List<BienModel>();
            foreach (BienEntity item in listBiens)
            {
                BienModel b = new BienModel
                {
                    Titre = item.Titre,
                    Photo = item.Photo,
                };

                bestBiens.Add(b);
                List<AvisEntity> goodRatings = ((AvisRepository)_avisRepo).BestRated();
                int note = 0;
                foreach (AvisEntity element in goodRatings)
                {
                    note = element.Note;
                }
                b.Rating = note;
            }

            return bestBiens;
        }

        // add new bien
        public bool CreateBien(BienModel bm)
        {
            BienEntity bienEntity = new BienEntity()
            {
                Titre = bm.Titre,
                DescCourte = bm.DescCourte,
                DescLong = bm.DescLong,
                NombrePerson = bm.NombrePerson,
                Pays = bm.Pays,
                Ville = bm.Ville,
                Rue = bm.Rue,
                Numero = bm.Numero,
                CodePostal = bm.CodePostal,
                Photo = bm.Photo,
                AssuranceObligatoire = bm.AssuranceObligatoire,
                IsEnabled = bm.IsEnabled,
                Latitude = bm.Latitude,
                Longitude = bm.Longitude,
            };
            return _bienRepo.Insert(bienEntity);
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
