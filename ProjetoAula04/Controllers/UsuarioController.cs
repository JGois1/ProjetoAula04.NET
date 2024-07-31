using ProjetoAula04.Entities;
using ProjetoAula04.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    /// <summary>
    /// Controlador para realizar fluxos de entrada de dados de usuário
    /// </summary>
    public class UsuarioController
    {
        /// <summary>
        /// Método para preenchimento e cadastro de um usuário
        /// </summary>
        public void CadastrarUsuario()
        {
            Console.WriteLine("\nCADASTRO DE USUÁRIO:\n");

            var usuario = new Usuario();
            usuario.Id = Guid.NewGuid();

            try
            {
                Console.Write("INFORME O NOME DO USUÁRIO.....: ");
                usuario.Nome = Console.ReadLine();

                Console.Write("INFORME O EMAIL DO USUÁRIO....: ");
                usuario.Email = Console.ReadLine();

                Console.Write("INFORME A SENHA DO USUÁRIO....: ");
                usuario.Senha = Console.ReadLine();

                var usuarioRepository = new UsuarioRepository();
                usuarioRepository.Inserir(usuario);

                Console.WriteLine("\nUSUARIO CADASTRADO COM SUCESSO.");    
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nERRO DE VALIDAÇÃO!");
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERRO AO GRAVAR O USUARIO NO BANCO DE DADOS.");
                Console.WriteLine(e.Message);       
            }
            catch(Exception e)
            {
                Console.WriteLine("\nERRO");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.Write("\nDESEJA REPETIR A OPERAÇÃO? (S/N): ");
                var opcao = Console.ReadLine();

                if(opcao == "S" || opcao == "s")
                {
                    Console.Clear(); //limpar o conteudo do prompt
                    CadastrarUsuario(); //recursividade
                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA");
                }
            }
        }
    }
}



