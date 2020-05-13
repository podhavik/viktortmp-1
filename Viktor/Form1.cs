using Firefly.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viktor.Providers;
using ViktorDataModel;

namespace Viktor
{
    [RegisterSingleton]
    public partial class Form1 : Form
    {
        private readonly SranecProvider _sranecProvider;

        public Form1(SranecProvider sranecProvider)
        {
            InitializeComponent();
            
            this._sranecProvider = sranecProvider;
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            var newSranec = await _sranecProvider.AddSranec(sranecName.Text);
            listBox1.Items.Add($"{newSranec.Id}: {newSranec.Name}");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var items = await _sranecProvider.LoadAllAsync();

            Console.Out.WriteLine($"Nalezeno {items.Count()} sranců v db.");

            listBox1.Items.AddRange(items
                .Select(x => $"{x.Id}: {x.Name}, Measure: {x.Measure?.Value}")
                .ToArray()
                );
        }
    }
}
