using System;
using System.Drawing;
using Microsoft.EntityFrameworkCore.Migrations;
using PublishingHouse.Helpers;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PublishingHouse.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Books" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "Login", "PasswordHash", "Role" },
                values: new object[] { 1, new DateTime(2023, 6, 11, 15, 39, 13, 822, DateTimeKind.Local).AddTicks(1017), "Admin", "Admin", "admin", "$2a$11$sCaP0BlY/WkRH/bkIprxa.L9I7wl52fUy81UwB//AjDQFoYA/0H8O", "Administrator" });

            migrationBuilder.InsertData(
                table: "PrintedEdition",
                columns: new[] { "Id", "Author", "CategoryId", "Cover", "Description", "Genre", "IsAvailable", "Language", "Price", "ReleaseDate", "Title", "Updated" },
                values: new object[,]
                {
                    //{ 1, "Isaac Asimov", 1, new byte[] { 1 }, "Isaac Asimov's I, Robot launches readers on an adventure into a not-so-distant future where man and machine , struggle to redefinelife, love, and consciousness—and where the stakes are nothing less than survival. Filled with unforgettable characters, mind-bending speculation, and nonstop action, I, Robot is a powerful reading experience from one of the master storytellers of our time.\nI, ROBOT\nThey mustn't harm a human being, they must obey human orders, and they must protect their own existence...but only so long as that doesn't violate rules one and two. With these Three Laws of Robotics, humanity embarked on perhaps its greatest adventure: the invention of the first positronic man. It was a bold new era of evolution that would open up enormous possibilities—and unforeseen risks. For the scientists who invented the earliest robots weren't content that their creations should ' remain programmed helpers, companions, and semisentient worker-machines. And soon the robots themselves; aware of their own intelligence, power, and humanity, aren't either.\nAs humans and robots struggle to survive together—and sometimes against each other—on earth and in space, the future of both hangs in the balance. Human men and women confront robots gone mad, telepathic robots, robot politicians, and vast robotic intelligences that may already secretly control the world. And both are asking the same questions: What is human? And is humanity obsolete?\nIn l, Robot Isaac Asimov changes forever our perception of robots, and human beings and updates the timeless myth of man's dream to play god. with all its rewards—and terrors.\n", "Science Fiction & Fantasy", true, "English", 10m, new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7071), "I, Robot", new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7112) },
                    { 2, "Stephen King", 1, Helper.ConvertImageToByteArray(Image.FromFile("D:\\University\\OOPR\\Lab2\\Publishing house\\Resources\\Stephen_King_The_Mist.jpg")), "It's a hot, lazy day, perfect for a cookout, until you see those strange dark clouds. Suddenly a violent storm sweeps across the lake and ends as abruptly and unexpectedly as it had begun. Then comes the mist...creeping slowly, inexorably into town, where it settles and waits, trapping you in the supermarket with dozens of others, cut off from your families and the world. The mist is alive, seething with unearthly sounds and movements. What unleashed this terror? Was it the Arrowhead Project---the top secret government operation that everyone has noticed but no one quite understands? And what happens when the provisions have run out and you're forced to make your escape, edging blindly through the dim light?", "Horror", true, "English", 10m, new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7120), "The Mist", new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7122) },
                    { 3, "Semuel Delany", 1, Helper.ConvertImageToByteArray(Image.FromFile("D:\\University\\OOPR\\Lab2\\Publishing house\\Resources\\Samuel_Delany_Babel-17.jpg")), "Babel-17 is all about the power of language. Humanity, which has spread throughout the universe, is involved in a war with the Invaders, who have been covertly assassinating officials and sabotaging spaceships. The only clues humanity has to go on are strange alien messages that have been intercepted in space. Poet and linguist Rydra Wong is determined to understand the language and stop the alien threat.", "Science Fiction & Fantasy", true, "English", 9m, new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7125), "Babel-17", new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7127) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PrintedEdition",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PrintedEdition",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PrintedEdition",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
