using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelMe_webapp.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Post_PostID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_User_UserID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceCatagory_Category_CategoryID",
                table: "PlaceCatagory");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceCatagory_Place_PlaceID",
                table: "PlaceCatagory");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Place_PlaceID",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Post_PostID",
                table: "Comments",
                column: "PostID",
                principalTable: "Post",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_User_UserID",
                table: "Comments",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceCatagory_Category_CategoryID",
                table: "PlaceCatagory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceCatagory_Place_PlaceID",
                table: "PlaceCatagory",
                column: "PlaceID",
                principalTable: "Place",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Place_PlaceID",
                table: "Post",
                column: "PlaceID",
                principalTable: "Place",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Post_PostID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_User_UserID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceCatagory_Category_CategoryID",
                table: "PlaceCatagory");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceCatagory_Place_PlaceID",
                table: "PlaceCatagory");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Place_PlaceID",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Post_PostID",
                table: "Comments",
                column: "PostID",
                principalTable: "Post",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_User_UserID",
                table: "Comments",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceCatagory_Category_CategoryID",
                table: "PlaceCatagory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceCatagory_Place_PlaceID",
                table: "PlaceCatagory",
                column: "PlaceID",
                principalTable: "Place",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Place_PlaceID",
                table: "Post",
                column: "PlaceID",
                principalTable: "Place",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
