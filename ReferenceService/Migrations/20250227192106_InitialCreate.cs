using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReferenceService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencySign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedAt", "CurrencyCode", "CurrencySign", "DialingCode", "FlagUrl", "IsActive", "IsDeleted", "Name", "TimeZone" },
                values: new object[,]
                {
                    { 1, "AF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AFN", "؋", "+93", "https://flagsapi.com/AF/shiny/64.png", true, false, "Afghanistan", "UTC+4:30" },
                    { 2, "AL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL", "L", "+355", "https://flagsapi.com/AL/shiny/64.png", true, false, "Albania", "UTC+1" },
                    { 3, "DZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DZD", "دج", "+213", "https://flagsapi.com/DZ/shiny/64.png", true, false, "Algeria", "UTC+1" },
                    { 4, "AD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+376", "https://flagsapi.com/AD/shiny/64.png", true, false, "Andorra", "UTC+1" },
                    { 5, "AO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AOA", "Kz", "+244", "https://flagsapi.com/AO/shiny/64.png", true, false, "Angola", "UTC+1" },
                    { 6, "AR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARS", "$", "+54", "https://flagsapi.com/AR/shiny/64.png", true, false, "Argentina", "UTC-3" },
                    { 7, "AM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMD", "֏", "+374", "https://flagsapi.com/AM/shiny/64.png", true, false, "Armenia", "UTC+4" },
                    { 8, "AU", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", "$", "+61", "https://flagsapi.com/AU/shiny/64.png", true, false, "Australia", "UTC+10" },
                    { 9, "AT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+43", "https://flagsapi.com/AT/shiny/64.png", true, false, "Austria", "UTC+1" },
                    { 10, "AZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AZN", "₼", "+994", "https://flagsapi.com/AZ/shiny/64.png", true, false, "Azerbaijan", "UTC+4" },
                    { 11, "BH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BHD", ".د.ب", "+973", "https://flagsapi.com/BH/shiny/64.png", true, false, "Bahrain", "UTC+3" },
                    { 12, "BD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BDT", "৳", "+880", "https://flagsapi.com/BD/shiny/64.png", true, false, "Bangladesh", "UTC+6" },
                    { 13, "BY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BYN", "Br", "+375", "https://flagsapi.com/BY/shiny/64.png", true, false, "Belarus", "UTC+3" },
                    { 14, "BE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+32", "https://flagsapi.com/BE/shiny/64.png", true, false, "Belgium", "UTC+1" },
                    { 15, "BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRL", "R$", "+55", "https://flagsapi.com/BR/shiny/64.png", true, false, "Brazil", "UTC-3" },
                    { 16, "CA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAD", "$", "+1", "https://flagsapi.com/CA/shiny/64.png", true, false, "Canada", "UTC-5" },
                    { 17, "CN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNY", "¥", "+86", "https://flagsapi.com/CN/shiny/64.png", true, false, "China", "UTC+8" },
                    { 18, "FR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+33", "https://flagsapi.com/FR/shiny/64.png", true, false, "France", "UTC+1" },
                    { 19, "DE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+49", "https://flagsapi.com/DE/shiny/64.png", true, false, "Germany", "UTC+1" },
                    { 20, "IN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INR", "₹", "+91", "https://flagsapi.com/IN/shiny/64.png", true, false, "India", "UTC+5:30" },
                    { 21, "JP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPY", "¥", "+81", "https://flagsapi.com/JP/shiny/64.png", true, false, "Japan", "UTC+9" },
                    { 22, "US", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "$", "+1", "https://flagsapi.com/US/shiny/64.png", true, false, "United States", "UTC-5" },
                    { 23, "AG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "$", "+1-268", "https://flagsapi.com/AG/shiny/64.png", true, false, "Antigua and Barbuda", "UTC-4" },
                    { 24, "BS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BSD", "$", "+1-242", "https://flagsapi.com/BS/shiny/64.png", true, false, "Bahamas", "UTC-5" },
                    { 25, "BB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BBD", "$", "+1-246", "https://flagsapi.com/BB/shiny/64.png", true, false, "Barbados", "UTC-4" },
                    { 26, "BZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BZD", "$", "+501", "https://flagsapi.com/BZ/shiny/64.png", true, false, "Belize", "UTC-6" },
                    { 27, "BO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOB", "Bs", "+591", "https://flagsapi.com/BO/shiny/64.png", true, false, "Bolivia", "UTC-4" },
                    { 28, "BW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BWP", "P", "+267", "https://flagsapi.com/BW/shiny/64.png", true, false, "Botswana", "UTC+2" },
                    { 29, "BG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BGN", "лв", "+359", "https://flagsapi.com/BG/shiny/64.png", true, false, "Bulgaria", "UTC+2" },
                    { 30, "BF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "CFA", "+226", "https://flagsapi.com/BF/shiny/64.png", true, false, "Burkina Faso", "UTC" },
                    { 31, "BI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIF", "FBu", "+257", "https://flagsapi.com/BI/shiny/64.png", true, false, "Burundi", "UTC+2" },
                    { 32, "KH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KHR", "៛", "+855", "https://flagsapi.com/KH/shiny/64.png", true, false, "Cambodia", "UTC+7" },
                    { 33, "CM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "FCFA", "+237", "https://flagsapi.com/CM/shiny/64.png", true, false, "Cameroon", "UTC+1" },
                    { 34, "CV", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CVE", "$", "+238", "https://flagsapi.com/CV/shiny/64.png", true, false, "Cape Verde", "UTC-1" },
                    { 35, "CF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "FCFA", "+236", "https://flagsapi.com/CF/shiny/64.png", true, false, "Central African Republic", "UTC+1" },
                    { 36, "TD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "FCFA", "+235", "https://flagsapi.com/TD/shiny/64.png", true, false, "Chad", "UTC+1" },
                    { 37, "CL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLP", "$", "+56", "https://flagsapi.com/CL/shiny/64.png", true, false, "Chile", "UTC-4" },
                    { 38, "CO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "COP", "$", "+57", "https://flagsapi.com/CO/shiny/64.png", true, false, "Colombia", "UTC-5" },
                    { 39, "KM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KMF", "CF", "+269", "https://flagsapi.com/KM/shiny/64.png", true, false, "Comoros", "UTC+3" },
                    { 40, "CG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "FCFA", "+242", "https://flagsapi.com/CG/shiny/64.png", true, false, "Congo", "UTC+1" },
                    { 41, "CR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRC", "₡", "+506", "https://flagsapi.com/CR/shiny/64.png", true, false, "Costa Rica", "UTC-6" },
                    { 42, "HR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HRK", "kn", "+385", "https://flagsapi.com/HR/shiny/64.png", true, false, "Croatia", "UTC+1" },
                    { 43, "CU", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUP", "$", "+53", "https://flagsapi.com/CU/shiny/64.png", true, false, "Cuba", "UTC-5" },
                    { 44, "CY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+357", "https://flagsapi.com/CY/shiny/64.png", true, false, "Cyprus", "UTC+2" },
                    { 45, "CZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CZK", "Kč", "+420", "https://flagsapi.com/CZ/shiny/64.png", true, false, "Czech Republic", "UTC+1" },
                    { 46, "DK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", "kr", "+45", "https://flagsapi.com/DK/shiny/64.png", true, false, "Denmark", "UTC+1" },
                    { 47, "DJ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DJF", "Fdj", "+253", "https://flagsapi.com/DJ/shiny/64.png", true, false, "Djibouti", "UTC+3" },
                    { 48, "DM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "$", "+1-767", "https://flagsapi.com/DM/shiny/64.png", true, false, "Dominica", "UTC-4" },
                    { 49, "DO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOP", "$", "+1-809, +1-829, +1-849", "https://flagsapi.com/DO/shiny/64.png", true, false, "Dominican Republic", "UTC-4" },
                    { 50, "EC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "$", "+593", "https://flagsapi.com/EC/shiny/64.png", true, false, "Ecuador", "UTC-5" },
                    { 51, "EG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EGP", "£", "+20", "https://flagsapi.com/EG/shiny/64.png", true, false, "Egypt", "UTC+2" },
                    { 52, "SV", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "$", "+503", "https://flagsapi.com/SV/shiny/64.png", true, false, "El Salvador", "UTC-6" },
                    { 53, "GQ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "FCFA", "+240", "https://flagsapi.com/GQ/shiny/64.png", true, false, "Equatorial Guinea", "UTC+1" },
                    { 54, "ER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ERN", "Nfk", "+291", "https://flagsapi.com/ER/shiny/64.png", true, false, "Eritrea", "UTC+3" },
                    { 55, "EE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+372", "https://flagsapi.com/EE/shiny/64.png", true, false, "Estonia", "UTC+2" },
                    { 56, "SZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SZL", "L", "+268", "https://flagsapi.com/SZ/shiny/64.png", true, false, "Eswatini", "UTC+2" },
                    { 57, "ET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ETB", "Br", "+251", "https://flagsapi.com/ET/shiny/64.png", true, false, "Ethiopia", "UTC+3" },
                    { 58, "FJ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FJD", "$", "+679", "https://flagsapi.com/FJ/shiny/64.png", true, false, "Fiji", "UTC+12" },
                    { 59, "FI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+358", "https://flagsapi.com/FI/shiny/64.png", true, false, "Finland", "UTC+2" },
                    { 60, "GA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "FCFA", "+241", "https://flagsapi.com/GA/shiny/64.png", true, false, "Gabon", "UTC+1" },
                    { 61, "GM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GMD", "D", "+220", "https://flagsapi.com/GM/shiny/64.png", true, false, "Gambia", "UTC" },
                    { 62, "GE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEL", "₾", "+995", "https://flagsapi.com/GE/shiny/64.png", true, false, "Georgia", "UTC+4" },
                    { 63, "GH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GHS", "₵", "+233", "https://flagsapi.com/GH/shiny/64.png", true, false, "Ghana", "UTC" },
                    { 64, "GR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+30", "https://flagsapi.com/GR/shiny/64.png", true, false, "Greece", "UTC+2" },
                    { 65, "GD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "$", "+1-473", "https://flagsapi.com/GD/shiny/64.png", true, false, "Grenada", "UTC-4" },
                    { 66, "GT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTQ", "Q", "+502", "https://flagsapi.com/GT/shiny/64.png", true, false, "Guatemala", "UTC-6" },
                    { 67, "GN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GNF", "FG", "+224", "https://flagsapi.com/GN/shiny/64.png", true, false, "Guinea", "UTC" },
                    { 68, "GW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "CFA", "+245", "https://flagsapi.com/GW/shiny/64.png", true, false, "Guinea-Bissau", "UTC" },
                    { 69, "GY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GYD", "$", "+592", "https://flagsapi.com/GY/shiny/64.png", true, false, "Guyana", "UTC-4" },
                    { 70, "HT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTG", "G", "+509", "https://flagsapi.com/HT/shiny/64.png", true, false, "Haiti", "UTC-5" },
                    { 71, "HN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HNL", "L", "+504", "https://flagsapi.com/HN/shiny/64.png", true, false, "Honduras", "UTC-6" },
                    { 72, "HU", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HUF", "Ft", "+36", "https://flagsapi.com/HU/shiny/64.png", true, false, "Hungary", "UTC+1" },
                    { 73, "IS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISK", "kr", "+354", "https://flagsapi.com/IS/shiny/64.png", true, false, "Iceland", "UTC" },
                    { 74, "ID", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IDR", "Rp", "+62", "https://flagsapi.com/ID/shiny/64.png", true, false, "Indonesia", "UTC+7" },
                    { 75, "IR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IRR", "﷼", "+98", "https://flagsapi.com/IR/shiny/64.png", true, false, "Iran", "UTC+3:30" },
                    { 76, "IQ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IQD", "ع.د", "+964", "https://flagsapi.com/IQ/shiny/64.png", true, false, "Iraq", "UTC+3" },
                    { 77, "IE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+353", "https://flagsapi.com/IE/shiny/64.png", true, false, "Ireland", "UTC+1" },
                    { 78, "IL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ILS", "₪", "+972", "https://flagsapi.com/IL/shiny/64.png", true, false, "Israel", "UTC+2" },
                    { 79, "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+39", "https://flagsapi.com/IT/shiny/64.png", true, false, "Italy", "UTC+1" },
                    { 80, "JM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JMD", "$", "+1-876", "https://flagsapi.com/JM/shiny/64.png", true, false, "Jamaica", "UTC-5" },
                    { 81, "JO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JOD", "د.ا", "+962", "https://flagsapi.com/JO/shiny/64.png", true, false, "Jordan", "UTC+2" },
                    { 82, "KZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KZT", "₸", "+7", "https://flagsapi.com/KZ/shiny/64.png", true, false, "Kazakhstan", "UTC+5" },
                    { 83, "KE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KES", "KSh", "+254", "https://flagsapi.com/KE/shiny/64.png", true, false, "Kenya", "UTC+3" },
                    { 84, "KI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", "$", "+686", "https://flagsapi.com/KI/shiny/64.png", true, false, "Kiribati", "UTC+12" },
                    { 85, "KP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KPW", "₩", "+850", "https://flagsapi.com/KP/shiny/64.png", true, false, "North Korea", "UTC+9" },
                    { 86, "KR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KRW", "₩", "+82", "https://flagsapi.com/KR/shiny/64.png", true, false, "South Korea", "UTC+9" },
                    { 87, "KW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KWD", "د.ك", "+965", "https://flagsapi.com/KW/shiny/64.png", true, false, "Kuwait", "UTC+3" },
                    { 88, "KG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KGS", "с", "+996", "https://flagsapi.com/KG/shiny/64.png", true, false, "Kyrgyzstan", "UTC+6" },
                    { 89, "LA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LAK", "₭", "+856", "https://flagsapi.com/LA/shiny/64.png", true, false, "Laos", "UTC+7" },
                    { 90, "LV", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+371", "https://flagsapi.com/LV/shiny/64.png", true, false, "Latvia", "UTC+2" },
                    { 91, "LB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LBP", "ل.ل", "+961", "https://flagsapi.com/LB/shiny/64.png", true, false, "Lebanon", "UTC+2" },
                    { 92, "LS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LSL", "L", "+266", "https://flagsapi.com/LS/shiny/64.png", true, false, "Lesotho", "UTC+2" },
                    { 93, "LR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LRD", "$", "+231", "https://flagsapi.com/LR/shiny/64.png", true, false, "Liberia", "UTC" },
                    { 94, "LY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LYD", "ل.د", "+218", "https://flagsapi.com/LY/shiny/64.png", true, false, "Libya", "UTC+2" },
                    { 95, "LI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHF", "CHF", "+423", "https://flagsapi.com/LI/shiny/64.png", true, false, "Liechtenstein", "UTC+1" },
                    { 96, "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+370", "https://flagsapi.com/LT/shiny/64.png", true, false, "Lithuania", "UTC+2" },
                    { 97, "LU", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+352", "https://flagsapi.com/LU/shiny/64.png", true, false, "Luxembourg", "UTC+1" },
                    { 98, "MG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGA", "Ar", "+261", "https://flagsapi.com/MG/shiny/64.png", true, false, "Madagascar", "UTC+3" },
                    { 99, "MW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MWK", "MK", "+265", "https://flagsapi.com/MW/shiny/64.png", true, false, "Malawi", "UTC+2" },
                    { 100, "MY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MYR", "RM", "+60", "https://flagsapi.com/MY/shiny/64.png", true, false, "Malaysia", "UTC+8" },
                    { 101, "MV", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MVR", "ރ.", "+960", "https://flagsapi.com/MV/shiny/64.png", true, false, "Maldives", "UTC+5" },
                    { 102, "ML", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "CFA", "+223", "https://flagsapi.com/ML/shiny/64.png", true, false, "Mali", "UTC" },
                    { 103, "MT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+356", "https://flagsapi.com/MT/shiny/64.png", true, false, "Malta", "UTC+1" },
                    { 104, "MH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "$", "+692", "https://flagsapi.com/MH/shiny/64.png", true, false, "Marshall Islands", "UTC+12" },
                    { 105, "MR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MRU", "UM", "+222", "https://flagsapi.com/MR/shiny/64.png", true, false, "Mauritania", "UTC" },
                    { 106, "MU", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MUR", "₨", "+230", "https://flagsapi.com/MU/shiny/64.png", true, false, "Mauritius", "UTC+4" },
                    { 107, "MX", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MXN", "$", "+52", "https://flagsapi.com/MX/shiny/64.png", true, false, "Mexico", "UTC-6" },
                    { 108, "FM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "$", "+691", "https://flagsapi.com/FM/shiny/64.png", true, false, "Micronesia", "UTC+11" },
                    { 109, "MD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MDL", "L", "+373", "https://flagsapi.com/MD/shiny/64.png", true, false, "Moldova", "UTC+2" },
                    { 110, "MC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+377", "https://flagsapi.com/MC/shiny/64.png", true, false, "Monaco", "UTC+1" },
                    { 111, "MN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MNT", "₮", "+976", "https://flagsapi.com/MN/shiny/64.png", true, false, "Mongolia", "UTC+8" },
                    { 112, "ME", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+382", "https://flagsapi.com/ME/shiny/64.png", true, false, "Montenegro", "UTC+1" },
                    { 113, "MA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAD", "د.م.", "+212", "https://flagsapi.com/MA/shiny/64.png", true, false, "Morocco", "UTC+1" },
                    { 114, "MZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MZN", "MT", "+258", "https://flagsapi.com/MZ/shiny/64.png", true, false, "Mozambique", "UTC+2" },
                    { 115, "MM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MMK", "K", "+95", "https://flagsapi.com/MM/shiny/64.png", true, false, "Myanmar", "UTC+6:30" },
                    { 116, "NA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NAD", "$", "+264", "https://flagsapi.com/NA/shiny/64.png", true, false, "Namibia", "UTC+2" },
                    { 117, "NR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", "$", "+674", "https://flagsapi.com/NR/shiny/64.png", true, false, "Nauru", "UTC+12" },
                    { 118, "NP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NPR", "₨", "+977", "https://flagsapi.com/NP/shiny/64.png", true, false, "Nepal", "UTC+5:45" },
                    { 119, "NL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+31", "https://flagsapi.com/NL/shiny/64.png", true, false, "Netherlands", "UTC+1" },
                    { 120, "NZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NZD", "$", "+64", "https://flagsapi.com/NZ/shiny/64.png", true, false, "New Zealand", "UTC+12" },
                    { 121, "NI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIO", "C$", "+505", "https://flagsapi.com/NI/shiny/64.png", true, false, "Nicaragua", "UTC-6" },
                    { 122, "NE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "CFA", "+227", "https://flagsapi.com/NE/shiny/64.png", true, false, "Niger", "UTC+1" },
                    { 123, "NG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NGN", "₦", "+234", "https://flagsapi.com/NG/shiny/64.png", true, false, "Nigeria", "UTC+1" },
                    { 124, "NO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NOK", "kr", "+47", "https://flagsapi.com/NO/shiny/64.png", true, false, "Norway", "UTC+1" },
                    { 125, "OM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OMR", "ر.ع.", "+968", "https://flagsapi.com/OM/shiny/64.png", true, false, "Oman", "UTC+4" },
                    { 126, "PK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PKR", "₨", "+92", "https://flagsapi.com/PK/shiny/64.png", true, false, "Pakistan", "UTC+5" },
                    { 127, "PW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "$", "+680", "https://flagsapi.com/PW/shiny/64.png", true, false, "Palau", "UTC+9" },
                    { 128, "PA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAB", "B/.", "+507", "https://flagsapi.com/PA/shiny/64.png", true, false, "Panama", "UTC-5" },
                    { 129, "PG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PGK", "K", "+675", "https://flagsapi.com/PG/shiny/64.png", true, false, "Papua New Guinea", "UTC+10" },
                    { 130, "PY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PYG", "₲", "+595", "https://flagsapi.com/PY/shiny/64.png", true, false, "Paraguay", "UTC-4" },
                    { 131, "PE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PEN", "S/.", "+51", "https://flagsapi.com/PE/shiny/64.png", true, false, "Peru", "UTC-5" },
                    { 132, "PH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PHP", "₱", "+63", "https://flagsapi.com/PH/shiny/64.png", true, false, "Philippines", "UTC+8" },
                    { 133, "PL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLN", "zł", "+48", "https://flagsapi.com/PL/shiny/64.png", true, false, "Poland", "UTC+1" },
                    { 134, "PT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+351", "https://flagsapi.com/PT/shiny/64.png", true, false, "Portugal", "UTC+1" },
                    { 135, "QA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "QAR", "ر.ق", "+974", "https://flagsapi.com/QA/shiny/64.png", true, false, "Qatar", "UTC+3" },
                    { 136, "RO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RON", "lei", "+40", "https://flagsapi.com/RO/shiny/64.png", true, false, "Romania", "UTC+2" },
                    { 137, "RU", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RUB", "₽", "+7", "https://flagsapi.com/RU/shiny/64.png", true, false, "Russia", "UTC+3" },
                    { 138, "RW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RWF", "FRw", "+250", "https://flagsapi.com/RW/shiny/64.png", true, false, "Rwanda", "UTC+2" },
                    { 139, "KN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "$", "+1-869", "https://flagsapi.com/KN/shiny/64.png", true, false, "Saint Kitts and Nevis", "UTC-4" },
                    { 140, "LC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "$", "+1-758", "https://flagsapi.com/LC/shiny/64.png", true, false, "Saint Lucia", "UTC-4" },
                    { 141, "VC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "$", "+1-784", "https://flagsapi.com/VC/shiny/64.png", true, false, "Saint Vincent and the Grenadines", "UTC-4" },
                    { 142, "WS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WST", "T", "+685", "https://flagsapi.com/WS/shiny/64.png", true, false, "Samoa", "UTC+13" },
                    { 143, "SM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+378", "https://flagsapi.com/SM/shiny/64.png", true, false, "San Marino", "UTC+1" },
                    { 144, "ST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "STN", "Db", "+239", "https://flagsapi.com/ST/shiny/64.png", true, false, "Sao Tome and Principe", "UTC" },
                    { 145, "SA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAR", "ر.س", "+966", "https://flagsapi.com/SA/shiny/64.png", true, false, "Saudi Arabia", "UTC+3" },
                    { 146, "SN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "CFA", "+221", "https://flagsapi.com/SN/shiny/64.png", true, false, "Senegal", "UTC" },
                    { 147, "RS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RSD", "дин", "+381", "https://flagsapi.com/RS/shiny/64.png", true, false, "Serbia", "UTC+1" },
                    { 148, "SC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCR", "₨", "+248", "https://flagsapi.com/SC/shiny/64.png", true, false, "Seychelles", "UTC+4" },
                    { 149, "SL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLL", "Le", "+232", "https://flagsapi.com/SL/shiny/64.png", true, false, "Sierra Leone", "UTC" },
                    { 150, "SG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SGD", "$", "+65", "https://flagsapi.com/SG/shiny/64.png", true, false, "Singapore", "UTC+8" },
                    { 151, "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+421", "https://flagsapi.com/SK/shiny/64.png", true, false, "Slovakia", "UTC+1" },
                    { 152, "SI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+386", "https://flagsapi.com/SI/shiny/64.png", true, false, "Slovenia", "UTC+1" },
                    { 153, "SB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SBD", "$", "+677", "https://flagsapi.com/SB/shiny/64.png", true, false, "Solomon Islands", "UTC+11" },
                    { 154, "SO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOS", "Sh", "+252", "https://flagsapi.com/SO/shiny/64.png", true, false, "Somalia", "UTC+3" },
                    { 155, "ZA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZAR", "R", "+27", "https://flagsapi.com/ZA/shiny/64.png", true, false, "South Africa", "UTC+2" },
                    { 156, "SS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SSP", "£", "+211", "https://flagsapi.com/SS/shiny/64.png", true, false, "South Sudan", "UTC+2" },
                    { 157, "ES", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+34", "https://flagsapi.com/ES/shiny/64.png", true, false, "Spain", "UTC+1" },
                    { 158, "LK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LKR", "Rs", "+94", "https://flagsapi.com/LK/shiny/64.png", true, false, "Sri Lanka", "UTC+5:30" },
                    { 159, "SD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SDG", "£", "+249", "https://flagsapi.com/SD/shiny/64.png", true, false, "Sudan", "UTC+2" },
                    { 160, "SR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SRD", "$", "+597", "https://flagsapi.com/SR/shiny/64.png", true, false, "Suriname", "UTC-3" },
                    { 161, "SE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEK", "kr", "+46", "https://flagsapi.com/SE/shiny/64.png", true, false, "Sweden", "UTC+1" },
                    { 162, "CH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHF", "CHF", "+41", "https://flagsapi.com/CH/shiny/64.png", true, false, "Switzerland", "UTC+1" },
                    { 163, "SY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SYP", "£", "+963", "https://flagsapi.com/SY/shiny/64.png", true, false, "Syria", "UTC+2" },
                    { 164, "TW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TWD", "NT$", "+886", "https://flagsapi.com/TW/shiny/64.png", true, false, "Taiwan", "UTC+8" },
                    { 165, "TJ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TJS", "ЅМ", "+992", "https://flagsapi.com/TJ/shiny/64.png", true, false, "Tajikistan", "UTC+5" },
                    { 166, "TZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TZS", "TSh", "+255", "https://flagsapi.com/TZ/shiny/64.png", true, false, "Tanzania", "UTC+3" },
                    { 167, "TH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "THB", "฿", "+66", "https://flagsapi.com/TH/shiny/64.png", true, false, "Thailand", "UTC+7" },
                    { 168, "TL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "$", "+670", "https://flagsapi.com/TL/shiny/64.png", true, false, "Timor-Leste", "UTC+9" },
                    { 169, "TG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "CFA", "+228", "https://flagsapi.com/TG/shiny/64.png", true, false, "Togo", "UTC" },
                    { 170, "TO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TOP", "T$", "+676", "https://flagsapi.com/TO/shiny/64.png", true, false, "Tonga", "UTC+13" },
                    { 171, "TT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TTD", "$", "+1-868", "https://flagsapi.com/TT/shiny/64.png", true, false, "Trinidad and Tobago", "UTC-4" },
                    { 172, "TN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TND", "د.ت", "+216", "https://flagsapi.com/TN/shiny/64.png", true, false, "Tunisia", "UTC+1" },
                    { 173, "TR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRY", "₺", "+90", "https://flagsapi.com/TR/shiny/64.png", true, false, "Turkey", "UTC+3" },
                    { 174, "TM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TMT", "T", "+993", "https://flagsapi.com/TM/shiny/64.png", true, false, "Turkmenistan", "UTC+5" },
                    { 175, "TV", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", "$", "+688", "https://flagsapi.com/TV/shiny/64.png", true, false, "Tuvalu", "UTC+12" },
                    { 176, "UG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UGX", "USh", "+256", "https://flagsapi.com/UG/shiny/64.png", true, false, "Uganda", "UTC+3" },
                    { 177, "UA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UAH", "₴", "+380", "https://flagsapi.com/UA/shiny/64.png", true, false, "Ukraine", "UTC+2" },
                    { 178, "AE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AED", "د.إ", "+971", "https://flagsapi.com/AE/shiny/64.png", true, false, "United Arab Emirates", "UTC+4" },
                    { 179, "GB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP", "£", "+44", "https://flagsapi.com/GB/shiny/64.png", true, false, "United Kingdom", "UTC+1" },
                    { 180, "UY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UYU", "$", "+598", "https://flagsapi.com/UY/shiny/64.png", true, false, "Uruguay", "UTC-3" },
                    { 181, "UZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UZS", "so'm", "+998", "https://flagsapi.com/UZ/shiny/64.png", true, false, "Uzbekistan", "UTC+5" },
                    { 182, "VU", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VUV", "VT", "+678", "https://flagsapi.com/VU/shiny/64.png", true, false, "Vanuatu", "UTC+11" },
                    { 183, "VA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+379", "https://flagsapi.com/VA/shiny/64.png", true, false, "Vatican City", "UTC+1" },
                    { 184, "VE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VES", "Bs.", "+58", "https://flagsapi.com/VE/shiny/64.png", true, false, "Venezuela", "UTC-4" },
                    { 185, "VN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VND", "₫", "+84", "https://flagsapi.com/VN/shiny/64.png", true, false, "Vietnam", "UTC+7" },
                    { 186, "YE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YER", "﷼", "+967", "https://flagsapi.com/YE/shiny/64.png", true, false, "Yemen", "UTC+3" },
                    { 187, "ZM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZMW", "ZK", "+260", "https://flagsapi.com/ZM/shiny/64.png", true, false, "Zambia", "UTC+2" },
                    { 188, "ZW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZWL", "$", "+263", "https://flagsapi.com/ZW/shiny/64.png", true, false, "Zimbabwe", "UTC+2" },
                    { 189, "PS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ILS", "₪", "+970", "https://flagsapi.com/PS/shiny/64.png", true, false, "Palestine", "UTC+2" },
                    { 190, "XK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "€", "+383", "https://flagsapi.com/XK/shiny/64.png", true, false, "Kosovo", "UTC+1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
