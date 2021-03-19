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
        private List<BienModel> _bestRatedBiens;

        public BiensViewModel()
        {
            ListeBiens = ctx.GetAllBiens();
            ListeDePays = ctx.GetAllCountries();
            LastFiveAdded = ctx.GetLastFiveBiens();
            BestRatedBiens = ctx.GetBestRated();
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

        public List<BienModel> BestRatedBiens
        {
            get
            {
                return _bestRatedBiens;
            }

            set
            {
                _bestRatedBiens = value;
            }
        }
    }
}