using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Timeshedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Timeschedule",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   StartDate = table.Column<DateTime>(nullable: false),
                   EndDate = table.Column<DateTime>(nullable: true),
                   Comments = table.Column<string>(nullable: true),
                   IsActive = table.Column<bool>(nullable: true),
                   CId = table.Column<int>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Timeschedule", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Timeschedule_Candidate_Id",
                       column: x => x.CId,
                       principalTable: "Candidate",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timeschedule");
        }
    }
}
