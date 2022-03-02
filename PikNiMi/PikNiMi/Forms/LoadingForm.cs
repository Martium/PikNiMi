using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikNiMi.Forms
{
    public partial class LoadingForm : Form
    {
        public readonly Action Worker;

        public LoadingForm(Action worker)
        {
            InitializeComponent();

            if (worker == null)
                throw new ArgumentNullException();

            Worker = worker;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker)
                .ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
