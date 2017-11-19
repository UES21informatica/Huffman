using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHuffman
{
    class Huffman
    {
        Hashtable tabla;

        public BinaryTreeNode<Dato> construirArbol(int[] frecuencias)
        {
            PriorityQueue<BinaryTreeNode<Dato>> pqueue = new PriorityQueue<BinaryTreeNode<Dato>>();

            for (int i = 0; i < frecuencias.Length; i++)
            {
                if (frecuencias[i] > 0)
                {
                    pqueue.Enqueue(new BinaryTreeNode<Dato>(new Dato(i, frecuencias[i])));
                }
            }
          
            while (pqueue.Count > 1)
            {
                BinaryTreeNode<Dato> nf1 = pqueue.Dequeue();
                BinaryTreeNode<Dato> nf2 = pqueue.Dequeue();

                Dato dato = new Dato();
                dato.setFrecuencia(nf1.Value.getFrecuencia() + nf2.Value.getFrecuencia());
                pqueue.Enqueue(new BinaryTreeNode<Dato>(dato, nf1, nf2));
            }

            return pqueue.Dequeue();

        }

       
        public Hashtable CrearTabla(BinaryTreeNode<Dato> nodo)
        {
            tabla = new Hashtable();
            CargaTabla(nodo, "");
            return tabla;
        }

        private void CargaTabla(BinaryTreeNode<Dato> nodo, string bits)
        {
            if (nodo != null)
            {
                if (nodo.LeftChild == null && nodo.RightChild == null)
                {
                    tabla.Add(nodo.Value.getSimbolo(), bits);
                }
                else
                {
                    CargaTabla(nodo.LeftChild, bits + "0");
                    CargaTabla(nodo.RightChild, bits + "1");
                }
            }
        }

        public int[] getFrecuencias(String text)
        {
            int[] frecuencias = new int[257];
            char[] a = text.ToCharArray();
            for (int i = 0; i < a.Length; i++)
                frecuencias[a[i]]++;
            return frecuencias;
        }

        public String Codificar(Hashtable tabla, String mensaje)
        {
            String mensajeCodificado = "";
            char[] a = mensaje.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                mensajeCodificado = mensajeCodificado + tabla[(int) a[i]];
            }

            return mensajeCodificado;
        }


        public String Decodificar(Hashtable tabla, String mensaje)
        {
            Hashtable tablaInvertida = new Hashtable();

            foreach (int i in tabla.Keys)
            {
                    tablaInvertida.Add(tabla[i], i);
            }

            String mensajeDecodificado = "";
            String codigo = "";
            foreach (char c in mensaje.ToCharArray())
            {
                if (!tablaInvertida.ContainsKey(codigo))
                {
                    codigo = codigo + Char.ConvertFromUtf32(c);
                }
                else
                {
                    mensajeDecodificado = mensajeDecodificado + Char.ConvertFromUtf32((int) tablaInvertida[codigo]);
                    codigo = Char.ConvertFromUtf32(c);
                }
                        
            }

            return mensajeDecodificado + Char.ConvertFromUtf32((int)tablaInvertida[codigo]);
        }
    }

}
