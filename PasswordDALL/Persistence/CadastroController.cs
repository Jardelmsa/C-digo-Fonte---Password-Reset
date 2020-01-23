using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PasswordDALL.Models;

namespace PasswordDALL.Persistence
{
    public class CadastroController: Conexao
    {

        public void Create( Cadastro c)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand(" INSERT INTO Cadastro VALUES (@v1, @v2, @v3, @v4) ", Con);
                Cmd.Parameters.AddWithValue("@v1", c.CPF);
                Cmd.Parameters.AddWithValue("@v2", c.NomeCompleto);
                Cmd.Parameters.AddWithValue("@v3", c.Usuario);
                Cmd.Parameters.AddWithValue("@v4", c.Senha);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Update(Cadastro c)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE Cadastro SET senha=@v1 WHERE cpf=@v2", Con);
                Cmd.Parameters.AddWithValue("@v1", c.Senha);
                Cmd.Parameters.AddWithValue("@v2", c.CPF);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
