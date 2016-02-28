using CadeMeuMedicoMVC.Models.WebAPI;
using CadeMeuMedicoMVC.Util;
using Dominio;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CadeMeuMedicoMVC.Models.Business
{
    public class UsuarioBL
    {
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
            var autenticado = false;
            var usuario = UsuarioAPI.Get("api/usuario", Login, SenhaCriptografada).First<Usuario>(); //UsuarioDTO.AutenticarUsuario(Login, SenhaCriptografada);

            if (usuario != null)
            {
                autenticado = true;
                Cookies.RegistraCookieAutenticacao(usuario);
            }
            return autenticado;
        }

        public static Usuario VerificaSeOUsuarioEstaLogado()
        {
            var JsonUsuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];

            if (JsonUsuario == null)
            {
                return null;
            }
            else
            {
                string json = Criptografia.
                Descriptografar(JsonUsuario.Values["Usuario"]);
                var UsuarioRetornado = JsonConvert.DeserializeObject<Usuario>(json);
                return UsuarioRetornado;
            }
        }
    }
}