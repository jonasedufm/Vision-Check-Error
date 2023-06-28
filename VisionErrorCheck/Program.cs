using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace VisionErrorCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Vision Check Error";
            iniFile MyIni = new iniFile("Erros.ini");
            string DetalheErro = string.Empty;
            while (true)
            {
               try
                {
                    Console.WriteLine("Digite o numero do erro: ");
                    int erro = int.Parse(Console.ReadLine());

                    if (MyIni.keyExist(erro.ToString(), "ListaErros"))
                    {
                        DetalheErro = MyIni.read(erro.ToString(), "ListaErros");
                        Console.WriteLine("Erro => " + DetalheErro + ".");
                    }
                    else
                    {
                        Console.WriteLine("Não foi encontrado o erro digitado!!!");
                    }
                }
                catch
                {
                    Console.WriteLine("Digite um número válido.");
                }
                Console.WriteLine("________________________________________________________");
            }
        }
    }
}
