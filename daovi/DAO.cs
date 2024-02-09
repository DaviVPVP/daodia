using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Cadastro
{
    class Dao
    {
        public MySqlConnection conexao;//Conectar ao banco de dados
        public string dados;
        public string sql;
        public string resultado;
        public int[] codigo;
        public string[] nome;
        public string[] telefone;
        public string[] email;
        public string[] nascimento;
        public string[] login;
        public string[] senha;
        public int i;
        public int contador;
        public string nsg;
        public Dao()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=TI18NPessoa;Uid=root;Password=");
            try
            {
                conexao.Open();
                Console.WriteLine("Conectado com sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Algo deu errado! Verifique os dados de conexão!\n\n" + erro);
                conexao.Close();
            }//fim do try catch
        }//fim do método DAO

        //Método inserir
        public void Inserir(string nome, string telefone, string email, string nascimento, string login, string senha)
        {
            try
            {
                dados = "('','" + nome + "', '" + telefone + "','" + email + "','" + nascimento + "','" + login + "','" + senha + "')";
                sql = "insert into tarefas(dia, hora, descricao) values" + dados;

                MySqlCommand conn = new MySqlCommand(sql, conexao);
                resultado = "" + conn.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linha afetada");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro!!! Algo deu errado!\n\n\n" + erro);
            }

        }//fim do inserir dados

        public void InserirL(string login, string senha)
        {
            try
            {
                dados = "('', '" + login + "', '" + senha + "')";
                sql = "insert into administrador(codigo, nome, telefone, city) values " + dados;
                MySqlCommand conn = new MySqlCommand(sql, conexao);//prepara a execução no banco
                resultado = "" + conn.ExecuteNonQuery();//Ctrl + Enter -> Executando o comando no bd
                Console.WriteLine(resultado + "Linha afetada");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro!!! Algo deu errado!\n\n\n" + erro);
            }
        }//fim do inserir login

        public void InserirTarefas(string codigoTarefa, string nomeTarefa, string descricaoTarefa, string dataTarefa, string horaTarefa)
        {
            try
            {
                dados = "('" + codigoTarefa + "','" + nomeTarefa + "', '" + descricaoTarefa + "', '" + dataTarefa + "', '" + horaTarefa + "')";
                sql = "insert into administrador(codigo, nome, telefone, city) values " + dados;
                MySqlCommand conn = new MySqlCommand(sql, conexao);
                resultado = "" + conn.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linha afetada");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro!!! Algo deu errado!\n\n\n" + erro);
            }
        }//fim do inserir tarefas

        public string Atualizar(int cod, string campo, string dado)
        {
            try
            {
                string query = "update pessoa set " + campo + " = '" + dado + "' where codigo = '" + cod + "'";
                
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " linha afetado";
            }
            catch (Exception erro)
            {
                return "Algo deu errado!\n\n" + erro;
            }
        }//fim do atualizar

        public string Excluir(int cod)
        {
            string query = "delete from tarefa where codigo = '" + cod + "'";
            //Preparar comando
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = "" + sql.ExecuteNonQuery();
            //Mostrar resultado
            return resultado + "Linha afetada! ";
        }
    }//fim da classe
}//fim do projeto
