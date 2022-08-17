using Microsoft.AspNetCore.Mvc;
using Desafio_Unifenas.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Desafio_Unifenas.Controllers
{
    public class AlunoController : Controller
    {
        public _DbContext context;
        public ValidaCpf validar=new ValidaCpf();
        
        public AlunoController(_DbContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.alunos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.id = new SelectList(context.alunos.OrderBy(f => f.Nome), "id", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno aluno)
        {
            if (validar.Valida(aluno.Cpf) == true) { 
                context.Add(aluno);
                context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError(nameof(aluno.Cpf), "Cpf invalido");
                return View(aluno);
            }
            return RedirectToAction("Index");
        }
        public IActionResult edit(int id)
        {
            var aluno = context.alunos.Find(id);
            ViewBag.id = new SelectList(context.alunos.OrderBy(f => f.Nome), "id", "Nome");
            return View(aluno);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult edit(Aluno alunos)
        {
            context.Entry(alunos).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var aluno = context.alunos.Find(id);    
            return View(aluno);
        }
        public IActionResult Delete(int id)
        {
            var aluno = context.alunos.Find(id);
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Aluno aluno)
        {
            context.Remove(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
