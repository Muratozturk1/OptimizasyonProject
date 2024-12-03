using System.ComponentModel.DataAnnotations;

namespace Optimizasyon.Core.Domain.Entities;

public class MarangozModel
    {
        [Key]
        public int Id { get; set; }
        public int WoodPerTable { get; set; }  // Masa başına gerekli tahta miktarı
        public int LaborPerTable { get; set; } // Masa başına gerekli iş gücü saati
        public int WoodPerChair { get; set; }  // Sandalye başına gerekli tahta miktarı
        public int LaborPerChair { get; set; } // Sandalye başına gerekli iş gücü saati
        public int TotalWood { get; set; } // Toplam tahta miktarı
        public int TotalLabor { get; set; } // Toplam iş gücü saati
        public double ProfitPerTable { get; set; } // Masa başına kar
        public double ProfitPerChair { get; set; } // Sandalye başına kar
    }