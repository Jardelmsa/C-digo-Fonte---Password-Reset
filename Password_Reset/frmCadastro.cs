using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordDALL.Models;
using PasswordDALL.Persistence;

namespace Password_Reset
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCPF.Text == "" || txtNomeCompleto.Text=="" || txtUsuario.Text=="" || txtSenha.Text == "" || txtConfirmarSenha.Text =="")
                {
                    lblMensagem.Text = " * Preencha Todos os Campos do Formulário ! * ";
                    txtCPF.Focus();
                }
                else
                {
                    if(txtSenha.Text == txtConfirmarSenha.Text)
                    {
                        Cadastro c = new Cadastro();
                        c.CPF = txtCPF.Text;
                        c.NomeCompleto = txtNomeCompleto.Text;
                        c.Usuario = txtUsuario.Text;
                        c.Senha = txtSenha.Text;

                        CadastroController cc = new CadastroController();
                        cc.Create(c);

                        lblMensagem.Text = "Cadastro Realizado !";
                        this.txtCPF.Text = "";
                        this.txtNomeCompleto.Text = "";
                        this.txtUsuario.Text = "";
                        this.txtSenha.Text = "";
                        this.txtConfirmarSenha.Text = "";

                    }
                    else
                    {
                        lblMensagem.Text = " * As Senhas não Conferem ...  Tente novamente... * ";
                        txtConfirmarSenha.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtCPF.Text = "";
            this.txtNomeCompleto.Text = "";
            this.txtUsuario.Text = "";
            this.txtSenha.Text = "";
            this.txtConfirmarSenha.Text = "";
        }
    }
}
