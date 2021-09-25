using Linq_Samples.Linq_Samples_Codes.AggregateOperators;
using Linq_Samples.Linq_Samples_Codes.ConversionOperators;
using Linq_Samples.Linq_Samples_Codes.ElementOperators;
using Linq_Samples.Linq_Samples_Codes.GenerationOperators;
using Linq_Samples.Linq_Samples_Codes.GroupingOperators;
using Linq_Samples.Linq_Samples_Codes.JoinOperators;
using Linq_Samples.Linq_Samples_Codes.MiscellaneousOperators;
using Linq_Samples.Linq_Samples_Codes.OrderingOperators;
using Linq_Samples.Linq_Samples_Codes.PartitioningOperators;
using Linq_Samples.Linq_Samples_Codes.ProjectionOperators;
using Linq_Samples.Linq_Samples_Codes.Quantifiers;
using Linq_Samples.Linq_Samples_Codes.QueryExecution;
using Linq_Samples.Linq_Samples_Codes.RestrictionOperators;
using Linq_Samples.Linq_Samples_Codes.SetOperators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Samples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestrictionOperators fro = new RestrictionOperators();
            fro.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProjectionOperators fpo = new ProjectionOperators();
            fpo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PartitioningOperators fp = new PartitioningOperators();
            fp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderingOperators foo = new OrderingOperators();
            foo.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GroupingOperators fgo = new GroupingOperators();
            fgo.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetOperators fso = new SetOperators();
            fso.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ConversionOperators fco = new ConversionOperators();
            fco.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ElementOperators feo = new ElementOperators();
            feo.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GenerationOperators fgo = new GenerationOperators();
            fgo.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Quantifiers fq = new Quantifiers();
            fq.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AggregateOperators fao = new AggregateOperators();
            fao.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MiscellaneousOperators fmo = new MiscellaneousOperators();
            fmo.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            JoinOperators fjo = new JoinOperators();
            fjo.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            QueryExecution fqo = new QueryExecution();
            fqo.Show();
        }
    }
}

