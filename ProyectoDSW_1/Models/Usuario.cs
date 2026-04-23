using System.ComponentModel.DataAnnotations;

namespace ProyectoDSW_1.Models
{
    public class Usuario
    {
        [Key]
        [Display(Name ="IdUsuario")]
        public int id { get; set; }

        [Display(Name ="Usuario")]
        public string usuario { get; set; }

        [Display(Name ="Contraseña")]
        public string contraseñaHash { get; set; }

        public int RolId { get; set; }
        public Rol? Rol { get; set; }

        public Dueno? Dueno { get; set; }
    }
}

