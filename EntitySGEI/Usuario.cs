using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySGEI
{
    public class Usuario
    {
        public static int ID { get; set; }
        public static int ID_Localidade { get; set; }
        public static string Nome { get; set; }
        public static string Login { get; set; }
        public static string Senha { get; set; }
        public static string Contato { get; set; }
        public static string Tipo { get; set; }
        public static string Inativo { get; set; }
        public static DateTime DataAtualiza { get; set; }
        public static string RespAtualiza { get; set; }
    }
}
