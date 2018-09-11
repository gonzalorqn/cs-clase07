using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clase07
{
    class Tempera
    {
        #region Atributos
        private sbyte _cantidad;
        private ConsoleColor _color;
        private string _marca;
        #endregion

        #region Constructores
        public Tempera(sbyte cant, ConsoleColor color, string marca)
        {
            this._cantidad = cant;
            this._color = color;
            this._marca = marca;
        }
        #endregion

        #region Metodos
        private string Mostrar()
        {
            return "Cantidad: " + this._cantidad.ToString() + " Color: " + this._color.ToString() + " Marca: " + this._marca;
        }

        public static implicit operator string(Tempera a)
        {
            return a.Mostrar();
        }

        public static explicit operator sbyte(Tempera a)
        {
            return a._cantidad;
        }
        #endregion

        #region Sobrecarga operadores
        public static bool operator ==(Tempera a, Tempera b)
        {
            bool retorno = false;
            if(!Object.Equals(a, null) || !Object.Equals(b, null))
            {
                if(a._color == b._color && a._marca == b._marca)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Tempera a, Tempera b)
        {
            return !(a == b);
        }

        public static Tempera operator +(Tempera a, sbyte num)
        {
            a._cantidad += num;
            return a;
        }

        public static Tempera operator +(Tempera a, Tempera b)
        {
            Tempera retorno = new Tempera(a._cantidad,a._color,a._marca);
            if(a == b)
            {
                retorno += b._cantidad;
            }
            return retorno;
        }
        #endregion
    }
}
