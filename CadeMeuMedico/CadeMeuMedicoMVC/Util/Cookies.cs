using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadeMeuMedicoMVC.Util
{
    public class Cookies
    {
        public static void RegistraCookieAutenticacao(Usuario usuario)
        {
            //Criando um objeto cookie
            HttpCookie UserCookie = new HttpCookie("UserCookieAuthentication");
            var jsonUsuario = JsonConvert.SerializeObject(usuario);
            //Setando o ID do usuário no cookie
            UserCookie.Values["Usuario"] = Criptografia.Criptografar(jsonUsuario);

            //Definindo o prazo de vida do cookie
            UserCookie.Expires = DateTime.Now.AddDays(1);

            //Adicionando o cookie no contexto da aplicação
            HttpContext.Current.Response.Cookies.Add(UserCookie);
        }
    }
}