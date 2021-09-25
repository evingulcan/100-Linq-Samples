using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Samples.Linq_Samples_Codes.GenerationOperators
{
    public partial class GenerationOperators : Form
    {
        public GenerationOperators()
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
            if (radioButton58.Checked == true)
            {
                //Linq il lambda kullanımı
                //var numbers = Enumerable.Range(100, 50)
                //         .Select(n => new { Number = n, OddEven = n % 2 == 1 ? "odd" : "even" });

                // Bu örnek, 100 ile 149 arasında bir sayı dizisi oluşturmak için Aralık kullanır
                // bu aralıktaki hangi sayıların tek ve çift olduğunu bulmak için kullanılır.
               
                var numbers =
               from n in Enumerable.Range(100, 50)
               select new { Sayi = n, TekMi = n % 2 == 0  };
                foreach (var n in numbers.Take(10))
                {
                    listView1.Items.Add(n.Sayi.ToString(), n.TekMi ? "tek" : "çift");
                }
                MessageBox.Show("100 ile 149 arasında bir sayı dizisi oluşturmak bu aralıktaki hangi sayıların tek ve çift olduğunu bulmak...");
            }

            if (radioButton59.Checked == true)
            {
                //7 sayısını on kez içeren bir dizi oluşturmak için Repeat kullanır.
                var numbers = Enumerable.Repeat(7, 10);
              
                foreach (var n in numbers)
                {
                    listView1.Items.Add(n.ToString());
                }
                MessageBox.Show("7 sayısını on kez içeren bir dizi oluşturmak...");
            }
        }
    }
}
