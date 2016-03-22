using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Globalization;

namespace GUIControleMensagens
{
    public partial class FormPrincipal : Form
    {
        private FormEnvioMensagem formEnvioMensagem;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void envioDeMensagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formEnvioMensagem == null)
            {
                formEnvioMensagem = new FormEnvioMensagem();
            }
            formEnvioMensagem.ShowDialog(this);
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                //Instancio o SqlConnection, passando como parâmetro a string de conexão ao banco
                    SqlConnection conn = new SqlConnection(@"Data Source=INFO03;Initial Catalog=CadastrodeClientes;Integrated Security=True;Pooling=False");

                    //Instancio o SqlCommand, responsavel pelas instruções SQL e
                    //Passo ao SqlCommand que a conexão que ele usará é o SqlConnection
                    SqlCommand Comm = new SqlCommand();
                    Comm.Connection = conn;

                    //No CommandText do SqlCommand, passo a instrução SQL referenteà Inserção dos dados
                    Comm.CommandText = "INSERT INTO tbClientes (CLIENTE, CIDADE, " +
                              " CPF, ESTADO, BAIRRO, FABRICANTE, EMAILCLIENTE, VENDEDOR, VENDA ) " +
                        //Nos Values, passo os valores parametricados usado @ para garantir a segurança dos dados
                              " VALUES (@CLIENTE, @CIDADE, @CPF, @ESTADO," +
                              "     @BAIRRO, @FABRICANTE, @EMAILCLIENTE, @VENDEDOR, @VENDA) ";

                    //Agora passo os Valores parametrizados por meio do metodo AddWithValue
                    Comm.Parameters.AddWithValue("@CLIENTE", Cliente.Text);
                    Comm.Parameters.AddWithValue("@CIDADE", Cidade.Text);
                    Comm.Parameters.AddWithValue("@CPF", CPF.SelectedItem.ToString());
                    Comm.Parameters.AddWithValue("@ESTADO", Estado.SelectedItem.ToString());
                    Comm.Parameters.AddWithValue("@BAIRRO", Telefone.Text);
                    Comm.Parameters.AddWithValue("@FABRICANTE", Fabricante.Text);
                    Comm.Parameters.AddWithValue("@EMAILCLIENTE", Email.Text);
                    Comm.Parameters.AddWithValue("@VENDEDOR",Vendedor.Text);
                    Comm.Parameters.AddWithValue("@VENDA",Venda.SelectedItem.Tostring());
                    //Abor a conexão e uso o método ExecuteNonQuery, após isso, fecho a conexão
                    conn.Open();
                    Comm.ExecuteNonQuery();
                    conn.Close();

                    //Exibo uma mensagem ao usuário de inserção realizada com seucesso
                    MessageBox.Show("Dados Inseridos com sucesso!", "mensagem",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                

            }

            finally

            {
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja Cancelar o Cadastro e Fazer Um Novo?", "Menssagem do Sistema",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cliente.Text = "";
                    Cidade.Text = "";
                    CPF.SelectedIndex = -1;
                    Estado.SelectedIndex = -1;
                    Bairro.Text = "";
                    Email.Text = "";
                    Vendedor.Text = "";
                    Venda.Text = "";
                }
            }
            catch (Exception)
            {
                throw;
            }


            {

            }
        }

        private void btnVerCadastros_Click(object sender, EventArgs e)
        {
            try
            {
                VerCadastros frmVerCadastros = new VerCadastros();
                frmVerCadastros.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja Cancelar o Cadastro e Fazer um Novo?", "Mensagem do Sistema",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cliente.Text = "";
                    Cidade.Text = "";
                    CPF.SelectedIndex = -1;
                    Estado.SelectedIndex = -1;
                    Bairro.Text = "";
                    Email.Text = "";
                    Vendedor.Text = "";
                    Venda.Text = "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {

        }




    


}