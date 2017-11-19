using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHuffman
{
    class Dato : IComparable
    {
        private int simbolo;
        private int frecuencia;

        public Dato(int simbolo, int frecuencia)
        {
            this.simbolo = simbolo;
            this.frecuencia = frecuencia;
        }

        public Dato()
        {
        }

        public int getFrecuencia()
        {
            return frecuencia;
        }

        internal void setFrecuencia(int v)
        {
            frecuencia = v;

        }

        public int getSimbolo()
        {
            return simbolo;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }


        override public String ToString()
        {
            return Char.ConvertFromUtf32(simbolo) + ": " + frecuencia;
        }
    }
    }
