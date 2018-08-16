using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DogTrials.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stake",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stake", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trial",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClubID = table.Column<int>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trial", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trial_Club_ClubID",
                        column: x => x.ClubID,
                        principalTable: "Club",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Breed = table.Column<int>(nullable: false),
                    CallName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false),
                    RegisteredName = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dog_Person_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryFee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fee = table.Column<decimal>(nullable: false),
                    StakeID = table.Column<int>(nullable: true),
                    TrialID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryFee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EntryFee_Stake_StakeID",
                        column: x => x.StakeID,
                        principalTable: "Stake",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryFee_Trial_TrialID",
                        column: x => x.TrialID,
                        principalTable: "Trial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Judge",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonID = table.Column<int>(nullable: true),
                    StakeID = table.Column<int>(nullable: true),
                    TrialID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judge", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Judge_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Judge_Stake_StakeID",
                        column: x => x.StakeID,
                        principalTable: "Stake",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Judge_Trial_TrialID",
                        column: x => x.TrialID,
                        principalTable: "Trial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DogID = table.Column<int>(nullable: true),
                    HandlerID = table.Column<int>(nullable: true),
                    Paid = table.Column<bool>(nullable: false),
                    StakeID = table.Column<int>(nullable: true),
                    TrialID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Entry_Dog_DogID",
                        column: x => x.DogID,
                        principalTable: "Dog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entry_Person_HandlerID",
                        column: x => x.HandlerID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entry_Stake_StakeID",
                        column: x => x.StakeID,
                        principalTable: "Stake",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entry_Trial_TrialID",
                        column: x => x.TrialID,
                        principalTable: "Trial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dog_OwnerID",
                table: "Dog",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_DogID",
                table: "Entry",
                column: "DogID");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_HandlerID",
                table: "Entry",
                column: "HandlerID");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_StakeID",
                table: "Entry",
                column: "StakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_TrialID",
                table: "Entry",
                column: "TrialID");

            migrationBuilder.CreateIndex(
                name: "IX_EntryFee_StakeID",
                table: "EntryFee",
                column: "StakeID");

            migrationBuilder.CreateIndex(
                name: "IX_EntryFee_TrialID",
                table: "EntryFee",
                column: "TrialID");

            migrationBuilder.CreateIndex(
                name: "IX_Judge_PersonID",
                table: "Judge",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Judge_StakeID",
                table: "Judge",
                column: "StakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Judge_TrialID",
                table: "Judge",
                column: "TrialID");

            migrationBuilder.CreateIndex(
                name: "IX_Trial_ClubID",
                table: "Trial",
                column: "ClubID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "EntryFee");

            migrationBuilder.DropTable(
                name: "Judge");

            migrationBuilder.DropTable(
                name: "Dog");

            migrationBuilder.DropTable(
                name: "Stake");

            migrationBuilder.DropTable(
                name: "Trial");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Club");
        }
    }
}
