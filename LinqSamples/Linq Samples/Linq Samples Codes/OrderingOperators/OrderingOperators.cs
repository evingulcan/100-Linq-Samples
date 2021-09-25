using Linq_Samples.DBContext;
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

namespace Linq_Samples.Linq_Samples_Codes.OrderingOperators
{
    public partial class OrderingOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public OrderingOperators()
        {
            InitializeComponent();
        }
        public void Temizle()
        {
            listView1.Items.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Temizle();
            if (radioButton27.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //  var sortedWords =    words.OrderBy(word => word);

                //Bir kelime listesini alfabetik olarak sıralamak için orderby kullanır.
                string[] words = { "cherry", "apple", "blueberry" };
                var sortedWords = from word in words
                                  orderby word
                                  select word;
                foreach(var w in sortedWords)
                {
                    listView1.Items.Add(w);
                }
                MessageBox.Show("Bir kelime listesini alfabetik olarak sıralamak... ");
            }
            if (radioButton28.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var sortedWords = words.OrderBy(word => word.Length);


                // Bir kelime listesini uzunluğa göre sıralamak için orderby kullanır.
                string[] words = { "cherry", "apple", "blueberry" };

                var sortedWords =
                    from word in words
                    orderby word.Length
                    select word;
                foreach (var w in sortedWords)
                {
                    listView1.Items.Add(w);
                }
                MessageBox.Show(" Bir kelime listesini uzunluğa göre sıralamak...");
            }
            if (radioButton29.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var sortedProducts =_context.Products.OrderByDescending(prod => prod.ProductName);

                // Bir ürün listesini ada göre sıralamak için orderby kullanır.
                // Ters sıralama yapmak için yan tümcenin sonundaki \"descending\" anahtar sözcüğünü kullanın.
                var sortedProducts = from pro in _context.Products
                                     orderby pro.ProductName
                                     select (new { 
                                         pro.ProductName,  
                                     });

                dataGridView1.DataSource = sortedProducts.ToList();
                MessageBox.Show("Bir ürün listesini Ada göre sıralamak...");
            }
            if (radioButton30.Checked == true)
            {
                // Özel bir karşılaştırıcıya sahip bir OrderBy yan tümcesi kullanır.
                // Bir dizideki sözcüklerin büyük/küçük harfe duyarlı olmayan bir sıralaması.
                string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
               
                var sortedWords = words.OrderBy(a => a);
                foreach (var w in sortedWords)
                {
                    listView1.Items.Add(w);
                }
                MessageBox.Show("Bir dizideki sözcüklerin büyük/küçük harfe duyarlı olmayan bir sıralaması...");
            }
            if (radioButton31.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var sortedDoubles = doubles.OrderByDescending(d => d);

                // Bir listeyi sıralamak için orderby ve descending(azalan) kullanır
                double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

                var sortedDoubles =
                    from d in doubles
                    orderby d descending
                    select d;
                foreach (var d in sortedDoubles)
                {
                    listView1.Items.Add(d.ToString());
 
                }
                MessageBox.Show("Bir listeyi en yüksekten en düşüğe olarak sıralamak...");

            }
            if (radioButton32.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //  var sortedProducts = _context.Products.OrderByDescending(prod => prod.UnitsInStock).Take(10);

                // Bir ürün listesini stoktaki birimlere göre sıralamak için orderby kullanır
                // en yüksekten en düşüğe
                var sortedProducts = (from pro in _context.Products
                                      orderby pro.UnitsInStock descending
                                      select new
                                      {
                                          pro.ProductID,
                                          pro.ProductName,
                                         
                                      }).Take(10);
                dataGridView1.DataSource = sortedProducts.ToList();
                MessageBox.Show("Bir ürün listesini stoktaki birimlere göre  en yüksekten en düşüğe sıralamak ...");
            }
            if (radioButton33.Checked == true)
            {
                //OrderByDescending'i çağırmak için yöntem sözdizimini kullanır, çünkü
                // Özel bir karşılaştırıcı kullanmanızı sağlar.
                string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

                var sortedWords = words.OrderByDescending(a => a);
                foreach (var w in sortedWords)
                {
                    listView1.Items.Add(w);
                }
                MessageBox.Show(" Bir kelime listesini uzunluğa göre sıralamak...");
            }
            if (radioButton34.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var sortedDigits = digits.OrderBy(digit => digit.Length).ThenBy(digit => digit);

                // Bir basamak listesini sıralamak için bileşik bir sıralama kullanır,
                // önce adlarının uzunluğuna göre, sonra alfabetik olarak adın kendisine göre.

                string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                var sortedDigits = from digit in digits
                                   orderby digit.Length, digit
                                   select digit;

                foreach (var d in sortedDigits)
                {
                    listView1.Items.Add(d);
                }
                MessageBox.Show("Önce adlarının uzunluğuna göre, sonra alfabetik olarak adın kendisine göre sıralama...");
            }
            if (radioButton35.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var sortedProducts = _context.Products
                //                          .OrderBy(prod => prod.CategoryID)
                //                          .ThenByDescending(prod => prod.UnitPrice).Take(10);


                // Bir ürün listesini sıralamak için bileşik bir sıralama kullanır,
                // önce kategoriye göre, sonra birim fiyata göre en yüksekten en düşüğe.
                var sortedProducts = (from pro in _context.Products
                                      orderby pro.CategoryID, pro.UnitPrice descending
                                      select new
                                      {
                                          pro.ProductID,
                                          pro.ProductName,
                                      }).Take(5);

                dataGridView1.DataSource = sortedProducts.ToList();
                MessageBox.Show("Önce kategoriye göre, sonra birim fiyata göre en yüksekten en düşüğe...");
            }
            if (radioButton36.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //  var reversedIDigits = digits.Where(digit => digit[1] == 'i').Reverse();

                // dizideki tüm rakamların bir listesini oluşturmak için Ters kullanır.
                // ikinci harf, orijinal dizideki sıranın tersi olan 'i'dir.
                string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                var reversedIDigits = (
                from digit in digits
                where digit[1] == 'i'
                select digit)
                 .Reverse();

                foreach (var d in reversedIDigits)
                {
                    listView1.Items.Add(d);
                }
                MessageBox.Show("Dizideki kelimelerden ikinci harfi (i) olanları getir...");
            }

            if (radioButton37.Checked == true)
            {
                // özel bir karşılaştırıcıyla OrderBy ve ThenBy'yi çağırmak için yöntem sözdizimini kullanır " +
                // bir dizideki sözcükleri önce sözcük uzunluğuna ve ardından büyük/küçük harfe duyarlı olmayan bir sıralamaya göre sıralayın.

                string[] words = { "aPPLEE", "AbAcUsS", "bRaNcHHh", "BlUeBeRrYYyy", "ClOvErRrRr", "cHeRryYyRr" };

                IEnumerable<string> sortedWords =
                    words.OrderBy(a => a.Length)
                         .ThenByDescending(a => a, new CaseInsensitiveCompare());

                foreach (var d in sortedWords)
                {
                    listView1.Items.Add(d);
                }
                MessageBox.Show("Bir dizideki sözcükleri önce sözcük uzunluğuna, en yüksekten en düşüğe  ve ardından büyük/küçük harfe duyarlı olmayan bir sıralamaya göre sıralayın...");
            }
            if (radioButton38.Checked == true)
            {
           
                // özel bir karşılaştırıcıyla OrderBy ve ThenBy'yi çağırmak için yöntem sözdizimini kullanır " +
                // bir dizideki sözcükleri önce sözcük uzunluğuna ve ardından büyük/küçük harfe duyarlı olmayan bir sıralamaya göre sıralayın.
                string[] words = { "aPPLE", "AbAcUss", "bRaNcH", "BlUeBeRrY", "ClOvErrr", "cHeRryyyyy" };

                IEnumerable<string> sortedWords =
                    words.OrderBy(a => a.Length)
                         .ThenBy(a => a, new CaseInsensitiveCompare());
                foreach (var d in sortedWords)
                {
                    listView1.Items.Add(d);
                }
                MessageBox.Show("Bir dizideki sözcükleri önce sözcük uzunluğuna ve ardından büyük/küçük harfe duyarlı olmayan bir sıralamaya göre sıralayın...");
            }

        }
    }
}
