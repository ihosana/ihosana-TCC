
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tcc_ihosana.Models;

namespace tcc_ihosana.Controllers
{
    public class UsuarioController :Controller
    {
           public IActionResult Welcome()
        {
            return View();
        }
          public IActionResult Cadastro()
        {
            return View();
        }
          [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioBanco use = new UsuarioBanco();
            if (use != null)
            {
                use.Insert(u);
                ViewBag.Mensagem = "Usuario Cadastrado com sucesso";
                return View();
            }
            else
            {
                ViewBag.Mensagem = "Erro no cadastro";
                return View();
            }
        }
          public IActionResult Partusuario(){
           return View("./Agenda/Consulta");
       }
         public IActionResult Login(){
           return View();
       }
       public IActionResult Login1(){
           return View();
       }
        
          [HttpPost]
        public IActionResult Login1(Usuario u)
        {
            UsuarioBanco ub = new UsuarioBanco();
            Usuario pessoa = ub.QueryLogin(u);
            if (pessoa != null)
            {
                ViewBag.Mensagem = "Logado";
                HttpContext.Session.SetInt32("idusuario", u.Id);
                HttpContext.Session.SetString("loginUsuario", u.Login);
                   return View("Partusuario");
            }
            else
            {
                ViewBag.Mensagem = "erro no login";
                return View();
            }
        }
        
         public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("");
        }
        
    }
}