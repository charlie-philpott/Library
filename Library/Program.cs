using System;
using System.Collections.Generic;


namespace Library
{
    class Program
    {
        public static List<Book> MyLibrary = new List<Book>();

        static void Main(string[] args)
        {
            CheckOption(Menu());            
        }

        public static int Menu() {

            bool invalidInput = true;
            string selection = "";
            int selectionNumber = 0;

            // While loop iterates whilst the value of the selection is ether 1, 2 or 3. If not it will ask the question again.
            while (invalidInput)
            {
                Console.WriteLine("1 - View Library");
                Console.WriteLine("2 - Add Book");
                Console.WriteLine("3 - Delete Book");
                selection = Console.ReadLine();

                // Input checker
                if (selection == "1" || selection == "2" || selection == "3")
                {
                    selectionNumber = Convert.ToInt16(selection);
                    invalidInput = false;
                    return selectionNumber;

                }
                else
                {
                    Console.WriteLine(selection + " is not a valid option.");
                }
            }

            return selectionNumber;
        }

        public static void CheckOption(int option)
        {
            switch (option)
            {
                case 1:
                    ViewLibrary();
                    break;
                case 2:
                    AddBook();
                    break;
                default:
                    DeleteBook();
                    break;
            }
        }

        public static void ViewLibrary()
        {

            if (MyLibrary.Count > 0)
            {
                foreach (Book Book in MyLibrary)
                {
                    Console.WriteLine(Book.Title);
                }
            }
            else {
                Console.WriteLine("There is no books in the library");
            }

            CheckOption(Menu());
        }

        public static void AddBook()
        {
            Book newBook = new Book();

            Console.WriteLine("What is the title of the book?");
            newBook.Title = Console.ReadLine();

            Console.WriteLine("Who is the author of the book?");
            newBook.Author = Console.ReadLine();

            Console.WriteLine("What is the price of the book?");
            newBook.Price = Convert.ToInt16(Console.ReadLine());

            MyLibrary.Add(newBook);

            CheckOption(Menu());
        }

        public static void DeleteBook()
        {
            if (MyLibrary.Count > 0)
            {
                Console.WriteLine("Which book do you want to delete?");

                foreach (Book Book in MyLibrary)
                {
                    Console.WriteLine(Book.Title);
                }

                string BookToDelete = Console.ReadLine();

                MyLibrary.RemoveAll(x => x.Title == BookToDelete);
            }
            else
            {
                Console.WriteLine("There is no books in the library");
            }

            CheckOption(Menu());
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}