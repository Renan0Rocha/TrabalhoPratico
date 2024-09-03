using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrabalhoPratico.Views;

namespace TrabalhoPratico
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCadastrarCli_Click(object sender, RoutedEventArgs e)
        {
            CadClienteFormWindow view = new CadClienteFormWindow();
            view.ShowDialog();
        }

        private void btnListarCliente_Click(object sender, RoutedEventArgs e)
        {
            ListClienteFormWindow view = new ListClienteFormWindow();
            view.ShowDialog();
        }
    }
}
