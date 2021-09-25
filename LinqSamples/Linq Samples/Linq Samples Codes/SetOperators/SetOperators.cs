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

namespace Linq_Samples.Linq_Samples_Codes.SetOperators
{
    public partial class SetOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public SetOperators()
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
            if (radioButton44.Checked == true)
            {
                // Bir dizideki yinelenen öğeleri kaldırmak için Distinct'i kullanır.
                // 300'ün çarpanları.
                int[] factorsOf300 = { 2, 2, 3, 5, 5 };

                var uniqueFactors = factorsOf300.Distinct();
                foreach(var f in uniqueFactors)
                {
                    listView1.Items.Add(f.ToString());
                }
                MessageBox.Show("Tekrarlanan sayıları bir kere yazdır...");
            }
            if (radioButton45.Checked == true)
            {
                 // Benzersiz Kategori adlarını bulmak için Distinct kullanır.
                 var categoryNames = (from pro in _context.Products
                                     join cat in _context.Categories on pro.CategoryID equals cat.CategoryID
                                     select new {
                                         cat.CategoryID,
                                         cat.CategoryName
                                     }).Distinct();
                
                    dataGridView1.DataSource = categoryNames.ToList();
                MessageBox.Show("Benzersiz Kategori adlarını getir...");
            }
            if (radioButton46.Checked == true)
            {
                // Benzersiz değerleri içeren bir dizi oluşturmak için Union kullanır.
                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
                int[] numbersB = { 1, 3, 5, 7, 8 };
                var uniqueNumbers = numbersA.Union(numbersB);
                foreach(var n in uniqueNumbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("Benzersiz değerleri içeren bir dizi oluştur...");
            }
            if (radioButton47.Checked == true)
            {
                //Ortak değerleri içeren bir dizi oluşturmak için Intersect'i kullanır
                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
                int[] numbersB = { 1, 3, 5, 7, 8 };

                var commonNumbers = numbersA.Intersect(numbersB);
                foreach(var n in commonNumbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("Ortak değerleri içeren bir dizi oluştur...");
            }
            if (radioButton48.Checked == true)
            {

                //A sayılarından gelen değerleri içeren bir dizi oluşturmak için Except kullanır.
                // sayılarda da olmayanlarB.
                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
                int[] numbersB = { 1, 3, 5, 7, 8 };

                IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB);
                foreach (var n in aOnlyNumbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("A sayılarından gelen değerleri içeren bir dizi oluşturmak...");
            } 
        }
    }
}
