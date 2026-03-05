using System;              // Импорт пространства для работы с исключениями
using System.Collections.Generic;  // Импорт для работы со списками (List)
using System.Linq;         // Импорт для LINQ-запросов (FirstOrDefault, Any, Select)

namespace ClassLibrary
{
    /// <summary>
    /// Класс "BookStore" представляет книжный магазин с определённым количеством шкафов и балансом.
    /// </summary>
    public class BookStore
    {
        private List<BookCase> bookCases;  // Список для хранения всех книжных шкафов в магазине
        public int MaxBookCases { get; private set; }  // Максимальное количество шкафов (n)
        public double Balance { get; private set; }    // Текущий баланс магазина (заработанные деньги)

        /// <summary>
        /// Конструктор класса BookStore.
        /// </summary>
        /// <param name="maxBookCases">Максимальное количество шкафов в магазине</param>
        public BookStore(int maxBookCases)
        {
            // Проверяем, что максимальное количество шкафов больше нуля
            if (maxBookCases <= 0)
                throw new ArgumentException("Максимальное количество шкафов должно быть больше нуля");

            this.MaxBookCases = maxBookCases;  // Устанавливаем максимальное количество шкафов
            this.bookCases = new List<BookCase>();  // Инициализируем пустой список шкафов
            this.Balance = 0.0;  // Начальный баланс магазина - 0 рублей
        }

        /// <summary>
        /// Добавляет новый книжный шкаф в магазин.
        /// </summary>
        /// <param name="genre">Жанр книг для шкафа</param>
        /// <param name="capacity">Вместимость шкафа (количество книг)</param>
        public void AddBookCase(string genre, int capacity)
        {
            // Проверяем, нет ли уже шкафа с таким жанром (жанр должен быть уникальным)
            if (bookCases.Any(bc => bc.genre == genre))
                throw new InvalidOperationException($"Шкаф с жанром '{genre}' уже существует.");

            // Проверяем, не достигнут ли лимит шкафов в магазине
            if (bookCases.Count >= MaxBookCases)
                throw new InvalidOperationException($"Достигнуто максимальное количество шкафов ({MaxBookCases}).");

            // Создаём новый шкаф и добавляем его в список
            bookCases.Add(new BookCase(genre, capacity));
        }

        /// <summary>
        /// Добавляет книгу в магазин (в соответствующий шкаф по жанру).
        /// </summary>
        /// <param name="book">Книга для добавления</param>
        public void AddBook(Book book)
        {
            // Проверяем, что книга не null
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            // Ищем шкаф с жанром, соответствующим жанру книги
            BookCase targetCase = bookCases.FirstOrDefault(bc => bc.genre == book.Genre);

            // Если шкаф с таким жанром не найден
            if (targetCase == null)
            {
                // Проверяем, есть ли место для нового шкафа
                if (bookCases.Count >= MaxBookCases)
                    throw new InvalidOperationException($"Нет места для нового жанра '{book.Genre}'.");

                // Создаём новый шкаф для этого жанра (вместимость по умолчанию 10 книг)
                AddBookCase(book.Genre, 10);
                // Находим только что созданный шкаф
                targetCase = bookCases.First(bc => bc.genre == book.Genre);
            }

            // Добавляем книгу в найденный/созданный шкаф
            targetCase.AddBook(book);
        }

        /// <summary>
        /// Продаёт книгу по ID и обновляет баланс.
        /// </summary>
        /// <param name="bookId">Идентификационный номер книги</param>
        public void SellBook(int bookId)
        {
            // Ищем книгу по ID во всех шкафах
            Book book = FindBookById(bookId);
            // Если книга не найдена, выбрасываем исключение
            if (book == null)
                throw new InvalidOperationException($"Книга с ID {bookId} не найдена.");

            // Проходим по всем шкафам для поиска книги
            foreach (var bookCase in bookCases)
            {
                // Проверяем, есть ли эта книга в текущем шкафу
                if (bookCase.FindById(bookId) != null)
                {
                    // Получаем цену книги и добавляем её к балансу магазина
                    Balance += book.Sell();
                    // Удаляем книгу из шкафа (освобождаем место)
                    bookCase.RemoveBook(bookId);
                    // Выходим из метода, так как книга продана
                    return;
                }
            }
        }

        /// <summary>
        /// Находит книгу по ID во всех шкафах.
        /// </summary>
        /// <param name="id">Идентификационный номер книги</param>
        /// <returns>Найденная книга или null</returns>
        public Book FindBookById(int id)
        {
            // Проходим по всем шкафам в магазине
            foreach (var bookCase in bookCases)
            {
                // Пытаемся найти книгу в текущем шкафу
                Book found = bookCase.FindById(id);
                // Если книга найдена, возвращаем её
                if (found != null)
                    return found;
            }
            // Если книга не найдена ни в одном шкафу, возвращаем null
            return null;
        }

        /// <summary>
        /// Находит книгу по названию.
        /// </summary>
        /// <param name="title">Название книги</param>
        /// <returns>Найденная книга или null</returns>
        public Book FindBookByTitle(string title)
        {
            // Проходим по всем шкафам в магазине
            foreach (var bookCase in bookCases)
            {
                // Пытаемся найти книгу по названию в текущем шкафу
                Book found = bookCase.FindbyTitle(title);
                // Если книга найдена, возвращаем её
                if (found != null)
                    return found;
            }
            // Если книга не найдена ни в одном шкафу, возвращаем null
            return null;
        }

        /// <summary>
        /// Возвращает все книги в магазине.
        /// </summary>
        /// <returns>Список всех книг</returns>
        public List<Book> GetAllBooks()
        {
            // Создаём пустой список для хранения всех книг
            List<Book> allBooks = new List<Book>();
            // Проходим по всем шкафам
            foreach (var bookCase in bookCases)
                // Добавляем все книги из текущего шкафа в общий список
                allBooks.AddRange(bookCase.GetAllBooks());
            // Возвращаем полный список книг
            return allBooks;
        }

        /// <summary>
        /// Возвращает книги определённого жанра.
        /// </summary>
        /// <param name="genre">Жанр книг</param>
        /// <returns>Список книг указанного жанра</returns>
        public List<Book> GetBooksByGenre(string genre)
        {
            // Ищем шкаф с указанным жанром
            BookCase bookCase = bookCases.FirstOrDefault(bc => bc.genre == genre);
            // Если шкаф не найден, выбрасываем исключение
            if (bookCase == null)
                throw new InvalidOperationException($"Шкаф с жанром '{genre}' не найден.");
            // Возвращаем все книги из найденного шкафа
            return bookCase.GetAllBooks();
        }

        /// <summary>
        /// Возвращает список всех жанров в магазине.
        /// </summary>
        /// <returns>Список жанров</returns>
        public List<string> GetAllGenres()
        {
            // Извлекаем жанр из каждого шкафа и возвращаем как список
            return bookCases.Select(bc => bc.genre).ToList();
        }

        /// <summary>
        /// Очищает шкаф (продаёт все книги и освобождает место).
        /// </summary>
        /// <param name="genre">Жанр шкафа для очистки</param>
        public void ClearBookCase(string genre)
        {
            // Ищем шкаф с указанным жанром
            BookCase bookCase = bookCases.FirstOrDefault(bc => bc.genre == genre);
            // Если шкаф не найден, выбрасываем исключение
            if (bookCase == null)
                throw new InvalidOperationException($"Шкаф с жанром '{genre}' не найден.");

            // Проходим по всем книгам в шкафу и продаём их
            foreach (var book in bookCase.GetAllBooks())
                // Добавляем выручку от продажи каждой книги к балансу
                Balance += book.Sell();

            // Удаляем очищенный шкаф из магазина (освобождаем место для нового жанра)
            bookCases.Remove(bookCase);
        }
    }
}