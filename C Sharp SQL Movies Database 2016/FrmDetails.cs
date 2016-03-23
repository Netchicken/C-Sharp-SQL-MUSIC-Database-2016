using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_SQL_Movies_Database_2016 {
    public partial class FrmDetails : Form
    {
        //http://stackoverflow.com/questions/7886544/passing-a-value-from-one-form-to-another-form
        private Form1 frm1 = null;
        public string CDName;
        private string address; 
        public FrmDetails(Form1 frm1) {
            InitializeComponent();
            CDName = frm1.txtCDName.Text;
           
                address = "https://www.google.com/#q=" + CDName + "&tbm=vid";
                webBrowser1.Navigate(new Uri(address));
            
        }
        private void Navigate(String address) {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://")) {
                address = "http://" + address;
                }
            try {
                webBrowser1.Navigate(new Uri(address));
                this.Text = webBrowser1.Url.ToString();  //show url
                } catch (System.UriFormatException) {
                return;
                }
            }

        private void webBrowser1_Navigated(object sender,
    WebBrowserNavigatedEventArgs e) {
           this.Text = webBrowser1.Url.ToString();
            }

        }
    }
