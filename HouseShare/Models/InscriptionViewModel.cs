using HouseShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HouseShare.Models
{
    public class InscriptionViewModel
    {
        private DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        private List<PaysModel> _listePays;

        public InscriptionViewModel()
        {
            ListePays = ctx.GetAllCountries();
        }

        #region Props
        public List<PaysModel> ListePays
        {
            get
            {
                return _listePays;
            }

            set
            {
                _listePays = value;
            }
        }

        #endregion
    }
}