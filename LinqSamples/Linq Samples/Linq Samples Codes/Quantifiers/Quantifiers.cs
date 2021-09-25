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

namespace Linq_Samples.Linq_Samples_Codes.Quantifiers
{
    public partial class Quantifiers : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public Quantifiers()
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
            if (radioButton60.Checked == true)
            {
                // Dizideki kelimelerden herhangi birinin olup olmadığını belirlemek için Any kullanır.
                // 'ei' alt dizesini içerir.
                string[] words = { "believe", "relief", "receipt", "field" };

                bool iAfterE = words.Any(w => w.Contains("ei"));

                listView1.Items.Add(iAfterE.ToString());
                MessageBox.Show("Dizideki kelimelerden (ei) sinin  olup olmadığını bulmak...");
            }

            if (radioButton61.Checked == true)
            {
                var productGroups = _context.Products
                    .GroupBy(pro => pro.CategoryID)
                    .Where(proGroup => proGroup.Any(p => p.UnitsInStock == 0))
                    .Select(proGroup => new
                    {
                        Category = proGroup.Key,
                        Products = proGroup
                    }).Take(2);
                dataGridView1.DataSource = productGroups.ToList();
                MessageBox.Show("Dizideki kelimelerden (ei) sinin  olup olmadığını bulmak...");
            }
            if (radioButton62.Checked == true)
            {
                // Bu örnek, bir dizinin yalnızca tek sayılar içerip içermediğini belirlemek için Tümünü kullanır.
                int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };

                bool onlyOdd = numbers.All(n => n % 2 == 1);

                listView1.Items.Add(numbers.ToString());
                MessageBox.Show("Dizideki kelimelerden (ei) sinin  olup olmadığını bulmak...");
            }
            if (radioButton63.Checked == true)
            {
                //Linq ile Lambda kullanımı
                //var productGroups = _context.Products
                //    .GroupBy(prod => prod.ProductName)
                //    .Where(prodGroup => prodGroup.All(p => p.UnitsInStock > 0))
                //    .Select(prodGroup => new { Category = prodGroup.Key, Products = prodGroup });

                // yalnızca kategoriler için gruplandırılmış bir ürün listesi döndürmek için Tümünü kullanır
                // tüm ürünlerini stokta bulundurur.

                var productGroups =
                 from prod in _context.Products
                 group prod by prod.ProductName into prodGroup
                 where prodGroup.All(p => p.UnitsInStock > 0)
                 select new { 
                     Category = prodGroup.Key, 
                     Products = prodGroup 
                 };
                dataGridView1.DataSource = productGroups.ToList();
                MessageBox.Show("Yalnızca kategoriler için gruplandırılmış bir ürün listesi döndürmek için Tümünü kullanır tüm ürünlerini stokta bulundurur....");
            }
          
        }
    }
}
