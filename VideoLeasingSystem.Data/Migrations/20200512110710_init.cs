using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoLeasingSystem.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    FullName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 10, nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoName = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Actor = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NoOfCopies = table.Column<int>(nullable: false),
                    LeaseAmount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    VideoId = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    DueAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserName",
                table: "Records",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VideoId",
                table: "Records",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
