﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCore6App.Migrations
{
    public partial class makeCategoryNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AlterColumn<string>(
	            name: "Category",
	            table: "Products",
	            type: "nvarchar(max)",
	            nullable: true,
	            oldClrType: typeof(string),
	            oldType: "nvarchar(max)");

		}

		protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AlterColumn<string>(
				 name: "Category",
				 table: "Products",
				 type: "nvarchar(max)",
				 nullable: false,
				 oldClrType: typeof(string),
				 oldType: "nvarchar(max)",
				 oldNullable: true);

		}
	}
}
