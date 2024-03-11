using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace domain.entity
{
    public class Barang
    {
        [Key]
        public Guid IdBarang { get; set; }
        public string? Gambar { get; set; } = string.Empty;
        public string NamaBarang { get; set; }
        public int Stok { get; set; }
        public float Harga { get; set; }
        public Guid IdKategori { get; set; }
        [ForeignKey(nameof(IdKategori))]
        public Kategori Kategori { get; set; }
    }
}