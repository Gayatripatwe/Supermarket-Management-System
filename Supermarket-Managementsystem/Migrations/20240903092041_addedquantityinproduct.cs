﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket_Managementsystem.Migrations
{
    /// <inheritdoc />
    public partial class addedquantityinproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Products");
        }
    }
}
