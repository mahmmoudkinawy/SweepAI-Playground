using System.ComponentModel.DataAnnotations;

namespace SweepAI_Playground.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}