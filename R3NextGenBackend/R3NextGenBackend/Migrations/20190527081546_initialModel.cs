using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace R3NextGenBackend.Migrations
{
    public partial class initialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompletedForm",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: false),
                    FormId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedForm_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormField",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Column = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Headline = table.Column<string>(nullable: true),
                    Static = table.Column<bool>(nullable: false),
                    FormId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormField_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComponentName = table.Column<string>(maxLength: 25, nullable: true),
                    FormFieldId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Component_FormField_FormFieldId",
                        column: x => x.FormFieldId,
                        principalTable: "FormField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Brand" },
                    { 2L, "Affaldssortering" },
                    { 3L, "Biluheld" },
                    { 4L, "Overfald" },
                    { 5L, "Underet Borgmesterkontoret" },
                    { 6L, "Kemikaliebrand" },
                    { 7L, "Tilkald helikopter" }
                });

            migrationBuilder.InsertData(
                table: "CompletedForm",
                columns: new[] { "Id", "CompletedDate", "FormId", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), 1L, 1L },
                    { 2L, new DateTime(2019, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), 2L, 2L },
                    { 3L, new DateTime(2019, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), 3L, 3L },
                    { 4L, new DateTime(2019, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), 4L, 1L },
                    { 5L, new DateTime(2019, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), 5L, 2L },
                    { 6L, new DateTime(2019, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), 6L, 1L },
                    { 7L, new DateTime(2019, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), 7L, 1L }
                });

            migrationBuilder.InsertData(
                table: "FormField",
                columns: new[] { "Id", "Column", "FormId", "Headline", "Height", "Row", "Static", "Width" },
                values: new object[,]
                {
                    { 1L, 3, 1L, "Indtast Dit Navn", 3, 3, false, 3 },
                    { 2L, 2, 2L, "Er der en affaldsspand", 3, 3, false, 2 },
                    { 3L, 3, 3L, "Antal kvæstede", 4, 3, false, 3 },
                    { 4L, 3, 4L, "Overfaldsvåben", 5, 3, false, 3 },
                    { 5L, 3, 5L, "Skal komunaldirektøren underrettes", 2, 3, false, 5 },
                    { 6L, 3, 6L, "Hvilken type kemikalie er i brand?", 5, 3, false, 5 },
                    { 7L, 3, 7L, "Hvor skal helikopteren lande?", 2, 3, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Id", "ComponentName", "FormFieldId" },
                values: new object[,]
                {
                    { 1L, "appInputFieldComponent", 1L },
                    { 2L, "appInputFieldComponent", 2L },
                    { 3L, "appInputFieldComponent", 3L },
                    { 4L, "appInputFieldComponent", 4L },
                    { 5L, "appInputFieldComponent", 5L },
                    { 6L, "appInputFieldComponent", 6L },
                    { 7L, "appInputFieldComponent", 7L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedForm_FormId",
                table: "CompletedForm",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_FormFieldId",
                table: "Component",
                column: "FormFieldId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormField_FormId",
                table: "FormField",
                column: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedForm");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "FormField");

            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
