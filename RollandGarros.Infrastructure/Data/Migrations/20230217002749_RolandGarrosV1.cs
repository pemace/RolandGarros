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
                    NationaliteId = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    NationaliteId = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    NationaliteId = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    { 2, "AL", "ALB", 8, "Albania", "Albanie" },
                    { 3, "AQ", "ATA", 10, "Antarctica", "Antarctique" },
                    { 4, "DZ", "DZA", 12, "Algeria", "Algérie" },
                    { 5, "AS", "ASM", 16, "American Samoa", "Samoa Américaines" },
                    { 6, "AD", "AND", 20, "Andorra", "Andorre" },
                    { 7, "AO", "AGO", 24, "Angola", "Angola" },
                    { 8, "AG", "ATG", 28, "Antigua and Barbuda", "Antigua-et-Barbuda" },
                    { 9, "AZ", "AZE", 31, "Azerbaijan", "Azerbaïdjan" },
                    { 10, "AR", "ARG", 32, "Argentina", "Argentine" },
                    { 11, "AU", "AUS", 36, "Australia", "Australie" },
                    { 12, "AT", "AUT", 40, "Austria", "Autriche" },
                    { 13, "BS", "BHS", 44, "Bahamas", "Bahamas" },
                    { 14, "BH", "BHR", 48, "Bahrain", "Bahreïn" },
                    { 15, "BD", "BGD", 50, "Bangladesh", "Bangladesh" },
                    { 16, "AM", "ARM", 51, "Armenia", "Arménie" },
                    { 17, "BB", "BRB", 52, "Barbados", "Barbade" },
                    { 18, "BE", "BEL", 56, "Belgium", "Belgique" },
                    { 19, "BM", "BMU", 60, "Bermuda", "Bermudes" },
                    { 20, "BT", "BTN", 64, "Bhutan", "Bhoutan" },
                    { 21, "BO", "BOL", 68, "Bolivia", "Bolivie" },
                    { 22, "BA", "BIH", 70, "Bosnia and Herzegovina", "Bosnie-Herzégovine" },
                    { 23, "BW", "BWA", 72, "Botswana", "Botswana" },
                    { 24, "BV", "BVT", 74, "Bouvet Island", "Île Bouvet" },
                    { 25, "BR", "BRA", 76, "Brazil", "Brésil" },
                    { 26, "BZ", "BLZ", 84, "Belize", "Belize" },
                    { 27, "IO", "IOT", 86, "British Indian Ocean Territory", "Territoire Britannique de l'Océan Indien" },
                    { 28, "SB", "SLB", 90, "Solomon Islands", "Îles Salomon" },
                    { 29, "VG", "VGB", 92, "British Virgin Islands", "Îles Vierges Britanniques" },
                    { 30, "BN", "BRN", 96, "Brunei Darussalam", "Brunéi Darussalam" },
                    { 31, "BG", "BGR", 100, "Bulgaria", "Bulgarie" },
                    { 32, "MM", "MMR", 104, "Myanmar", "Myanmar" },
                    { 33, "BI", "BDI", 108, "Burundi", "Burundi" },
                    { 34, "BY", "BLR", 112, "Belarus", "Bélarus" },
                    { 35, "KH", "KHM", 116, "Cambodia", "Cambodge" },
                    { 36, "CM", "CMR", 120, "Cameroon", "Cameroun" },
                    { 37, "CA", "CAN", 124, "Canada", "Canada" },
                    { 38, "CV", "CPV", 132, "Cape Verde", "Cap-vert" },
                    { 39, "KY", "CYM", 136, "Cayman Islands", "Îles Caïmanes" },
                    { 40, "CF", "CAF", 140, "Central African", "République Centrafricaine" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 41, "LK", "LKA", 144, "Sri Lanka", "Sri Lanka" },
                    { 42, "TD", "TCD", 148, "Chad", "Tchad" },
                    { 43, "CL", "CHL", 152, "Chile", "Chili" },
                    { 44, "CN", "CHN", 156, "China", "Chine" },
                    { 45, "TW", "TWN", 158, "Taiwan", "Taïwan" },
                    { 46, "CX", "CXR", 162, "Christmas Island", "Île Christmas" },
                    { 47, "CC", "CCK", 166, "Cocos (Keeling) Islands", "Îles Cocos (Keeling)" },
                    { 48, "CO", "COL", 170, "Colombia", "Colombie" },
                    { 49, "KM", "COM", 174, "Comoros", "Comores" },
                    { 50, "YT", "MYT", 175, "Mayotte", "Mayotte" },
                    { 51, "CG", "COG", 178, "Republic of the Congo", "République du Congo" },
                    { 52, "CD", "COD", 180, "The Democratic Republic Of The Congo", "République Démocratique du Congo" },
                    { 53, "CK", "COK", 184, "Cook Islands", "Îles Cook" },
                    { 54, "CR", "CRI", 188, "Costa Rica", "Costa Rica" },
                    { 55, "HR", "HRV", 191, "Croatia", "Croatie" },
                    { 56, "CU", "CUB", 192, "Cuba", "Cuba" },
                    { 57, "CY", "CYP", 196, "Cyprus", "Chypre" },
                    { 58, "CZ", "CZE", 203, "Czech Republic", "République Tchèque" },
                    { 59, "BJ", "BEN", 204, "Benin", "Bénin" },
                    { 60, "DK", "DNK", 208, "Denmark", "Danemark" },
                    { 61, "DM", "DMA", 212, "Dominica", "Dominique" },
                    { 62, "DO", "DOM", 214, "Dominican Republic", "République Dominicaine" },
                    { 63, "EC", "ECU", 218, "Ecuador", "Équateur" },
                    { 64, "SV", "SLV", 222, "El Salvador", "El Salvador" },
                    { 65, "GQ", "GNQ", 226, "Equatorial Guinea", "Guinée Équatoriale" },
                    { 66, "ET", "ETH", 231, "Ethiopia", "Éthiopie" },
                    { 67, "ER", "ERI", 232, "Eritrea", "Érythrée" },
                    { 68, "EE", "EST", 233, "Estonia", "Estonie" },
                    { 69, "FO", "FRO", 234, "Faroe Islands", "Îles Féroé" },
                    { 70, "FK", "FLK", 238, "Falkland Islands", "Îles (malvinas) Falkland" },
                    { 71, "GS", "SGS", 239, "South Georgia and the South Sandwich Islands", "Géorgie du Sud et les Îles Sandwich du Sud" },
                    { 72, "FJ", "FJI", 242, "Fiji", "Fidji" },
                    { 73, "FI", "FIN", 246, "Finland", "Finlande" },
                    { 74, "AX", "ALA", 248, "Åland Islands", "Îles Åland" },
                    { 75, "FR", "FRA", 250, "France", "France" },
                    { 76, "GF", "GUF", 254, "French Guiana", "Guyane Française" },
                    { 77, "PF", "PYF", 258, "French Polynesia", "Polynésie Française" },
                    { 78, "TF", "ATF", 260, "French Southern Territories", "Terres Australes Françaises" },
                    { 79, "DJ", "DJI", 262, "Djibouti", "Djibouti" },
                    { 80, "GA", "GAB", 266, "Gabon", "Gabon" },
                    { 81, "GE", "GEO", 268, "Georgia", "Géorgie" },
                    { 82, "GM", "GMB", 270, "Gambia", "Gambie" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 83, "PS", "PSE", 275, "Occupied Palestinian Territory", "Territoire Palestinien Occupé" },
                    { 84, "DE", "DEU", 276, "Germany", "Allemagne" },
                    { 85, "GH", "GHA", 288, "Ghana", "Ghana" },
                    { 86, "GI", "GIB", 292, "Gibraltar", "Gibraltar" },
                    { 87, "KI", "KIR", 296, "Kiribati", "Kiribati" },
                    { 88, "GR", "GRC", 300, "Greece", "Grèce" },
                    { 89, "GL", "GRL", 304, "Greenland", "Groenland" },
                    { 90, "GD", "GRD", 308, "Grenada", "Grenade" },
                    { 91, "GP", "GLP", 312, "Guadeloupe", "Guadeloupe" },
                    { 92, "GU", "GUM", 316, "Guam", "Guam" },
                    { 93, "GT", "GTM", 320, "Guatemala", "Guatemala" },
                    { 94, "GN", "GIN", 324, "Guinea", "Guinée" },
                    { 95, "GY", "GUY", 328, "Guyana", "Guyana" },
                    { 96, "HT", "HTI", 332, "Haiti", "Haïti" },
                    { 97, "HM", "HMD", 334, "Heard Island and McDonald Islands", "Îles Heard et Mcdonald" },
                    { 98, "VA", "VAT", 336, "Vatican City State", "Saint-Siège (état de la Cité du Vatican)" },
                    { 99, "HN", "HND", 340, "Honduras", "Honduras" },
                    { 100, "HK", "HKG", 344, "Hong Kong", "Hong-Kong" },
                    { 101, "HU", "HUN", 348, "Hungary", "Hongrie" },
                    { 102, "IS", "ISL", 352, "Iceland", "Islande" },
                    { 103, "IN", "IND", 356, "India", "Inde" },
                    { 104, "ID", "IDN", 360, "Indonesia", "Indonésie" },
                    { 105, "IR", "IRN", 364, "Islamic Republic of Iran", "République Islamique d'Iran" },
                    { 106, "IQ", "IRQ", 368, "Iraq", "Iraq" },
                    { 107, "IE", "IRL", 372, "Ireland", "Irlande" },
                    { 108, "IL", "ISR", 376, "Israel", "Israël" },
                    { 109, "IT", "ITA", 380, "Italy", "Italie" },
                    { 110, "CI", "CIV", 384, "Côte d'Ivoire", "Côte d'Ivoire" },
                    { 111, "JM", "JAM", 388, "Jamaica", "Jamaïque" },
                    { 112, "JP", "JPN", 392, "Japan", "Japon" },
                    { 113, "KZ", "KAZ", 398, "Kazakhstan", "Kazakhstan" },
                    { 114, "JO", "JOR", 400, "Jordan", "Jordanie" },
                    { 115, "KE", "KEN", 404, "Kenya", "Kenya" },
                    { 116, "KP", "PRK", 408, "Democratic People's Republic of Korea", "République Populaire Démocratique de Corée" },
                    { 117, "KR", "KOR", 410, "Republic of Korea", "République de Corée" },
                    { 118, "KW", "KWT", 414, "Kuwait", "Koweït" },
                    { 119, "KG", "KGZ", 417, "Kyrgyzstan", "Kirghizistan" },
                    { 120, "LA", "LAO", 418, "Lao People's Democratic Republic", "République Démocratique Populaire Lao" },
                    { 121, "LB", "LBN", 422, "Lebanon", "Liban" },
                    { 122, "LS", "LSO", 426, "Lesotho", "Lesotho" },
                    { 123, "LV", "LVA", 428, "Latvia", "Lettonie" },
                    { 124, "LR", "LBR", 430, "Liberia", "Libéria" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 125, "LY", "LBY", 434, "Libyan Arab Jamahiriya", "Jamahiriya Arabe Libyenne" },
                    { 126, "LI", "LIE", 438, "Liechtenstein", "Liechtenstein" },
                    { 127, "LT", "LTU", 440, "Lithuania", "Lituanie" },
                    { 128, "LU", "LUX", 442, "Luxembourg", "Luxembourg" },
                    { 129, "MO", "MAC", 446, "Macao", "Macao" },
                    { 130, "MG", "MDG", 450, "Madagascar", "Madagascar" },
                    { 131, "MW", "MWI", 454, "Malawi", "Malawi" },
                    { 132, "MY", "MYS", 458, "Malaysia", "Malaisie" },
                    { 133, "MV", "MDV", 462, "Maldives", "Maldives" },
                    { 134, "ML", "MLI", 466, "Mali", "Mali" },
                    { 135, "MT", "MLT", 470, "Malta", "Malte" },
                    { 136, "MQ", "MTQ", 474, "Martinique", "Martinique" },
                    { 137, "MR", "MRT", 478, "Mauritania", "Mauritanie" },
                    { 138, "MU", "MUS", 480, "Mauritius", "Maurice" },
                    { 139, "MX", "MEX", 484, "Mexico", "Mexique" },
                    { 140, "MC", "MCO", 492, "Monaco", "Monaco" },
                    { 141, "MN", "MNG", 496, "Mongolia", "Mongolie" },
                    { 142, "MD", "MDA", 498, "Republic of Moldova", "République de Moldova" },
                    { 143, "MS", "MSR", 500, "Montserrat", "Montserrat" },
                    { 144, "MA", "MAR", 504, "Morocco", "Maroc" },
                    { 145, "MZ", "MOZ", 508, "Mozambique", "Mozambique" },
                    { 146, "OM", "OMN", 512, "Oman", "Oman" },
                    { 147, "NA", "NAM", 516, "Namibia", "Namibie" },
                    { 148, "NR", "NRU", 520, "Nauru", "Nauru" },
                    { 149, "NP", "NPL", 524, "Nepal", "Népal" },
                    { 150, "NL", "NLD", 528, "Netherlands", "Pays-Bas" },
                    { 151, "AN", "ANT", 530, "Netherlands Antilles", "Antilles Néerlandaises" },
                    { 152, "AW", "ABW", 533, "Aruba", "Aruba" },
                    { 153, "NC", "NCL", 540, "New Caledonia", "Nouvelle-Calédonie" },
                    { 154, "VU", "VUT", 548, "Vanuatu", "Vanuatu" },
                    { 155, "NZ", "NZL", 554, "New Zealand", "Nouvelle-Zélande" },
                    { 156, "NI", "NIC", 558, "Nicaragua", "Nicaragua" },
                    { 157, "NE", "NER", 562, "Niger", "Niger" },
                    { 158, "NG", "NGA", 566, "Nigeria", "Nigéria" },
                    { 159, "NU", "NIU", 570, "Niue", "Niué" },
                    { 160, "NF", "NFK", 574, "Norfolk Island", "Île Norfolk" },
                    { 161, "NO", "NOR", 578, "Norway", "Norvège" },
                    { 162, "MP", "MNP", 580, "Northern Mariana Islands", "Îles Mariannes du Nord" },
                    { 163, "UM", "UMI", 581, "United States Minor Outlying Islands", "Îles Mineures Éloignées des États-Unis" },
                    { 164, "FM", "FSM", 583, "Federated States of Micronesia", "États Fédérés de Micronésie" },
                    { 165, "MH", "MHL", 584, "Marshall Islands", "Îles Marshall" },
                    { 166, "PW", "PLW", 585, "Palau", "Palaos" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 167, "PK", "PAK", 586, "Pakistan", "Pakistan" },
                    { 168, "PA", "PAN", 591, "Panama", "Panama" },
                    { 169, "PG", "PNG", 598, "Papua New Guinea", "Papouasie-Nouvelle-Guinée" },
                    { 170, "PY", "PRY", 600, "Paraguay", "Paraguay" },
                    { 171, "PE", "PER", 604, "Peru", "Pérou" },
                    { 172, "PH", "PHL", 608, "Philippines", "Philippines" },
                    { 173, "PN", "PCN", 612, "Pitcairn", "Pitcairn" },
                    { 174, "PL", "POL", 616, "Poland", "Pologne" },
                    { 175, "PT", "PRT", 620, "Portugal", "Portugal" },
                    { 176, "GW", "GNB", 624, "Guinea-Bissau", "Guinée-Bissau" },
                    { 177, "TL", "TLS", 626, "Timor-Leste", "Timor-Leste" },
                    { 178, "PR", "PRI", 630, "Puerto Rico", "Porto Rico" },
                    { 179, "QA", "QAT", 634, "Qatar", "Qatar" },
                    { 180, "RE", "REU", 638, "Réunion", "Réunion" },
                    { 181, "RO", "ROU", 642, "Romania", "Roumanie" },
                    { 182, "RU", "RUS", 643, "Russian Federation", "Fédération de Russie" },
                    { 183, "RW", "RWA", 646, "Rwanda", "Rwanda" },
                    { 184, "SH", "SHN", 654, "Saint Helena", "Sainte-Hélène" },
                    { 185, "KN", "KNA", 659, "Saint Kitts and Nevis", "Saint-Kitts-et-Nevis" },
                    { 186, "AI", "AIA", 660, "Anguilla", "Anguilla" },
                    { 187, "LC", "LCA", 662, "Saint Lucia", "Sainte-Lucie" },
                    { 188, "PM", "SPM", 666, "Saint-Pierre and Miquelon", "Saint-Pierre-et-Miquelon" },
                    { 189, "VC", "VCT", 670, "Saint Vincent and the Grenadines", "Saint-Vincent-et-les Grenadines" },
                    { 190, "SM", "SMR", 674, "San Marino", "Saint-Marin" },
                    { 191, "ST", "STP", 678, "Sao Tome and Principe", "Sao Tomé-et-Principe" },
                    { 192, "SA", "SAU", 682, "Saudi Arabia", "Arabie Saoudite" },
                    { 193, "SN", "SEN", 686, "Senegal", "Sénégal" },
                    { 194, "SC", "SYC", 690, "Seychelles", "Seychelles" },
                    { 195, "SL", "SLE", 694, "Sierra Leone", "Sierra Leone" },
                    { 196, "SG", "SGP", 702, "Singapore", "Singapour" },
                    { 197, "SK", "SVK", 703, "Slovakia", "Slovaquie" },
                    { 198, "VN", "VNM", 704, "Vietnam", "Viet Nam" },
                    { 199, "SI", "SVN", 705, "Slovenia", "Slovénie" },
                    { 200, "SO", "SOM", 706, "Somalia", "Somalie" },
                    { 201, "ZA", "ZAF", 710, "South Africa", "Afrique du Sud" },
                    { 202, "ZW", "ZWE", 716, "Zimbabwe", "Zimbabwe" },
                    { 203, "ES", "ESP", 724, "Spain", "Espagne" },
                    { 204, "EH", "ESH", 732, "Western Sahara", "Sahara Occidental" },
                    { 205, "SD", "SDN", 736, "Sudan", "Soudan" },
                    { 206, "SR", "SUR", 740, "Suriname", "Suriname" },
                    { 207, "SJ", "SJM", 744, "Svalbard and Jan Mayen", "Svalbard etÎle Jan Mayen" },
                    { 208, "SZ", "SWZ", 748, "Swaziland", "Swaziland" }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "NomEnGb", "NomFrFr" },
                values: new object[,]
                {
                    { 209, "SE", "SWE", 752, "Sweden", "Suède" },
                    { 210, "CH", "CHE", 756, "Switzerland", "Suisse" },
                    { 211, "SY", "SYR", 760, "Syrian Arab Republic", "République Arabe Syrienne" },
                    { 212, "TJ", "TJK", 762, "Tajikistan", "Tadjikistan" },
                    { 213, "TH", "THA", 764, "Thailand", "Thaïlande" },
                    { 214, "TG", "TGO", 768, "Togo", "Togo" },
                    { 215, "TK", "TKL", 772, "Tokelau", "Tokelau" },
                    { 216, "TO", "TON", 776, "Tonga", "Tonga" },
                    { 217, "TT", "TTO", 780, "Trinidad and Tobago", "Trinité-et-Tobago" },
                    { 218, "AE", "ARE", 784, "United Arab Emirates", "Émirats Arabes Unis" },
                    { 219, "TN", "TUN", 788, "Tunisia", "Tunisie" },
                    { 220, "TR", "TUR", 792, "Turkey", "Turquie" },
                    { 221, "TM", "TKM", 795, "Turkmenistan", "Turkménistan" },
                    { 222, "TC", "TCA", 796, "Turks and Caicos Islands", "Îles Turks et Caïques" },
                    { 223, "TV", "TUV", 798, "Tuvalu", "Tuvalu" },
                    { 224, "UG", "UGA", 800, "Uganda", "Ouganda" },
                    { 225, "UA", "UKR", 804, "Ukraine", "Ukraine" },
                    { 226, "MK", "MKD", 807, "The Former Yugoslav Republic of Macedonia", "L'ex-République Yougoslave de Macédoine" },
                    { 227, "EG", "EGY", 818, "Egypt", "Égypte" },
                    { 228, "GB", "GBR", 826, "United Kingdom", "Royaume-Uni" },
                    { 229, "IM", "IMN", 833, "Isle of Man", "Île de Man" },
                    { 230, "TZ", "TZA", 834, "United Republic Of Tanzania", "République-Unie de Tanzanie" },
                    { 231, "US", "USA", 840, "United States", "États-Unis" },
                    { 232, "VI", "VIR", 850, "U.S. Virgin Islands", "Îles Vierges des États-Unis" },
                    { 233, "BF", "BFA", 854, "Burkina Faso", "Burkina Faso" },
                    { 234, "UY", "URY", 858, "Uruguay", "Uruguay" },
                    { 235, "UZ", "UZB", 860, "Uzbekistan", "Ouzbékistan" },
                    { 236, "VE", "VEN", 862, "Venezuela", "Venezuela" },
                    { 237, "WF", "WLF", 876, "Wallis and Futuna", "Wallis et Futuna" },
                    { 238, "WS", "WSM", 882, "Samoa", "Samoa" },
                    { 239, "YE", "YEM", 887, "Yemen", "Yémen" },
                    { 240, "CS", "SCG", 891, "Serbia and Montenegro", "Serbie-et-Monténégro" },
                    { 241, "ZM", "ZMB", 894, "Zambia", "Zambie" }
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
                columns: new[] { "Id", "NationaliteId", "Nom", "PhotoUrl", "Prenom" },
                values: new object[,]
                {
                    { 1, 1, "Dujardin", null, "François" },
                    { 2, 2, "Al Kashi", null, "Youssef" }
                });

            migrationBuilder.InsertData(
                table: "Joueurs",
                columns: new[] { "Id", "Classement", "DateNaissance", "NationaliteId", "Nom", "PhotoUrl", "Prenom", "Sexe" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1983, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Rihane", "/images/profiles/rihane.jpg", "Youcef", 0 },
                    { 2, null, new DateTime(1986, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, "Monfils", "/images/profiles/monfils.png", "Gaël", 0 },
                    { 3, null, new DateTime(1995, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Mertens", "/images/profiles/mertens.webp", "Elise", 1 },
                    { 4, null, new DateTime(1994, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, "Garcia", "/images/profiles/garcia.webp", "Caroline", 1 }
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
