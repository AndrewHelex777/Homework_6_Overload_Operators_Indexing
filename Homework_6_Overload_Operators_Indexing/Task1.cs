namespace Homework_6_Overload_Operators_Indexing
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool IsRead { get; set; }
        public Book(string t, string a, int y, bool r)
        {
            Title = t;
            Author = a;
            Year = y;
            IsRead = r;
        }
        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nYear: {Year}\nIs read? {IsRead}";
        }
        public static bool operator ==(Book a, Book b)
        {
            return (a.Title == b.Title && a.Author == b.Author && a.Year == b.Year);
        }
        public static bool operator !=(Book a, Book b)
        {
            return !(a==b);
        }
    }
    class ReadingList
    {
        private Book[] books;
        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return books.Length;
            }
            set
            {
                if (value < Count || value < 0)
                {
                    throw new ArgumentException("Invalid capacity!");
                }
                Array.Resize(ref books, value);
            }
        }
        public ReadingList(int c)
        {
            books = new Book[c];
            Count = 0;
        }
        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Wrong index");
                }
                return books[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Wrong index");
                }
                books[index] = value;
            }
        }
        public static ReadingList operator +(ReadingList rl, Book b)
        {
            if (rl.Count >= rl.Capacity)
            {
                rl.Capacity = rl.Capacity == 0 ? 1 : rl.Capacity * 2;
            }
            rl.books[rl.Count++] = b;
            return rl;
        }
        public static ReadingList operator -(ReadingList rl, Book b)
        {
            int index = -1;
            for (int i = 0; i < rl.Count; i++)
            {
                if (rl.books[i] == b)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                for (int i = index; i < rl.Count - 1; i++)
                {
                    rl.books[i] = rl.books[i + 1];
                }
                rl.Count--;
            }
            return rl;
        }
        public bool Contains(Book b)
        {
            for (int i = 0; i < Count; i++)
            {
                if (books[i] == b)
                {
                    return true;
                }
            }
            return false;
        }
        public void Display()
        {
            if (Count == 0)
            {
                Console.WriteLine("Reading list is empty.");
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.WriteLine($"{i + 1}.\n{books[i]}\n");
                }
            }
        }
    }
    internal class Task1
    {
        static void Main(string[] args)
        {
            try
            {
                Book b1 = new Book("Pride and Prejudice", "Jane Austen", 1813, true);
                Book b2 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, false);
                Book b3 = new Book("Harry Potter and the Philosopher's Stone", "J. K. Rowling", 1997, true);
                Book b4 = new Book("Fourth Wing", "Rebecca Yarros", 2023, false);
                ReadingList rl = new ReadingList(3);
                rl += b1;
                rl += b2;
                rl += b3;
                rl.Display();

                Console.WriteLine($"Properties:\nCount: {rl.Count}\nCapacity: {rl.Capacity}\n");
                Console.WriteLine($"Indexing: book by index 1:\n{rl[1]}\n");
                rl[1].IsRead = true;
                Console.WriteLine($"Indexing: book by index 1 after changing IsRead:\n{rl[1]}\n");
                Console.WriteLine($"Book \"{b1.Title}\" in reading list? {rl.Contains(b1)}");
                Console.WriteLine($"Book \"{b4.Title}\" in reading list? {rl.Contains(b4)}\n");

                rl -= b1;
                Console.WriteLine($"Reading list after deleting book 1:");
                rl.Display();
                Console.WriteLine($"Properties:\nCount: {rl.Count}\nCapacity: {rl.Capacity}\n");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
