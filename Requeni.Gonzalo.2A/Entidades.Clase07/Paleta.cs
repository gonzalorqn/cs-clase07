using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clase07
{
    public class Paleta
    {
        #region Atributos
        private Tempera[] _colores;
        private int _cantMaximaElementos;
        #endregion

        #region Constructores
        private Paleta() :this(5)
        {

        }

        private Paleta(int a)
        {
            this._cantMaximaElementos = a;
            this._colores = new Tempera[this._cantMaximaElementos];
        }

        public static implicit operator Paleta(int num)
        {
            return new Paleta(num);
        }
        #endregion

        #region Metodos
        private string Mostrar()
        {
            string retorno;
            retorno = "Cantidad maxima de elementos: " + this._cantMaximaElementos.ToString();
            foreach(Tempera item in this._colores)
            {
                retorno += "\n" + item;
            }
            return retorno;
        }

        public static explicit operator string(Paleta a)
        {
            return a.Mostrar();
        }

        private int ObtenerIndice()
        {
            int retorno = -1;
            int indice = 0;
            foreach(Tempera item in this._colores)
            {                
                if(Object.Equals(item, null))
                {
                    retorno = indice;
                    break;
                }
                indice++;
            }
            return retorno;
        }

        private int ObtenerIndice(Tempera a)
        {
            int indice = 0;
            foreach (Tempera item in this._colores)
            {
                if(!Object.Equals(item, null) && item == a)
                {
                    break;
                }
                indice++;
            }
            return indice;
        }
        #endregion

        #region Sobrecaga operadores
        public static bool operator ==(Paleta a, Tempera b)
        {
            bool retorno = false;
            if (!Object.Equals(a, null) || !Object.Equals(b, null))
            {
                foreach(Tempera item in a._colores)
                {
                    if(!Object.Equals(item, null) && item == b)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(Paleta a, Tempera b)
        {
            return !(a == b);
        }

        public static Paleta operator +(Paleta a,Tempera b)
        {
            int indice;
            if(a == b)
            {
                indice = a.ObtenerIndice(b);
                a._colores[indice] += b;
            }
            else
            {
                indice = a.ObtenerIndice();
                if(indice != -1)
                {
                    a._colores[indice] = b;
                }
            }
            return a;
        }

        public static Paleta operator -(Paleta a, Tempera b)
        {
            int indice;
            sbyte cantPaleta;
            sbyte cantTempera;
            if (a == b)
            {
                indice = a.ObtenerIndice(b);
                cantPaleta = (sbyte)a._colores[indice];
                cantTempera = (sbyte)b;
                if(cantPaleta > cantTempera)
                {
                    cantPaleta -= cantTempera;
                    a._colores[indice] += (sbyte) (cantPaleta * (-1));
                }
                else
                {
                    a._colores[indice] = null;
                }
            }
            return a;
        }
        #endregion
    }
}
