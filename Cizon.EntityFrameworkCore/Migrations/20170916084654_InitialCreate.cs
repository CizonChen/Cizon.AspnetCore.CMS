using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cizon.EntityFrameworkCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dept",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CityCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ContactNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Creator = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Leader = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Note = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Postcode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ShortName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    Tag1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Tag2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    WebSite = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dept", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "s_menu",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    AssemblyName = table.Column<string>(type: "longtext", nullable: true),
                    BindRight = table.Column<string>(type: "longtext", nullable: true),
                    ClassName = table.Column<string>(type: "longtext", nullable: true),
                    Icon1 = table.Column<string>(type: "longtext", nullable: true),
                    Icon2 = table.Column<string>(type: "longtext", nullable: true),
                    Modifier = table.Column<string>(type: "longtext", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    NavigationVisible = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true),
                    OpenType = table.Column<int>(type: "int", nullable: false),
                    OrderNum = table.Column<int>(type: "int", nullable: false),
                    PId = table.Column<string>(type: "longtext", nullable: false),
                    SystemId = table.Column<string>(type: "longtext", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UrlAddress = table.Column<string>(type: "longtext", nullable: true),
                    UrlExtraParam = table.Column<string>(type: "longtext", nullable: true),
                    UrlIncludeUserSession = table.Column<string>(type: "longtext", nullable: true),
                    Visible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s_menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "s_right",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Modifier = table.Column<string>(type: "longtext", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true),
                    OrderNum = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<string>(type: "longtext", nullable: true),
                    Visible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s_right", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "s_role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Modifier = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    RoleCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    SystemId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "s_roleassignment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    RoleId = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    SetTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Setter = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<string>(type: "longtext", nullable: false),
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s_roleassignment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "s_rolesetting",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    LinkId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LinkType = table.Column<int>(type: "int", nullable: true),
                    Modifier = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s_rolesetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userinfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Creator = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DeptId = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ErrorTimes = table.Column<int>(type: "int", nullable: true),
                    LogonCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Modifier = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "longtext", nullable: true),
                    Postcode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Tel = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    UserCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userinfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dept");

            migrationBuilder.DropTable(
                name: "s_menu");

            migrationBuilder.DropTable(
                name: "s_right");

            migrationBuilder.DropTable(
                name: "s_role");

            migrationBuilder.DropTable(
                name: "s_roleassignment");

            migrationBuilder.DropTable(
                name: "s_rolesetting");

            migrationBuilder.DropTable(
                name: "userinfo");
        }
    }
}
