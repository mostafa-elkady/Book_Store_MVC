using System.ComponentModel.DataAnnotations;

namespace Book_Store_Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        [Range(1,1000), Required, Display(Name ="List Price")]
        public double ListPrice { get; set; } 
        [Range(1,1000), Required, Display(Name ="Price For 1-50")]
        public double Price { get; set; }
        [Range(1,1000), Required, Display(Name ="Price For 50+")]
        public double Price50 { get; set; }   
        [Range(1,1000), Required, Display(Name ="Price For 100+")]
        public double Price100 { get; set; }
    }
}
