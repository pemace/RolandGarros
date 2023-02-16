using Microsoft.EntityFrameworkCore;
using RolandGarros.Entities;

namespace RolandGarros.Data
{
    public class TennisContext : DbContext
    {
        public DbSet<Match> Matchs => Set<Match>();
        public DbSet<Joueur> Joueurs => Set<Joueur>();
        public DbSet<Arbitre> Arbitres => Set<Arbitre>();
        public DbSet<Court> Courts => Set<Court>();
        public DbSet<Pays> Pays => Set<Pays>();
        public DbSet<Organisateur> Organisateurs => Set<Organisateur>();
        public DbSet<SousTournoi> SousTournois => Set<SousTournoi>();
        public DbSet<Resultat> Resultats => Set<Resultat>();

        public TennisContext( DbContextOptions<TennisContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder
            )
        {
            modelBuilder.Entity<Pays>().HasData(
                    new Pays { Id = 1, Code = 4, Alpha2 = "AF", Alpha3 = "AFG", NomFrFr = "Afghanistan", NomEnGb = "Afghanistan" },
                    new Pays { Id = 2, Code = 8, Alpha2 = "AL", Alpha3 = "ALB", NomFrFr = "Albanie", NomEnGb = "Albania" },
                    new Pays { Id = 3, Code = 10, Alpha2 = "AQ", Alpha3 = "ATA", NomFrFr = "Antarctique", NomEnGb = "Antarctica" },
                    new Pays { Id = 4, Code = 12, Alpha2 = "DZ", Alpha3 = "DZA", NomFrFr = "Algérie", NomEnGb = "Algeria" },
                    new Pays { Id = 5, Code = 16, Alpha2 = "AS", Alpha3 = "ASM", NomFrFr = "Samoa Américaines", NomEnGb = "American Samoa" },
                    new Pays { Id = 6, Code = 20, Alpha2 = "AD", Alpha3 = "AND", NomFrFr = "Andorre", NomEnGb = "Andorra" },
                    new Pays { Id = 7, Code = 24, Alpha2 = "AO", Alpha3 = "AGO", NomFrFr = "Angola", NomEnGb = "Angola" },
                    new Pays { Id = 8, Code = 28, Alpha2 = "AG", Alpha3 = "ATG", NomFrFr = "Antigua-et-Barbuda", NomEnGb = "Antigua and Barbuda" },
                    new Pays { Id = 9, Code = 31, Alpha2 = "AZ", Alpha3 = "AZE", NomFrFr = "Azerbaïdjan", NomEnGb = "Azerbaijan" },
                    new Pays { Id = 10, Code = 32, Alpha2 = "AR", Alpha3 = "ARG", NomFrFr = "Argentine", NomEnGb = "Argentina" },
                    new Pays { Id = 11, Code = 36, Alpha2 = "AU", Alpha3 = "AUS", NomFrFr = "Australie", NomEnGb = "Australia" },
                    new Pays { Id = 12, Code = 40, Alpha2 = "AT", Alpha3 = "AUT", NomFrFr = "Autriche", NomEnGb = "Austria" },
                    new Pays { Id = 13, Code = 44, Alpha2 = "BS", Alpha3 = "BHS", NomFrFr = "Bahamas", NomEnGb = "Bahamas" },
                    new Pays { Id = 14, Code = 48, Alpha2 = "BH", Alpha3 = "BHR", NomFrFr = "Bahreïn", NomEnGb = "Bahrain" },
                    new Pays { Id = 15, Code = 50, Alpha2 = "BD", Alpha3 = "BGD", NomFrFr = "Bangladesh", NomEnGb = "Bangladesh" },
                    new Pays { Id = 16, Code = 51, Alpha2 = "AM", Alpha3 = "ARM", NomFrFr = "Arménie", NomEnGb = "Armenia" },
                    new Pays { Id = 17, Code = 52, Alpha2 = "BB", Alpha3 = "BRB", NomFrFr = "Barbade", NomEnGb = "Barbados" },
                    new Pays { Id = 18, Code = 56, Alpha2 = "BE", Alpha3 = "BEL", NomFrFr = "Belgique", NomEnGb = "Belgium" },
                    new Pays { Id = 19, Code = 60, Alpha2 = "BM", Alpha3 = "BMU", NomFrFr = "Bermudes", NomEnGb = "Bermuda" },
                    new Pays { Id = 20, Code = 64, Alpha2 = "BT", Alpha3 = "BTN", NomFrFr = "Bhoutan", NomEnGb = "Bhutan" },
                    new Pays { Id = 21, Code = 68, Alpha2 = "BO", Alpha3 = "BOL", NomFrFr = "Bolivie", NomEnGb = "Bolivia" },
                    new Pays { Id = 22, Code = 70, Alpha2 = "BA", Alpha3 = "BIH", NomFrFr = "Bosnie-Herzégovine", NomEnGb = "Bosnia and Herzegovina" },
                    new Pays { Id = 23, Code = 72, Alpha2 = "BW", Alpha3 = "BWA", NomFrFr = "Botswana", NomEnGb = "Botswana" },
                    new Pays { Id = 24, Code = 74, Alpha2 = "BV", Alpha3 = "BVT", NomFrFr = "Île Bouvet", NomEnGb = "Bouvet Island" },
                    new Pays { Id = 25, Code = 76, Alpha2 = "BR", Alpha3 = "BRA", NomFrFr = "Brésil", NomEnGb = "Brazil" },
                    new Pays { Id = 26, Code = 84, Alpha2 = "BZ", Alpha3 = "BLZ", NomFrFr = "Belize", NomEnGb = "Belize" },
                    new Pays { Id = 27, Code = 86, Alpha2 = "IO", Alpha3 = "IOT", NomFrFr = "Territoire Britannique de l'Océan Indien", NomEnGb = "British Indian Ocean Territory" },
                    new Pays { Id = 28, Code = 90, Alpha2 = "SB", Alpha3 = "SLB", NomFrFr = "Îles Salomon", NomEnGb = "Solomon Islands" },
                    new Pays { Id = 29, Code = 92, Alpha2 = "VG", Alpha3 = "VGB", NomFrFr = "Îles Vierges Britanniques", NomEnGb = "British Virgin Islands" },
                    new Pays { Id = 30, Code = 96, Alpha2 = "BN", Alpha3 = "BRN", NomFrFr = "Brunéi Darussalam", NomEnGb = "Brunei Darussalam" },
                    new Pays { Id = 31, Code = 100, Alpha2 = "BG", Alpha3 = "BGR", NomFrFr = "Bulgarie", NomEnGb = "Bulgaria" },
                    new Pays { Id = 32, Code = 104, Alpha2 = "MM", Alpha3 = "MMR", NomFrFr = "Myanmar", NomEnGb = "Myanmar" },
                    new Pays { Id = 33, Code = 108, Alpha2 = "BI", Alpha3 = "BDI", NomFrFr = "Burundi", NomEnGb = "Burundi" },
                    new Pays { Id = 34, Code = 112, Alpha2 = "BY", Alpha3 = "BLR", NomFrFr = "Bélarus", NomEnGb = "Belarus" },
                    new Pays { Id = 35, Code = 116, Alpha2 = "KH", Alpha3 = "KHM", NomFrFr = "Cambodge", NomEnGb = "Cambodia" },
                    new Pays { Id = 36, Code = 120, Alpha2 = "CM", Alpha3 = "CMR", NomFrFr = "Cameroun", NomEnGb = "Cameroon" },
                    new Pays { Id = 37, Code = 124, Alpha2 = "CA", Alpha3 = "CAN", NomFrFr = "Canada", NomEnGb = "Canada" },
                    new Pays { Id = 38, Code = 132, Alpha2 = "CV", Alpha3 = "CPV", NomFrFr = "Cap-vert", NomEnGb = "Cape Verde" },
                    new Pays { Id = 39, Code = 136, Alpha2 = "KY", Alpha3 = "CYM", NomFrFr = "Îles Caïmanes", NomEnGb = "Cayman Islands" },
                    new Pays { Id = 40, Code = 140, Alpha2 = "CF", Alpha3 = "CAF", NomFrFr = "République Centrafricaine", NomEnGb = "Central African" },
                    new Pays { Id = 41, Code = 144, Alpha2 = "LK", Alpha3 = "LKA", NomFrFr = "Sri Lanka", NomEnGb = "Sri Lanka" },
                    new Pays { Id = 42, Code = 148, Alpha2 = "TD", Alpha3 = "TCD", NomFrFr = "Tchad", NomEnGb = "Chad" },
                    new Pays { Id = 43, Code = 152, Alpha2 = "CL", Alpha3 = "CHL", NomFrFr = "Chili", NomEnGb = "Chile" },
                    new Pays { Id = 44, Code = 156, Alpha2 = "CN", Alpha3 = "CHN", NomFrFr = "Chine", NomEnGb = "China" },
                    new Pays { Id = 45, Code = 158, Alpha2 = "TW", Alpha3 = "TWN", NomFrFr = "Taïwan", NomEnGb = "Taiwan" },
                    new Pays { Id = 46, Code = 162, Alpha2 = "CX", Alpha3 = "CXR", NomFrFr = "Île Christmas", NomEnGb = "Christmas Island" },
                    new Pays { Id = 47, Code = 166, Alpha2 = "CC", Alpha3 = "CCK", NomFrFr = "Îles Cocos (Keeling)", NomEnGb = "Cocos (Keeling) Islands" },
                    new Pays { Id = 48, Code = 170, Alpha2 = "CO", Alpha3 = "COL", NomFrFr = "Colombie", NomEnGb = "Colombia" },
                    new Pays { Id = 49, Code = 174, Alpha2 = "KM", Alpha3 = "COM", NomFrFr = "Comores", NomEnGb = "Comoros" },
                    new Pays { Id = 50, Code = 175, Alpha2 = "YT", Alpha3 = "MYT", NomFrFr = "Mayotte", NomEnGb = "Mayotte" },
                    new Pays { Id = 51, Code = 178, Alpha2 = "CG", Alpha3 = "COG", NomFrFr = "République du Congo", NomEnGb = "Republic of the Congo" },
                    new Pays { Id = 52, Code = 180, Alpha2 = "CD", Alpha3 = "COD", NomFrFr = "République Démocratique du Congo", NomEnGb = "The Democratic Republic Of The Congo" },
                    new Pays { Id = 53, Code = 184, Alpha2 = "CK", Alpha3 = "COK", NomFrFr = "Îles Cook", NomEnGb = "Cook Islands" },
                    new Pays { Id = 54, Code = 188, Alpha2 = "CR", Alpha3 = "CRI", NomFrFr = "Costa Rica", NomEnGb = "Costa Rica" },
                    new Pays { Id = 55, Code = 191, Alpha2 = "HR", Alpha3 = "HRV", NomFrFr = "Croatie", NomEnGb = "Croatia" },
                    new Pays { Id = 56, Code = 192, Alpha2 = "CU", Alpha3 = "CUB", NomFrFr = "Cuba", NomEnGb = "Cuba" },
                    new Pays { Id = 57, Code = 196, Alpha2 = "CY", Alpha3 = "CYP", NomFrFr = "Chypre", NomEnGb = "Cyprus" },
                    new Pays { Id = 58, Code = 203, Alpha2 = "CZ", Alpha3 = "CZE", NomFrFr = "République Tchèque", NomEnGb = "Czech Republic" },
                    new Pays { Id = 59, Code = 204, Alpha2 = "BJ", Alpha3 = "BEN", NomFrFr = "Bénin", NomEnGb = "Benin" },
                    new Pays { Id = 60, Code = 208, Alpha2 = "DK", Alpha3 = "DNK", NomFrFr = "Danemark", NomEnGb = "Denmark" },
                    new Pays { Id = 61, Code = 212, Alpha2 = "DM", Alpha3 = "DMA", NomFrFr = "Dominique", NomEnGb = "Dominica" },
                    new Pays { Id = 62, Code = 214, Alpha2 = "DO", Alpha3 = "DOM", NomFrFr = "République Dominicaine", NomEnGb = "Dominican Republic" },
                    new Pays { Id = 63, Code = 218, Alpha2 = "EC", Alpha3 = "ECU", NomFrFr = "Équateur", NomEnGb = "Ecuador" },
                    new Pays { Id = 64, Code = 222, Alpha2 = "SV", Alpha3 = "SLV", NomFrFr = "El Salvador", NomEnGb = "El Salvador" },
                    new Pays { Id = 65, Code = 226, Alpha2 = "GQ", Alpha3 = "GNQ", NomFrFr = "Guinée Équatoriale", NomEnGb = "Equatorial Guinea" },
                    new Pays { Id = 66, Code = 231, Alpha2 = "ET", Alpha3 = "ETH", NomFrFr = "Éthiopie", NomEnGb = "Ethiopia" },
                    new Pays { Id = 67, Code = 232, Alpha2 = "ER", Alpha3 = "ERI", NomFrFr = "Érythrée", NomEnGb = "Eritrea" },
                    new Pays { Id = 68, Code = 233, Alpha2 = "EE", Alpha3 = "EST", NomFrFr = "Estonie", NomEnGb = "Estonia" },
                    new Pays { Id = 69, Code = 234, Alpha2 = "FO", Alpha3 = "FRO", NomFrFr = "Îles Féroé", NomEnGb = "Faroe Islands" },
                    new Pays { Id = 70, Code = 238, Alpha2 = "FK", Alpha3 = "FLK", NomFrFr = "Îles (malvinas) Falkland", NomEnGb = "Falkland Islands" },
                    new Pays { Id = 71, Code = 239, Alpha2 = "GS", Alpha3 = "SGS", NomFrFr = "Géorgie du Sud et les Îles Sandwich du Sud", NomEnGb = "South Georgia and the South Sandwich Islands" },
                    new Pays { Id = 72, Code = 242, Alpha2 = "FJ", Alpha3 = "FJI", NomFrFr = "Fidji", NomEnGb = "Fiji" },
                    new Pays { Id = 73, Code = 246, Alpha2 = "FI", Alpha3 = "FIN", NomFrFr = "Finlande", NomEnGb = "Finland" },
                    new Pays { Id = 74, Code = 248, Alpha2 = "AX", Alpha3 = "ALA", NomFrFr = "Îles Åland", NomEnGb = "Åland Islands" },
                    new Pays { Id = 75, Code = 250, Alpha2 = "FR", Alpha3 = "FRA", NomFrFr = "France", NomEnGb = "France" },
                    new Pays { Id = 76, Code = 254, Alpha2 = "GF", Alpha3 = "GUF", NomFrFr = "Guyane Française", NomEnGb = "French Guiana" },
                    new Pays { Id = 77, Code = 258, Alpha2 = "PF", Alpha3 = "PYF", NomFrFr = "Polynésie Française", NomEnGb = "French Polynesia" },
                    new Pays { Id = 78, Code = 260, Alpha2 = "TF", Alpha3 = "ATF", NomFrFr = "Terres Australes Françaises", NomEnGb = "French Southern Territories" },
                    new Pays { Id = 79, Code = 262, Alpha2 = "DJ", Alpha3 = "DJI", NomFrFr = "Djibouti", NomEnGb = "Djibouti" },
                    new Pays { Id = 80, Code = 266, Alpha2 = "GA", Alpha3 = "GAB", NomFrFr = "Gabon", NomEnGb = "Gabon" },
                    new Pays { Id = 81, Code = 268, Alpha2 = "GE", Alpha3 = "GEO", NomFrFr = "Géorgie", NomEnGb = "Georgia" },
                    new Pays { Id = 82, Code = 270, Alpha2 = "GM", Alpha3 = "GMB", NomFrFr = "Gambie", NomEnGb = "Gambia" },
                    new Pays { Id = 83, Code = 275, Alpha2 = "PS", Alpha3 = "PSE", NomFrFr = "Territoire Palestinien Occupé", NomEnGb = "Occupied Palestinian Territory" },
                    new Pays { Id = 84, Code = 276, Alpha2 = "DE", Alpha3 = "DEU", NomFrFr = "Allemagne", NomEnGb = "Germany" },
                    new Pays { Id = 85, Code = 288, Alpha2 = "GH", Alpha3 = "GHA", NomFrFr = "Ghana", NomEnGb = "Ghana" },
                    new Pays { Id = 86, Code = 292, Alpha2 = "GI", Alpha3 = "GIB", NomFrFr = "Gibraltar", NomEnGb = "Gibraltar" },
                    new Pays { Id = 87, Code = 296, Alpha2 = "KI", Alpha3 = "KIR", NomFrFr = "Kiribati", NomEnGb = "Kiribati" },
                    new Pays { Id = 88, Code = 300, Alpha2 = "GR", Alpha3 = "GRC", NomFrFr = "Grèce", NomEnGb = "Greece" },
                    new Pays { Id = 89, Code = 304, Alpha2 = "GL", Alpha3 = "GRL", NomFrFr = "Groenland", NomEnGb = "Greenland" },
                    new Pays { Id = 90, Code = 308, Alpha2 = "GD", Alpha3 = "GRD", NomFrFr = "Grenade", NomEnGb = "Grenada" },
                    new Pays { Id = 91, Code = 312, Alpha2 = "GP", Alpha3 = "GLP", NomFrFr = "Guadeloupe", NomEnGb = "Guadeloupe" },
                    new Pays { Id = 92, Code = 316, Alpha2 = "GU", Alpha3 = "GUM", NomFrFr = "Guam", NomEnGb = "Guam" },
                    new Pays { Id = 93, Code = 320, Alpha2 = "GT", Alpha3 = "GTM", NomFrFr = "Guatemala", NomEnGb = "Guatemala" },
                    new Pays { Id = 94, Code = 324, Alpha2 = "GN", Alpha3 = "GIN", NomFrFr = "Guinée", NomEnGb = "Guinea" },
                    new Pays { Id = 95, Code = 328, Alpha2 = "GY", Alpha3 = "GUY", NomFrFr = "Guyana", NomEnGb = "Guyana" },
                    new Pays { Id = 96, Code = 332, Alpha2 = "HT", Alpha3 = "HTI", NomFrFr = "Haïti", NomEnGb = "Haiti" },
                    new Pays { Id = 97, Code = 334, Alpha2 = "HM", Alpha3 = "HMD", NomFrFr = "Îles Heard et Mcdonald", NomEnGb = "Heard Island and McDonald Islands" },
                    new Pays { Id = 98, Code = 336, Alpha2 = "VA", Alpha3 = "VAT", NomFrFr = "Saint-Siège (état de la Cité du Vatican)", NomEnGb = "Vatican City State" },
                    new Pays { Id = 99, Code = 340, Alpha2 = "HN", Alpha3 = "HND", NomFrFr = "Honduras", NomEnGb = "Honduras" },
                    new Pays { Id = 100, Code = 344, Alpha2 = "HK", Alpha3 = "HKG", NomFrFr = "Hong-Kong", NomEnGb = "Hong Kong" },
                    new Pays { Id = 101, Code = 348, Alpha2 = "HU", Alpha3 = "HUN", NomFrFr = "Hongrie", NomEnGb = "Hungary" },
                    new Pays { Id = 102, Code = 352, Alpha2 = "IS", Alpha3 = "ISL", NomFrFr = "Islande", NomEnGb = "Iceland" },
                    new Pays { Id = 103, Code = 356, Alpha2 = "IN", Alpha3 = "IND", NomFrFr = "Inde", NomEnGb = "India" },
                    new Pays { Id = 104, Code = 360, Alpha2 = "ID", Alpha3 = "IDN", NomFrFr = "Indonésie", NomEnGb = "Indonesia" },
                    new Pays { Id = 105, Code = 364, Alpha2 = "IR", Alpha3 = "IRN", NomFrFr = "République Islamique d'Iran", NomEnGb = "Islamic Republic of Iran" },
                    new Pays { Id = 106, Code = 368, Alpha2 = "IQ", Alpha3 = "IRQ", NomFrFr = "Iraq", NomEnGb = "Iraq" },
                    new Pays { Id = 107, Code = 372, Alpha2 = "IE", Alpha3 = "IRL", NomFrFr = "Irlande", NomEnGb = "Ireland" },
                    new Pays { Id = 108, Code = 376, Alpha2 = "IL", Alpha3 = "ISR", NomFrFr = "Israël", NomEnGb = "Israel" },
                    new Pays { Id = 109, Code = 380, Alpha2 = "IT", Alpha3 = "ITA", NomFrFr = "Italie", NomEnGb = "Italy" },
                    new Pays { Id = 110, Code = 384, Alpha2 = "CI", Alpha3 = "CIV", NomFrFr = "Côte d'Ivoire", NomEnGb = "Côte d'Ivoire" },
                    new Pays { Id = 111, Code = 388, Alpha2 = "JM", Alpha3 = "JAM", NomFrFr = "Jamaïque", NomEnGb = "Jamaica" },
                    new Pays { Id = 112, Code = 392, Alpha2 = "JP", Alpha3 = "JPN", NomFrFr = "Japon", NomEnGb = "Japan" },
                    new Pays { Id = 113, Code = 398, Alpha2 = "KZ", Alpha3 = "KAZ", NomFrFr = "Kazakhstan", NomEnGb = "Kazakhstan" },
                    new Pays { Id = 114, Code = 400, Alpha2 = "JO", Alpha3 = "JOR", NomFrFr = "Jordanie", NomEnGb = "Jordan" },
                    new Pays { Id = 115, Code = 404, Alpha2 = "KE", Alpha3 = "KEN", NomFrFr = "Kenya", NomEnGb = "Kenya" },
                    new Pays { Id = 116, Code = 408, Alpha2 = "KP", Alpha3 = "PRK", NomFrFr = "République Populaire Démocratique de Corée", NomEnGb = "Democratic People's Republic of Korea" },
                    new Pays { Id = 117, Code = 410, Alpha2 = "KR", Alpha3 = "KOR", NomFrFr = "République de Corée", NomEnGb = "Republic of Korea" },
                    new Pays { Id = 118, Code = 414, Alpha2 = "KW", Alpha3 = "KWT", NomFrFr = "Koweït", NomEnGb = "Kuwait" },
                    new Pays { Id = 119, Code = 417, Alpha2 = "KG", Alpha3 = "KGZ", NomFrFr = "Kirghizistan", NomEnGb = "Kyrgyzstan" },
                    new Pays { Id = 120, Code = 418, Alpha2 = "LA", Alpha3 = "LAO", NomFrFr = "République Démocratique Populaire Lao", NomEnGb = "Lao People's Democratic Republic" },
                    new Pays { Id = 121, Code = 422, Alpha2 = "LB", Alpha3 = "LBN", NomFrFr = "Liban", NomEnGb = "Lebanon" },
                    new Pays { Id = 122, Code = 426, Alpha2 = "LS", Alpha3 = "LSO", NomFrFr = "Lesotho", NomEnGb = "Lesotho" },
                    new Pays { Id = 123, Code = 428, Alpha2 = "LV", Alpha3 = "LVA", NomFrFr = "Lettonie", NomEnGb = "Latvia" },
                    new Pays { Id = 124, Code = 430, Alpha2 = "LR", Alpha3 = "LBR", NomFrFr = "Libéria", NomEnGb = "Liberia" },
                    new Pays { Id = 125, Code = 434, Alpha2 = "LY", Alpha3 = "LBY", NomFrFr = "Jamahiriya Arabe Libyenne", NomEnGb = "Libyan Arab Jamahiriya" },
                    new Pays { Id = 126, Code = 438, Alpha2 = "LI", Alpha3 = "LIE", NomFrFr = "Liechtenstein", NomEnGb = "Liechtenstein" },
                    new Pays { Id = 127, Code = 440, Alpha2 = "LT", Alpha3 = "LTU", NomFrFr = "Lituanie", NomEnGb = "Lithuania" },
                    new Pays { Id = 128, Code = 442, Alpha2 = "LU", Alpha3 = "LUX", NomFrFr = "Luxembourg", NomEnGb = "Luxembourg" },
                    new Pays { Id = 129, Code = 446, Alpha2 = "MO", Alpha3 = "MAC", NomFrFr = "Macao", NomEnGb = "Macao" },
                    new Pays { Id = 130, Code = 450, Alpha2 = "MG", Alpha3 = "MDG", NomFrFr = "Madagascar", NomEnGb = "Madagascar" },
                    new Pays { Id = 131, Code = 454, Alpha2 = "MW", Alpha3 = "MWI", NomFrFr = "Malawi", NomEnGb = "Malawi" },
                    new Pays { Id = 132, Code = 458, Alpha2 = "MY", Alpha3 = "MYS", NomFrFr = "Malaisie", NomEnGb = "Malaysia" },
                    new Pays { Id = 133, Code = 462, Alpha2 = "MV", Alpha3 = "MDV", NomFrFr = "Maldives", NomEnGb = "Maldives" },
                    new Pays { Id = 134, Code = 466, Alpha2 = "ML", Alpha3 = "MLI", NomFrFr = "Mali", NomEnGb = "Mali" },
                    new Pays { Id = 135, Code = 470, Alpha2 = "MT", Alpha3 = "MLT", NomFrFr = "Malte", NomEnGb = "Malta" },
                    new Pays { Id = 136, Code = 474, Alpha2 = "MQ", Alpha3 = "MTQ", NomFrFr = "Martinique", NomEnGb = "Martinique" },
                    new Pays { Id = 137, Code = 478, Alpha2 = "MR", Alpha3 = "MRT", NomFrFr = "Mauritanie", NomEnGb = "Mauritania" },
                    new Pays { Id = 138, Code = 480, Alpha2 = "MU", Alpha3 = "MUS", NomFrFr = "Maurice", NomEnGb = "Mauritius" },
                    new Pays { Id = 139, Code = 484, Alpha2 = "MX", Alpha3 = "MEX", NomFrFr = "Mexique", NomEnGb = "Mexico" },
                    new Pays { Id = 140, Code = 492, Alpha2 = "MC", Alpha3 = "MCO", NomFrFr = "Monaco", NomEnGb = "Monaco" },
                    new Pays { Id = 141, Code = 496, Alpha2 = "MN", Alpha3 = "MNG", NomFrFr = "Mongolie", NomEnGb = "Mongolia" },
                    new Pays { Id = 142, Code = 498, Alpha2 = "MD", Alpha3 = "MDA", NomFrFr = "République de Moldova", NomEnGb = "Republic of Moldova" },
                    new Pays { Id = 143, Code = 500, Alpha2 = "MS", Alpha3 = "MSR", NomFrFr = "Montserrat", NomEnGb = "Montserrat" },
                    new Pays { Id = 144, Code = 504, Alpha2 = "MA", Alpha3 = "MAR", NomFrFr = "Maroc", NomEnGb = "Morocco" },
                    new Pays { Id = 145, Code = 508, Alpha2 = "MZ", Alpha3 = "MOZ", NomFrFr = "Mozambique", NomEnGb = "Mozambique" },
                    new Pays { Id = 146, Code = 512, Alpha2 = "OM", Alpha3 = "OMN", NomFrFr = "Oman", NomEnGb = "Oman" },
                    new Pays { Id = 147, Code = 516, Alpha2 = "NA", Alpha3 = "NAM", NomFrFr = "Namibie", NomEnGb = "Namibia" },
                    new Pays { Id = 148, Code = 520, Alpha2 = "NR", Alpha3 = "NRU", NomFrFr = "Nauru", NomEnGb = "Nauru" },
                    new Pays { Id = 149, Code = 524, Alpha2 = "NP", Alpha3 = "NPL", NomFrFr = "Népal", NomEnGb = "Nepal" },
                    new Pays { Id = 150, Code = 528, Alpha2 = "NL", Alpha3 = "NLD", NomFrFr = "Pays-Bas", NomEnGb = "Netherlands" },
                    new Pays { Id = 151, Code = 530, Alpha2 = "AN", Alpha3 = "ANT", NomFrFr = "Antilles Néerlandaises", NomEnGb = "Netherlands Antilles" },
                    new Pays { Id = 152, Code = 533, Alpha2 = "AW", Alpha3 = "ABW", NomFrFr = "Aruba", NomEnGb = "Aruba" },
                    new Pays { Id = 153, Code = 540, Alpha2 = "NC", Alpha3 = "NCL", NomFrFr = "Nouvelle-Calédonie", NomEnGb = "New Caledonia" },
                    new Pays { Id = 154, Code = 548, Alpha2 = "VU", Alpha3 = "VUT", NomFrFr = "Vanuatu", NomEnGb = "Vanuatu" },
                    new Pays { Id = 155, Code = 554, Alpha2 = "NZ", Alpha3 = "NZL", NomFrFr = "Nouvelle-Zélande", NomEnGb = "New Zealand" },
                    new Pays { Id = 156, Code = 558, Alpha2 = "NI", Alpha3 = "NIC", NomFrFr = "Nicaragua", NomEnGb = "Nicaragua" },
                    new Pays { Id = 157, Code = 562, Alpha2 = "NE", Alpha3 = "NER", NomFrFr = "Niger", NomEnGb = "Niger" },
                    new Pays { Id = 158, Code = 566, Alpha2 = "NG", Alpha3 = "NGA", NomFrFr = "Nigéria", NomEnGb = "Nigeria" },
                    new Pays { Id = 159, Code = 570, Alpha2 = "NU", Alpha3 = "NIU", NomFrFr = "Niué", NomEnGb = "Niue" },
                    new Pays { Id = 160, Code = 574, Alpha2 = "NF", Alpha3 = "NFK", NomFrFr = "Île Norfolk", NomEnGb = "Norfolk Island" },
                    new Pays { Id = 161, Code = 578, Alpha2 = "NO", Alpha3 = "NOR", NomFrFr = "Norvège", NomEnGb = "Norway" },
                    new Pays { Id = 162, Code = 580, Alpha2 = "MP", Alpha3 = "MNP", NomFrFr = "Îles Mariannes du Nord", NomEnGb = "Northern Mariana Islands" },
                    new Pays { Id = 163, Code = 581, Alpha2 = "UM", Alpha3 = "UMI", NomFrFr = "Îles Mineures Éloignées des États-Unis", NomEnGb = "United States Minor Outlying Islands" },
                    new Pays { Id = 164, Code = 583, Alpha2 = "FM", Alpha3 = "FSM", NomFrFr = "États Fédérés de Micronésie", NomEnGb = "Federated States of Micronesia" },
                    new Pays { Id = 165, Code = 584, Alpha2 = "MH", Alpha3 = "MHL", NomFrFr = "Îles Marshall", NomEnGb = "Marshall Islands" },
                    new Pays { Id = 166, Code = 585, Alpha2 = "PW", Alpha3 = "PLW", NomFrFr = "Palaos", NomEnGb = "Palau" },
                    new Pays { Id = 167, Code = 586, Alpha2 = "PK", Alpha3 = "PAK", NomFrFr = "Pakistan", NomEnGb = "Pakistan" },
                    new Pays { Id = 168, Code = 591, Alpha2 = "PA", Alpha3 = "PAN", NomFrFr = "Panama", NomEnGb = "Panama" },
                    new Pays { Id = 169, Code = 598, Alpha2 = "PG", Alpha3 = "PNG", NomFrFr = "Papouasie-Nouvelle-Guinée", NomEnGb = "Papua New Guinea" },
                    new Pays { Id = 170, Code = 600, Alpha2 = "PY", Alpha3 = "PRY", NomFrFr = "Paraguay", NomEnGb = "Paraguay" },
                    new Pays { Id = 171, Code = 604, Alpha2 = "PE", Alpha3 = "PER", NomFrFr = "Pérou", NomEnGb = "Peru" },
                    new Pays { Id = 172, Code = 608, Alpha2 = "PH", Alpha3 = "PHL", NomFrFr = "Philippines", NomEnGb = "Philippines" },
                    new Pays { Id = 173, Code = 612, Alpha2 = "PN", Alpha3 = "PCN", NomFrFr = "Pitcairn", NomEnGb = "Pitcairn" },
                    new Pays { Id = 174, Code = 616, Alpha2 = "PL", Alpha3 = "POL", NomFrFr = "Pologne", NomEnGb = "Poland" },
                    new Pays { Id = 175, Code = 620, Alpha2 = "PT", Alpha3 = "PRT", NomFrFr = "Portugal", NomEnGb = "Portugal" },
                    new Pays { Id = 176, Code = 624, Alpha2 = "GW", Alpha3 = "GNB", NomFrFr = "Guinée-Bissau", NomEnGb = "Guinea-Bissau" },
                    new Pays { Id = 177, Code = 626, Alpha2 = "TL", Alpha3 = "TLS", NomFrFr = "Timor-Leste", NomEnGb = "Timor-Leste" },
                    new Pays { Id = 178, Code = 630, Alpha2 = "PR", Alpha3 = "PRI", NomFrFr = "Porto Rico", NomEnGb = "Puerto Rico" },
                    new Pays { Id = 179, Code = 634, Alpha2 = "QA", Alpha3 = "QAT", NomFrFr = "Qatar", NomEnGb = "Qatar" },
                    new Pays { Id = 180, Code = 638, Alpha2 = "RE", Alpha3 = "REU", NomFrFr = "Réunion", NomEnGb = "Réunion" },
                    new Pays { Id = 181, Code = 642, Alpha2 = "RO", Alpha3 = "ROU", NomFrFr = "Roumanie", NomEnGb = "Romania" },
                    new Pays { Id = 182, Code = 643, Alpha2 = "RU", Alpha3 = "RUS", NomFrFr = "Fédération de Russie", NomEnGb = "Russian Federation" },
                    new Pays { Id = 183, Code = 646, Alpha2 = "RW", Alpha3 = "RWA", NomFrFr = "Rwanda", NomEnGb = "Rwanda" },
                    new Pays { Id = 184, Code = 654, Alpha2 = "SH", Alpha3 = "SHN", NomFrFr = "Sainte-Hélène", NomEnGb = "Saint Helena" },
                    new Pays { Id = 185, Code = 659, Alpha2 = "KN", Alpha3 = "KNA", NomFrFr = "Saint-Kitts-et-Nevis", NomEnGb = "Saint Kitts and Nevis" },
                    new Pays { Id = 186, Code = 660, Alpha2 = "AI", Alpha3 = "AIA", NomFrFr = "Anguilla", NomEnGb = "Anguilla" },
                    new Pays { Id = 187, Code = 662, Alpha2 = "LC", Alpha3 = "LCA", NomFrFr = "Sainte-Lucie", NomEnGb = "Saint Lucia" },
                    new Pays { Id = 188, Code = 666, Alpha2 = "PM", Alpha3 = "SPM", NomFrFr = "Saint-Pierre-et-Miquelon", NomEnGb = "Saint-Pierre and Miquelon" },
                    new Pays { Id = 189, Code = 670, Alpha2 = "VC", Alpha3 = "VCT", NomFrFr = "Saint-Vincent-et-les Grenadines", NomEnGb = "Saint Vincent and the Grenadines" },
                    new Pays { Id = 190, Code = 674, Alpha2 = "SM", Alpha3 = "SMR", NomFrFr = "Saint-Marin", NomEnGb = "San Marino" },
                    new Pays { Id = 191, Code = 678, Alpha2 = "ST", Alpha3 = "STP", NomFrFr = "Sao Tomé-et-Principe", NomEnGb = "Sao Tome and Principe" },
                    new Pays { Id = 192, Code = 682, Alpha2 = "SA", Alpha3 = "SAU", NomFrFr = "Arabie Saoudite", NomEnGb = "Saudi Arabia" },
                    new Pays { Id = 193, Code = 686, Alpha2 = "SN", Alpha3 = "SEN", NomFrFr = "Sénégal", NomEnGb = "Senegal" },
                    new Pays { Id = 194, Code = 690, Alpha2 = "SC", Alpha3 = "SYC", NomFrFr = "Seychelles", NomEnGb = "Seychelles" },
                    new Pays { Id = 195, Code = 694, Alpha2 = "SL", Alpha3 = "SLE", NomFrFr = "Sierra Leone", NomEnGb = "Sierra Leone" },
                    new Pays { Id = 196, Code = 702, Alpha2 = "SG", Alpha3 = "SGP", NomFrFr = "Singapour", NomEnGb = "Singapore" },
                    new Pays { Id = 197, Code = 703, Alpha2 = "SK", Alpha3 = "SVK", NomFrFr = "Slovaquie", NomEnGb = "Slovakia" },
                    new Pays { Id = 198, Code = 704, Alpha2 = "VN", Alpha3 = "VNM", NomFrFr = "Viet Nam", NomEnGb = "Vietnam" },
                    new Pays { Id = 199, Code = 705, Alpha2 = "SI", Alpha3 = "SVN", NomFrFr = "Slovénie", NomEnGb = "Slovenia" },
                    new Pays { Id = 200, Code = 706, Alpha2 = "SO", Alpha3 = "SOM", NomFrFr = "Somalie", NomEnGb = "Somalia" },
                    new Pays { Id = 201, Code = 710, Alpha2 = "ZA", Alpha3 = "ZAF", NomFrFr = "Afrique du Sud", NomEnGb = "South Africa" },
                    new Pays { Id = 202, Code = 716, Alpha2 = "ZW", Alpha3 = "ZWE", NomFrFr = "Zimbabwe", NomEnGb = "Zimbabwe" },
                    new Pays { Id = 203, Code = 724, Alpha2 = "ES", Alpha3 = "ESP", NomFrFr = "Espagne", NomEnGb = "Spain" },
                    new Pays { Id = 204, Code = 732, Alpha2 = "EH", Alpha3 = "ESH", NomFrFr = "Sahara Occidental", NomEnGb = "Western Sahara" },
                    new Pays { Id = 205, Code = 736, Alpha2 = "SD", Alpha3 = "SDN", NomFrFr = "Soudan", NomEnGb = "Sudan" },
                    new Pays { Id = 206, Code = 740, Alpha2 = "SR", Alpha3 = "SUR", NomFrFr = "Suriname", NomEnGb = "Suriname" },
                    new Pays { Id = 207, Code = 744, Alpha2 = "SJ", Alpha3 = "SJM", NomFrFr = "Svalbard etÎle Jan Mayen", NomEnGb = "Svalbard and Jan Mayen" },
                    new Pays { Id = 208, Code = 748, Alpha2 = "SZ", Alpha3 = "SWZ", NomFrFr = "Swaziland", NomEnGb = "Swaziland" },
                    new Pays { Id = 209, Code = 752, Alpha2 = "SE", Alpha3 = "SWE", NomFrFr = "Suède", NomEnGb = "Sweden" },
                    new Pays { Id = 210, Code = 756, Alpha2 = "CH", Alpha3 = "CHE", NomFrFr = "Suisse", NomEnGb = "Switzerland" },
                    new Pays { Id = 211, Code = 760, Alpha2 = "SY", Alpha3 = "SYR", NomFrFr = "République Arabe Syrienne", NomEnGb = "Syrian Arab Republic" },
                    new Pays { Id = 212, Code = 762, Alpha2 = "TJ", Alpha3 = "TJK", NomFrFr = "Tadjikistan", NomEnGb = "Tajikistan" },
                    new Pays { Id = 213, Code = 764, Alpha2 = "TH", Alpha3 = "THA", NomFrFr = "Thaïlande", NomEnGb = "Thailand" },
                    new Pays { Id = 214, Code = 768, Alpha2 = "TG", Alpha3 = "TGO", NomFrFr = "Togo", NomEnGb = "Togo" },
                    new Pays { Id = 215, Code = 772, Alpha2 = "TK", Alpha3 = "TKL", NomFrFr = "Tokelau", NomEnGb = "Tokelau" },
                    new Pays { Id = 216, Code = 776, Alpha2 = "TO", Alpha3 = "TON", NomFrFr = "Tonga", NomEnGb = "Tonga" },
                    new Pays { Id = 217, Code = 780, Alpha2 = "TT", Alpha3 = "TTO", NomFrFr = "Trinité-et-Tobago", NomEnGb = "Trinidad and Tobago" },
                    new Pays { Id = 218, Code = 784, Alpha2 = "AE", Alpha3 = "ARE", NomFrFr = "Émirats Arabes Unis", NomEnGb = "United Arab Emirates" },
                    new Pays { Id = 219, Code = 788, Alpha2 = "TN", Alpha3 = "TUN", NomFrFr = "Tunisie", NomEnGb = "Tunisia" },
                    new Pays { Id = 220, Code = 792, Alpha2 = "TR", Alpha3 = "TUR", NomFrFr = "Turquie", NomEnGb = "Turkey" },
                    new Pays { Id = 221, Code = 795, Alpha2 = "TM", Alpha3 = "TKM", NomFrFr = "Turkménistan", NomEnGb = "Turkmenistan" },
                    new Pays { Id = 222, Code = 796, Alpha2 = "TC", Alpha3 = "TCA", NomFrFr = "Îles Turks et Caïques", NomEnGb = "Turks and Caicos Islands" },
                    new Pays { Id = 223, Code = 798, Alpha2 = "TV", Alpha3 = "TUV", NomFrFr = "Tuvalu", NomEnGb = "Tuvalu" },
                    new Pays { Id = 224, Code = 800, Alpha2 = "UG", Alpha3 = "UGA", NomFrFr = "Ouganda", NomEnGb = "Uganda" },
                    new Pays { Id = 225, Code = 804, Alpha2 = "UA", Alpha3 = "UKR", NomFrFr = "Ukraine", NomEnGb = "Ukraine" },
                    new Pays { Id = 226, Code = 807, Alpha2 = "MK", Alpha3 = "MKD", NomFrFr = "L'ex-République Yougoslave de Macédoine", NomEnGb = "The Former Yugoslav Republic of Macedonia" },
                    new Pays { Id = 227, Code = 818, Alpha2 = "EG", Alpha3 = "EGY", NomFrFr = "Égypte", NomEnGb = "Egypt" },
                    new Pays { Id = 228, Code = 826, Alpha2 = "GB", Alpha3 = "GBR", NomFrFr = "Royaume-Uni", NomEnGb = "United Kingdom" },
                    new Pays { Id = 229, Code = 833, Alpha2 = "IM", Alpha3 = "IMN", NomFrFr = "Île de Man", NomEnGb = "Isle of Man" },
                    new Pays { Id = 230, Code = 834, Alpha2 = "TZ", Alpha3 = "TZA", NomFrFr = "République-Unie de Tanzanie", NomEnGb = "United Republic Of Tanzania" },
                    new Pays { Id = 231, Code = 840, Alpha2 = "US", Alpha3 = "USA", NomFrFr = "États-Unis", NomEnGb = "United States" },
                    new Pays { Id = 232, Code = 850, Alpha2 = "VI", Alpha3 = "VIR", NomFrFr = "Îles Vierges des États-Unis", NomEnGb = "U.S. Virgin Islands" },
                    new Pays { Id = 233, Code = 854, Alpha2 = "BF", Alpha3 = "BFA", NomFrFr = "Burkina Faso", NomEnGb = "Burkina Faso" },
                    new Pays { Id = 234, Code = 858, Alpha2 = "UY", Alpha3 = "URY", NomFrFr = "Uruguay", NomEnGb = "Uruguay" },
                    new Pays { Id = 235, Code = 860, Alpha2 = "UZ", Alpha3 = "UZB", NomFrFr = "Ouzbékistan", NomEnGb = "Uzbekistan" },
                    new Pays { Id = 236, Code = 862, Alpha2 = "VE", Alpha3 = "VEN", NomFrFr = "Venezuela", NomEnGb = "Venezuela" },
                    new Pays { Id = 237, Code = 876, Alpha2 = "WF", Alpha3 = "WLF", NomFrFr = "Wallis et Futuna", NomEnGb = "Wallis and Futuna" },
                    new Pays { Id = 238, Code = 882, Alpha2 = "WS", Alpha3 = "WSM", NomFrFr = "Samoa", NomEnGb = "Samoa" },
                    new Pays { Id = 239, Code = 887, Alpha2 = "YE", Alpha3 = "YEM", NomFrFr = "Yémen", NomEnGb = "Yemen" },
                    new Pays { Id = 240, Code = 891, Alpha2 = "CS", Alpha3 = "SCG", NomFrFr = "Serbie-et-Monténégro", NomEnGb = "Serbia and Montenegro" },
                    new Pays { Id = 241, Code = 894, Alpha2 = "ZM", Alpha3 = "ZMB", NomFrFr = "Zambie", NomEnGb = "Zambia" }
                );

            modelBuilder.Entity<Joueur>().HasData(
                    new {
                            Id = 1,
                            Nom= "Rihane",
                            Prenom= "Youcef",
                            DateNaissance=new DateTime(1983,12,10),
                            NationaliteId=4,
                            Sexe=Sexe.Homme
                        },
                    new
                    {
                        Id = 2,
                        Nom = "Monfils",
                        Prenom = "Gaël",
                        DateNaissance = new DateTime(1986, 9, 1),
                        NationaliteId = 75,
                        Sexe = Sexe.Homme
                    },
                    new
                    {
                        Id = 3,
                        Nom = "Mertens",
                        Prenom = "Elise",
                        DateNaissance = new DateTime(1995, 11, 17),
                        NationaliteId = 18,
                        Sexe = Sexe.Femme
                    },
                    new
                    {
                        Id = 4,
                        Nom = "Garcia",
                        Prenom = "Caroline",
                        DateNaissance = new DateTime(1994, 11, 17),
                        NationaliteId = 75,
                        Sexe = Sexe.Femme
                    }
                );

            modelBuilder.Entity<SousTournoi>().HasData(
                    new SousTournoi {
                                        Id = 1,
                                        TypeSousTournoi=TypeSousTournoi.SimpleMessieurs,
                                        DateDebut=new DateTime(2022,6,5),
                                        DateFin = new DateTime(2022, 7, 1),
                                        Nom= "Coupe des mousquetaires"
                    },
                    new SousTournoi
                    {
                        Id = 2,
                        TypeSousTournoi = TypeSousTournoi.SimpleDames,
                        DateDebut = new DateTime(2022, 6, 5),
                        DateFin = new DateTime(2022, 7, 1),
                        Nom = "Coupe Suzanne Leglen"
                    }
                );

            modelBuilder.Entity<Court>().HasData(
                    new Court { Id = 1, Nom= "Philippe-Chatrier", Numero = 1 },
                    new Court { Id = 2, Nom = "Suzanne-Lenglen", Numero = 2 }
                );

            modelBuilder.Entity<Arbitre>().HasData(
                    new { Id = 1, Nom = "Dujardin",Prenom = "François", NationaliteId = 1 },
                    new { Id = 2, Nom = "Al Kashi",Prenom = "Youssef", NationaliteId = 2 }
                );

            modelBuilder.Entity<Match>().HasData(
                    new {
                            Id=1,
                            Joueur1Id=1,
                            Joueur2Id=2,
                            ArbitreId=1,
                            CourtId=1,
                            Date= new DateTime(2022, 6, 5),
                            SousTournoiId=1
                    },
                    new
                    {
                        Id = 2,
                        Joueur1Id = 3,
                        Joueur2Id = 4,
                        ArbitreId = 2,
                        CourtId = 2,
                        Date = new DateTime(2022, 6, 6),
                        SousTournoiId = 2
                    }
                );

        }
    }
}
