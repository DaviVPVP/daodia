using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cadastro
{
    class ControlUsuario
    {
        Dao conectar;
        private int opcao;
        public int codigo;
        private int OpcaoTarefas;
        private int Alteracao;
        private int codigoTarefa;

        public ControlUsuario()
        {
            //Instanciar uma variável = determinar o valor inicial dela
            ConsultarOpcao = 0;
            conectar = new Dao();//Conectando ao banco de dados
        }//fim do construtor

        public int ConsultarOpcao
        {
            get { return this.opcao; }
            set { this.opcao = value; }
        }//fim do getSet

        public void MenuInicial()
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n" +
                "1. Cadastrar\n" +
                "2. Fazer login\n" +
                "3. Sair");
            ConsultarOpcao = Convert.ToInt32(Console.ReadLine());
        }//fim do menu

        //Fazer cadastro
        public void Cadastrar()
        {
            Console.WriteLine("Informe o nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o telefone: ");
            string telefone = Console.ReadLine();
            Console.WriteLine("Informe o email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Informe a data de nascimento: ");
            string nascimento = Console.ReadLine();
            Console.WriteLine("Informe o login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Informe a senha: ");
            string senha = Console.ReadLine();
            //Inserir no banco de dados
            conectar.Inserir(nome, telefone, email, nascimento, login, senha);
        }//fim de cadastrar

        //Fazer Login
        public void FazerLogin()
        {
            Console.WriteLine("Informe o telefone da pessoa: ");
            string login = Console.ReadLine();
            Console.WriteLine("Informe a city da pessoa: ");
            string senha = Console.ReadLine();
            //Inserir no banco de dados
            conectar.InserirL(login, senha);
        }//fim de login

        public void Operacao()
        {
            do
            {
                MenuInicial();
                switch (ConsultarOpcao)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        FazerLogin();
                        break;
                    case 3:
                        Console.WriteLine("Obrigado! ");
                        break;
                    default:
                        Console.WriteLine("Informe uma opção que esteja no menu! ");
                        break;
                }//fim do escolha do caso
            } while (ConsultarOpcao != 3);
        }//fim do método

        public void MenuTarefas()
        {
            Console.WriteLine("\nEscolha uma das opções abaixo:\n\n" +
                              "1. Criar Tarefa.\n" +
                              "2. Alterar Tarefa.\n" +
                              "3. Excluir Tarefa.\n" +
                              "4. Consultar Tarefa.\n");
            OpcaoTarefas = Convert.ToInt32(Console.ReadLine());
        }


        //Criar tarefas
        public void CriarTarefas()
        {

            Console.WriteLine("Informe o código da tarefa: ");
            string codigoTarefa = Console.ReadLine();
            Console.WriteLine("Informe o nome da tarefa: ");
            string nomeTarefa = Console.ReadLine();
            Console.WriteLine("Informe a descrição da tarefa: ");
            string descricaoTarefa = Console.ReadLine();
            Console.WriteLine("Informe a data da tarefa: ");
            string dataTarefa = (Console.ReadLine());
            Console.WriteLine("Informe a hora da tarefa: ");
            string horaTarefa = (Console.ReadLine());
            conectar.InserirTarefas(codigoTarefa, nomeTarefa, descricaoTarefa, dataTarefa, horaTarefa);
        }//fim do criar tarefas

        //Atualizar tarefas
        public void AtualizarTarefas()
        {
            do
            {
                Console.WriteLine("\nQual das opções de tarefa você deseja alterar?" +
                              "\n1. Nome" +
                              "\n2. Descrição" +
                              "\n3. Data " +
                              "\n.4 Hora");
                Alteracao = Convert.ToInt32(Console.ReadLine());
                switch (Alteracao)
                {
                    case 1:
                        Console.Write("\nNovo nome: ");
                        string nomeTarefa = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("\nNova Descrição: ");
                        string descricaoTarefa = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("\nNova Descrição: ");
                        string dataTarefa = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("\nNova Descrição: ");
                        string horaTarefa = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Selecione uma opção válida");
                        break;
                }

            } while (Alteracao < 1 || Alteracao > 4);
            Console.WriteLine("Dado(s) alterado(s)! ");
        }//fim do alterar


        public void OperacaoTarefas()
        {
            do
            {
                MenuTarefas();
                switch (ConsultarOpcao)
                {
                    case 1:
                        CriarTarefas();
                        break;
                    case 2:
                        AtualizarTarefas();
                        break;
                    case 3:
                        Console.WriteLine("Obrigado! ");
                        break;
                    default:
                        Console.WriteLine("Informe uma opção que esteja no menu! ");
                        break;
                }//fim do escolha do caso
            } while (ConsultarOpcao != 3);
        }//fim do método

        public void Deletar()
        {
            Console.WriteLine("Informe o código da tarefa que deseja excluir: ");
            codigoTarefa = Convert.ToInt32(Console.ReadLine());
            //Utilizar o método excluir
            Console.WriteLine("\n\n" + conectar.Excluir(codigoTarefa));
        }//fim do método

    }//fim da classe
}//fim do projeto
