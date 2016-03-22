using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using System.Data.SqlClient;

namespace GUIControleMensagens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

               
                    SqlConnection conn = new SqlConnection(@"Data Source=INFO03;Initial Catalog=CadastrodeClientes;Integrated Security=True;Pooling=False");

                    
                    SqlCommand Comm = new SqlCommand();
                    Comm.Connection = conn;

                   
                    Comm.CommandText = "INSERT INTO tbClientes (CLIENTE, CIDADE, " +
                              " CPF, ESTADO, BAIRRO, EMAILCLIENTE , TELEFONE) " +
                                                     " VALUES (@CLIENTE, @CIDADE, @CPF, @ESTADO," +
                              "     @BAIRRO, @EMAILCLIENTE, @TELEFONE) ";

                    Comm.Parameters.AddWithValue("@CLIENTE", Cliente.Text);
                    Comm.Parameters.AddWithValue("@CIDADE", Cidade.Text);
                    Comm.Parameters.AddWithValue("@CPF", CPF.ToString());
                    Comm.Parameters.AddWithValue("@ESTADO", Estado.SelectedItem.ToString());
                    Comm.Parameters.AddWithValue("@BAIRRO", Telefone.Text);
                    Comm.Parameters.AddWithValue("@EMAILCLIENTE", Email.Text);
                    Comm.Parameters.AddWithValue("@TELEFONE",Telefone.Text);
                   
                    conn.Open();
                    Comm.ExecuteNonQuery();
                    conn.Close();

                   
                    MessageBox.Show("Dados Inseridos com sucesso!", "mensagem",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
              

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
                    CPF.Text = "";
                    Estado.SelectedIndex = -1;
                    Telefone.Text = "";
                    Bairro.Text = "";
                    Email.Text = "";
                    
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnVerCadastros_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Em manutenção.");
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
                    CPF.Text = "";
                    Estado.SelectedIndex = -1;
                    Telefone.Text = "";
                    Bairro.Text = "";
                    Email.Text = "";
                    
                    
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
}
