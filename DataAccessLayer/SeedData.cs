using Microsoft.EntityFrameworkCore;
using PublishingHouse.Constats;
using PublishingHouse.Models.CategoryEntity;
using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.Models.UserEntity;
using System;

namespace PublishingHouse.DataAccessLayer
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder) 
        {
            SeedPrintedEdition(builder);
            SeedCategory(builder);
            SeedUser(builder);
        }

        #region SeedPrintedEdition

        public static void SeedPrintedEdition(ModelBuilder builder)
        {
            PrintedEdition[] printedEditions =
            {
                new PrintedEdition(1, "Isaac Asimov", "Science Fiction & Fantasy", new byte[1]{1}, 
                "I, Robot", "Isaac Asimov's I, Robot launches readers on an adventure into a " +
                "not-so-distant future where man and machine , struggle to redefinelife, love, " +
                "and consciousness—and where the stakes are nothing less than survival. Filled with " +
                "unforgettable characters, mind-bending speculation, and nonstop action, " +
                "I, Robot is a powerful reading experience from one of the master storytellers of our time.\n" +
                "I, ROBOT\nThey mustn't harm a human being, they must obey human orders, " +
                "and they must protect their own existence...but only so long as that doesn't violate rules one and two. " +
                "With these Three Laws of Robotics, humanity embarked on perhaps its greatest adventure: " +
                "the invention of the first positronic man. It was a bold new era of evolution " +
                "that would open up enormous possibilities—and unforeseen risks. For the scientists " +
                "who invented the earliest robots weren't content that their creations should ' remain programmed helpers, " +
                "companions, and semisentient worker-machines. And soon the robots themselves; aware of their own intelligence, " +
                "power, and humanity, aren't either.\nAs humans and robots struggle to survive " +
                "together—and sometimes against each other—on earth and in space, the future of both hangs in the balance. " +
                "Human men and women confront robots gone mad, telepathic robots, robot politicians, " +
                "and vast robotic intelligences that may already secretly control the world. And both are asking the same questions: " +
                "What is human? And is humanity obsolete?\nIn l, Robot Isaac Asimov changes forever our perception of robots," +
                " and human beings and updates the timeless myth of man's dream to play god. with all its rewards—and terrors.\n",
                "English", (decimal)10.0, DateTime.Now, DateTime.Now, true, 1),

                new PrintedEdition(2, "Stephen King", "Horror", new byte[1]{1},
                "The Mist", "It's a hot, lazy day, " +
                "perfect for a cookout, until you see those strange dark clouds. Suddenly a violent storm " +
                "sweeps across the lake and ends as abruptly and unexpectedly as it had begun. Then comes " +
                "the mist...creeping slowly, inexorably into town, where it settles and waits, trapping " +
                "you in the supermarket with dozens of others, cut off from your families and the world. " +
                "The mist is alive, seething with unearthly sounds and movements. What unleashed this " +
                "terror? Was it the Arrowhead Project---the top secret government operation that everyone " +
                "has noticed but no one quite understands? And what happens when the provisions have run " +
                "out and you're forced to make your escape, edging blindly through the dim light?",
                "English", (decimal)10.0, DateTime.Now, DateTime.Now, true, 1),

                new PrintedEdition(3, "Semuel Delany", "Science Fiction & Fantasy", new byte[1] { 1 }, "Babel-17",
                "Babel-17 is all about the power of language. Humanity, which has spread throughout " +
                "the universe, is involved in a war with the Invaders, who have been covertly " +
                "assassinating officials and sabotaging spaceships. The only clues humanity has " +
                "to go on are strange alien messages that have been intercepted in space. " +
                "Poet and linguist Rydra Wong is determined to understand the language and " +
                "stop the alien threat.", "English", (decimal)9.0, DateTime.Now, DateTime.Now, true, 1)
            };

            builder.Entity<PrintedEdition>().HasData(printedEditions);
        }

        #endregion

        #region SeedCategory

        public static void SeedCategory(ModelBuilder builder)
        {
            Category[] categories =
            {
                new Category(1, "Books")
            };

            builder.Entity<Category>().HasData(categories);
        }

        #endregion

        #region SeedUser

        public static void SeedUser(ModelBuilder builder)
        {
            User[] users =
            {
                new User(1, "Admin", "Admin", "admin", BCrypt.Net.BCrypt.HashPassword("admin"), UserRole.Administrator.ToString(), false, DateTime.Now, null)
            };

            builder.Entity<User>().HasData(users);
        }

        #endregion
    }
}
