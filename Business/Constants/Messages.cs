using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        // Customer
        public static string CustomerAdded = "Müşteri başarılı bir şekilde eklendi";
        public static string CustomerDeleted = "Müşteri başarılı bir şekilde silindi";
        public static string CustomerUpdated = "Müşteri başarılı bir şekilde güncellendi";
        public static string CustomersListed = "Müşteriler başarılı bir şekilde listelendi";
        public static string CustomerListed = "Müşteri başarılı bir şekilde listelendi";

        public static string TCNotEmpty = "TC kimlik boş bırakılamaz";
        public static string TCMaxLength = "TC kimlik 11 karakter uzunluğunda olmalıdır";

        public static string FirstNameNotEmpty = "Ad boş bırakılamaz";
        public static string FirstNameMinLength = "Ad en az 2 karakter uzunluğunda olmalıdır";
        public static string FirstNameMaxLength = "Ad en fazla 30 karakter uzunluğunda olmalıdır";

        public static string LastNameNotEmpty = "Soyad boş bırakılamaz";
        public static string LastNameMinLength = "Soyad en az 2 karakter uzunluğunda olmalıdır";
        public static string LastNameMaxLength = "Soyad en fazla 30 karakter uzunluğunda olmalıdır";

        //Gender
        public static string GenderAdded = "Cinsiyet başarılı bir şekilde eklendi";
        public static string GenderDeleted = "Cinsiyet başarılı bir şekilde silindi";
        public static string GenderUpdated = "Cinsiyet başarılı bir şekilde güncellendi";
        public static string GendersListed = "Cinsiyetler başarılı bir şekilde listelendi";
        public static string GenderListed = "Cinsiyet başarılı bir şekilde listelendi";

        //RentalSituation
        public static string RentalSituationAdded = "Kiralama durumu başarılı bir şekilde eklendi";
        public static string RentalSituationDeleted = "Kiralama durumu başarılı bir şekilde silindi";
        public static string RentalSituationUpdated = "Kiralama durumu başarılı bir şekilde güncellendi";
        public static string RentalSituationsListed = "Kiralama durumuları başarılı bir şekilde listelendi";
        public static string RentalSituationListed = "Kiralama durumu başarılı bir şekilde listelendi";

        //Rent
        public static string RentAdded = "Aracınız için otoparktan yer rezerve edilmiştir";
        public static string RentDeleted = "Aracınız için otoparktan rezerve ettğiniz rezervasyon iptal edilmiştir";
        public static string RentUpdated = "Aracınız için otoparktan rezerve ettğiniz rezervasyon güncellenmiştir";
        public static string RentsListed = "Otoparktaki araçlar başarılı bir şekilde listelendi";
        public static string RentListed = "Otoparktaki araç başarılı bir şekilde listelendi";

        //SecurityQuestion
        public static string SecurityQuestionAdded = "Güvenlik sorusu başarılı bir şekilde eklendi";
        public static string SecurityQuestionDeleted = "Güvenlik sorusu başarılı bir şekilde silindi";
        public static string SecurityQuestionUpdated = "Güvenlik sorusu başarılı bir şekilde güncellendi";
        public static string SecurityQuestionsListed = "Güvenlik sorusuları başarılı bir şekilde listelendi";
        public static string SecurityQuestionListed = "Güvenlik sorusu başarılı bir şekilde listelendi";

        //VehicleBrand
        public static string VehicleBrandAdded = "Araç Markası başarılı bir şekilde eklendi";
        public static string VehicleBrandDeleted = "Araç Markası başarılı bir şekilde silindi";
        public static string VehicleBrandUpdated = "Araç Markası başarılı bir şekilde güncellendi";
        public static string VehicleBrandsListed = "Araç Markaları başarılı bir şekilde listelendi";
        public static string VehicleBrandListed = "Araç Markası başarılı bir şekilde listelendi";

        //VehicleType
        public static string VehicleTypeAdded = "Araç türü başarılı bir şekilde eklendi";
        public static string VehicleTypeDeleted = "Araç türü başarılı bir şekilde silindi";
        public static string VehicleTypeUpdated = "Araç türü başarılı bir şekilde güncellendi";
        public static string VehicleTypesListed = "Araç türleri başarılı bir şekilde listelendi";
        public static string VehicleTypeListed = "Araç türü başarılı bir şekilde listelendi";
        
    }
}
