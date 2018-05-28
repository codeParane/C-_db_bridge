using System.ComponentModel.DataAnnotations;
namespace EFCoreDemo
{ 
    public class Book
    {
        [Key]
        public string Books{get; set;}
        public string Authors{get; set;}
        //  public int BookId { get; set; }
        // public string Title { get; set; }
        // public int AuthorId { get; set; }
        // public Author Author { get; set; }
    }
}