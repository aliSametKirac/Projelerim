using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballManager.Migrations
{
    public partial class V0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "TeamsCoaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "TeamPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Seasons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "HomeTeamID",
                table: "Matches",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AwayID",
                table: "Matches",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "MatchDate",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GoalCount",
                table: "GoolPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AssistsCount",
                table: "AssistsPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeamsCoaches_SeasonId",
                table: "TeamsCoaches",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayers_PlayerId",
                table: "TeamPlayers",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayers_Players_PlayerId",
                table: "TeamPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsCoaches_Seasons_SeasonId",
                table: "TeamsCoaches",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayers_Players_PlayerId",
                table: "TeamPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsCoaches_Seasons_SeasonId",
                table: "TeamsCoaches");

            migrationBuilder.DropIndex(
                name: "IX_TeamsCoaches_SeasonId",
                table: "TeamsCoaches");

            migrationBuilder.DropIndex(
                name: "IX_TeamPlayers_PlayerId",
                table: "TeamPlayers");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "TeamsCoaches");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "TeamPlayers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MatchDate",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "GoalCount",
                table: "GoolPlayers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "AssistsCount",
                table: "AssistsPlayers");

            migrationBuilder.AlterColumn<string>(
                name: "HomeTeamID",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AwayID",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
