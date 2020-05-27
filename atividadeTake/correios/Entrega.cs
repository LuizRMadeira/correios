using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using correios.servicos;

namespace correios
{

    public class Grafo
    {
        public int[,] M;
    }

    public class Entrega 
    {
        public string resultadoFinal = ""; 
        public TrechosServicos _trechosServicos;

        public Entrega(TrechosServicos trechosServicos)
        {
            _trechosServicos = trechosServicos;
        }
       
        void comparaMelhorCaminho( Grafo grafo, List<int> caminho, ref int melhorCusto, ref List<int> melhorCaminho)
        {
            int custo = 0;
            for (int i = 0; i < caminho.Count - 1; i++ )
            {
                custo += grafo.M[caminho[i],caminho[i+1]];
            }

            if (custo < melhorCusto) 
            {
                melhorCusto = custo;
                melhorCaminho.Clear();
                for (int i =0;i<caminho.Count;i++)
                    melhorCaminho.Add(caminho[i]);
            }
        }

        public string rota(string encomenda)
        {
            int melhorCusto = int.MaxValue;  
            List<int> melhorCaminho = new List<int>();
            List<string> legendaCidades = new List<string>();
            Grafo grafo;

            carregaTrechos(out string[,] trechos);
            criaLegenda(trechos, ref legendaCidades);
            montaGrafo(out grafo, trechos, legendaCidades);
            imprimeGrafo(grafo, legendaCidades);

            escolheCaminhos(grafo, ref melhorCusto, ref melhorCaminho, encomenda, legendaCidades);
            formataResultadoFinal(melhorCusto, melhorCaminho, legendaCidades, out resultadoFinal);

            return resultadoFinal;

        }

        void permuta(Grafo grafo, ref int melhorCusto, ref List<int> melhorCaminho, int cidadeDestino, int cidadeAtual, ref List<int> caminho, int numCidades)
        {
            if (!caminho.Contains(cidadeAtual))
                caminho.Add(cidadeAtual); 

            for (int cidade = 0; cidade < numCidades; cidade++) 
            {
                if  (grafo.M[cidadeAtual,cidade] == 0 || caminho.Contains(cidade))
                    continue;
                
                caminho.Add(cidade);
                if (cidade == cidadeDestino)
                {
                   comparaMelhorCaminho(grafo, caminho, ref melhorCusto, ref melhorCaminho);
                }
                else 
                {
                    permuta(grafo, ref melhorCusto, ref melhorCaminho, cidadeDestino, cidade, ref caminho, numCidades);
                }
                caminho.RemoveAt(caminho.Count - 1);
            }
           
        }

        public void montaGrafo(out Grafo grafo, string[,]  trechos, List<string> legendaCidades)
        {
            int numCidades = legendaCidades.Count;
            
            grafo = new Grafo();
            grafo.M = new int[numCidades, numCidades];

            int qntLinhas = trechos.GetLength(0);

            for (int i = 0; i < qntLinhas; i++)
            {
                int cidade01 = legendaCidades.IndexOf(trechos[i,0]);
                int cidade02 = legendaCidades.IndexOf(trechos[i,1]);
                int custo = Convert.ToInt32(trechos[i,2]);

                grafo.M[cidade01, cidade02] = custo;
            }
        } 

        public void escolheCaminhos(Grafo grafo, ref int melhorCusto, ref List<int> melhorCaminho, string encomenda, List<string> legendaCidades)
        {
            melhorCusto = int.MaxValue;
            var enc = encomenda.Split(" ");

            int cididadeAtual = legendaCidades.IndexOf(enc[0]);
            int cidadeDestino = legendaCidades.IndexOf(enc[1]);
            int numCidades = legendaCidades.Count;
            
            List<int> caminho = new List<int>();

            permuta(grafo, ref melhorCusto, ref melhorCaminho, cidadeDestino, cididadeAtual, ref caminho, numCidades);
        }

        public void formataResultadoFinal(int custo,  List<int> caminho, List<string> legendaCidades, out string resultado)
        {
            string trajeto = "";
            for (int i=0;i<caminho.Count;i++)
                trajeto += " " + legendaCidades[caminho[i]];

            resultado = trajeto.Trim() + " " + custo;
        } 

    
        public void imprimeGrafo(Grafo grafo, List<string> legendaCidades)
        {
            /* Exibicao do grafo no console para facilitar entendimento */
            int numCidades = legendaCidades.Count;

            Console.Write("\nGrafo de Cidades e custos:\n   ");
            for (int i = 0; i < numCidades; i++)
                Console.Write(legendaCidades[i] + " ");
            Console.WriteLine();
            for (int i = 0; i < numCidades; i++)
            {
                Console.Write(legendaCidades[i] );
                for (int j = 0; j < numCidades; j++) 
                {
                    Console.Write("  " + grafo.M[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void criaLegenda(string[,] trechos, ref List<string> adicionados)
        {
            int qntLinhas = trechos.GetLength(0);

            for (int i = 0; i < qntLinhas; i++)
            {
                if (!adicionados.Contains(trechos[i,0]))
                {
                    adicionados.Add(trechos[i,0]);
                }
                if (!adicionados.Contains(trechos[i,1]))
                {
                    adicionados.Add(trechos[i,1]);
                }
            }
        }

        public void carregaTrechos(out string[,] trechos)
        {
             trechos = _trechosServicos.consultarTrechos();
        }
    }
}