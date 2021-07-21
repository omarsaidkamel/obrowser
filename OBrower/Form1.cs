using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OBrower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
            }
        }
        private void webTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            comboBox1.Items.Add("http://"+"www." + webTab.DocumentTitle + ".com");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            webTab.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webTab.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webTab.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webTab.Stop();
        }
        WebBrowser webTab ;
        private void button6_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "New Tab";
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount-1);
            webTab = new WebBrowser() {ScriptErrorsSuppressed=true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;   
            webTab.DocumentCompleted += WebTab_DocumentCompleted;
            webTab.Navigate("http://www.google.com");
        }
        private void WebTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
               tabControl1.SelectedTab.Text = webTab.DocumentTitle;          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabCount== 0)
            {
                MessageBox.Show("You Must Add New Tab","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else { webTab.Navigate(comboBox1.Text); }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
            }
        }
    }
}
