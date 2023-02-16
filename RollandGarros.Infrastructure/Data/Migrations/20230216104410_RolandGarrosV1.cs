using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RolandGarros.Data.Migrations
{
    public partial class RolandGarrosV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Alpha2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alpha3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomEnGb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomFrFr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arbitres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NationaliteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arbitres_Pays_NationaliteId",
                        column: x => x.NationaliteId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Joueurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sexe = table.Column<int>(type: "int", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Classement = table.Column<int>(type: "int", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NationaliteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joueurs_Pays_NationaliteId",
                        column: x => x.NationaliteId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifiant = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NationaliteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organisateurs_Pays_NationaliteId",
                        column: x => x.NationaliteId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SousTournois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GagnantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousTournois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SousTournois_Joueurs_GagnantId",
                        column: x => x.GagnantId,
                        principalTable: "Joueurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Joueur1Id = table.Column<int>(type: "int", nullable: true),
                    Joueur2Id = table.Column<int>(type: "int", nullable: true),
                    ArbitreId = table.Column<int>(type: "int", nullable: false),
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SousTournoiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchs_Arbitres_ArbitreId",
                        column: x => x.ArbitreId,
                        principalTable: "Arbitres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matchs_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matchs_Joueurs_Joueur1Id",
                        column: x => x.Joueur1Id,
                        principalTable: "Joueurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_Joueurs_Joueur2Id",
                        column: x => x.Joueur2Id,
                        principalTable: "Joueurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_SousTournois_SousTournoiId",
                        column: x => x.SousTournoiId,
                        principalTable: "SousTournois",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Resultats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GagnantId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultats_Joueurs_GagnantId",
                        column: x => x.GagnantId,
                        principalTable: "Joueurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultats_Matchs_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matchs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Nom", "Numero" },
                values: new object[,]
                {
                    { 1, "Philippe-Chatrier", 1 },
                    { 2, "Suzanne-Lenglen", 2 }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 1, "AF", "AFG", 4, "Afghanistan", "Afghanistan" },
                    { 2, "AL", "ALB", 8, "Albanie", "Albania" },
                    { 3, "AQ", "ATA", 10, "Antarctique", "Antarctica" },
                    { 4, "DZ", "DZA", 12, "Algérie", "Algeria" },
                    { 5, "AS", "ASM", 16, "Samoa Américaines", "American Samoa" },
                    { 6, "AD", "AND", 20, "Andorre", "Andorra" },
                    { 7, "AO", "AGO", 24, "Angola", "Angola" },
                    { 8, "AG", "ATG", 28, "Antigua-et-Barbuda", "Antigua and Barbuda" },
                    { 9, "AZ", "AZE", 31, "Azerbaïdjan", "Azerbaijan" },
                    { 10, "AR", "ARG", 32, "Argentine", "Argentina" },
                    { 11, "AU", "AUS", 36, "Australie", "Australia" },
                    { 12, "AT", "AUT", 40, "Autriche", "Austria" },
                    { 13, "BS", "BHS", 44, "Bahamas", "Bahamas" },
                    { 14, "BH", "BHR", 48, "Bahreïn", "Bahrain" },
                    { 15, "BD", "BGD", 50, "Bangladesh", "Bangladesh" },
                    { 16, "AM", "ARM", 51, "Arménie", "Armenia" },
                    { 17, "BB", "BRB", 52, "Barbade", "Barbados" },
                    { 18, "BE", "BEL", 56, "Belgique", "Belgium" },
                    { 19, "BM", "BMU", 60, "Bermudes", "Bermuda" },
                    { 20, "BT", "BTN", 64, "Bhoutan", "Bhutan" },
                    { 21, "BO", "BOL", 68, "Bolivie", "Bolivia" },
                    { 22, "BA", "BIH", 70, "Bosnie-Herzégovine", "Bosnia and Herzegovina" },
                    { 23, "BW", "BWA", 72, "Botswana", "Botswana" },
                    { 24, "BV", "BVT", 74, "Île Bouvet", "Bouvet Island" },
                    { 25, "BR", "BRA", 76, "Brésil", "Brazil" },
                    { 26, "BZ", "BLZ", 84, "Belize", "Belize" },
                    { 27, "IO", "IOT", 86, "Territoire Britannique de l'Océan Indien", "British Indian Ocean Territory" },
                    { 28, "SB", "SLB", 90, "Îles Salomon", "Solomon Islands" },
                    { 29, "VG", "VGB", 92, "Îles Vierges Britanniques", "British Virgin Islands" },
                    { 30, "BN", "BRN", 96, "Brunéi Darussalam", "Brunei Darussalam" },
                    { 31, "BG", "BGR", 100, "Bulgarie", "Bulgaria" },
                    { 32, "MM", "MMR", 104, "Myanmar", "Myanmar" },
                    { 33, "BI", "BDI", 108, "Burundi", "Burundi" },
                    { 34, "BY", "BLR", 112, "Bélarus", "Belarus" },
                    { 35, "KH", "KHM", 116, "Cambodge", "Cambodia" },
                    { 36, "CM", "CMR", 120, "Cameroun", "Cameroon" },
                    { 37, "CA", "CAN", 124, "Canada", "Canada" },
                    { 38, "CV", "CPV", 132, "Cap-vert", "Cape Verde" },
                    { 39, "KY", "CYM", 136, "Îles Caïmanes", "Cayman Islands" },
                    { 40, "CF", "CAF", 140, "République Centrafricaine", "Central African" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 41, "LK", "LKA", 144, "Sri Lanka", "Sri Lanka" },
                    { 42, "TD", "TCD", 148, "Tchad", "Chad" },
                    { 43, "CL", "CHL", 152, "Chili", "Chile" },
                    { 44, "CN", "CHN", 156, "Chine", "China" },
                    { 45, "TW", "TWN", 158, "Taïwan", "Taiwan" },
                    { 46, "CX", "CXR", 162, "Île Christmas", "Christmas Island" },
                    { 47, "CC", "CCK", 166, "Îles Cocos (Keeling)", "Cocos (Keeling) Islands" },
                    { 48, "CO", "COL", 170, "Colombie", "Colombia" },
                    { 49, "KM", "COM", 174, "Comores", "Comoros" },
                    { 50, "YT", "MYT", 175, "Mayotte", "Mayotte" },
                    { 51, "CG", "COG", 178, "République du Congo", "Republic of the Congo" },
                    { 52, "CD", "COD", 180, "République Démocratique du Congo", "The Democratic Republic Of The Congo" },
                    { 53, "CK", "COK", 184, "Îles Cook", "Cook Islands" },
                    { 54, "CR", "CRI", 188, "Costa Rica", "Costa Rica" },
                    { 55, "HR", "HRV", 191, "Croatie", "Croatia" },
                    { 56, "CU", "CUB", 192, "Cuba", "Cuba" },
                    { 57, "CY", "CYP", 196, "Chypre", "Cyprus" },
                    { 58, "CZ", "CZE", 203, "République Tchèque", "Czech Republic" },
                    { 59, "BJ", "BEN", 204, "Bénin", "Benin" },
                    { 60, "DK", "DNK", 208, "Danemark", "Denmark" },
                    { 61, "DM", "DMA", 212, "Dominique", "Dominica" },
                    { 62, "DO", "DOM", 214, "République Dominicaine", "Dominican Republic" },
                    { 63, "EC", "ECU", 218, "Équateur", "Ecuador" },
                    { 64, "SV", "SLV", 222, "El Salvador", "El Salvador" },
                    { 65, "GQ", "GNQ", 226, "Guinée Équatoriale", "Equatorial Guinea" },
                    { 66, "ET", "ETH", 231, "Éthiopie", "Ethiopia" },
                    { 67, "ER", "ERI", 232, "Érythrée", "Eritrea" },
                    { 68, "EE", "EST", 233, "Estonie", "Estonia" },
                    { 69, "FO", "FRO", 234, "Îles Féroé", "Faroe Islands" },
                    { 70, "FK", "FLK", 238, "Îles (malvinas) Falkland", "Falkland Islands" },
                    { 71, "GS", "SGS", 239, "Géorgie du Sud et les Îles Sandwich du Sud", "South Georgia and the South Sandwich Islands" },
                    { 72, "FJ", "FJI", 242, "Fidji", "Fiji" },
                    { 73, "FI", "FIN", 246, "Finlande", "Finland" },
                    { 74, "AX", "ALA", 248, "Îles Åland", "Åland Islands" },
                    { 75, "FR", "FRA", 250, "France", "France" },
                    { 76, "GF", "GUF", 254, "Guyane Française", "French Guiana" },
                    { 77, "PF", "PYF", 258, "Polynésie Française", "French Polynesia" },
                    { 78, "TF", "ATF", 260, "Terres Australes Françaises", "French Southern Territories" },
                    { 79, "DJ", "DJI", 262, "Djibouti", "Djibouti" },
                    { 80, "GA", "GAB", 266, "Gabon", "Gabon" },
                    { 81, "GE", "GEO", 268, "Géorgie", "Georgia" },
                    { 82, "GM", "GMB", 270, "Gambie", "Gambia" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 83, "PS", "PSE", 275, "Territoire Palestinien Occupé", "Occupied Palestinian Territory" },
                    { 84, "DE", "DEU", 276, "Allemagne", "Germany" },
                    { 85, "GH", "GHA", 288, "Ghana", "Ghana" },
                    { 86, "GI", "GIB", 292, "Gibraltar", "Gibraltar" },
                    { 87, "KI", "KIR", 296, "Kiribati", "Kiribati" },
                    { 88, "GR", "GRC", 300, "Grèce", "Greece" },
                    { 89, "GL", "GRL", 304, "Groenland", "Greenland" },
                    { 90, "GD", "GRD", 308, "Grenade", "Grenada" },
                    { 91, "GP", "GLP", 312, "Guadeloupe", "Guadeloupe" },
                    { 92, "GU", "GUM", 316, "Guam", "Guam" },
                    { 93, "GT", "GTM", 320, "Guatemala", "Guatemala" },
                    { 94, "GN", "GIN", 324, "Guinée", "Guinea" },
                    { 95, "GY", "GUY", 328, "Guyana", "Guyana" },
                    { 96, "HT", "HTI", 332, "Haïti", "Haiti" },
                    { 97, "HM", "HMD", 334, "Îles Heard et Mcdonald", "Heard Island and McDonald Islands" },
                    { 98, "VA", "VAT", 336, "Saint-Siège (état de la Cité du Vatican)", "Vatican City State" },
                    { 99, "HN", "HND", 340, "Honduras", "Honduras" },
                    { 100, "HK", "HKG", 344, "Hong-Kong", "Hong Kong" },
                    { 101, "HU", "HUN", 348, "Hongrie", "Hungary" },
                    { 102, "IS", "ISL", 352, "Islande", "Iceland" },
                    { 103, "IN", "IND", 356, "Inde", "India" },
                    { 104, "ID", "IDN", 360, "Indonésie", "Indonesia" },
                    { 105, "IR", "IRN", 364, "République Islamique d'Iran", "Islamic Republic of Iran" },
                    { 106, "IQ", "IRQ", 368, "Iraq", "Iraq" },
                    { 107, "IE", "IRL", 372, "Irlande", "Ireland" },
                    { 108, "IL", "ISR", 376, "Israël", "Israel" },
                    { 109, "IT", "ITA", 380, "Italie", "Italy" },
                    { 110, "CI", "CIV", 384, "Côte d'Ivoire", "Côte d'Ivoire" },
                    { 111, "JM", "JAM", 388, "Jamaïque", "Jamaica" },
                    { 112, "JP", "JPN", 392, "Japon", "Japan" },
                    { 113, "KZ", "KAZ", 398, "Kazakhstan", "Kazakhstan" },
                    { 114, "JO", "JOR", 400, "Jordanie", "Jordan" },
                    { 115, "KE", "KEN", 404, "Kenya", "Kenya" },
                    { 116, "KP", "PRK", 408, "République Populaire Démocratique de Corée", "Democratic People's Republic of Korea" },
                    { 117, "KR", "KOR", 410, "République de Corée", "Republic of Korea" },
                    { 118, "KW", "KWT", 414, "Koweït", "Kuwait" },
                    { 119, "KG", "KGZ", 417, "Kirghizistan", "Kyrgyzstan" },
                    { 120, "LA", "LAO", 418, "République Démocratique Populaire Lao", "Lao People's Democratic Republic" },
                    { 121, "LB", "LBN", 422, "Liban", "Lebanon" },
                    { 122, "LS", "LSO", 426, "Lesotho", "Lesotho" },
                    { 123, "LV", "LVA", 428, "Lettonie", "Latvia" },
                    { 124, "LR", "LBR", 430, "Libéria", "Liberia" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 125, "LY", "LBY", 434, "Jamahiriya Arabe Libyenne", "Libyan Arab Jamahiriya" },
                    { 126, "LI", "LIE", 438, "Liechtenstein", "Liechtenstein" },
                    { 127, "LT", "LTU", 440, "Lituanie", "Lithuania" },
                    { 128, "LU", "LUX", 442, "Luxembourg", "Luxembourg" },
                    { 129, "MO", "MAC", 446, "Macao", "Macao" },
                    { 130, "MG", "MDG", 450, "Madagascar", "Madagascar" },
                    { 131, "MW", "MWI", 454, "Malawi", "Malawi" },
                    { 132, "MY", "MYS", 458, "Malaisie", "Malaysia" },
                    { 133, "MV", "MDV", 462, "Maldives", "Maldives" },
                    { 134, "ML", "MLI", 466, "Mali", "Mali" },
                    { 135, "MT", "MLT", 470, "Malte", "Malta" },
                    { 136, "MQ", "MTQ", 474, "Martinique", "Martinique" },
                    { 137, "MR", "MRT", 478, "Mauritanie", "Mauritania" },
                    { 138, "MU", "MUS", 480, "Maurice", "Mauritius" },
                    { 139, "MX", "MEX", 484, "Mexique", "Mexico" },
                    { 140, "MC", "MCO", 492, "Monaco", "Monaco" },
                    { 141, "MN", "MNG", 496, "Mongolie", "Mongolia" },
                    { 142, "MD", "MDA", 498, "République de Moldova", "Republic of Moldova" },
                    { 143, "MS", "MSR", 500, "Montserrat", "Montserrat" },
                    { 144, "MA", "MAR", 504, "Maroc", "Morocco" },
                    { 145, "MZ", "MOZ", 508, "Mozambique", "Mozambique" },
                    { 146, "OM", "OMN", 512, "Oman", "Oman" },
                    { 147, "NA", "NAM", 516, "Namibie", "Namibia" },
                    { 148, "NR", "NRU", 520, "Nauru", "Nauru" },
                    { 149, "NP", "NPL", 524, "Népal", "Nepal" },
                    { 150, "NL", "NLD", 528, "Pays-Bas", "Netherlands" },
                    { 151, "AN", "ANT", 530, "Antilles Néerlandaises", "Netherlands Antilles" },
                    { 152, "AW", "ABW", 533, "Aruba", "Aruba" },
                    { 153, "NC", "NCL", 540, "Nouvelle-Calédonie", "New Caledonia" },
                    { 154, "VU", "VUT", 548, "Vanuatu", "Vanuatu" },
                    { 155, "NZ", "NZL", 554, "Nouvelle-Zélande", "New Zealand" },
                    { 156, "NI", "NIC", 558, "Nicaragua", "Nicaragua" },
                    { 157, "NE", "NER", 562, "Niger", "Niger" },
                    { 158, "NG", "NGA", 566, "Nigéria", "Nigeria" },
                    { 159, "NU", "NIU", 570, "Niué", "Niue" },
                    { 160, "NF", "NFK", 574, "Île Norfolk", "Norfolk Island" },
                    { 161, "NO", "NOR", 578, "Norvège", "Norway" },
                    { 162, "MP", "MNP", 580, "Îles Mariannes du Nord", "Northern Mariana Islands" },
                    { 163, "UM", "UMI", 581, "Îles Mineures Éloignées des États-Unis", "United States Minor Outlying Islands" },
                    { 164, "FM", "FSM", 583, "États Fédérés de Micronésie", "Federated States of Micronesia" },
                    { 165, "MH", "MHL", 584, "Îles Marshall", "Marshall Islands" },
                    { 166, "PW", "PLW", 585, "Palaos", "Palau" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 167, "PK", "PAK", 586, "Pakistan", "Pakistan" },
                    { 168, "PA", "PAN", 591, "Panama", "Panama" },
                    { 169, "PG", "PNG", 598, "Papouasie-Nouvelle-Guinée", "Papua New Guinea" },
                    { 170, "PY", "PRY", 600, "Paraguay", "Paraguay" },
                    { 171, "PE", "PER", 604, "Pérou", "Peru" },
                    { 172, "PH", "PHL", 608, "Philippines", "Philippines" },
                    { 173, "PN", "PCN", 612, "Pitcairn", "Pitcairn" },
                    { 174, "PL", "POL", 616, "Pologne", "Poland" },
                    { 175, "PT", "PRT", 620, "Portugal", "Portugal" },
                    { 176, "GW", "GNB", 624, "Guinée-Bissau", "Guinea-Bissau" },
                    { 177, "TL", "TLS", 626, "Timor-Leste", "Timor-Leste" },
                    { 178, "PR", "PRI", 630, "Porto Rico", "Puerto Rico" },
                    { 179, "QA", "QAT", 634, "Qatar", "Qatar" },
                    { 180, "RE", "REU", 638, "Réunion", "Réunion" },
                    { 181, "RO", "ROU", 642, "Roumanie", "Romania" },
                    { 182, "RU", "RUS", 643, "Fédération de Russie", "Russian Federation" },
                    { 183, "RW", "RWA", 646, "Rwanda", "Rwanda" },
                    { 184, "SH", "SHN", 654, "Sainte-Hélène", "Saint Helena" },
                    { 185, "KN", "KNA", 659, "Saint-Kitts-et-Nevis", "Saint Kitts and Nevis" },
                    { 186, "AI", "AIA", 660, "Anguilla", "Anguilla" },
                    { 187, "LC", "LCA", 662, "Sainte-Lucie", "Saint Lucia" },
                    { 188, "PM", "SPM", 666, "Saint-Pierre-et-Miquelon", "Saint-Pierre and Miquelon" },
                    { 189, "VC", "VCT", 670, "Saint-Vincent-et-les Grenadines", "Saint Vincent and the Grenadines" },
                    { 190, "SM", "SMR", 674, "Saint-Marin", "San Marino" },
                    { 191, "ST", "STP", 678, "Sao Tomé-et-Principe", "Sao Tome and Principe" },
                    { 192, "SA", "SAU", 682, "Arabie Saoudite", "Saudi Arabia" },
                    { 193, "SN", "SEN", 686, "Sénégal", "Senegal" },
                    { 194, "SC", "SYC", 690, "Seychelles", "Seychelles" },
                    { 195, "SL", "SLE", 694, "Sierra Leone", "Sierra Leone" },
                    { 196, "SG", "SGP", 702, "Singapour", "Singapore" },
                    { 197, "SK", "SVK", 703, "Slovaquie", "Slovakia" },
                    { 198, "VN", "VNM", 704, "Viet Nam", "Vietnam" },
                    { 199, "SI", "SVN", 705, "Slovénie", "Slovenia" },
                    { 200, "SO", "SOM", 706, "Somalie", "Somalia" },
                    { 201, "ZA", "ZAF", 710, "Afrique du Sud", "South Africa" },
                    { 202, "ZW", "ZWE", 716, "Zimbabwe", "Zimbabwe" },
                    { 203, "ES", "ESP", 724, "Espagne", "Spain" },
                    { 204, "EH", "ESH", 732, "Sahara Occidental", "Western Sahara" },
                    { 205, "SD", "SDN", 736, "Soudan", "Sudan" },
                    { 206, "SR", "SUR", 740, "Suriname", "Suriname" },
                    { 207, "SJ", "SJM", 744, "Svalbard etÎle Jan Mayen", "Svalbard and Jan Mayen" },
                    { 208, "SZ", "SWZ", 748, "Swaziland", "Swaziland" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 209, "SE", "SWE", 752, "Suède", "Sweden" },
                    { 210, "CH", "CHE", 756, "Suisse", "Switzerland" },
                    { 211, "SY", "SYR", 760, "République Arabe Syrienne", "Syrian Arab Republic" },
                    { 212, "TJ", "TJK", 762, "Tadjikistan", "Tajikistan" },
                    { 213, "TH", "THA", 764, "Thaïlande", "Thailand" },
                    { 214, "TG", "TGO", 768, "Togo", "Togo" },
                    { 215, "TK", "TKL", 772, "Tokelau", "Tokelau" },
                    { 216, "TO", "TON", 776, "Tonga", "Tonga" },
                    { 217, "TT", "TTO", 780, "Trinité-et-Tobago", "Trinidad and Tobago" },
                    { 218, "AE", "ARE", 784, "Émirats Arabes Unis", "United Arab Emirates" },
                    { 219, "TN", "TUN", 788, "Tunisie", "Tunisia" },
                    { 220, "TR", "TUR", 792, "Turquie", "Turkey" },
                    { 221, "TM", "TKM", 795, "Turkménistan", "Turkmenistan" },
                    { 222, "TC", "TCA", 796, "Îles Turks et Caïques", "Turks and Caicos Islands" },
                    { 223, "TV", "TUV", 798, "Tuvalu", "Tuvalu" },
                    { 224, "UG", "UGA", 800, "Ouganda", "Uganda" },
                    { 225, "UA", "UKR", 804, "Ukraine", "Ukraine" },
                    { 226, "MK", "MKD", 807, "L'ex-République Yougoslave de Macédoine", "The Former Yugoslav Republic of Macedonia" },
                    { 227, "EG", "EGY", 818, "Égypte", "Egypt" },
                    { 228, "GB", "GBR", 826, "Royaume-Uni", "United Kingdom" },
                    { 229, "IM", "IMN", 833, "Île de Man", "Isle of Man" },
                    { 230, "TZ", "TZA", 834, "République-Unie de Tanzanie", "United Republic Of Tanzania" },
                    { 231, "US", "USA", 840, "États-Unis", "United States" },
                    { 232, "VI", "VIR", 850, "Îles Vierges des États-Unis", "U.S. Virgin Islands" },
                    { 233, "BF", "BFA", 854, "Burkina Faso", "Burkina Faso" },
                    { 234, "UY", "URY", 858, "Uruguay", "Uruguay" },
                    { 235, "UZ", "UZB", 860, "Ouzbékistan", "Uzbekistan" },
                    { 236, "VE", "VEN", 862, "Venezuela", "Venezuela" },
                    { 237, "WF", "WLF", 876, "Wallis et Futuna", "Wallis and Futuna" },
                    { 238, "WS", "WSM", 882, "Samoa", "Samoa" },
                    { 239, "YE", "YEM", 887, "Yémen", "Yemen" },
                    { 240, "CS", "SCG", 891, "Serbie-et-Monténégro", "Serbia and Montenegro" },
                    { 241, "ZM", "ZMB", 894, "Zambie", "Zambia" }
                });

            migrationBuilder.InsertData(
                table: "SousTournois",
                columns: new[] { "Id", "DateDebut", "DateFin", "GagnantId", "Nom" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Coupe des mousquetaires" },
                    { 2, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Coupe Suzanne Leglen" }
                });

            migrationBuilder.InsertData(
                table: "Arbitres",
                columns: new[] { "Id", "NationaliteId", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 1, 1, "Dujardin", "François" },
                    { 2, 2, "Al Kashi", "Youssef" }
                });

            migrationBuilder.InsertData(
                table: "Joueurs",
                columns: new[] { "Id", "Classement", "DateNaissance", "NationaliteId", "Nom", "Prenom", "Sexe" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1983, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Rihane", "Youcef", 0 },
                    { 2, null, new DateTime(1986, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, "Monfils", "Gaël", 0 },
                    { 3, null, new DateTime(1995, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Mertens", "Elise", 1 },
                    { 4, null, new DateTime(1994, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, "Garcia", "Caroline", 1 }
                });

            migrationBuilder.InsertData(
                table: "Matchs",
                columns: new[] { "Id", "ArbitreId", "CourtId", "Date", "Joueur1Id", "Joueur2Id", "SousTournoiId" },
                values: new object[] { 1, 1, 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "Matchs",
                columns: new[] { "Id", "ArbitreId", "CourtId", "Date", "Joueur1Id", "Joueur2Id", "SousTournoiId" },
                values: new object[] { 2, 2, 2, new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Arbitres_NationaliteId",
                table: "Arbitres",
                column: "NationaliteId");

            migrationBuilder.CreateIndex(
                name: "IX_Joueurs_NationaliteId",
                table: "Joueurs",
                column: "NationaliteId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_ArbitreId",
                table: "Matchs",
                column: "ArbitreId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_CourtId",
                table: "Matchs",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_Joueur1Id",
                table: "Matchs",
                column: "Joueur1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_Joueur2Id",
                table: "Matchs",
                column: "Joueur2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_SousTournoiId",
                table: "Matchs",
                column: "SousTournoiId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisateurs_NationaliteId",
                table: "Organisateurs",
                column: "NationaliteId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultats_GagnantId",
                table: "Resultats",
                column: "GagnantId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultats_MatchId",
                table: "Resultats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_SousTournois_GagnantId",
                table: "SousTournois",
                column: "GagnantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organisateurs");

            migrationBuilder.DropTable(
                name: "Resultats");

            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "Arbitres");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "SousTournois");

            migrationBuilder.DropTable(
                name: "Joueurs");

            migrationBuilder.DropTable(
                name: "Pays");
        }
    }
}
