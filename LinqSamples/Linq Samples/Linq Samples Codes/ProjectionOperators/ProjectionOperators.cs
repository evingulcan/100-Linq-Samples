using Linq_Samples.DBContext;
using Linq_Samples.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Samples.Linq_Samples_Codes.ProjectionOperators
{
    public partial class ProjectionOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public ProjectionOperators()
        {
            InitializeComponent();
        }
        public void Temizle()
        {
            listView1.Items.Clear();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
            if (radioButton7.Checked == true)
            {
                //Linq ile Lambda Kullanımı
                // var nums = numbers.Select(n => n + 1);


                // Dizideki her bir sayıyı 1 artırır

                int[] numbers = { 5, 4, 1, 3, 2, 9, 8, 6, 7, 0 };
                var nums = from n in numbers
                           select n + 1;
                foreach (var i in nums)
                {
                    listView1.Items.Add(i.ToString());
                }
                MessageBox.Show("Dizideki değerleri 1 arttır...");
            }

            if (radioButton8.Checked == true)
            {
                //Büyük harfe döüştürmek için ToUpper kullanır
                //küçük harfe dönüştürmek için ToLower kullanır

                var sorgu = _context.Customers.Select(c => new
                {
                    CompanyName = c.CompanyName.ToUpper(),
                    ContactName = c.ContactName.ToLower()

                });
                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("CompanyName ları Büyük harfe dönüştür ve ContactName larıda Küçük harfe dönüştür...");
            }
            if (radioButton9.Checked == true)
            {

                //Linq ile Lambda Kullanımı
                //  var textNums = numbers.Select(n => strings[n]);

                //Bir int dizisinin metin versiyonu yapma
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

                var textNums = from num in numbers
                               select strings[num];

                foreach (var s in textNums)
                {
                    listView1.Items.Add(s);

                }
                MessageBox.Show("Bir int dizisinin metin versiyonu...");
            }

            if (radioButton10.Checked == true)
            {

                var sorgu = from sup in _context.Suppliers
                            select (new
                            {
                                sup.SupplierID,
                                sup.CompanyName,
                                sup.ContactName
                            });
                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("Tedarikçilerin isteninen bilgilerini getir...");
            }
            if (radioButton11.Checked == true)
            {
              
                // bir dizide dizideki konumlarıyla eşleşir.
               
                    int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                    var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

                    foreach (var s in numsInPlace)
                    {
                        listView1.Items.Add(s.ToString());

                    }
                MessageBox.Show("Bir dizide dizideki konumlarıyla eşleşir...");
            }
            if (radioButton12.Checked == true)
            {
                
                // her basamağın 5'ten küçük metin biçimi.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

                var lowNums =
                    from num in numbers
                    where num < 5
                    select digits[num];
                foreach (var s in lowNums)
                {
                    listView1.Items.Add(s.ToString());

                }
                MessageBox.Show("Her basamağın 5'ten küçük metin biçimi....");
            }
            if (radioButton13.Checked == true)
            {
                //A sayılarından gelen sayı sayıdan küçük olacak şekilde her iki dizideki sayıların B sayılarıyla kıyaslama yapılır
               
                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
                int[] numbersB = { 1, 3, 5, 7, 8 };

                var pairs = from a in numbersA
                            from b in numbersB
                            where a < b
                            select new { a, b };

                foreach (var s in pairs)
                {
                    listView1.Items.Add(s.ToString());

                }
                MessageBox.Show("A sayılarından gelen sayı sayıdan küçük olacak şekilde her iki dizideki sayıların B sayılarıyla kıyaslama yapılır....");
            }
            if (radioButton14.Checked == true)
            {
               //Rakamların temsilleri ve metin uzunluğunun çift mi yoksa tek mi olduğunu belirten bir Boole.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

                var digitOddEvens =
                    from num in numbers
                    select new {
                        Digit = strings[num], 
                        Even = (num % 2 == 0) };

                foreach (var digit in digitOddEvens)
                {
                    listView1.Items.Add(digit.ToString());
                }
                MessageBox.Show("Rakamların temsilleri ve metin uzunluğunun çift mi yoksa tek mi olduğunu belirten bir Boole.....");
            }
            if (radioButton15.Checked == true)
            {
                var sorgu = from c in _context.Customers
                            join o in _context.Orders on c.CustomerID equals o.CustomerID
                            where o.Freight < 40.000
                            select (new
                            {

                             c.CompanyName,
                             c.ContactName,
                             o.ShipName,
                             o.ShipCountry,
                             o.ShipVia,
                            
                           
                             
                            });
                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("Müşterinin oluşturduğu siparişin nakliyesi 40.000'den az olanları getir.....");
            }
            if (radioButton16.Checked == true)
            {
                var sorgu = from c in _context.Customers
                            join o in _context.Orders on c.CustomerID equals o.CustomerID
                            where o.OrderDate >= new DateTime(1996, 2, 1)
                            select (new
                            {
                                c.ContactName,
                                o.ShipName,
                                o.OrderDate
                            });
                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("Siparişi 1996'de veya daha sonra yapılanlar....");
            }
            if (radioButton17.Checked == true)
            {
                var sorgu = from c in _context.Customers
                            where c.Region=="WA"
                            join o in _context.Orders on c.CustomerID equals o.CustomerID
                            where o.OrderDate >= new DateTime(1997, 1, 1)
                            select (new
                            {
                                c.ContactName,
                                c.Region,
                                o.OrderDate,
                            });
                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("WA bölgesindeki  müşterilerin oluşturunan siparişlerin 1997,1,1 den sonralarını getir....");
            }
            if (radioButton18.Checked == true)
            {
                var sorgu = _context.Customers.SelectMany(c => _context.Orders.
                  Where(o => o.CustomerID == c.CustomerID),
                (c, o) => new
                {
                    c.ContactName,
                    c.CompanyName,
                    o.OrderDate,
                    o.ShipName
                });
                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("SelectMany ile Müşterileri ve Siparişleri birleştirmek...");
            }

        }

       
    }
}
