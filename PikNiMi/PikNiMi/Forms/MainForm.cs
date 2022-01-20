using System.Windows.Forms;
using PikNiMi.Forms.Constants;

namespace PikNiMi.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            SetTextBoxLength();
        }

        #region CustomPrivateMethods

        private void SetTextBoxLength()
        {
            searchTextBox.MaxLength = TextBoxLength.ProductSearchText;
            dateTextBox.MaxLength = TextBoxLength.ProductDate;
            tripExpensesTextBox.MaxLength = TextBoxLength.NumberLength;
        }

        #endregion

        
    }
}
