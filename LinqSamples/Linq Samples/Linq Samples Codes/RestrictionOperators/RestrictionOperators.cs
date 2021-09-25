using Linq_Samples.DBContext;
using Linq_Samples.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unipluss.Sign.ExternalContract.Entities;

namespace Linq_Samples.Linq_Samples_Codes.RestrictionOperators
{
    public partial class RestrictionOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public RestrictionOperators()
        {
            InitializeComponent();
        } public void Temizle()
        {
            listView1.Items.Clear();

        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Temizle();
            if (radioButton1.Checked == true)
            { 
                // "where" - Bir yüklem işlevine göre değerleri filtrele
                // "OfType" - Belirtilen bir tür olma yeteneklerine göre değerleri filtrele

                int[] numbers = { 5, 4, 1, 3, 2, 9, 8, 6, 7, 0 };

                //Linq ile Lambda kullanımı
                //var lowNums = numbers.Where(num => num < 5);

                // 5'ten küçük tüm sayıları seç
                var lowNums = from num in numbers
                              where num < 5
                              select num;

                foreach (var x in lowNums)
                {
                    listView1.Items.Add(x.ToString());
                }
                MessageBox.Show("Değeri 5'ten küçük olan bir dizinin tüm öğelerini bulmak...");
            }
            if (radioButton2.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //Where(), OfType() çağrıldıktan sonra ArrayList türüne uygulanabilir.
                // IEnumerable<string> query2 = fruits.OfType<string>().Where(fruit => fruit.ToLower().Contains("n"));


                ArrayList fruits = new ArrayList(4) { "Mango", "Orange", "Apple", 3.0, "Banana" };
                // OfType()'ı ArrayList'e uygula.
                IEnumerable<string> query1 = fruits.OfType<string>();

                foreach (string fruit in query1)
                {
                    listView1.Items.Add(fruit);
                }
                MessageBox.Show("Dizideki string olanları getirir...");
            }

            if (radioButton3.Checked == true)
            {

                //Rakamları döndüren dizine alınmış bir where yan tümcesini gösterir.
                string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

                var shortDigits = digits.Where((digit, index) => digit.Length < index);

                foreach (var d in shortDigits)
                {
                    listView1.Items.Add(d);

                }
                MessageBox.Show("Dizi uzunluğunu dizideki kelimelerin uzunluklarından küçük olanları getir...");
            }

            if (radioButton4.Checked == true)
            {
                //Linq ile Lambda Kullanımı
                // var sorgu = _context.Products.Where(pro => pro.UnitsInStock == 0);

                // Stokta olmayan tüm numaraları bul
                var sorgu = from pro in _context.Products
                            where pro.UnitsInStock == 0
                            select new
                            {
                                pro.ProductID,
                                pro.ProductName
                            };

                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("Stokta olmayan tüm numaraları bul...");
            }

            if (radioButton5.Checked == true)
            {
                //Linq ile Lambd Kullanımı
                //var sorgu = _context.Products.Where(pro => pro.UnitsInStock >= 0 && pro.UnitsInStock >= 3.00M);

                // Birim başına 3.00'den fazla maliyeti getir
                var sorgu = from pro in _context.Products
                            where pro.UnitsInStock > 0 && pro.UnitsInStock > 3.00M
                            select new
                            {
                                pro.ProductID,
                                pro.ProductName,
                                pro.UnitsInStock
                            };


                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("Birim başına 3.00'den fazla maliyeti getir...");
            }

            if (radioButton6.Checked == true)
            {
                //Linq ile Lambd Kullanımı
                //var sorgu = _context.Customers.Where(cus=>cus.Region=="WA");

                //Tüm müşteriler için siparişi oluşturan kişinin adını  ve kişinin adresini görüntüleyin (Bölge == "WA")
                var sorgu = (from cus in _context.Customers
                             where cus.Region == "WA"
                             select new
                             {
                                 cus.Region,
                                 cus.ContactName,                            
                                 cus.Address
                             });
                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("Bölgesi WA olan Tüm müşterilerin  adını  ve  adresini görüntüleyin ...");
            }
        }
    }
}
