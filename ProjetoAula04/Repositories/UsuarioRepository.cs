using Dapper;
using ProjetoAula04.Entities;
using ProjetoAula04.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Repositories
{
    /// <summary>
    /// Repositório para operações de banco de dados com Usuário
    /// </summary>
    public class UsuarioRepository
    {
        /// <summary>
        /// Método para inserir um usuário no banco de dados
        /// </summary>
        /// <param name="usuario">Objeto com os dados do usuário</param>
        public void Inserir(Usuario usuario)
        {
            //mapeando a string de conexão do banco de dados
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDAula04;Integrated Security=True;";

            //abrindo conexão com o banco de dados
            var connection = new SqlConnection(connectionString);

            //instanciando a classe helper para criptografia 
            var cryptoHelper = new CryptoHelper();

            //executando a stored procedure
            connection.Execute("PROC_INSERIR_USUARIO", new
            {
                @NOME = usuario.Nome,
                @EMAIL = usuario.Email,
                @SENHA = cryptoHelper.SHA256Encrypt(usuario.Senha)
            }, commandType: CommandType.StoredProcedure);

            //fechando conexão com o banco de dados
            connection.Close();
        }
    }
}




