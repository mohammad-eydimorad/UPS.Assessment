using System.Windows;
using System.Windows.Controls;

namespace UPS.Assessment.App
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : UserControl
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmpoloyeeForm_Loaded(object sender, RoutedEventArgs e)
        {
            NameInput.Focus();
        }

    }
}
