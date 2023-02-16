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
                    new Pays { Id = 1, Code = 4, Alpha2 = "AF", Alpha3 = "AFG", NomEnGb = "Afghanistan", NomFrFr = "Afghanistan" },
                    new Pays { Id = 2, Code = 8, Alpha2 = "AL", Alpha3 = "ALB", NomEnGb = "Albanie", NomFrFr = "Albania" },
                    new Pays { Id = 3, Code = 10, Alpha2 = "AQ", Alpha3 = "ATA", NomEnGb = "Antarctique", NomFrFr = "Antarctica" },
                    new Pays { Id = 4, Code = 12, Alpha2 = "DZ", Alpha3 = "DZA", NomEnGb = "Algérie", NomFrFr = "Algeria" },
                    new Pays { Id = 5, Code = 16, Alpha2 = "AS", Alpha3 = "ASM", NomEnGb = "Samoa Américaines", NomFrFr = "American Samoa" },
                    new Pays { Id = 6, Code = 20, Alpha2 = "AD", Alpha3 = "AND", NomEnGb = "Andorre", NomFrFr = "Andorra" },
                    new Pays { Id = 7, Code = 24, Alpha2 = "AO", Alpha3 = "AGO", NomEnGb = "Angola", NomFrFr = "Angola" },
                    new Pays { Id = 8, Code = 28, Alpha2 = "AG", Alpha3 = "ATG", NomEnGb = "Antigua-et-Barbuda", NomFrFr = "Antigua and Barbuda" },
                    new Pays { Id = 9, Code = 31, Alpha2 = "AZ", Alpha3 = "AZE", NomEnGb = "Azerbaïdjan", NomFrFr = "Azerbaijan" },
                    new Pays { Id = 10, Code = 32, Alpha2 = "AR", Alpha3 = "ARG", NomEnGb = "Argentine", NomFrFr = "Argentina" },
                    new Pays { Id = 11, Code = 36, Alpha2 = "AU", Alpha3 = "AUS", NomEnGb = "Australie", NomFrFr = "Australia" },
                    new Pays { Id = 12, Code = 40, Alpha2 = "AT", Alpha3 = "AUT", NomEnGb = "Autriche", NomFrFr = "Austria" },
                    new Pays { Id = 13, Code = 44, Alpha2 = "BS", Alpha3 = "BHS", NomEnGb = "Bahamas", NomFrFr = "Bahamas" },
                    new Pays { Id = 14, Code = 48, Alpha2 = "BH", Alpha3 = "BHR", NomEnGb = "Bahreïn", NomFrFr = "Bahrain" },
                    new Pays { Id = 15, Code = 50, Alpha2 = "BD", Alpha3 = "BGD", NomEnGb = "Bangladesh", NomFrFr = "Bangladesh" },
                    new Pays { Id = 16, Code = 51, Alpha2 = "AM", Alpha3 = "ARM", NomEnGb = "Arménie", NomFrFr = "Armenia" },
                    new Pays { Id = 17, Code = 52, Alpha2 = "BB", Alpha3 = "BRB", NomEnGb = "Barbade", NomFrFr = "Barbados" },
                    new Pays { Id = 18, Code = 56, Alpha2 = "BE", Alpha3 = "BEL", NomEnGb = "Belgique", NomFrFr = "Belgium" },
                    new Pays { Id = 19, Code = 60, Alpha2 = "BM", Alpha3 = "BMU", NomEnGb = "Bermudes", NomFrFr = "Bermuda" },
                    new Pays { Id = 20, Code = 64, Alpha2 = "BT", Alpha3 = "BTN", NomEnGb = "Bhoutan", NomFrFr = "Bhutan" },
                    new Pays { Id = 21, Code = 68, Alpha2 = "BO", Alpha3 = "BOL", NomEnGb = "Bolivie", NomFrFr = "Bolivia" },
                    new Pays { Id = 22, Code = 70, Alpha2 = "BA", Alpha3 = "BIH", NomEnGb = "Bosnie-Herzégovine", NomFrFr = "Bosnia and Herzegovina" },
                    new Pays { Id = 23, Code = 72, Alpha2 = "BW", Alpha3 = "BWA", NomEnGb = "Botswana", NomFrFr = "Botswana" },
                    new Pays { Id = 24, Code = 74, Alpha2 = "BV", Alpha3 = "BVT", NomEnGb = "Île Bouvet", NomFrFr = "Bouvet Island" },
                    new Pays { Id = 25, Code = 76, Alpha2 = "BR", Alpha3 = "BRA", NomEnGb = "Brésil", NomFrFr = "Brazil" },
                    new Pays { Id = 26, Code = 84, Alpha2 = "BZ", Alpha3 = "BLZ", NomEnGb = "Belize", NomFrFr = "Belize" },
                    new Pays { Id = 27, Code = 86, Alpha2 = "IO", Alpha3 = "IOT", NomEnGb = "Territoire Britannique de l'Océan Indien", NomFrFr = "British Indian Ocean Territory" },
                    new Pays { Id = 28, Code = 90, Alpha2 = "SB", Alpha3 = "SLB", NomEnGb = "Îles Salomon", NomFrFr = "Solomon Islands" },
                    new Pays { Id = 29, Code = 92, Alpha2 = "VG", Alpha3 = "VGB", NomEnGb = "Îles Vierges Britanniques", NomFrFr = "British Virgin Islands" },
                    new Pays { Id = 30, Code = 96, Alpha2 = "BN", Alpha3 = "BRN", NomEnGb = "Brunéi Darussalam", NomFrFr = "Brunei Darussalam" },
                    new Pays { Id = 31, Code = 100, Alpha2 = "BG", Alpha3 = "BGR", NomEnGb = "Bulgarie", NomFrFr = "Bulgaria" },
                    new Pays { Id = 32, Code = 104, Alpha2 = "MM", Alpha3 = "MMR", NomEnGb = "Myanmar", NomFrFr = "Myanmar" },
                    new Pays { Id = 33, Code = 108, Alpha2 = "BI", Alpha3 = "BDI", NomEnGb = "Burundi", NomFrFr = "Burundi" },
                    new Pays { Id = 34, Code = 112, Alpha2 = "BY", Alpha3 = "BLR", NomEnGb = "Bélarus", NomFrFr = "Belarus" },
                    new Pays { Id = 35, Code = 116, Alpha2 = "KH", Alpha3 = "KHM", NomEnGb = "Cambodge", NomFrFr = "Cambodia" },
                    new Pays { Id = 36, Code = 120, Alpha2 = "CM", Alpha3 = "CMR", NomEnGb = "Cameroun", NomFrFr = "Cameroon" },
                    new Pays { Id = 37, Code = 124, Alpha2 = "CA", Alpha3 = "CAN", NomEnGb = "Canada", NomFrFr = "Canada" },
                    new Pays { Id = 38, Code = 132, Alpha2 = "CV", Alpha3 = "CPV", NomEnGb = "Cap-vert", NomFrFr = "Cape Verde" },
                    new Pays { Id = 39, Code = 136, Alpha2 = "KY", Alpha3 = "CYM", NomEnGb = "Îles Caïmanes", NomFrFr = "Cayman Islands" },
                    new Pays { Id = 40, Code = 140, Alpha2 = "CF", Alpha3 = "CAF", NomEnGb = "République Centrafricaine", NomFrFr = "Central African" },
                    new Pays { Id = 41, Code = 144, Alpha2 = "LK", Alpha3 = "LKA", NomEnGb = "Sri Lanka", NomFrFr = "Sri Lanka" },
                    new Pays { Id = 42, Code = 148, Alpha2 = "TD", Alpha3 = "TCD", NomEnGb = "Tchad", NomFrFr = "Chad" },
                    new Pays { Id = 43, Code = 152, Alpha2 = "CL", Alpha3 = "CHL", NomEnGb = "Chili", NomFrFr = "Chile" },
                    new Pays { Id = 44, Code = 156, Alpha2 = "CN", Alpha3 = "CHN", NomEnGb = "Chine", NomFrFr = "China" },
                    new Pays { Id = 45, Code = 158, Alpha2 = "TW", Alpha3 = "TWN", NomEnGb = "Taïwan", NomFrFr = "Taiwan" },
                    new Pays { Id = 46, Code = 162, Alpha2 = "CX", Alpha3 = "CXR", NomEnGb = "Île Christmas", NomFrFr = "Christmas Island" },
                    new Pays { Id = 47, Code = 166, Alpha2 = "CC", Alpha3 = "CCK", NomEnGb = "Îles Cocos (Keeling)", NomFrFr = "Cocos (Keeling) Islands" },
                    new Pays { Id = 48, Code = 170, Alpha2 = "CO", Alpha3 = "COL", NomEnGb = "Colombie", NomFrFr = "Colombia" },
                    new Pays { Id = 49, Code = 174, Alpha2 = "KM", Alpha3 = "COM", NomEnGb = "Comores", NomFrFr = "Comoros" },
                    new Pays { Id = 50, Code = 175, Alpha2 = "YT", Alpha3 = "MYT", NomEnGb = "Mayotte", NomFrFr = "Mayotte" },
                    new Pays { Id = 51, Code = 178, Alpha2 = "CG", Alpha3 = "COG", NomEnGb = "République du Congo", NomFrFr = "Republic of the Congo" },
                    new Pays { Id = 52, Code = 180, Alpha2 = "CD", Alpha3 = "COD", NomEnGb = "République Démocratique du Congo", NomFrFr = "The Democratic Republic Of The Congo" },
                    new Pays { Id = 53, Code = 184, Alpha2 = "CK", Alpha3 = "COK", NomEnGb = "Îles Cook", NomFrFr = "Cook Islands" },
                    new Pays { Id = 54, Code = 188, Alpha2 = "CR", Alpha3 = "CRI", NomEnGb = "Costa Rica", NomFrFr = "Costa Rica" },
                    new Pays { Id = 55, Code = 191, Alpha2 = "HR", Alpha3 = "HRV", NomEnGb = "Croatie", NomFrFr = "Croatia" },
                    new Pays { Id = 56, Code = 192, Alpha2 = "CU", Alpha3 = "CUB", NomEnGb = "Cuba", NomFrFr = "Cuba" },
                    new Pays { Id = 57, Code = 196, Alpha2 = "CY", Alpha3 = "CYP", NomEnGb = "Chypre", NomFrFr = "Cyprus" },
                    new Pays { Id = 58, Code = 203, Alpha2 = "CZ", Alpha3 = "CZE", NomEnGb = "République Tchèque", NomFrFr = "Czech Republic" },
                    new Pays { Id = 59, Code = 204, Alpha2 = "BJ", Alpha3 = "BEN", NomEnGb = "Bénin", NomFrFr = "Benin" },
                    new Pays { Id = 60, Code = 208, Alpha2 = "DK", Alpha3 = "DNK", NomEnGb = "Danemark", NomFrFr = "Denmark" },
                    new Pays { Id = 61, Code = 212, Alpha2 = "DM", Alpha3 = "DMA", NomEnGb = "Dominique", NomFrFr = "Dominica" },
                    new Pays { Id = 62, Code = 214, Alpha2 = "DO", Alpha3 = "DOM", NomEnGb = "République Dominicaine", NomFrFr = "Dominican Republic" },
                    new Pays { Id = 63, Code = 218, Alpha2 = "EC", Alpha3 = "ECU", NomEnGb = "Équateur", NomFrFr = "Ecuador" },
                    new Pays { Id = 64, Code = 222, Alpha2 = "SV", Alpha3 = "SLV", NomEnGb = "El Salvador", NomFrFr = "El Salvador" },
                    new Pays { Id = 65, Code = 226, Alpha2 = "GQ", Alpha3 = "GNQ", NomEnGb = "Guinée Équatoriale", NomFrFr = "Equatorial Guinea" },
                    new Pays { Id = 66, Code = 231, Alpha2 = "ET", Alpha3 = "ETH", NomEnGb = "Éthiopie", NomFrFr = "Ethiopia" },
                    new Pays { Id = 67, Code = 232, Alpha2 = "ER", Alpha3 = "ERI", NomEnGb = "Érythrée", NomFrFr = "Eritrea" },
                    new Pays { Id = 68, Code = 233, Alpha2 = "EE", Alpha3 = "EST", NomEnGb = "Estonie", NomFrFr = "Estonia" },
                    new Pays { Id = 69, Code = 234, Alpha2 = "FO", Alpha3 = "FRO", NomEnGb = "Îles Féroé", NomFrFr = "Faroe Islands" },
                    new Pays { Id = 70, Code = 238, Alpha2 = "FK", Alpha3 = "FLK", NomEnGb = "Îles (malvinas) Falkland", NomFrFr = "Falkland Islands" },
                    new Pays { Id = 71, Code = 239, Alpha2 = "GS", Alpha3 = "SGS", NomEnGb = "Géorgie du Sud et les Îles Sandwich du Sud", NomFrFr = "South Georgia and the South Sandwich Islands" },
                    new Pays { Id = 72, Code = 242, Alpha2 = "FJ", Alpha3 = "FJI", NomEnGb = "Fidji", NomFrFr = "Fiji" },
                    new Pays { Id = 73, Code = 246, Alpha2 = "FI", Alpha3 = "FIN", NomEnGb = "Finlande", NomFrFr = "Finland" },
                    new Pays { Id = 74, Code = 248, Alpha2 = "AX", Alpha3 = "ALA", NomEnGb = "Îles Åland", NomFrFr = "Åland Islands" },
                    new Pays { Id = 75, Code = 250, Alpha2 = "FR", Alpha3 = "FRA", NomEnGb = "France", NomFrFr = "France" },
                    new Pays { Id = 76, Code = 254, Alpha2 = "GF", Alpha3 = "GUF", NomEnGb = "Guyane Française", NomFrFr = "French Guiana" },
                    new Pays { Id = 77, Code = 258, Alpha2 = "PF", Alpha3 = "PYF", NomEnGb = "Polynésie Française", NomFrFr = "French Polynesia" },
                    new Pays { Id = 78, Code = 260, Alpha2 = "TF", Alpha3 = "ATF", NomEnGb = "Terres Australes Françaises", NomFrFr = "French Southern Territories" },
                    new Pays { Id = 79, Code = 262, Alpha2 = "DJ", Alpha3 = "DJI", NomEnGb = "Djibouti", NomFrFr = "Djibouti" },
                    new Pays { Id = 80, Code = 266, Alpha2 = "GA", Alpha3 = "GAB", NomEnGb = "Gabon", NomFrFr = "Gabon" },
                    new Pays { Id = 81, Code = 268, Alpha2 = "GE", Alpha3 = "GEO", NomEnGb = "Géorgie", NomFrFr = "Georgia" },
                    new Pays { Id = 82, Code = 270, Alpha2 = "GM", Alpha3 = "GMB", NomEnGb = "Gambie", NomFrFr = "Gambia" },
                    new Pays { Id = 83, Code = 275, Alpha2 = "PS", Alpha3 = "PSE", NomEnGb = "Territoire Palestinien Occupé", NomFrFr = "Occupied Palestinian Territory" },
                    new Pays { Id = 84, Code = 276, Alpha2 = "DE", Alpha3 = "DEU", NomEnGb = "Allemagne", NomFrFr = "Germany" },
                    new Pays { Id = 85, Code = 288, Alpha2 = "GH", Alpha3 = "GHA", NomEnGb = "Ghana", NomFrFr = "Ghana" },
                    new Pays { Id = 86, Code = 292, Alpha2 = "GI", Alpha3 = "GIB", NomEnGb = "Gibraltar", NomFrFr = "Gibraltar" },
                    new Pays { Id = 87, Code = 296, Alpha2 = "KI", Alpha3 = "KIR", NomEnGb = "Kiribati", NomFrFr = "Kiribati" },
                    new Pays { Id = 88, Code = 300, Alpha2 = "GR", Alpha3 = "GRC", NomEnGb = "Grèce", NomFrFr = "Greece" },
                    new Pays { Id = 89, Code = 304, Alpha2 = "GL", Alpha3 = "GRL", NomEnGb = "Groenland", NomFrFr = "Greenland" },
                    new Pays { Id = 90, Code = 308, Alpha2 = "GD", Alpha3 = "GRD", NomEnGb = "Grenade", NomFrFr = "Grenada" },
                    new Pays { Id = 91, Code = 312, Alpha2 = "GP", Alpha3 = "GLP", NomEnGb = "Guadeloupe", NomFrFr = "Guadeloupe" },
                    new Pays { Id = 92, Code = 316, Alpha2 = "GU", Alpha3 = "GUM", NomEnGb = "Guam", NomFrFr = "Guam" },
                    new Pays { Id = 93, Code = 320, Alpha2 = "GT", Alpha3 = "GTM", NomEnGb = "Guatemala", NomFrFr = "Guatemala" },
                    new Pays { Id = 94, Code = 324, Alpha2 = "GN", Alpha3 = "GIN", NomEnGb = "Guinée", NomFrFr = "Guinea" },
                    new Pays { Id = 95, Code = 328, Alpha2 = "GY", Alpha3 = "GUY", NomEnGb = "Guyana", NomFrFr = "Guyana" },
                    new Pays { Id = 96, Code = 332, Alpha2 = "HT", Alpha3 = "HTI", NomEnGb = "Haïti", NomFrFr = "Haiti" },
                    new Pays { Id = 97, Code = 334, Alpha2 = "HM", Alpha3 = "HMD", NomEnGb = "Îles Heard et Mcdonald", NomFrFr = "Heard Island and McDonald Islands" },
                    new Pays { Id = 98, Code = 336, Alpha2 = "VA", Alpha3 = "VAT", NomEnGb = "Saint-Siège (état de la Cité du Vatican)", NomFrFr = "Vatican City State" },
                    new Pays { Id = 99, Code = 340, Alpha2 = "HN", Alpha3 = "HND", NomEnGb = "Honduras", NomFrFr = "Honduras" },
                    new Pays { Id = 100, Code = 344, Alpha2 = "HK", Alpha3 = "HKG", NomEnGb = "Hong-Kong", NomFrFr = "Hong Kong" },
                    new Pays { Id = 101, Code = 348, Alpha2 = "HU", Alpha3 = "HUN", NomEnGb = "Hongrie", NomFrFr = "Hungary" },
                    new Pays { Id = 102, Code = 352, Alpha2 = "IS", Alpha3 = "ISL", NomEnGb = "Islande", NomFrFr = "Iceland" },
                    new Pays { Id = 103, Code = 356, Alpha2 = "IN", Alpha3 = "IND", NomEnGb = "Inde", NomFrFr = "India" },
                    new Pays { Id = 104, Code = 360, Alpha2 = "ID", Alpha3 = "IDN", NomEnGb = "Indonésie", NomFrFr = "Indonesia" },
                    new Pays { Id = 105, Code = 364, Alpha2 = "IR", Alpha3 = "IRN", NomEnGb = "République Islamique d'Iran", NomFrFr = "Islamic Republic of Iran" },
                    new Pays { Id = 106, Code = 368, Alpha2 = "IQ", Alpha3 = "IRQ", NomEnGb = "Iraq", NomFrFr = "Iraq" },
                    new Pays { Id = 107, Code = 372, Alpha2 = "IE", Alpha3 = "IRL", NomEnGb = "Irlande", NomFrFr = "Ireland" },
                    new Pays { Id = 108, Code = 376, Alpha2 = "IL", Alpha3 = "ISR", NomEnGb = "Israël", NomFrFr = "Israel" },
                    new Pays { Id = 109, Code = 380, Alpha2 = "IT", Alpha3 = "ITA", NomEnGb = "Italie", NomFrFr = "Italy" },
                    new Pays { Id = 110, Code = 384, Alpha2 = "CI", Alpha3 = "CIV", NomEnGb = "Côte d'Ivoire", NomFrFr = "Côte d'Ivoire" },
                    new Pays { Id = 111, Code = 388, Alpha2 = "JM", Alpha3 = "JAM", NomEnGb = "Jamaïque", NomFrFr = "Jamaica" },
                    new Pays { Id = 112, Code = 392, Alpha2 = "JP", Alpha3 = "JPN", NomEnGb = "Japon", NomFrFr = "Japan" },
                    new Pays { Id = 113, Code = 398, Alpha2 = "KZ", Alpha3 = "KAZ", NomEnGb = "Kazakhstan", NomFrFr = "Kazakhstan" },
                    new Pays { Id = 114, Code = 400, Alpha2 = "JO", Alpha3 = "JOR", NomEnGb = "Jordanie", NomFrFr = "Jordan" },
                    new Pays { Id = 115, Code = 404, Alpha2 = "KE", Alpha3 = "KEN", NomEnGb = "Kenya", NomFrFr = "Kenya" },
                    new Pays { Id = 116, Code = 408, Alpha2 = "KP", Alpha3 = "PRK", NomEnGb = "République Populaire Démocratique de Corée", NomFrFr = "Democratic People's Republic of Korea" },
                    new Pays { Id = 117, Code = 410, Alpha2 = "KR", Alpha3 = "KOR", NomEnGb = "République de Corée", NomFrFr = "Republic of Korea" },
                    new Pays { Id = 118, Code = 414, Alpha2 = "KW", Alpha3 = "KWT", NomEnGb = "Koweït", NomFrFr = "Kuwait" },
                    new Pays { Id = 119, Code = 417, Alpha2 = "KG", Alpha3 = "KGZ", NomEnGb = "Kirghizistan", NomFrFr = "Kyrgyzstan" },
                    new Pays { Id = 120, Code = 418, Alpha2 = "LA", Alpha3 = "LAO", NomEnGb = "République Démocratique Populaire Lao", NomFrFr = "Lao People's Democratic Republic" },
                    new Pays { Id = 121, Code = 422, Alpha2 = "LB", Alpha3 = "LBN", NomEnGb = "Liban", NomFrFr = "Lebanon" },
                    new Pays { Id = 122, Code = 426, Alpha2 = "LS", Alpha3 = "LSO", NomEnGb = "Lesotho", NomFrFr = "Lesotho" },
                    new Pays { Id = 123, Code = 428, Alpha2 = "LV", Alpha3 = "LVA", NomEnGb = "Lettonie", NomFrFr = "Latvia" },
                    new Pays { Id = 124, Code = 430, Alpha2 = "LR", Alpha3 = "LBR", NomEnGb = "Libéria", NomFrFr = "Liberia" },
                    new Pays { Id = 125, Code = 434, Alpha2 = "LY", Alpha3 = "LBY", NomEnGb = "Jamahiriya Arabe Libyenne", NomFrFr = "Libyan Arab Jamahiriya" },
                    new Pays { Id = 126, Code = 438, Alpha2 = "LI", Alpha3 = "LIE", NomEnGb = "Liechtenstein", NomFrFr = "Liechtenstein" },
                    new Pays { Id = 127, Code = 440, Alpha2 = "LT", Alpha3 = "LTU", NomEnGb = "Lituanie", NomFrFr = "Lithuania" },
                    new Pays { Id = 128, Code = 442, Alpha2 = "LU", Alpha3 = "LUX", NomEnGb = "Luxembourg", NomFrFr = "Luxembourg" },
                    new Pays { Id = 129, Code = 446, Alpha2 = "MO", Alpha3 = "MAC", NomEnGb = "Macao", NomFrFr = "Macao" },
                    new Pays { Id = 130, Code = 450, Alpha2 = "MG", Alpha3 = "MDG", NomEnGb = "Madagascar", NomFrFr = "Madagascar" },
                    new Pays { Id = 131, Code = 454, Alpha2 = "MW", Alpha3 = "MWI", NomEnGb = "Malawi", NomFrFr = "Malawi" },
                    new Pays { Id = 132, Code = 458, Alpha2 = "MY", Alpha3 = "MYS", NomEnGb = "Malaisie", NomFrFr = "Malaysia" },
                    new Pays { Id = 133, Code = 462, Alpha2 = "MV", Alpha3 = "MDV", NomEnGb = "Maldives", NomFrFr = "Maldives" },
                    new Pays { Id = 134, Code = 466, Alpha2 = "ML", Alpha3 = "MLI", NomEnGb = "Mali", NomFrFr = "Mali" },
                    new Pays { Id = 135, Code = 470, Alpha2 = "MT", Alpha3 = "MLT", NomEnGb = "Malte", NomFrFr = "Malta" },
                    new Pays { Id = 136, Code = 474, Alpha2 = "MQ", Alpha3 = "MTQ", NomEnGb = "Martinique", NomFrFr = "Martinique" },
                    new Pays { Id = 137, Code = 478, Alpha2 = "MR", Alpha3 = "MRT", NomEnGb = "Mauritanie", NomFrFr = "Mauritania" },
                    new Pays { Id = 138, Code = 480, Alpha2 = "MU", Alpha3 = "MUS", NomEnGb = "Maurice", NomFrFr = "Mauritius" },
                    new Pays { Id = 139, Code = 484, Alpha2 = "MX", Alpha3 = "MEX", NomEnGb = "Mexique", NomFrFr = "Mexico" },
                    new Pays { Id = 140, Code = 492, Alpha2 = "MC", Alpha3 = "MCO", NomEnGb = "Monaco", NomFrFr = "Monaco" },
                    new Pays { Id = 141, Code = 496, Alpha2 = "MN", Alpha3 = "MNG", NomEnGb = "Mongolie", NomFrFr = "Mongolia" },
                    new Pays { Id = 142, Code = 498, Alpha2 = "MD", Alpha3 = "MDA", NomEnGb = "République de Moldova", NomFrFr = "Republic of Moldova" },
                    new Pays { Id = 143, Code = 500, Alpha2 = "MS", Alpha3 = "MSR", NomEnGb = "Montserrat", NomFrFr = "Montserrat" },
                    new Pays { Id = 144, Code = 504, Alpha2 = "MA", Alpha3 = "MAR", NomEnGb = "Maroc", NomFrFr = "Morocco" },
                    new Pays { Id = 145, Code = 508, Alpha2 = "MZ", Alpha3 = "MOZ", NomEnGb = "Mozambique", NomFrFr = "Mozambique" },
                    new Pays { Id = 146, Code = 512, Alpha2 = "OM", Alpha3 = "OMN", NomEnGb = "Oman", NomFrFr = "Oman" },
                    new Pays { Id = 147, Code = 516, Alpha2 = "NA", Alpha3 = "NAM", NomEnGb = "Namibie", NomFrFr = "Namibia" },
                    new Pays { Id = 148, Code = 520, Alpha2 = "NR", Alpha3 = "NRU", NomEnGb = "Nauru", NomFrFr = "Nauru" },
                    new Pays { Id = 149, Code = 524, Alpha2 = "NP", Alpha3 = "NPL", NomEnGb = "Népal", NomFrFr = "Nepal" },
                    new Pays { Id = 150, Code = 528, Alpha2 = "NL", Alpha3 = "NLD", NomEnGb = "Pays-Bas", NomFrFr = "Netherlands" },
                    new Pays { Id = 151, Code = 530, Alpha2 = "AN", Alpha3 = "ANT", NomEnGb = "Antilles Néerlandaises", NomFrFr = "Netherlands Antilles" },
                    new Pays { Id = 152, Code = 533, Alpha2 = "AW", Alpha3 = "ABW", NomEnGb = "Aruba", NomFrFr = "Aruba" },
                    new Pays { Id = 153, Code = 540, Alpha2 = "NC", Alpha3 = "NCL", NomEnGb = "Nouvelle-Calédonie", NomFrFr = "New Caledonia" },
                    new Pays { Id = 154, Code = 548, Alpha2 = "VU", Alpha3 = "VUT", NomEnGb = "Vanuatu", NomFrFr = "Vanuatu" },
                    new Pays { Id = 155, Code = 554, Alpha2 = "NZ", Alpha3 = "NZL", NomEnGb = "Nouvelle-Zélande", NomFrFr = "New Zealand" },
                    new Pays { Id = 156, Code = 558, Alpha2 = "NI", Alpha3 = "NIC", NomEnGb = "Nicaragua", NomFrFr = "Nicaragua" },
                    new Pays { Id = 157, Code = 562, Alpha2 = "NE", Alpha3 = "NER", NomEnGb = "Niger", NomFrFr = "Niger" },
                    new Pays { Id = 158, Code = 566, Alpha2 = "NG", Alpha3 = "NGA", NomEnGb = "Nigéria", NomFrFr = "Nigeria" },
                    new Pays { Id = 159, Code = 570, Alpha2 = "NU", Alpha3 = "NIU", NomEnGb = "Niué", NomFrFr = "Niue" },
                    new Pays { Id = 160, Code = 574, Alpha2 = "NF", Alpha3 = "NFK", NomEnGb = "Île Norfolk", NomFrFr = "Norfolk Island" },
                    new Pays { Id = 161, Code = 578, Alpha2 = "NO", Alpha3 = "NOR", NomEnGb = "Norvège", NomFrFr = "Norway" },
                    new Pays { Id = 162, Code = 580, Alpha2 = "MP", Alpha3 = "MNP", NomEnGb = "Îles Mariannes du Nord", NomFrFr = "Northern Mariana Islands" },
                    new Pays { Id = 163, Code = 581, Alpha2 = "UM", Alpha3 = "UMI", NomEnGb = "Îles Mineures Éloignées des États-Unis", NomFrFr = "United States Minor Outlying Islands" },
                    new Pays { Id = 164, Code = 583, Alpha2 = "FM", Alpha3 = "FSM", NomEnGb = "États Fédérés de Micronésie", NomFrFr = "Federated States of Micronesia" },
                    new Pays { Id = 165, Code = 584, Alpha2 = "MH", Alpha3 = "MHL", NomEnGb = "Îles Marshall", NomFrFr = "Marshall Islands" },
                    new Pays { Id = 166, Code = 585, Alpha2 = "PW", Alpha3 = "PLW", NomEnGb = "Palaos", NomFrFr = "Palau" },
                    new Pays { Id = 167, Code = 586, Alpha2 = "PK", Alpha3 = "PAK", NomEnGb = "Pakistan", NomFrFr = "Pakistan" },
                    new Pays { Id = 168, Code = 591, Alpha2 = "PA", Alpha3 = "PAN", NomEnGb = "Panama", NomFrFr = "Panama" },
                    new Pays { Id = 169, Code = 598, Alpha2 = "PG", Alpha3 = "PNG", NomEnGb = "Papouasie-Nouvelle-Guinée", NomFrFr = "Papua New Guinea" },
                    new Pays { Id = 170, Code = 600, Alpha2 = "PY", Alpha3 = "PRY", NomEnGb = "Paraguay", NomFrFr = "Paraguay" },
                    new Pays { Id = 171, Code = 604, Alpha2 = "PE", Alpha3 = "PER", NomEnGb = "Pérou", NomFrFr = "Peru" },
                    new Pays { Id = 172, Code = 608, Alpha2 = "PH", Alpha3 = "PHL", NomEnGb = "Philippines", NomFrFr = "Philippines" },
                    new Pays { Id = 173, Code = 612, Alpha2 = "PN", Alpha3 = "PCN", NomEnGb = "Pitcairn", NomFrFr = "Pitcairn" },
                    new Pays { Id = 174, Code = 616, Alpha2 = "PL", Alpha3 = "POL", NomEnGb = "Pologne", NomFrFr = "Poland" },
                    new Pays { Id = 175, Code = 620, Alpha2 = "PT", Alpha3 = "PRT", NomEnGb = "Portugal", NomFrFr = "Portugal" },
                    new Pays { Id = 176, Code = 624, Alpha2 = "GW", Alpha3 = "GNB", NomEnGb = "Guinée-Bissau", NomFrFr = "Guinea-Bissau" },
                    new Pays { Id = 177, Code = 626, Alpha2 = "TL", Alpha3 = "TLS", NomEnGb = "Timor-Leste", NomFrFr = "Timor-Leste" },
                    new Pays { Id = 178, Code = 630, Alpha2 = "PR", Alpha3 = "PRI", NomEnGb = "Porto Rico", NomFrFr = "Puerto Rico" },
                    new Pays { Id = 179, Code = 634, Alpha2 = "QA", Alpha3 = "QAT", NomEnGb = "Qatar", NomFrFr = "Qatar" },
                    new Pays { Id = 180, Code = 638, Alpha2 = "RE", Alpha3 = "REU", NomEnGb = "Réunion", NomFrFr = "Réunion" },
                    new Pays { Id = 181, Code = 642, Alpha2 = "RO", Alpha3 = "ROU", NomEnGb = "Roumanie", NomFrFr = "Romania" },
                    new Pays { Id = 182, Code = 643, Alpha2 = "RU", Alpha3 = "RUS", NomEnGb = "Fédération de Russie", NomFrFr = "Russian Federation" },
                    new Pays { Id = 183, Code = 646, Alpha2 = "RW", Alpha3 = "RWA", NomEnGb = "Rwanda", NomFrFr = "Rwanda" },
                    new Pays { Id = 184, Code = 654, Alpha2 = "SH", Alpha3 = "SHN", NomEnGb = "Sainte-Hélène", NomFrFr = "Saint Helena" },
                    new Pays { Id = 185, Code = 659, Alpha2 = "KN", Alpha3 = "KNA", NomEnGb = "Saint-Kitts-et-Nevis", NomFrFr = "Saint Kitts and Nevis" },
                    new Pays { Id = 186, Code = 660, Alpha2 = "AI", Alpha3 = "AIA", NomEnGb = "Anguilla", NomFrFr = "Anguilla" },
                    new Pays { Id = 187, Code = 662, Alpha2 = "LC", Alpha3 = "LCA", NomEnGb = "Sainte-Lucie", NomFrFr = "Saint Lucia" },
                    new Pays { Id = 188, Code = 666, Alpha2 = "PM", Alpha3 = "SPM", NomEnGb = "Saint-Pierre-et-Miquelon", NomFrFr = "Saint-Pierre and Miquelon" },
                    new Pays { Id = 189, Code = 670, Alpha2 = "VC", Alpha3 = "VCT", NomEnGb = "Saint-Vincent-et-les Grenadines", NomFrFr = "Saint Vincent and the Grenadines" },
                    new Pays { Id = 190, Code = 674, Alpha2 = "SM", Alpha3 = "SMR", NomEnGb = "Saint-Marin", NomFrFr = "San Marino" },
                    new Pays { Id = 191, Code = 678, Alpha2 = "ST", Alpha3 = "STP", NomEnGb = "Sao Tomé-et-Principe", NomFrFr = "Sao Tome and Principe" },
                    new Pays { Id = 192, Code = 682, Alpha2 = "SA", Alpha3 = "SAU", NomEnGb = "Arabie Saoudite", NomFrFr = "Saudi Arabia" },
                    new Pays { Id = 193, Code = 686, Alpha2 = "SN", Alpha3 = "SEN", NomEnGb = "Sénégal", NomFrFr = "Senegal" },
                    new Pays { Id = 194, Code = 690, Alpha2 = "SC", Alpha3 = "SYC", NomEnGb = "Seychelles", NomFrFr = "Seychelles" },
                    new Pays { Id = 195, Code = 694, Alpha2 = "SL", Alpha3 = "SLE", NomEnGb = "Sierra Leone", NomFrFr = "Sierra Leone" },
                    new Pays { Id = 196, Code = 702, Alpha2 = "SG", Alpha3 = "SGP", NomEnGb = "Singapour", NomFrFr = "Singapore" },
                    new Pays { Id = 197, Code = 703, Alpha2 = "SK", Alpha3 = "SVK", NomEnGb = "Slovaquie", NomFrFr = "Slovakia" },
                    new Pays { Id = 198, Code = 704, Alpha2 = "VN", Alpha3 = "VNM", NomEnGb = "Viet Nam", NomFrFr = "Vietnam" },
                    new Pays { Id = 199, Code = 705, Alpha2 = "SI", Alpha3 = "SVN", NomEnGb = "Slovénie", NomFrFr = "Slovenia" },
                    new Pays { Id = 200, Code = 706, Alpha2 = "SO", Alpha3 = "SOM", NomEnGb = "Somalie", NomFrFr = "Somalia" },
                    new Pays { Id = 201, Code = 710, Alpha2 = "ZA", Alpha3 = "ZAF", NomEnGb = "Afrique du Sud", NomFrFr = "South Africa" },
                    new Pays { Id = 202, Code = 716, Alpha2 = "ZW", Alpha3 = "ZWE", NomEnGb = "Zimbabwe", NomFrFr = "Zimbabwe" },
                    new Pays { Id = 203, Code = 724, Alpha2 = "ES", Alpha3 = "ESP", NomEnGb = "Espagne", NomFrFr = "Spain" },
                    new Pays { Id = 204, Code = 732, Alpha2 = "EH", Alpha3 = "ESH", NomEnGb = "Sahara Occidental", NomFrFr = "Western Sahara" },
                    new Pays { Id = 205, Code = 736, Alpha2 = "SD", Alpha3 = "SDN", NomEnGb = "Soudan", NomFrFr = "Sudan" },
                    new Pays { Id = 206, Code = 740, Alpha2 = "SR", Alpha3 = "SUR", NomEnGb = "Suriname", NomFrFr = "Suriname" },
                    new Pays { Id = 207, Code = 744, Alpha2 = "SJ", Alpha3 = "SJM", NomEnGb = "Svalbard etÎle Jan Mayen", NomFrFr = "Svalbard and Jan Mayen" },
                    new Pays { Id = 208, Code = 748, Alpha2 = "SZ", Alpha3 = "SWZ", NomEnGb = "Swaziland", NomFrFr = "Swaziland" },
                    new Pays { Id = 209, Code = 752, Alpha2 = "SE", Alpha3 = "SWE", NomEnGb = "Suède", NomFrFr = "Sweden" },
                    new Pays { Id = 210, Code = 756, Alpha2 = "CH", Alpha3 = "CHE", NomEnGb = "Suisse", NomFrFr = "Switzerland" },
                    new Pays { Id = 211, Code = 760, Alpha2 = "SY", Alpha3 = "SYR", NomEnGb = "République Arabe Syrienne", NomFrFr = "Syrian Arab Republic" },
                    new Pays { Id = 212, Code = 762, Alpha2 = "TJ", Alpha3 = "TJK", NomEnGb = "Tadjikistan", NomFrFr = "Tajikistan" },
                    new Pays { Id = 213, Code = 764, Alpha2 = "TH", Alpha3 = "THA", NomEnGb = "Thaïlande", NomFrFr = "Thailand" },
                    new Pays { Id = 214, Code = 768, Alpha2 = "TG", Alpha3 = "TGO", NomEnGb = "Togo", NomFrFr = "Togo" },
                    new Pays { Id = 215, Code = 772, Alpha2 = "TK", Alpha3 = "TKL", NomEnGb = "Tokelau", NomFrFr = "Tokelau" },
                    new Pays { Id = 216, Code = 776, Alpha2 = "TO", Alpha3 = "TON", NomEnGb = "Tonga", NomFrFr = "Tonga" },
                    new Pays { Id = 217, Code = 780, Alpha2 = "TT", Alpha3 = "TTO", NomEnGb = "Trinité-et-Tobago", NomFrFr = "Trinidad and Tobago" },
                    new Pays { Id = 218, Code = 784, Alpha2 = "AE", Alpha3 = "ARE", NomEnGb = "Émirats Arabes Unis", NomFrFr = "United Arab Emirates" },
                    new Pays { Id = 219, Code = 788, Alpha2 = "TN", Alpha3 = "TUN", NomEnGb = "Tunisie", NomFrFr = "Tunisia" },
                    new Pays { Id = 220, Code = 792, Alpha2 = "TR", Alpha3 = "TUR", NomEnGb = "Turquie", NomFrFr = "Turkey" },
                    new Pays { Id = 221, Code = 795, Alpha2 = "TM", Alpha3 = "TKM", NomEnGb = "Turkménistan", NomFrFr = "Turkmenistan" },
                    new Pays { Id = 222, Code = 796, Alpha2 = "TC", Alpha3 = "TCA", NomEnGb = "Îles Turks et Caïques", NomFrFr = "Turks and Caicos Islands" },
                    new Pays { Id = 223, Code = 798, Alpha2 = "TV", Alpha3 = "TUV", NomEnGb = "Tuvalu", NomFrFr = "Tuvalu" },
                    new Pays { Id = 224, Code = 800, Alpha2 = "UG", Alpha3 = "UGA", NomEnGb = "Ouganda", NomFrFr = "Uganda" },
                    new Pays { Id = 225, Code = 804, Alpha2 = "UA", Alpha3 = "UKR", NomEnGb = "Ukraine", NomFrFr = "Ukraine" },
                    new Pays { Id = 226, Code = 807, Alpha2 = "MK", Alpha3 = "MKD", NomEnGb = "L'ex-République Yougoslave de Macédoine", NomFrFr = "The Former Yugoslav Republic of Macedonia" },
                    new Pays { Id = 227, Code = 818, Alpha2 = "EG", Alpha3 = "EGY", NomEnGb = "Égypte", NomFrFr = "Egypt" },
                    new Pays { Id = 228, Code = 826, Alpha2 = "GB", Alpha3 = "GBR", NomEnGb = "Royaume-Uni", NomFrFr = "United Kingdom" },
                    new Pays { Id = 229, Code = 833, Alpha2 = "IM", Alpha3 = "IMN", NomEnGb = "Île de Man", NomFrFr = "Isle of Man" },
                    new Pays { Id = 230, Code = 834, Alpha2 = "TZ", Alpha3 = "TZA", NomEnGb = "République-Unie de Tanzanie", NomFrFr = "United Republic Of Tanzania" },
                    new Pays { Id = 231, Code = 840, Alpha2 = "US", Alpha3 = "USA", NomEnGb = "États-Unis", NomFrFr = "United States" },
                    new Pays { Id = 232, Code = 850, Alpha2 = "VI", Alpha3 = "VIR", NomEnGb = "Îles Vierges des États-Unis", NomFrFr = "U.S. Virgin Islands" },
                    new Pays { Id = 233, Code = 854, Alpha2 = "BF", Alpha3 = "BFA", NomEnGb = "Burkina Faso", NomFrFr = "Burkina Faso" },
                    new Pays { Id = 234, Code = 858, Alpha2 = "UY", Alpha3 = "URY", NomEnGb = "Uruguay", NomFrFr = "Uruguay" },
                    new Pays { Id = 235, Code = 860, Alpha2 = "UZ", Alpha3 = "UZB", NomEnGb = "Ouzbékistan", NomFrFr = "Uzbekistan" },
                    new Pays { Id = 236, Code = 862, Alpha2 = "VE", Alpha3 = "VEN", NomEnGb = "Venezuela", NomFrFr = "Venezuela" },
                    new Pays { Id = 237, Code = 876, Alpha2 = "WF", Alpha3 = "WLF", NomEnGb = "Wallis et Futuna", NomFrFr = "Wallis and Futuna" },
                    new Pays { Id = 238, Code = 882, Alpha2 = "WS", Alpha3 = "WSM", NomEnGb = "Samoa", NomFrFr = "Samoa" },
                    new Pays { Id = 239, Code = 887, Alpha2 = "YE", Alpha3 = "YEM", NomEnGb = "Yémen", NomFrFr = "Yemen" },
                    new Pays { Id = 240, Code = 891, Alpha2 = "CS", Alpha3 = "SCG", NomEnGb = "Serbie-et-Monténégro", NomFrFr = "Serbia and Montenegro" },
                    new Pays { Id = 241, Code = 894, Alpha2 = "ZM", Alpha3 = "ZMB", NomEnGb = "Zambie", NomFrFr = "Zambia" }
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
