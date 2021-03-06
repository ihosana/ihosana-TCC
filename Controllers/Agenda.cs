using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tcc_ihosana.Models;

namespace tcc_ihosana.Controllers
{
    public class Agenda : Controller
    {
        public IActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Consulta(Agendamento a)
        {
            Agendarbanco ab = new Agendarbanco();
            if ((HttpContext.Session.GetInt32("idusuario") == null))
            {
                ViewBag.Mensagem = "Erro no agendamento, faça o login ou insira todos os dados";
                return View();
            }
            else
            {
                ab.Insert(a, (int)HttpContext.Session.GetInt32("idusuario"));

                ViewBag.Mensagem = "Agendamento feito";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public IActionResult Lista()
        {
            {
                Agendarbanco abd = new Agendarbanco();
                List<Agendamento> agendamentos = abd.Query();
              
                    return View(agendamentos);
                

            }

         
        }
    }
}