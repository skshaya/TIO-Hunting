using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class updateCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Candidates",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false),
                   FirstName = table.Column<string>(maxLength: 256, nullable: true),
                   LastName = table.Column<string>(maxLength: 256, nullable: true),
                   Address = table.Column<string>(maxLength: 256, nullable: true),
                   Email = table.Column<string>(maxLength: 256, nullable: true),
                   Comments = table.Column<string>(maxLength: 256, nullable: true),
                   Designation = table.Column<string>(maxLength: 256, nullable: true),
                   Experience = table.Column<string>(maxLength: 256, nullable: true),
                   DOB = table.Column<DateTime>(maxLength: 256, nullable: true),
                   PhoneNumber = table.Column<string>(nullable: true),
                   StartDate = table.Column<DateTime>(nullable: true),
                   EndDate = table.Column<DateTime>(nullable: true),
                   Interviewer = table.Column<string>(nullable: true),

                   IsEnable = table.Column<bool>(nullable: false),

               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Candidates", x => x.Id);
               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                   name: "Candidates");
        }
    }
}
