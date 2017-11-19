using System;
using System.Collections;

namespace ConsoleHuffman
{
    class Program
    {
        static void Main(string[] args)
        {

            string mensaje = System.IO.File.ReadAllText(@"C:\Users\Sebastian\WriteText.txt");

            Huffman huffman = new Huffman();
            int[] frecuencias = huffman.getFrecuencias(mensaje);

            for (int i = 0; i < frecuencias.Length; i++)
                //if (frecuencias[i] != 0) Console.WriteLine((i) + ": " + frecuencias[i]);
                if (frecuencias[i] != 0) Console.WriteLine(Char.ConvertFromUtf32(i) + ": " + frecuencias[i]);

            BinaryTreeNode<Dato> root = huffman.construirArbol(frecuencias);
            Hashtable tabla = huffman.CrearTabla(root);

            foreach (DictionaryEntry pair in tabla)
            {
                Console.WriteLine("{0}={1}", Char.ConvertFromUtf32((int)pair.Key), pair.Value);
                
            }


            Console.WriteLine("Codificar mensaje: "+ mensaje );
            String mensajeCodificado = huffman.Codificar(tabla, mensaje);
            Console.WriteLine("Mensaje Codificado: " + mensajeCodificado);
            String mensajeDecodificado = huffman.Decodificar(tabla, mensajeCodificado);
            Console.WriteLine("Mensaje Decodificado: " + mensajeDecodificado);

            Console.ReadKey();

        }


    }


}







