using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordDALL.Models
{
    public class Cadastro
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
