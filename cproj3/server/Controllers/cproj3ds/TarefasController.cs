using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace Cproj3.Controllers.Cproj3Ds
{
  using Models;
  using Data;
  using Models.Cproj3Ds;

  [ODataRoutePrefix("odata/cproj3ds/Tarefas")]
  [Route("mvc/odata/cproj3ds/Tarefas")]
  public partial class TarefasController : ODataController
  {
    private Data.Cproj3DsContext context;

    public TarefasController(Data.Cproj3DsContext context)
    {
      this.context = context;
    }
    // GET /odata/Cproj3Ds/Tarefas
    [EnableQuery(MaxExpansionDepth=10)]
    [HttpGet]
    public IEnumerable<Models.Cproj3Ds.Tarefa> GetTarefas()
    {
      var items = this.context.Tarefas.AsQueryable<Models.Cproj3Ds.Tarefa>();

      this.OnTarefasRead(ref items);

      return items;
    }

    partial void OnTarefasRead(ref IQueryable<Models.Cproj3Ds.Tarefa> items);

    [EnableQuery(MaxExpansionDepth=10)]
    [HttpGet("{Tarefa1}")]
    public SingleResult<Tarefa> GetTarefa(int key)
    {
        var items = this.context.Tarefas.Where(i=>i.Tarefa1 == key);

        return SingleResult.Create(items);
    }
    partial void OnTarefaDeleted(Models.Cproj3Ds.Tarefa item);

    [HttpDelete("{Tarefa1}")]
    public IActionResult DeleteTarefa(int key)
    {
        var item = this.context.Tarefas
            .Where(i => i.Tarefa1 == key)
            .SingleOrDefault();

        if (item == null)
        {
            return NotFound();
        }

        this.OnTarefaDeleted(item);
        this.context.Tarefas.Remove(item);
        this.context.SaveChanges();

        return new NoContentResult();
    }

    partial void OnTarefaUpdated(Models.Cproj3Ds.Tarefa item);

    [HttpPut("{Tarefa1}")]
    public IActionResult PutTarefa(int key, [FromBody]Models.Cproj3Ds.Tarefa newItem)
    {
        if (newItem == null || (newItem.Tarefa1 != key))
        {
            return BadRequest();
        }

        this.OnTarefaUpdated(newItem);
        this.context.Tarefas.Update(newItem);
        this.context.SaveChanges();

        var itemToReturn = this.context.Tarefas
            .Where(i => i.Tarefa1 == key)
            .Include(i => i.Pessoa)
            .Include(i => i.Projeto1)
            .FirstOrDefault();

        return new JsonResult(itemToReturn, new Newtonsoft.Json.JsonSerializerSettings
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        })
        {
            StatusCode = 200
        };
    }

    [HttpPatch("{Tarefa1}")]
    public IActionResult PatchTarefa(int key, [FromBody]Delta<Models.Cproj3Ds.Tarefa> patch)
    {
        var item = this.context.Tarefas.Where(i=>i.Tarefa1 == key).FirstOrDefault();

        if (item == null)
        {
            return BadRequest();
        }

        patch.Patch(item);

        this.OnTarefaUpdated(item);
        this.context.Tarefas.Update(item);
        this.context.SaveChanges();

        var itemToReturn = this.context.Tarefas
            .Where(i => i.Tarefa1 == key)
            .Include(i => i.Pessoa)
            .Include(i => i.Projeto1)
            .FirstOrDefault();

        return new JsonResult(itemToReturn, new Newtonsoft.Json.JsonSerializerSettings
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        })
        {
            StatusCode = 200
        };
    }

    partial void OnTarefaCreated(Models.Cproj3Ds.Tarefa item);

    [HttpPost]
    public IActionResult Post([FromBody] Models.Cproj3Ds.Tarefa item)
    {
        if (item == null)
        {
            return BadRequest();
        }

        this.OnTarefaCreated(item);
        this.context.Tarefas.Add(item);
        this.context.SaveChanges();

        var key = item.Tarefa1;
        var itemToReturn = this.context.Tarefas
            .Where(i => i.Tarefa1 == key)
            .Include(i => i.Pessoa)
            .Include(i => i.Projeto1)
            .FirstOrDefault();

        return new JsonResult(itemToReturn, new Newtonsoft.Json.JsonSerializerSettings
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        })
        {
            StatusCode = 201
        };
    }
  }
}
