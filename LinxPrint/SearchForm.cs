/*
    See LICENSE in the project root for license information.
*/
namespace LinxPrint
{
    using System.Windows.Forms;

    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        public string Result
        {
            get { return textCode.Text; }
        }
    }
}
