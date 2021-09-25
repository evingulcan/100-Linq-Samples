using Linq_Samples.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Samples.Linq_Samples_Codes.AggregateOperators
{
    public partial class AggregateOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public AggregateOperators()
        {
            InitializeComponent();
        }
        public void Temizle()
        {
            listView1.Items.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Temizle();
            if (radioButton64.Checked == true)
            {
                //300'ün benzersiz asal çarpanlarının sayısını elde etmek için Count (ve farklı) kullanır.
                int[] primeFactorsOf300 = { 2, 2, 3, 5, 5 };
                int uniqueFactors = primeFactorsOf300.Distinct().Count();
                listView1.Items.Add(uniqueFactors.ToString());
                MessageBox.Show("300'ün benzersiz asal çarpanlarının sayısını elde etmek...");
            }
            if (radioButton65.Checked == true)
            {
                //Dizideki tek sayıların sayısını almak için Count kullanır.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                int oddNumbers = numbers.Count(n => n % 2 == 1);
                listView1.Items.Add(numbers.ToString());
                MessageBox.Show("Dizideki tek sayıların sayısını almak...");

            }
            if (radioButton66.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var categoryCounts = _context.Products
                //    .GroupBy(pro => pro.CategoryID)
                //    .Select(proGroup => new
                //    {
                //        Category = prodGroup.Key,
                //        ProductCount = prodGroup.Count()
                //    });

                //Bir kategori listesi ve kaç ürün döndürmek için Count kullanır.

                var categoryCounts =
                from prod in _context.Products
                group prod by prod.CategoryID into prodGroup
                select new 
                { 
                    Category = prodGroup.Key, 
                    ProductCount = prodGroup.Count()
                };

                dataGridView1.DataSource = categoryCounts.ToList();
                MessageBox.Show("Bir kategori listesi ve kaç ürün olduğunu topla...");
            }
            if (radioButton67.Checked == true)
            {
                //Bir dizideki tüm sayıları eklemek için Sum'u kullanır.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                double numSum = numbers.Sum();
                listView1.Items.Add(numSum.ToString());
                MessageBox.Show("Dizideki tüm sayıları toplama ...");
            }
            if (radioButton68.Checked == true)
            {
                //Dizideki tüm kelimelerin toplam karakter sayısını almak için Sum'u kullanır.
                string[] words = { "cherry", "apple", "blueberry" };

                double totalChars = words.Sum(w=>w.Length);
                listView1.Items.Add(totalChars.ToString());
                MessageBox.Show("Dizideki tüm kelimelerin toplam karakter sayısını almak....");
            }
            if (radioButton69.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var categories = _context.Products.GroupBy(pro => pro.CategoryID)
                //    .Select(proGroup => new
                //    {
                //        Category=proGroup.Key,
                //        TotalUnitsInStock=proGroup.Sum(p=>p.UnitsInStock)
                //    });

                //Her ürün kategorisi için stoktaki toplam birimleri almak için Sum'u kullanır.
                var categories = from pro in _context.Products
                                 group pro by pro.CategoryID into proGroup
                                 select new 
                                 { 
                                     Category=proGroup.Key,
                                     TotalUnitsInStock=proGroup.Sum(p=>p.UnitsInStock)
                                 };
              
                dataGridView1.DataSource = categories.ToList();
                MessageBox.Show("Her ürün kategorisi için stoktaki toplam birimleri almak ....");
            }
            if (radioButton70.Checked == true)
            {
                //Bir dizideki en düşük sayıyı almak için Min'i kullanır.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                int minNum = numbers.Min();

                listView1.Items.Add(minNum.ToString());
                MessageBox.Show("Bir dizideki en düşük sayıyı almak....");

            }
            if (radioButton71.Checked == true)
            {
                //Bir dizideki en kısa kelimenin uzunluğunu almak için Min'i kullanır."
                string[] words = { "cherry", "apple", "blueberry" };

                int shortesWord = words.Min(w => w.Length);
                listView1.Items.Add(shortesWord.ToString());
                MessageBox.Show("Bir dizideki en kısa kelimenin uzunluğunu almak...");
            }
            if (radioButton72.Checked == true)
            {
                //Linq ile Lambda kullanma
                //var categories = _context.Products
                //    .GroupBy(pro => pro.CategoryID)
                //    .Select(proGroup => new
                //    {
                //        Category=proGroup.Key,
                //        CheapestPrice=proGroup.Min(p=>p.UnitPrice)
                //    });
                //Her kategorinin ürünleri arasında en ucuz fiyatı almak için Min'i kullanır.
                var categories = from pro in _context.Products
                                 group pro by pro.CategoryID into proGroup
                                 select new
                                 { 
                                     Category=proGroup.Key,
                                     CheapestPrice=proGroup.Min(p=>p.UnitPrice)
                                 };
                dataGridView1.DataSource = categories.ToList();
                MessageBox.Show("Her kategorinin ürünleri arasında en ucuz fiyatı almak....");
            }
            if (radioButton73.Checked == true)
            {
                //Her kategoride en düşük fiyata sahip ürünleri almak için Min'i kullanır.
                var categories = (from pro in _context.Products
                                 group pro by pro.CategoryID into proGroup
                                 let minPrice = proGroup.Min(p => p.UnitPrice)
                                 select new
                                 {
                                     Category=proGroup.Key,
                                     CheapestProducts=proGroup.Where(p=>p.UnitPrice==minPrice)
                                 }).Take(5);
                dataGridView1.DataSource = categories.ToList();

                MessageBox.Show("Her kategoride en düşük  fiyata sahip 5 ürün almak ...");
            }
            if (radioButton74.Checked == true)
            {
                //Bir dizideki en yüksek sayıyı almak için Maks'ı kullanır. Yöntemin tek bir değer döndürdüğünü unutmayın.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                int maxNum = numbers.Max();
                listView1.Items.Add(maxNum.ToString());
                MessageBox.Show("Dizideki en yüksek sayıyı almak...");

            }
            if (radioButton75.Checked == true)
            {
                //Dizideki en uzun kelimenin uzunluğunu almak için Max'i kullanır.
                string[] words = { "cherry", "apple", "blueberry" };

                int longestLength = words.Max(w => w.Length);
                listView1.Items.Add(longestLength.ToString());
                MessageBox.Show("Dizideki en uzun kelimenin uzunluğunu almak...");
            }
            if (radioButton76.Checked == true)
            {
                //Her kategorinin ürünleri arasında en pahalı fiyatı almak için Max'i kullanır.
                //var categories = _context.Products
                //    .GroupBy(pro => pro.CategoryID)
                //    .Select(proGroup => new
                //    {
                //        Category=proGroup.Key,
                //        MostExpensivePrice=proGroup.Max(p=>p.UnitPrice)
                //    });

                var categories =
                    from pro in _context.Products
                    group pro by pro.CategoryID into proGroup
                    select new {
                        Category = proGroup.Key, 
                        MostExpensivePrice = proGroup.Max(p => p.UnitPrice) };
                dataGridView1.DataSource = categories.ToList();
                MessageBox.Show("Her kategorinin ürünleri arasında en pahalı fiyatı almak....");
            }
            if (radioButton77.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var categories = _context.Products
                   //.GroupBy(pro => pro.CategoryID)
                   //.Select(proGroup => new { proGroup, maxPrice = proGroup.Max(p => p.UnitPrice) })
                   //.Select(pG => new {
                   //    Category = pG.proGroup.Key,
                   //    MostExpensiveProducts = pG.proGroup.Where(p => p.UnitPrice == pG.maxPrice)
                   //});

                //Her kategoride en pahalı fiyata sahip ürünleri almak için Max'i kullanır.
                var categories = from pro in _context.Products
                                 group pro by pro.CategoryID into proGroup
                                 let maxPrice = proGroup.Max(p => p.UnitPrice)
                                 select new
                                 {
                                     Category = proGroup.Key,
                                     MostExpensiveProducts = proGroup.Where(p => p.UnitPrice == maxPrice)
                                 };
                dataGridView1.DataSource = categories.ToList();
                MessageBox.Show("Her kategoride en pahalı fiyata sahip ürünleri almak...");
            }
            if (radioButton78.Checked == true)
            {

                //Bir dizideki tüm sayıların ortalamasını almak için Ortalama'yı kullanır.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                double averageNum = numbers.Average();

                listView1.Items.Add(numbers.ToString());
                MessageBox.Show("Bir dizideki tüm sayıların ortalamasını almak ...");

            }
            if (radioButton79.Checked == true)
            {
                //Dizideki kelimelerin ortalama uzunluğunu almak için Ortalama'yı kullanır.
                string[] words = { "cherry", "apple", "blueberry" };
                double averageLength = words.Average(w => w.Length);
                listView1.Items.Add(averageLength.ToString());
                MessageBox.Show("Bir dizideki tüm sayıların ortalamasını almak ...");

            }
            if (radioButton80.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var categories = _context.Products
                //.GroupBy(prod => prod.CategoryID)
                //.Select(prodGroup => new {
                //    Category = prodGroup.Key,
                //    AveragePrice = prodGroup.Average(p => p.UnitPrice)
                //});


                //Her kategorinin ürünlerinin ortalama fiyatını almak için Ortalama'yı kullanır.
                var categories =
                     from prod in _context.Products
                     group prod by prod.CategoryID into prodGroup
                     select new 
                     { 
                         Category = prodGroup.Key, 
                         AveragePrice = prodGroup.Average(p => p.UnitPrice) 
                     };
                dataGridView1.DataSource = categories.ToList();
                MessageBox.Show("Her kategorinin ürünlerinin ortalama fiyatını almak...");
            }
            if (radioButton81.Checked == true)
            {
                //Dizide çalışan bir ürün oluşturmak için Toplama kullanır.
                //tüm elemanların toplam çarpımını hesaplar.
                double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

                double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);

                listView1.Items.Add(product.ToString());
                MessageBox.Show("Tüm elemanların toplam çarpımını hesaplar...");

            }
            if (radioButton82.Checked == true)
            {
                //Bu örnek, geçerli bir hesap bakiyesi oluşturmak için Toplama'yı kullanır.
                // her para çekme işlemini 100'lük başlangıç ​​bakiyesinden çıkarır.
                // bakiye asla 0'ın altına düşmez.
                double startBalance = 100.0;

                int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

                double endBalance = attemptedWithdrawals.Aggregate(startBalance,
                    (balance, nextWithdrawal) => ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance));


                listView1.Items.Add(endBalance.ToString());
                MessageBox.Show("Tüm elemanların toplam çarpımını hesaplar...");

            }
        }
    }
}
