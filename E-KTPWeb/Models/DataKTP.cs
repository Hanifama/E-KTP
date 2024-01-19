using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_KTPWeb.Models
{
    public class DataKTP
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [DisplayName("masukan nik anda")]
        
        public long NIK { get; set; }
        [DisplayName("masukan nama anda")]
        
        public required string Name { get; set; }        
    }
        public class PaginationModel<T>
        {
            public List<T> Data { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }
}
