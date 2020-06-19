using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Test_Process
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TESTE PARA PROCESSOS");

            List<Process> lista = new List<Process>();

            var tamanho = lista.Count();

            Console.WriteLine($"Tamanho da lista atual {tamanho}");
            
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = true;

                
                    myProcess.StartInfo.FileName = "excel";
                    
                    myProcess.StartInfo.CreateNoWindow = true;
                    
                    myProcess.Start();
                    
                    Console.WriteLine("Press enter para continuar \n");

                    if (myProcess.Responding)
                    {
                       Console.WriteLine("Parece que tá funcionando Ok \n\n");  
                    }

                    Console.ReadKey();

                    var nome = myProcess.MainModule.ToString();  

                    Console.WriteLine("\n Janela rodando sobre: {0}", nome);

                    lista.Add(myProcess);

                    Console.WriteLine($"A lista está com {lista.Count()} processos");


                    Console.WriteLine("Fechando..");

                    lista.Clear();
                    
                    myProcess.Kill();

                    if (!myProcess.Responding)
                    {
                        Console.WriteLine("FECHADO COM SUCESSO! \n\n");
                    }

                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("-----------------------------------------------------------------------");

            var p = Process.GetProcesses().ToList();
            int i = 0;

            foreach (var processo in p)
            {
                
                Console.WriteLine("Processo 0{0}" + processo.ProcessName + " da lista", i++);
            }
        }
    }
}
