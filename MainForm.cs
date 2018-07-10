using System;
using System.Windows.Forms;

namespace KeyboardLock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var handler = new EventHandler(OnClick);
            this.Click += handler;
            label1.Click += handler;
            label2.Click += handler;
        }

        void OnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
