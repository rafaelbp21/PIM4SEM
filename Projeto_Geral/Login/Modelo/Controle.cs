using Login.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Login.Apresentacao;
using Microsoft.Win32;

namespace Login.Modelo
{
    public class Controle
    {
        public (bool,string, bool) tem;
        public string mensagem = "";

        public bool acessar(string usuario, string senha)
        {
            LoginDAO loginDao = new LoginDAO();
            tem = loginDao.verificarLogin(usuario, senha);
            if (!loginDao.mensagem.Equals(""))
            {
                this.mensagem = loginDao.mensagem;
            }
            return tem.Item1;
        }
        public string cadastrar(string usuario, string nome, string senha, string acesso, bool active)
        {
            LoginDAO loginDao = new LoginDAO();
            this.mensagem = loginDao.cadastrar(usuario, nome, senha, acesso, active);
            if(loginDao.tem)
            {
                this.tem.Item1 = true;
            }
            return mensagem;
        }
        public string alterar(string usuario, string nome, string senha, string acesso, int id, bool active)
        {
            LoginDAO loginDao = new LoginDAO();
            this.mensagem = loginDao.alterar(usuario, nome, senha, acesso, id, active);
            if (loginDao.tem)
            {
                this.tem.Item1 = true;
            }
            return mensagem;
        }
        /*public string excluir(int id)
        {
            LoginDaoComandos excluir = new LoginDaoComandos();
            this.mensagem = excluir.excluir(id);
            if (excluir.tem)
            {
                this.tem.Item1 = true;
            }
            return mensagem;
        }*/
    }
}
