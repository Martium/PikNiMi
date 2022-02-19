using System;
using System.Windows.Forms;
using PikNiMi.Enums;
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

        private void ProductDescriptionTextBoxResizeButton_Click(object sender, System.EventArgs e)
        {
            OpenNewForm(new TextBoxResizeForm());
        }

        private void AnotherForm_Closed(object sender, EventArgs e)
        {
            this.Show();

            //load last data update new data
        }

        #region Heplers

        private void OpenNewForm(Form form)
        {
            form.Closed += AnotherForm_Closed;
            HideProductForm(form);
        }

        private void HideProductForm(Form form)
        {
            this.Hide();
            form.Show();

            if (this.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        #endregion
    }
}
