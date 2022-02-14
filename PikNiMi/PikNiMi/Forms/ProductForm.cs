using System.Drawing;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;

namespace PikNiMi.Forms
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, System.EventArgs e)
        {
            TableLayoutPanel.Font = FormFontConstants.DefaultFontSize;
        }

        private void ProductForm_Resize(object sender, System.EventArgs e)
        {
            TableLayoutPanel.Font = WindowState == FormWindowState.Maximized ? FormFontConstants.MaximizedFontSize : FormFontConstants.DefaultFontSize;
        }

        
    }
}
