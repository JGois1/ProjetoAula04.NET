using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula04.Entities
{
    /// <summary>
    /// Modelo de entidade
    /// </summary>
    public class Usuario
    {
        #region Atributos

        private Guid _id;
        private string? _nome;
        private string? _email;
        private string? _senha;

        #endregion

        #region Propriedades

        //utilizando o lambda (=>)
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        public string? Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O preenchimento do nome do usuário é obrigatório.");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{6,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um nome valido de 6 a 100 caracteres.");


                _nome = value;
            }
        }
        public string? Email
        {
            get => _email;

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O preenchimento do email do usuário ;e obrigatório");

                var regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um email valido para o usuario");

                _email = value;
            }  
        }
        public string? Senha
        {
            get => _senha;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O preenchimento da senha do usuário é obrigatório");

                var regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe uma senha valida");

                _senha = value;
            }

        }

        #endregion



    }
}
