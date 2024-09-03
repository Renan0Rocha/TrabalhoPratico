using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;
using TrabalhoPratico.Dao;
using TrabalhoPratico.Models;

namespace TrabalhoPratico.Views
{
    /// <summary>
    /// Lógica interna para ListClienteFormWindow.xaml
    /// </summary>
    public partial class ListClienteFormWindow : Window
    {
        public ListClienteFormWindow()
        {
            InitializeComponent();
            Loaded += ListClienteFormWindow_Loaded;
            CarregarListagem();
        }

        private void ListClienteFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ClienteDAO();
                List<Cliente> listaClientes = dao.List();

                dataGridCliente.ItemsSource = listaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluirCliente_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = dataGridCliente.SelectedItem as Cliente;

            var result = MessageBox.Show($"Deseja realmente excluir o Cliente '{clienteSelected.Nome}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delete(clienteSelected);
                    CarregarListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAtualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = dataGridCliente.SelectedItem as Cliente;

            if (clienteSelected != null)
            {
                CadClienteFormWindow view = new CadClienteFormWindow(clienteSelected);
                view.Closed += (s, args) => CarregarListagem(); 
                view.ShowDialog();
            }
        }
    }
}
