using System.ComponentModel.DataAnnotations;

namespace NesHer.Models
{
    public class Contenido
    {
        [Key]
        public int idContenido { get; set; }
        public int cantidad { get; set; }
        public int idBotella { get; set; }
        



    }
}
