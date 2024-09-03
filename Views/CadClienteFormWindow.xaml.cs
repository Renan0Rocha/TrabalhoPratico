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
using System.Windows.Shapes;
using TrabalhoPratico.Dao;
using TrabalhoPratico.Models;

namespace TrabalhoPratico.Views
{
    /// <summary>
    /// Lógica interna para CadClienteFormWindow.xaml
    /// </summary>
    public partial class CadClienteFormWindow : Window
    {
        private Cliente _cliente = new Cliente();

        public CadClienteFormWindow()
        {
            InitializeComponent();
            Loaded += CadClienteFormWindow_Loaded;
        }

        public CadClienteFormWindow(Cliente cliente)
        {
            InitializeComponent();
            Loaded += CadClienteFormWindow_Loaded;
            CarregarListagem();
            _cliente = cliente;
        }

        private void CadClienteFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _cliente.Nome;
            txtCpf.Text = _cliente.Cpf;
            txtEmail.Text = _cliente.Email;
            txtTelefone.Text = _cliente.Telefone;
            dtpDataNascimento.SelectedDate = _cliente.DataNascimento;

        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ClienteDAO();
                List<Cliente> listaCliente = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _cliente.Nome = txtNome.Text;
            _cliente.Cpf = txtCpf.Text;
            _cliente.Email = txtEmail.Text;
            _cliente.Telefone = txtTelefone.Text;
            _cliente.DataNascimento = dtpDataNascimento.SelectedDate;

            try
            {
                var dao = new ClienteDAO();

                if (_cliente.IdCliente > 0)
                {
                    dao.Update(_cliente);
                    MessageBox.Show("Registro Atualizado com Sucesso!");
                }
                else
                {
                    dao.Insert(_cliente);
                    MessageBox.Show("Registro Salvo com Sucesso!");
                }

                CarregarListagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            dtpDataNascimento.SelectedDate = null;
        }

        private void VoltarMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
