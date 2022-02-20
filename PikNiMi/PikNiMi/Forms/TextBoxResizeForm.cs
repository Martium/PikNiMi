using System.Windows.Forms;
using PikNiMi.Forms.Constants;

namespace PikNiMi.Forms
{
    public partial class TextBoxResizeForm : Form
    {
        public TextBoxResizeForm()
        {
            InitializeComponent();
        }

        private void TextBoxResizeForm_Load(object sender, System.EventArgs e)
        {
            
        }

        private void TextBoxResizeForm_Resize(object sender, System.EventArgs e)
        {
            TableLayoutPanel.Font = WindowState == FormWindowState.Maximized ? FormFontConstants.MaximizedFontSize : FormFontConstants.DefaultFontSize;
        }

        #region Helpers

        private void SetFormTextHeader()
        {
           
        }

        #endregion
       
    }
}
