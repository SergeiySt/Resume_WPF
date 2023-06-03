﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WPF_Resume.Migrations.AplicationContextForma2Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserResumeForma",
                columns: table => new
                {
                    id_user_resume = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Surname = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Pobatkovi = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    Personal_qualities = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResumeForma", x => x.id_user_resume);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserResumeForma");
        }
    }
}
