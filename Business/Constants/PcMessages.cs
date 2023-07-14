using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class PcMessages
    {
        public static string PcAdded = "Bilgisayar başarı ile eklendi";
        public static string PcsListed = "Bilgisayarlar listelendi";
        public static string PcListed = "Bilgisayar listelendi";
        public static string PcDetailed = "Bilgisayar detayları listelendi";
        public static string PcNotBeNull = "Bilgisayar özellikleri doldurulmalıdır.";
        public static string PcUpdated = "Bilgisayar özellikleri güncellendi.";
        internal static string ProductCountOfCategoryError = "Ürün katagori sınırına ulaştı.";
        internal static string ProductNameInvalid = "Ürün adı geçersiz.";
        internal static string PcDeleted = "Bilgisayar başarı ile silindi.";
    }
}
