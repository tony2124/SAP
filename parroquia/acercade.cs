using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parroquia
{
    public partial class acercade : Form
    {
        public acercade()
        {
            InitializeComponent();
            linkLabel1.Links.Add(0,17, "www.simpus.com.mx");
            linkLabel2.Links.Add(0, 19, "www.simpus.com.mx/es/software/parroquia/terminos");

            // Get the version of the executing assembly (that is, this assembly).
           /* Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version;*/
            try
            {
                version_label.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (Exception e)
            { MessageBox.Show(""+e); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
