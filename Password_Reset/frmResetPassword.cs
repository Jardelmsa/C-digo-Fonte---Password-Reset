using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PasswordDALL.Models;
using PasswordDALL.Persistence;

namespace Password_Reset
{
    public partial class frmResetPassword : Form
    {
        public frmResetPassword()
        {
            InitializeComponent();
        }

        SqlConnection Con;
        SqlCommand Cmd;
        SqlDataAdapter Adpt;
        SqlDataReader Dr;

        private void AbrirConexao()
        {
            try
            {
                Con = new SqlConnection("Data Source=DESKTOP-6NKVMJU;Initial Catalog=dbproject;Integrated Security=True;");
                Con.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void FecharConexao()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCPF.Text =="" || txtNovaSenha.Text=="" || txtConfirmarSenha.Text == "")
                {
                    lblMensagem.Text = " * Preencha todos os campos do Formulário... *";
                    txtCPF.Focus();
                }
                else
                {
                    if(txtNovaSenha.Text== txtConfirmarSenha.Text)
                    {
                        AbrirConexao();
                        Cmd = new SqlCommand("SELECT * FROM Cadastro WHERE cpf= '" + txtCPF.Text + "' ", Con);
                        Dr = Cmd.ExecuteReader();
                      
                        if (Dr.Read())
                        {
                            AbrirConexao();
                            Cmd = new SqlCommand("UPDATE Cadastro SET senha=@v1 WHERE cpf= '" + txtCPF.Text + "' ", Con);
                            Cmd.Parameters.AddWithValue("@v1", txtNovaSenha.Text);
                            Dr = Cmd.ExecuteReader();
                            FecharConexao();

                            lblMensagem.Text = " * Senha Atualizada com Sucesso ! * ";

                            this.txtCPF.Text = "";
                            this.txtNovaSenha.Text = "";
                            this.txtConfirmarSenha.Text = "";
                        }
                    }
                    else
                    {
                        lblMensagem.Text = " * As Senhas não Conferem ...* ";
                        txtConfirmarSenha.Text = "";
                        txtConfirmarSenha.Focus();
                    }
                }
               
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtConfirmarSenha.Text = "";
            this.txtNovaSenha.Text = "";
            this.txtCPF.Text = "";
        }
    }
}
