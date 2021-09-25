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

namespace Linq_Samples.Linq_Samples_Codes.PartitioningOperators
{
    public partial class PartitioningOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public PartitioningOperators()
        {
            InitializeComponent();
        }
        public void Temizle()
        {
            listView1.Items.Clear();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Temizle();
            if (radioButton19.Checked == true)
            {
                //Take, yalnızca ilk 3 öğesini almak için Take kullanır
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var first3Numbers = numbers.Take(3);

                foreach(var n in first3Numbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("Dizideki ilk 3 değeri getir...");
            }
            if (radioButton20.Checked == true)
            {
                // Müşterilerden ilk 3 siparişi almak için Take kullanıyor

                var sorgu = (from c in _context.Customers
                            join o in _context.Orders on c.CustomerID equals o.CustomerID
                            where c.Region== "WA"
                            select new
                            {
                                c.ContactName,
                                c.CompanyName,
                                c.Region,
                                o.OrderDate,
                                o.ShipName
                            }).Take(3);
                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("Müşterilerin WA bölgesindeki oluşturdukları siparişlerin  ilk 3 siparişi getir...");
            }
            if (radioButton21.Checked == true)
            {
                // Skip, dizinin ilk dört öğesi dışında tümünü almak için Atla'yı kullanır.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                var allButFirst4Numbers = numbers.Skip(4);

                foreach(var n in allButFirst4Numbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("Dizideki ilk 4 öğesi dışında tümünü al...");
            }
            if (radioButton22.Checked == true)
            {
               // Müşterilerden gelen ilk 4 sipariş dışındaki tüm siparişleri almak için Al'ı kullanır " +


                var sorgu = from c in _context.Customers
                             join o in _context.Orders on c.CustomerID equals o.CustomerID
                             where c.Region == "WA"
                             select (new
                             {
                                 c.ContactName,
                                 c.CompanyName,
                                 c.Region,
                                 o.OrderDate,
                                 o.ShipName
                             });
                var allButFirst4Data= sorgu.Skip(4);
                dataGridView1.DataSource = sorgu.ToList();
                MessageBox.Show("Müşterilerden gelen ilk 4 sipariş dışındaki tüm siparişleri al...");
            }
            if (radioButton23.Checked == true)
            {
                //Başlayan öğeleri döndürmek için TakeWhile kullanır.
               //"Değeri 6'dan küçük olmayan bir sayı okunana kadar dizinin başlangıcı."
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);
                foreach (var num in firstNumbersLessThan6)
                {
                    listView1.Items.Add(num.ToString());
                }
                MessageBox.Show("Değeri 6'dan küçük olmayan bir sayı okunana kadar dizinin başlangıcı döndür...");
            }
            if (radioButton24.Checked == true)
            {
                //Dizinin başlangıcından, konumundan daha küçük bir sayıya ulaşana kadar döndür
                
                int[] numbers = { 5, 4, 1, 9, 8, 3, 6, 7, 2, 0 };
                var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);
                foreach (var n in firstSmallNumbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("Dizinin başlangıcından, konumundan daha küçük bir sayıya ulaşana kadar döndür...");
            }
            if (radioButton25.Checked == true)
            {

                //Dizisinin öğelerini almak için SkipWhile kullanır.
                  //3 ile bölünebilen ilk elemandan başlayarak değerleri yazdır.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var allButFirst3Numbers = numbers.SkipWhile(n => n % 3 != 0);
                foreach (var n in allButFirst3Numbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("3 ile bölünebilen ilk elemandan başlayarak değerleri yazdır...");
            }
            if (radioButton26.Checked == true)
            {
               // Konumundan daha az ilk elemandan başlayarak.

                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var laterNumbers = numbers.SkipWhile((n,index)=> n >= index);
                foreach (var n in laterNumbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("Konumundan daha az ilk elemandan başlayarak...");
            }
        }
    }
}
