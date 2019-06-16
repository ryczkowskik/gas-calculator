using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasCalculator.Entities
{
    /// <summary>
    /// Klasa reprezentująca encję Gaz
    /// </summary>
    public class Gas
    {
        /// <summary>
        /// Identyfikator encji
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Nazwa gazy
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Współczynnik gazu
        /// </summary>
        public decimal Factor { get; set; }

        /// <summary>
        /// Wartość DGW gazu
        /// </summary>
        public decimal DGW { get; set; }

        /// <summary>
        /// Wartosć GGW gazu
        /// </summary>
        public decimal GGW { get; set; }

        /// <summary>
        /// Gęstość gazu
        /// </summary>
        public decimal Consistency { get; set; }

        /// <summary>
        /// Charakterystyka zarożenia gazu
        /// </summary>
        public string Description { get; set; }
    }
}
