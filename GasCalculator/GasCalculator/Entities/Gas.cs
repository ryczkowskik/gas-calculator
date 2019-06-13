using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasCalculator.Entities
{
    public class Gas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Factor { get; set; }

        public decimal DGW { get; set; }

        public decimal GGW { get; set; }

        public decimal Consistency { get; set; }

        public string Description { get; set; }
    }
}
