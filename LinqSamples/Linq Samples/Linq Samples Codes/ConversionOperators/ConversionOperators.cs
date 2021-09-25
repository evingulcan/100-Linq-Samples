using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Samples.Linq_Samples_Codes.ConversionOperators
{
    public partial class ConversionOperators : Form
    {
        public ConversionOperators()
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
            if (radioButton49.Checked == true)
            {
                //Linq ile Lambda kullanımı
               // var doublesArray = doubles.OrderByDescending(d => d).ToArray();

                // Bir diziyi hemen bir dizide değerlendirmek için ToArray'i kullanır.
                double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };
                var sortedDoubles = from d in doubles
                                    orderby d descending
                                    select d;
                var doublesArray = sortedDoubles.ToArray();
                for(int d=0; d< doublesArray.Length; d += 2)
                {
                    listView1.Items.Add(doublesArray[d].ToString());
                }
                MessageBox.Show("Bir diziyi hemen bir dizide değerlendirmek...");
            }
            if (radioButton50.Checked == true)
            {
                //Dizinin yalnızca double türündeki öğelerini döndürmek için OfType'ı kullanır.
                object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

                var doubles = numbers.OfType<double>();
                foreach (var d in doubles)
                {
                    listView1.Items.Add(d.ToString());
                }
                MessageBox.Show("Dizide yalnızca double türündeki öğelerini döndürmek...");
            }
            if (radioButton51.Checked == true)
            {
                //Linq ile Lambda kullanımı
               // var sortedWords = sortedWords.OrderBy(w => w).ToList();


                // Bir diziyi hemen bir List<T> olarak değerlendirmek için ToList'i kullanır.
                string[] words = { "cherry", "apple", "blueberry" };

                var sortedWords =
                         from w in words
                         orderby w
                         select w;
                var wordList = sortedWords.ToList();
                foreach (var w in wordList)
                {
                    listView1.Items.Add(w);
                }
                MessageBox.Show("Bir diziyi hemen bir List<T> olarak değerlendirmek...");
            }
            if (radioButton52.Checked == true)
            {
                //Bir diziyi hemen değerlendirmek için ToDictionary'yi kullanır ve
                //Dizideki istenen anahtar ifadeyi getir
                var scoreRecords = new[] { new {Name = "Alice", Score = 50},
                                        new {Name = "Bob"  , Score = 40},
                                        new {Name = "Cathy", Score = 45}
                                    };
                var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);
                listView1.Items.Add(scoreRecordsDict["Bob"].ToString());

                MessageBox.Show("Dizideki istenen anahtar ifadeyi getir...");
            }
        }
    }
}
