using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TarefaLista.Models;

namespace TarefaLista.Controllers
{
    public class TarefaListasController : Controller
    {
        private ModeloDados db = new ModeloDados();

        // GET: TarefaListas
        public async Task<ActionResult> Index()
        {
            return View(await db.TarefaLista.ToListAsync());
        }

        // GET: TarefaListas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.TarefaLista tarefaLista = await db.TarefaLista.FindAsync(id);
            if (tarefaLista == null)
            {
                return HttpNotFound();
            }
            return View(tarefaLista);
        }

        // GET: TarefaListas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarefaListas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( FormCollection formCollection,[Bind(Exclude = "Id", Include = "Descricao,Anotacao,DataCriacao,DataAtividade,DataFinalizacao,Prioridade,Status")] Models.TarefaLista tarefaLista)
        {
            if (ModelState.IsValid)
            {
                tarefaLista.Prioridade = int.Parse(formCollection["ddlPrioridade"]);
                tarefaLista.Status = int.Parse(formCollection["ddlStatus"]);
                tarefaLista.DataCriacao = DateTime.Now;
                tarefaLista.DataFinalizacao =new DateTime();

                db.TarefaLista.Add(tarefaLista);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tarefaLista);
        }

        // GET: TarefaListas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.TarefaLista tarefaLista = await db.TarefaLista.FindAsync(id);
            if (tarefaLista == null)
            {
                return HttpNotFound();
            }
            return View(tarefaLista);
        }

        // POST: TarefaListas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao,Anotacao,DataCriacao,DataAtividade,DataFinalizacao,Prioridade,Status")] Models.TarefaLista tarefaLista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefaLista).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tarefaLista);
        }

        // GET: TarefaListas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.TarefaLista tarefaLista = await db.TarefaLista.FindAsync(id);
            if (tarefaLista == null)
            {
                return HttpNotFound();
            }
            return View(tarefaLista);
        }

        // POST: TarefaListas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Models.TarefaLista tarefaLista = await db.TarefaLista.FindAsync(id);
            db.TarefaLista.Remove(tarefaLista);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
