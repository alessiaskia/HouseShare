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

        private List<PaysModel> _listPays;

        public InscriptionViewModel()
        {
            ListPays = ctx.GetAllCountries();
        }

        #region Props
        public List<PaysModel> ListPays
        {
            get
            {
                return _listPays;
            }

            set
            {
                _listPays = value;
            }
        }

        #endregion
    }
}