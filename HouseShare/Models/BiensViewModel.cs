using HouseShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HouseShare.Models
{
    public class BiensViewModel
    {
        private DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        private List<BienModel> _listeBiens;
        private List<PaysModel> _listeDePays;
        private List<BienModel> _listeBiensMembre;
        private List<BienModel> _lastFiveAdded;

        public BiensViewModel()
        {
            ListeBiens = ctx.GetAllBiens();
            ListeDePays = ctx.GetAllCountries();
            LastFiveAdded = ctx.GetLastFiveBiens();
        }
        public List<BienModel> ListeBiens
        {
            get
            {
                return _listeBiens;
            }

            set
            {
                _listeBiens = value;
            }
        }

        public List<PaysModel> ListeDePays
        {
            get
            {
                return _listeDePays;
            }

            set
            {
                _listeDePays = value;
            }
        }

        public List<BienModel> ListeBiensMembre
        {
            get
            {
                return _listeBiensMembre;
            }

            set
            {
                _listeBiensMembre = value;
            }
        }

        public List<BienModel> LastFiveAdded
        {
            get
            {
                return _lastFiveAdded;
            }

            set
            {
                _lastFiveAdded = value;
            }
        }
    }
}