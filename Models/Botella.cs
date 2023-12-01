using System.ComponentModel.DataAnnotations;

namespace NesHer.Models
{
    public class Botella
    {
        [Key]
        public int idBotella { get; set; }
        public string marca { get; set; }
        public string tapa { get; set; }
    }
}
