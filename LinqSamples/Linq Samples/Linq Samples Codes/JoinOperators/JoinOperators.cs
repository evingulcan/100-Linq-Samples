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

namespace Linq_Samples.Linq_Samples_Codes.JoinOperators
{
    public partial class JoinOperators : Form
    {
        NorthwindContext _context = new NorthwindContext();
        public JoinOperators()
        {
            InitializeComponent();
        }

        public IEnumerable<object> CategoryAndProduct { get; private set; }

        public void Temizle()
        {
            listView1.Items.Clear();

        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
                Temizle();
                if (radioButton89.Checked == true)
                {
                    //Linq ile Lambda kullanımı
                    //var custSupJoin = _context.Suppliers
                    //   .Join(_context.Customers, sup => sup.Country, cust => cust.Country,
                    //   (sup, cust) => new { sup.Country, sup.ContactName, CustomerName = cust.CompanyName });

                    //iki dizinin basit bir iç birleştirmesinin nasıl gerçekleştirileceğini gösterir.
                    //bir eşleşen öğeye sahip tedarikçilerdeki her öğeden oluşan düz bir sonuç kümesi üret
                    var custSupJoin = from sup in _context.Suppliers
                                      join cust in _context.Customers on sup.Country equals cust.Country
                                      select new
                                      {
                                          Country = sup.Country,
                                          SupplierName = sup.ContactName,
                                          CustomerName = cust.CompanyName
                                      };

                    dataGridView1.DataSource = custSupJoin.ToList();
                    MessageBox.Show("İki dizinin basit bir iç birleştirmesinin nasıl gerçekleştirileceğini gösterir.Bir eşleşen öğeye sahip tedarikçilerdeki her öğeden oluşan düz bir sonuç kümesi üret...");
                }
                if (radioButton90.Checked == true)
                {
                    //Linq ile Lambda kullanımı
                    //var supplierCusts = _context.Suppliers
                    //    .GroupJoin(_context.Customers, sup => sup.Country, cust => cust.Country,
                    //    (sup, c) => new
                    //    {
                    //        sup.Country,
                    //        sup.ContactName,
                    //        c
                    //    })
                    //    .SelectMany(x => x.c, (sup, c) => new
                    //    {
                    //        sup.Country,
                    //        sup.ContactName,
                    //        CompanyName = c == null ? "(No customers)" : c.CompanyName

                    //    })
                    //    .OrderBy(sup => sup.ContactName);


                    //Sol dış birleşim, sol taraftaki tüm öğeleri içeren bir sonuç kümesi üretir.
                    // en az bir kez, sağ taraftaki öğelerle eşleşmeseler bile.
                    var supplierCusts =
                         from sup in _context.Suppliers
                         join cust in _context.Customers on sup.Country equals cust.Country into cs
                         from c in cs.DefaultIfEmpty()  // DefaultIfEmpty, sağ tarafta eşleşmesi olmayan sol taraftaki öğeleri korur
                     orderby sup.ContactName
                         select new
                         {
                             sup.Country,
                             CompanyName = c == null ? "(No customers)" : c.CompanyName,
                             sup.Address
                         };
                    dataGridView1.DataSource = supplierCusts.ToList();
                    MessageBox.Show("Sol dış birleşim, sol taraftaki tüm öğeleri içeren bir sonuç kümesi üretir.En az bir kez, sağ taraftaki öğelerle eşleşmeseler bile...");
                }
                if (radioButton91.Checked == true)
                {
                    //Linq ile Lambda kullanımı
                    //var supplierCusts = _context.Suppliers
                    //   .GroupJoin(_context.Customers, sup => new { sup.City, sup.Country }, cust => new { cust.City, cust.Country }
                    //                           , (sup, cs) => new
                    //                           {
                    //                               sup.Country,
                    //                               sup.City,
                    //                               sup.ContactName,
                    //                               cs
                    //                           })
                    //   .SelectMany(x => x.cs.DefaultIfEmpty(), (sub, cs) => new
                    //   {
                    //       sub.Country,
                    //       sub.City,
                    //       sub.ContactName,
                    //       CompanyName = cs == null ? "(No customers)" : cs.CompanyName
                    //   })
                    //   .OrderBy(sup => sup.ContactName);


                    //Tedarikçiler tablosundaki her tedarikçi için bu sorgu tüm müşterileri döndürür
                    //aynı şehir ve ülkeden veya o şehirden/ülkeden müşteri bulunamadığını gösteren bir dize.
                    //Birden çok anahtar değerini kapsüllemek için anonim türlerin kullanımına dikkat edin.

                    var supplierCusts = from sup in _context.Suppliers
                                        join cust in _context.Customers on new
                                        {
                                            sup.City,
                                            sup.Country
                                        }
                                        equals
                                        new
                                        {
                                            cust.City,
                                            cust.Country
                                        }
                                        into cs
                                        from c in cs.DefaultIfEmpty()// Bunu bir iç birleştirme yapmak için DefaultIfEmpty yöntem çağrısını kaldırın
                                        orderby sup.ContactName
                                        select new
                                        {
                                            sup.Country,
                                            sup.City,
                                            sup.ContactName,
                                            CompanyName = c == null ? "(No customers)" : c.CompanyName
                                        };
                    dataGridView1.DataSource = supplierCusts.ToList();
                    MessageBox.Show("Tedarikçiler tablosundaki her tedarikçi için bu sorgu tüm müşterileri döndürür aynı şehir ve ülkeden veya o şehirden/ülkeden müşteri bulunamadığını gösteren bir dize...");
                }
            if (radioButton92.Checked == true)
            {
                using(NorthwindContext db= new NorthwindContext())
                {
                    var sorgu = (from o in db.Orders
                                 join em in db.Employees
                                 on o.EmployeeID equals em.EmployeeID
                                 join c in db.Customers
                                 on o.CustomerID equals c.CustomerID
                                 where c.Region == "CA"
                                 select new
                                 {
                                     //EmployeeID=em.EmployeeID,
                                     FirstName = em.FirstName,
                                     LastName=em.LastName,
                                     //OrderID=o.OrderID,
                                  //  CustomerID=c.CustomerID,
                                     Region=c.Region,
                                 }).ToList();
                    dataGridView1.DataSource = sorgu;
                    MessageBox.Show("CA Bölgesindeki Personelerin Adlarını getir ...");
                }
            }
            if (radioButton93.Checked == true)
            {
                using(NorthwindContext db=new NorthwindContext())
                {
                    var sorgu = (from o in db.Orders
                                 join em in db.Employees
                                 on o.EmployeeID equals em.EmployeeID
                                 into j1
                                 from r in j1.DefaultIfEmpty()//Sol birleştirmeye dönüştürmek için, sonucu tutacak değişken oluşturmak
                                 select new
                                 {
                                     FirstName = r.FirstName,
                                     LastName = r.LastName,
                                     ShipName =o.ShipName,
                                     ShipCity = o.ShipCity,
                                   
                                     
                                 }).Take(5).ToList();
                    dataGridView1.DataSource = sorgu;
                    MessageBox.Show("Sol birleştirmeye dönüştürmek için, sonucu tutacak değişken oluşturmak örneği ...");
                }
            }
            if (radioButton94.Checked == true)
            {
                using(NorthwindContext db=new NorthwindContext())
                {
                    var sorgu = from pro in db.Products
                                join cat in db.Categories
                                on pro.CategoryID equals cat.CategoryID
                                into prodGroup
                                select new
                                {
                                    ProductName=pro.ProductName,
                                    CategoryName=prodGroup,
                                };
                    dataGridView1.DataSource = sorgu.ToList();
                    MessageBox.Show("Category adlarını gruplandırma ...");
                }

            }
            if (radioButton95.Checked == true)
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    var sorgu = (from pro in db.Products
                                 join cat in db.Categories
                                 on pro.CategoryID equals cat.CategoryID
                                into CategoryAndProduct
                                from g in CategoryAndProduct.DefaultIfEmpty()//Boş olanlar için varsayılan değeri kullan

                                 select new
                                 {
                                     ProductName = pro.ProductName,
                                     CategoryName = g == null ? "(No CategoryName)" : g.CategoryName,
                                     

                                 }).ToList();

                    dataGridView1.DataSource = sorgu.ToList();
                    MessageBox.Show("Ürün adının hangi Kategoriden olduğunu bul ve kategorisi olmayan ürüne No CategoryName yaz...");
                }
            }
            if (radioButton96.Checked == true)
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    var sorgu = from emp in db.Employees
                                where emp.ReportsTo < 5 && emp.Country == "USA"
                                select new
                                {
                                 emp.FirstName,
                                 emp.LastName,
                                 emp.ReportsTo,
                                 emp.Country
                                };
                    dataGridView1.DataSource = sorgu.ToList();

                    MessageBox.Show("Personellerden Raporları 5 ten küçük ve USA ülkesinde kalan Personelleri getir....");
                
            }

            }
        }
       
    }
       
   
}
 



