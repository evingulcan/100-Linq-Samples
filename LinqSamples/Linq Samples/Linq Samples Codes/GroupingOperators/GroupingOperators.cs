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

namespace Linq_Samples.Linq_Samples_Codes.GroupingOperators
{
    public partial class GroupingOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public GroupingOperators()
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
            if (radioButton39.Checked == true)
            {
                // Bir sayı listesini şuna göre bölmek için grubu kullanır:
                // 5'e bölündüğünde kalanlar.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var numberGroups =
                  from num in numbers
                  group num by num % 5 into numGroup
                  select new { Remainder = numGroup.Key,  };
                foreach (var grp in numberGroups)
                {
                    listView1.Items.Add(grp.ToString());
                }
                MessageBox.Show("5'e bölündüğünde kalanlar...");
            }
            if (radioButton40.Checked == true)
            {
                // Bir kelime listesini şuna göre bölmek için grubu kullanır:
                // onların ilk harfi.
                string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

                var wordGroups =
                    from num in words
                    group num by num[0] into grp
                    select new { FirstLetter = grp.Key, Words = grp };

                foreach (var wordgrp in wordGroups)
                {
                  
                    foreach (var word in wordgrp.Words)
                    {
                        listView1.Items.Add(word);
                    }
                }
                MessageBox.Show("Bir kelime listesini  ilk harfine göre gruplandır...");
            }
            if (radioButton41.Checked == true)
            {
                // Bir ürün listesini ContactName göre bölmek için gruplandırma yöntemini kullanır.
                var orderGroups =
               from sup in _context.Suppliers
               group sup by sup.ContactName into supGroup
               select new {
                   ContactName = supGroup.Key, 
                   Suppliers = supGroup
               };
                dataGridView1.DataSource = orderGroups.ToList();
                MessageBox.Show("Bir ürün listesini ContactName göre gruplandırma...");
            }
            if (radioButton42.Checked == true)
            {
                // Bu örnek, kullanarak bir dizinin kırpılmış öğelerini bölmek için GroupBy'yi kullanır.
                // birbirinin anagramı olan sözcüklerle eşleşen özel bir karşılaştırıcı.

                string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

                var orderGroups = anagrams.GroupBy(w =>w.Trim(),
                 new AnagramEqualityComparer());

                foreach (var g in orderGroups)
                {
                    
                    foreach (var w in g)
                    {
                        listView1.Items.Add("\t" + w);
                    }
                }
                MessageBox.Show("Birbirinin anagramı olan sözcüklerle eşleşen özel bir karşılaştırıcı...");
            }
            if (radioButton43.Checked == true)
            {
                // Bu örnek, kullanarak bir dizinin kırpılmış öğelerini bölmek için GroupBy'yi kullanır.
                // birbirinin anagramı olan kelimelerle eşleşen özel bir karşılaştırıcı,
                // ve ardından sonuçları büyük harfe dönüştürür.

                string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

                var orderGroups = anagrams.GroupBy(
                            w => w.Trim(),
                            a => a.ToUpper(),
                            new AnagramEqualityComparer()
                            );


                foreach (var g in orderGroups)
                {

                    foreach (var w in g)
                    {
                        listView1.Items.Add("\t" + w);
                    }
                }
                MessageBox.Show("Birbirinin anagramı olan kelimelerle eşleşen özel bir karşılaştırıcı, ve ardından sonuçları büyük harfe dönüştürür...");

            }

        }
    }
}
