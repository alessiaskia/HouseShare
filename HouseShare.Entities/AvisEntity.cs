using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseShare.Entities
{
    public class AvisEntity
    {
        private int _idAvis, _note, _idMembre, _idBien;
        private DateTime _dateAvis;
        private string message;
        private bool _approuve;

        public int IdAvis
        {
            get
            {
                return _idAvis;
            }

            set
            {
                _idAvis = value;
            }
        }

        public int Note
        {
            get
            {
                return _note;
            }

            set
            {
                _note = value;
            }
        }

        public int IdMembre
        {
            get
            {
                return _idMembre;
            }

            set
            {
                _idMembre = value;
            }
        }

        public int IdBien
        {
            get
            {
                return _idBien;
            }

            set
            {
                _idBien = value;
            }
        }

        public DateTime DateAvis
        {
            get
            {
                return _dateAvis;
            }

            set
            {
                _dateAvis = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public bool Approuve
        {
            get
            {
                return _approuve;
            }

            set
            {
                _approuve = value;
            }
        }
    }
}
