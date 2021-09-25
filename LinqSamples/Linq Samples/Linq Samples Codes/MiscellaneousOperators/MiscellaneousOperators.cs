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

namespace Linq_Samples.Linq_Samples_Codes.MiscellaneousOperators
{
    public partial class MiscellaneousOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public MiscellaneousOperators()
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
            if (radioButton84.Checked == true)
            {
                //her dizinin dizisini içeren bir dizi oluşturmak için Concat'i kullanır.
                //değerler, birbiri ardına.
                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
                int[] numbersB = { 1, 3, 5, 7, 8 };

                var allNumbers = numbersA.Concat(numbersB);
                foreach (var n in allNumbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("Her iki diziyi birbiri ardına yazma...");
            }
            if (radioButton85.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var allNames = _context.Customers
                //    .Select(cust => cust.CompanyName)
                //    .Concat(_context.Products.Select(pro => pro.ProductName));

                //adlarını içeren bir dizi oluşturmak için Concat'i kullanır.
                // yinelenenler dahil tüm müşteriler ve ürünler.
                var customerNames = from cust in _context.Customers
                                    select cust.CompanyName;
                var productNames = from pro in _context.Products
                                   select pro.ProductName;

                var allNames = customerNames.Concat(productNames);


                foreach (var n in allNames)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("Adlarını içeren bir dizi oluşturmak  yinelenenler dahil tüm müşteriler ve ürünler...");
            }
            if (radioButton86.Checked == true)
            {
                //İki dizinin tüm öğelerde eşleşip eşleşmediğini görmek için SequenceEquals kullanır
        
                var wordsA = new string[] { "cherry", "apple", "blueberry" };
                var wordsB = new string[] { "cherry", "apple", "blueberry" };

                bool match = wordsA.SequenceEqual(wordsB);

                listView1.Items.Add(match.ToString());
                MessageBox.Show("İki dizinin tüm öğelerde eşleşip eşleşmediğini boole onaylamak...");
            }
            if (radioButton87.Checked == true)
            {
                //İki dizinin tüm öğelerde eşleşip eşleşmediğini görmek için SequenceEquals kullanır

                var wordsA = new string[] { "cherry", "apple", "blueberry" };
                var wordsB = new string[] { "apple", "blueberry", "cherry" };

                bool match = wordsA.SequenceEqual(wordsB);

                listView1.Items.Add(match.ToString());
                MessageBox.Show("İki dizinin tüm öğelerde eşleşip eşleşmediğini boole onaylamak...");
            }
            if (radioButton88.Checked == true)
            {
                var customerNames = from cust in _context.Customers
                                    select cust.CompanyName;
                var supplierNames = from sup in _context.Suppliers
                                   select sup.CompanyName;

                var allNames = customerNames.Concat(supplierNames);

                foreach (var n in allNames)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("İki tablodaki CompanyNames içern bir dizi oluştur...");
            }
        }
    }
}
