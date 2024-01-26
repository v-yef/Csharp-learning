/*
 ============================================================================
 Name        : Homework_5-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a "Reading List" app. The application must allow to add
               and removing books from the list, to check if the book is in
               the list, etc. Use the mechanism of properties, operator
               overloading, indexers.
 ============================================================================
 */

namespace Task_2
{
    class Book
    {
        public string Name { get; set; }

        public Book(string name)
        {
            Name = name;
        }
    }

    class BookList
    {
        private readonly Book[] bookList;

        public BookList(int booksCount)
        {
            bookList = new Book[booksCount];
        }

        public int Length
        {
            get => bookList.Length;
        }

        // Индексатор массива книг для поиска и вставки по индексу
        public Book this[int searchedIndex]
        {
            get
            {
                if (searchedIndex >= 0 && searchedIndex < bookList.Length)
                {
                    return bookList[searchedIndex];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (searchedIndex >= 0 && searchedIndex < bookList.Length)
                {
                    bookList[searchedIndex] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        // Индексатор массива книг для поиска по названию
        public int this[string searchedName]
        {
            get
            {
                if (Array.FindIndex(bookList, book => book.Name == searchedName) >= 0)
                {
                    return Array.FindIndex(bookList, book => book.Name == searchedName);
                }
                else
                {
                    throw new Exception("Элемент не найден.");
                }
            }
        }

        // Метод удаления книги по индексу
        public void RemoveBook(int _Index) =>
            bookList[_Index].Name = "< Пусто >";
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BookList bookList = new BookList(5);

                bookList[0] = new Book("Книга 1");
                bookList[1] = new Book("Книга 2");
                bookList[2] = new Book("Книга 3");
                bookList[3] = new Book("Книга 4");
                bookList[4] = new Book("Книга 5");

                for (int i = 0; i < bookList.Length; i++)
                {
                    Console.WriteLine(bookList[i].Name);
                }
                Console.WriteLine();

                // Удалить книгу по индексу 2
                bookList.RemoveBook(2);

                for (int i = 0; i < bookList.Length; i++)
                {
                    Console.WriteLine(bookList[i].Name);
                }
                Console.WriteLine();

                // Записать книгу по индексу 2
                bookList[2].Name = "Книга 555";

                for (int i = 0; i < bookList.Length; i++)
                {
                    Console.WriteLine(bookList[i].Name);
                }
                Console.WriteLine();

                Console.WriteLine("Книга 555 находится по индексу " + bookList["Книга 555"]);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }
    }
}
