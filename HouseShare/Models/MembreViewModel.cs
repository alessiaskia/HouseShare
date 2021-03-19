using HouseShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HouseShare.Models
{
    public class MembreViewModel
    {
        private DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        private List<MembreModel> _listeMembres;
        public MembreViewModel()
        {
            ListeMembres = ctx.GetMembres();
        }
        public List<MembreModel> ListeMembres
        {
            get
            {
                return _listeMembres;
            }

            set
            {
                _listeMembres = value;
            }
        }
    }
}