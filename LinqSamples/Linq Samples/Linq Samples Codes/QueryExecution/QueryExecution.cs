using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Samples.Linq_Samples_Codes.QueryExecution
{
    public partial class QueryExecution : Form
    {
        public QueryExecution()
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
            if (radioButton97.Checked == true)
            {
                //Sorgu yürütmenin sorgu tamamlanana kadar nasıl ertelendiğini gösterir.
                // bir foreach ifadesinde numaralandırılmıştır.

                int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                int i = 0;

                var simpleQuery = from num in numbers
                                  select ++i;

                // i değişkeninin değeri de her bir eleman foreach içinde
                // kullanıldığında (döngü içinde) arttırılacaktır.
                foreach (var item in simpleQuery)
                {
                    listView1.Items.Add(item.ToString()); // şimdi i artırıldı        
                }
                MessageBox.Show("Dizideki karışık sayıları sıralama...");

            }
            if (radioButton98.Checked == true)
            {
                //Aşağıdaki örnek, sorguların nasıl anında yürütülebileceğini ve sonuçlarını gösterir.
                // ToList gibi yöntemlerle bellekte saklanır.

                // ToList(), Max() ve Count() gibi yöntemler sorgunun
                // hemen yürütülür.
                int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                int i = 0;
             
                var immediateQuery = (
                    from num in numbers
                    select ++i)
                    .ToList();
                foreach (var item in immediateQuery)
                {
                    listView1.Items.Add(item.ToString(), i.ToString());       
                }
                MessageBox.Show("Dizideki karışık sayıları sıralama...");
            }
            if (radioButton99.Checked == true)
            {
                //Aşağıdaki örnek, ertelenmiş yürütme nedeniyle sorguların nasıl kullanılabileceğini gösterir.
                // veri değiştikten sonra tekrar yeni veriler üzerinde çalışacaktır.

                // Ertelenmiş yürütme, bir sorguyu bir kez tanımlamamıza izin verir
                // ve daha sonra çeşitli şekillerde yeniden kullanın.
                int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var lowNumbers =
                    from num in numbers
                    where num <= 3
                    select num;
                foreach (var n in lowNumbers)
                {
                    listView1.Items.Add(n.ToString());
                }

                // Orijinal sorguyu sorgula.
                var lowEvenNumbers =
                    from num in lowNumbers
                    where num % 2 == 0
                    select num;

                foreach (int n in lowEvenNumbers)
                {
                    listView1.Items.Add(n.ToString());
                }

                // Kaynak verileri değiştirin.
                for (int i = 0; i < 10; i++)
                {
                    numbers[i] = -numbers[i];
                }

                // lowNumbers, yeni durum üzerinde yinelenecek
                // sayıların[], farklı sonuçlar üretiyor:
              
                foreach (int n in lowNumbers)
                {
                    listView1.Items.Add("İkinci çalıştırma numaraları <= 3:"+ n.ToString());
                }
                MessageBox.Show("Art arta örnek");
            }
            if (radioButton100.Checked == true)
            {

                int[] sayilar = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var kucukSayilar =
                                   from sayi in sayilar
                                   where sayi < 5
                                   select sayi;
                listView1.Items.Add("İlk çalıştırma sonucunda 5'den küçük sayılar :");
                foreach (int sayi in kucukSayilar)
                {
                    listView1.Items.Add(sayi.ToString());
                }
                // Dizideki sayıları değiştir (negatife çevir)
                for (int i = 0; i < 10; i++)
                {
                    sayilar[i] = sayilar[i] * -1;
                }
                // Sayılar değiştiği için alttaki foreach döngüsünde sorgu tekrar
                // çalıştırılacak ve dolayısıyla farklı sonuçlar görüntülenecektir.
                listView1.Items.Add("İkinci çalıştırma sonucunda 5'den küçük sayılar:");
                foreach (int sayi in kucukSayilar)
                {
                    listView1.Items.Add(sayi.ToString());
                }
                MessageBox.Show("Ertelenmiş çalıştırma bize sorguyu bir kez tanımladıktan sonra veriler değiştikçe tekrar tekrar çalıştırma imkanı verir....");
            }
           
        }
    }
}
