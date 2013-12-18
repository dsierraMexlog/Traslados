using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traslados.BLL
{
    public class API
    {
        public API() { }

        private CiudadesBLL _CiudadesBLL;
        public CiudadesBLL Ciudades
        {
            get
            {
                if (_CiudadesBLL == null)
                    _CiudadesBLL = new CiudadesBLL(this);
                return _CiudadesBLL;
            }
        }

        private EstadoBLL _EstadoBLL;
        public EstadoBLL Estado
        {
            get
            {
                if (_EstadoBLL == null)
                    _EstadoBLL = new EstadoBLL(this);
                return _EstadoBLL;
            }
        }

        private ConcesionarioBLL _ClienteBLL;
        public ConcesionarioBLL Cliente
        {
            get
            {
                if (_ClienteBLL== null)
                    _ClienteBLL = new ConcesionarioBLL(this);
                return _ClienteBLL;
            }
        }

        private TransportistaBLL _TransportistaBLL;
        public TransportistaBLL Transportista
        {
            get
            {
                if (_TransportistaBLL == null)
                    _TransportistaBLL = new TransportistaBLL(this);
                return _TransportistaBLL;
            }
        }

        private UsuarioBLL _UsuarioBLL;
        public UsuarioBLL Usuario
        {
            get
            {
                if (_UsuarioBLL == null)
                    _UsuarioBLL = new UsuarioBLL(this);
                return _UsuarioBLL;
            }
        }

        private NivelUsuarioBLL _NivelUsuarioBLL;
        public NivelUsuarioBLL NivelUsuario
        {
            get
            {
                if (_NivelUsuarioBLL == null)
                    _NivelUsuarioBLL = new NivelUsuarioBLL(this);
                return _NivelUsuarioBLL;
            }
        }

        private TipoQuejaBLL _TipoQejaBLL;
        public TipoQuejaBLL TipoQueja
        {
            get
            {
                if (_TipoQejaBLL == null)
                    _TipoQejaBLL = new TipoQuejaBLL(this);
                return _TipoQejaBLL;
            }
        }

    }
}
