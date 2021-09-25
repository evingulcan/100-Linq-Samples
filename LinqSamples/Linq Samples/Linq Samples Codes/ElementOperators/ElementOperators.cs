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

namespace Linq_Samples.Linq_Samples_Codes.ElementOperators
{
    public partial class ElementOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public ElementOperators()
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
            if (radioButton53.Checked == true)
            {
                //Dizideki 'o' ile başlayan ilk öğeyi bulmak için First'ü kullanır.
                string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

                string startsWithO = strings.First(s => s[0] == 'o');

                listView1.Items.Add(startsWithO);
                MessageBox.Show("Dizideki 'o' ile başlayan ilk öğeyi bulmak...");
            }
            if (radioButton54.Checked == true)
            {
                // Dizinin ilk öğesini döndürmeyi denemek için FirstOrDefault'u kullanır,
                // hiçbir öğe yoksa, bu durumda o tür için varsayılan değer
                // Geri döndü. FirstOrDefault, dış birleşimler oluşturmak için kullanışlıdır.
                int[] numbers = { };

                int firstNumOrDefault = numbers.FirstOrDefault();

                listView1.Items.Add(firstNumOrDefault.ToString());
                MessageBox.Show("Dizide eleman yoksa 0 atanır yazdırır...");
            }
            if (radioButton55.Checked == true)
            {
                //Linq ile Lambda kullanımı
               // int fourthLowNum = numbers.Where(num => num > 5).ElementAt(1);

                //5'ten büyük ikinci sayıyı almak için ElementA'yı kullanır
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                int fourthLowNum = (
                   from num in numbers
                   where num > 5
                   select num)
                   .ElementAt(1); // ikinci sayı dizin 1'dir çünkü diziler 0 tabanlı dizinleme kullanır

                listView1.Items.Add(fourthLowNum.ToString());
                MessageBox.Show("5'ten büyük ikinci sayıyı almak...");

            }
            if (radioButton56.Checked == true)
            {
                using(NorthwindContext db=new NorthwindContext())
                {
                    var product =
                  (from prod in db.Products

                   select new
                   {
                       prod.ProductName
                   }).First();
                    listView1.Items.Add(product.ToString());
                    MessageBox.Show("Ürün Adı İlk sıradakini getirir...");
                }
               
            }
            if (radioButton57.Checked == true)
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    var orderDate = db.Orders.FirstOrDefault(
                        or => or.OrderDate.Year == 1995);
                  
                    listView1.Items.Add(orderDate == null ? "yok" : "var");
                    MessageBox.Show("1995 yılında şipariş var mı yok mu...");
                }

            }
        }
    }
}
