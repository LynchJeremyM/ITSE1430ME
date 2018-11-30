/* Jeremy Lynch
 * 11/27/2018
 * ITSE 1430
 */

using System;
using System.Reflection;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class AboutForm : Form
    {
        #region Construction

        public AboutForm()
        {
            InitializeComponent();
            this.textBoxProduct.Text = AssemblyProduct;
            this.textBoxVersion.Text = AssemblyVersion;
            this.textBoxTrademark.Text = AssemblyTrademark;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #endregion

        #region Event Handlers

        private void OnOK( object sender, EventArgs e )
        {
            Close();
        }

        #endregion

        #region Assembly Attribute Accessors

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyTrademark
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyTrademarkAttribute)attributes[0]).Trademark;
            }
        }
        #endregion

    }
}
