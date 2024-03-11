using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    IdKategori = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NamaKategori = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.IdKategori);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Barangs",
                columns: table => new
                {
                    IdBarang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gambar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaBarang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stok = table.Column<int>(type: "int", nullable: false),
                    Harga = table.Column<float>(type: "real", nullable: false),
                    IdKategori = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barangs", x => x.IdBarang);
                    table.ForeignKey(
                        name: "FK_Barangs_Kategoris_IdKategori",
                        column: x => x.IdKategori,
                        principalTable: "Kategoris",
                        principalColumn: "IdKategori",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barangs_IdKategori",
                table: "Barangs",
                column: "IdKategori");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barangs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Kategoris");
        }
    }
}
