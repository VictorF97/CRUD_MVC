using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MVC_CRUD.Models
{
    //Nome da tabela no Banco de Dados
    [Table("Usuario")]
    public class UsuarioModel
    {
        //Chave Primaria do Banco de Dados
        [Key]
        public int Id { get; set; }
        [MaxLength(60)]

        public string Nome { get; set; }
        [MaxLength(60)]

        public string Email { get; set; }
        [MaxLength(10, ErrorMessage = "O tamanho máximo é de {1} caracter")]
        [MinLength(5, ErrorMessage ="O tamanha mínimo é de {1} caracter")]

        public string Senha { get; set; }

        public bool Administrador { get; set; }

        public bool Ativo {  get; set; }

        public DateTime DataDoCadastro {  get; set; }
        

        public DateTime UltimoAcesso { get; set; }
    }
}
