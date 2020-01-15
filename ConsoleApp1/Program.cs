using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач_38__вар
{
    abstract class Information
    {
        int key;
        public int Key { get { return key; } set { key = value; } }
        public abstract string Info();
    }
    class Book : Information
    {
        string name;
        public string Name { get { return name; } set { name = value; } }
        string genre;
        public string Genre { get { return genre; } set { genre = value; } }
        string author;
        public string Author { get { return author; } set { author = value; } }
        int year_of_edition;
        public int Year_of_edition { get { return year_of_edition; } set { year_of_edition = value; } }
        int quantity_pages;
        public int Quantity_pages { get { return quantity_pages; } set { quantity_pages = value; } }
        string carrier;
        public string Carrier { get { return carrier; } set { carrier = value; } }
        public override string Info()
        {
            string data = Key + ";" + Name + ";" + Genre + ";" + Author + ";" + Year_of_edition + ";" + Quantity_pages + ";" + Carrier;
            return data;
        }
        public Book() { }
        public Book(int key, string name, string genre, string author, int year_of_edition, int quantity_pages, string carrier)
        {
            Key = key;
            Name = name;
            Genre = genre;
            Author = author;
            Year_of_edition = year_of_edition;
            Quantity_pages = quantity_pages;
            Carrier = carrier;
        }
    }
    class Catalog : Information
    {
        string author;
        public string Author { get { return author; } set { author = value; } }
        string name;
        public string Name { get { return name; } set { name = value; } }
        string cypher;
        public string Cypher { get { return cypher; } set { cypher = value; } }
        decimal price;
        public decimal Price { get { return price; } set { price = value; } }
        string carrier;
        public string Carrier { get { return carrier; } set { carrier = value; } }
        public override string Info()
        {
            string data = Key + ";" + Author + ";" + Name + ";" + Cypher + ";" + Price + ";" + Carrier;
            return data;
        }
        public Catalog() { }
        public Catalog(int key, string author, string name, string cypher, decimal price, string carrier)
        {
            Key = key;
            Author = author;
            Name = name;
            Cypher = cypher;
            Price = price;
            Carrier = carrier;
        }

    }
    class Shop : Information
    {
        string name;
        public string Name { get { return name; } set { name = value; } }
        decimal price;
        public decimal Price { get { return price; } set { price = value; } }
        string quantitry_sales;
        public string Quantitry_sales { get { return quantitry_sales; } set { quantitry_sales = value; } }
        string presence;
        public string Presence { get { return presence; } set { presence = value; } }
        public override string Info()
        {
            string data = Key + ";" + Name + ";" + Price + ";" + Quantitry_sales + ";" + Presence;
            return data;
        }
        public Shop() { }
        public Shop(int key, string name, decimal price, string quantitry_sales, string presence)
        {
            Key = key;
            Name = name;
            Price = price;
            Quantitry_sales = quantitry_sales;
            Presence = presence;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            FileRead();
            int n = -1;
            while (true)
            {
                Frame();
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Это не цифра, нажмите Enter");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                switch (n)
                {
                    case 1:
                        Books_of_ganre();
                        continue;
                    case 2:
                        Book_of_author();
                        continue;
                    case 3:
                        Author_of_best_selling_books();
                        continue;
                    case 4:
                        RemoveBookAtGenre();
                        continue;
                    case 5:
                        Console.WriteLine("Введите ключ книги: ");
                        int key = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите название книги: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите жанр книги: ");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Введите автора книги: ");
                        string author = Console.ReadLine();
                        Console.WriteLine("Введите год издания: ");
                        int year_of_edition = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите количество страниц: ");
                        int quantity_pages = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите носителя: ");
                        string carrier = Console.ReadLine();
                        AddBook(key, name, genre, author, year_of_edition, quantity_pages, carrier);
                        continue;
                    case 6:
                        BookistView();
                        continue;
                    case 7:
                        CatalogListView();
                        continue;
                    case 8:
                        ShopListView();
                        continue;
                    case 0:
                        Console.Clear();
                        Console.WriteLine
                            ("Выйти из программы - да, нет - любая клавиша");
                        string s = Console.ReadLine();
                        if (s == "да") Environment.Exit(0);
                        else
                        {
                            Console.Clear();
                            continue;
                        }
                        continue;

                    default:
                        Console.Clear();
                        Console.WriteLine
                            ("Введенный № отсутствует, нажмите любую клавишу");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }
            }
        }
        static void FileRead()
        {
            using (StreamReader sr = new StreamReader(BookPath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(';');
                    lstBook.Add(new Book(Convert.ToInt32(words[0]), Convert.ToString(words[1]), Convert.ToString(words[2]), Convert.ToString(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), Convert.ToString(words[6])));
                    //  Console.WriteLine(line);
                }

            }
            using (StreamReader sr = new StreamReader(CatalogPath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(';');
                    lstCatalog.Add(new Catalog(Convert.ToInt32(words[0]), Convert.ToString(words[1]), Convert.ToString(words[2]), Convert.ToString(words[3]), Convert.ToDecimal(words[4]), Convert.ToString(words[5])));
                    //  Console.WriteLine(line);
                }

            }
            using (StreamReader sr = new StreamReader(ShopPath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(';');
                    lstShop.Add(new Shop(Convert.ToInt32(words[0]), Convert.ToString(words[1]), Convert.ToDecimal(words[2]), Convert.ToString(words[3]), Convert.ToString(words[4])));
                    //  Console.WriteLine(line);
                }

            }
        }
        static void Frame()
        {
            Console.WriteLine("\tВыберите № задачи\n");
            Console.WriteLine("1 - Книги в данном жанре");
            Console.WriteLine("2 - Книги данного автора");
            Console.WriteLine("3 - Автор самой продаваемой книги");
            Console.WriteLine("4 - Удалить книги заданого жанра");
            Console.WriteLine("5 - Добавить книгу");
            Console.WriteLine("6 - Просмотреть список книг");
            Console.WriteLine("7 - Просмотреть список каталогов");
            Console.WriteLine("8 - Просмотреть список книг закупаемых магазином");
            Console.WriteLine("0 - Выход из программы");
        }
        static public void Books_of_ganre()
        {
            Console.WriteLine("Введите жанр книги: ");
            string genre = Console.ReadLine();
            var s = from v in lstBook
                    where v.Genre == genre
                    select v.Name;

            Console.WriteLine("Книги в этом жанре: ");
            foreach (string t in s)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine
                            ("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static public void Book_of_author()
        {
            Console.WriteLine("Введите автора книги: ");
            string author = Console.ReadLine();
            var s = from v in lstBook
                    where v.Author == author
                    select v.Name;

            Console.WriteLine("Книги в этого автора: ");
            foreach (string t in s)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine
                            ("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static public void Author_of_best_selling_books()
        {
            var max = lstShop.Max(x => x.Quantitry_sales);
            var s = from v in lstShop
                    join b in lstBook on v.Name equals b.Name
                    where v.Quantitry_sales == max
                    where v.Name == b.Name
                    select b.Author;

            Console.WriteLine("Автор самых продаваемых книг: ");
            foreach (string t in s)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine
                            ("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static public void BookistView()
        {
            Console.Clear();
            Console.WriteLine("Ключ;Название;Жанр;Автор;Год издания;Колчество страниц;Носитель");
            foreach (Book ns in lstBook)
            {

                Console.WriteLine(ns.Info());
            }
            Console.WriteLine
                            ("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static public void CatalogListView()
        {
            Console.Clear();
            Console.WriteLine("Ключ;Автор;Название;Шифр;Цена(розница);Носитель");
            foreach (Catalog ns in lstCatalog)
            {

                Console.WriteLine(ns.Info());
            }
            Console.WriteLine
                            ("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static public void ShopListView()
        {
            Console.Clear();
            Console.WriteLine("Ключ;Название;Цена(опт);Количество продаж;Наличие");
            foreach (Shop ns in lstShop)
            {

                Console.WriteLine(ns.Info());
            }
            Console.WriteLine
                            ("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static public void RemoveBookAtGenre()
        {
            Console.Clear();
            Console.WriteLine("Жанры\n");
            foreach (var ns in lstBook)
            {
                Console.WriteLine(ns.Genre);
            }
            Console.WriteLine("\nВведите жанр\n");
            string genre = Console.ReadLine();
            var elem = lstBook.Where(nw => nw.Genre == genre).First();
            lstBook.Remove(elem);
            using (StreamWriter sw = new StreamWriter(BookPath, false, System.Text.Encoding.Default))
            {
                foreach (Book np in lstBook)
                {
                    sw.WriteLine(np.Info());
                }
            }
            Console.WriteLine("Книги в этом жанре успешно удалены\n" + "Нажмите любую клавишу чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }
        static public void AddBook(int key, string name, string genre, string author, int year_of_edition, int quantity_pages, string carrier)
        {

            lstBook.Add(new Book(key, name, genre, author, year_of_edition, quantity_pages, carrier));
            using (StreamWriter sw = new StreamWriter(BookPath, false, System.Text.Encoding.Default))
            {
                foreach (Book ns in lstBook)
                {
                    sw.WriteLine(ns.Info());
                }
            }
            Console.WriteLine
                            ("Книга успешно добавлена");
            Console.WriteLine
                            ("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static List<Book> lstBook = new List<Book>();
        static List<Catalog> lstCatalog = new List<Catalog>();
        static List<Shop> lstShop = new List<Shop>();
        static string BookPath = Directory.GetCurrentDirectory() + "\\Book.txt";
        static string CatalogPath = Directory.GetCurrentDirectory() + "\\Catalog.txt";
        static string ShopPath = Directory.GetCurrentDirectory() + "\\Shop.txt";
    }
}
