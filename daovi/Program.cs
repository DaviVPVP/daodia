using Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlUsuario control = new ControlUsuario();//Conectar a classe ControlUsuario
            control.Operacao();
            Console.ReadLine();//Manter o programa aberto
        }//fim do método
    }//fim da classe
}//fim do projeto
