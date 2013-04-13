using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Linq;

namespace cuboNumerico.Model
{
    class Buscas
    {
        public static List<No> buscaLargura(CuboNumerico estadoInicial, CuboNumerico estadoObjetivo, Boolean verificaCiclo)
        {
            No pai = new No(estadoInicial, null, 0,0);
            List<No> fila = new List<No>();
            fila.Add(pai);
            No aux = null;

            for (int i = 0; i < fila.Count(); i++)
            {
                aux = fila[i];

                if (aux.Equals(estadoObjetivo))
                {
                    break;
                }

                List<No> sucessores = aux.sucessores(verificaCiclo);

                for (int j = 0; j < sucessores.Count(); j++)
                    fila.Add(sucessores[j]);

            }

            List<No> caminhoInvertido = new List<No>();
            do
            {
                caminhoInvertido.Add(aux);
                aux = aux.Pai;
            } while (aux != null);

            List<No> caminho = new List<No>();
            for (int k = caminhoInvertido.Count() - 1; k >= 0; k--)
                caminho.Add(caminhoInvertido[k]);

            return caminho;
        }


        public static List<No> buscaAEstrela(CuboNumerico estadoInicial, CuboNumerico estadoObjetivo, Boolean verificaCiclo, int estimativaMovimentos)
        {
            No pai = new No(estadoInicial, null, CuboNumerico.pecasForaDoLugar(estadoInicial, estadoObjetivo), 0);
            No aux = null;
            List<No> fila = new List<No>();
            fila.Add(pai);

            for (int i = 0; i < fila.Count(); i++)
            {
                aux = fila[0];

                if (aux.Equals(estadoObjetivo))
                {
                    break;
                }

                List<No> sucessores = fila[0].sucessoresAEstrela(estadoObjetivo, true);
                foreach (No sucess in sucessores)
                {
                    if (sucess.Movimentos <= estimativaMovimentos)
                        fila.Add(sucess);
                }

                fila.RemoveAt(0);
                // * * * 
                // Organizando a fila - QuickSort foi abandonado, pois demorava um pouco para organizar a fila 
                // Sort do objeto List é muito mais rápido e cosome menos recursos
                //quickSort(ref fila, 0, fila.Count - 1);
                fila.Sort(delegate(No no1, No no2) { return Comparer<int>.Default.Compare(no1.Custo, no2.Custo); });
            }

            List<No> caminhoInvertido = new List<No>();
            do
            {
                caminhoInvertido.Add(aux);
                aux = aux.Pai;
            } while (aux != null);

            List<No> caminho = new List<No>();
            for (int k = caminhoInvertido.Count() - 1; k >= 0; k--)
                caminho.Add(caminhoInvertido[k]);

            return caminho;

        }

    }
}
