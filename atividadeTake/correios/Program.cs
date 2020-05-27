using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using correios.servicos;

namespace correios
{
    class Program
    {
        static void Main(string[] args)
        {
            var trechos = new TrechosServicos();
            string encomenda = "WS BC";

            Entrega entrega = new Entrega(trechos);

            string resultado = entrega.rota(encomenda);

            System.Console.WriteLine("\nResultado FInal:\n" + resultado);

        } 
    }
}
