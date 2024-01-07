/*
 ============================================================================
 Name        : Homework_5-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a Reading List app. The application should allow adding books to the list, removing books
  from the list, check if the book is in the list, etc. Use the mechanism of properties, operator loading,
indexers.
 ============================================================================
 */

namespace Task_2
{
    // Класс "Книга" - элемент массива книг
    class Book
    {
        public string BookName { get; set; }

        public Book(string _BookName) { BookName = _BookName; }
    }

    // Класс "Список книг"
    class BookList
    {
        Book[] bookList;

        public BookList(int _BooksNumber)
        {
            bookList = new Book[_BooksNumber];
        }

        public int Length
        {
            get { return bookList.Length; }
        }

        // Индексатор массива книг для поиска и вставки по индексу
        public Book this[int _Index]
        {
            get
            {
                if (_Index >= 0 && _Index < bookList.Length)
                {
                    return bookList[_Index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (_Index >= 0 && _Index < bookList.Length)
                {
                    bookList[_Index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        // Индексатор массива книг для поиска по названию
        public int this[string _BookName]
        {
            get
            {
                if (Array.FindIndex(bookList, book => book.BookName == _BookName) >= 0)
                {
                    return Array.FindIndex(bookList, book => book.BookName == _BookName);
                }
                else
                {
                    throw new Exception("Элемент не найден.");
                }
            }
        }

        // Метод удаления книги по индексу
        public void RemoveBook(int _Index)
        {
            bookList[_Index].BookName = "< Пусто >";

            return;
        }
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
                    Console.WriteLine(bookList[i].BookName);
                }
                Console.WriteLine();

                // Удалить книгу по индексу 2
                bookList.RemoveBook(2);

                for (int i = 0; i < bookList.Length; i++)
                {
                    Console.WriteLine(bookList[i].BookName);
                }
                Console.WriteLine();

                // Записать книгу по индексу 2
                bookList[2].BookName = "Книга 555";

                for (int i = 0; i < bookList.Length; i++)
                {
                    Console.WriteLine(bookList[i].BookName);
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
