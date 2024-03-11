    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.entity
{
    public class Kategori
    {
        [Key]

        public Guid IdKategori { get; set; }
        public string NamaKategori { get; set; }
        [JsonIgnore]
        public List<Barang> Barangs { get; set; }
    }
}