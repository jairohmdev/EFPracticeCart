namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int SellerId { get; set; }

        public int Bids { get; set; }
    }
}
