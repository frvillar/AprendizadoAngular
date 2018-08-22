using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace Cproj2.Controllers.Cproj2Ds
{
  using Models;
  using Data;
  using Models.Cproj2Ds;

  [ODataRoutePrefix("odata/cproj2ds/Projetos")]
  [Route("mvc/odata/cproj2ds/Projetos")]
  public partial class ProjetosController : ODataController
  {
    private Data.Cproj2DsContext context;

    public ProjetosController(Data.Cproj2DsContext context)
    {
      this.context = context;
    }
    // GET /odata/Cproj2Ds/Projetos
    [EnableQuery(MaxExpansionDepth=10)]
    [HttpGet]
    public IEnumerable<Models.Cproj2Ds.Projeto> GetProjetos()
    {
      var items = this.context.Projetos.AsQueryable<Models.Cproj2Ds.Projeto>();

      this.OnProjetosRead(ref items);

      return items;
    }

    partial void OnProjetosRead(ref IQueryable<Models.Cproj2Ds.Projeto> items);

    [EnableQuery(MaxExpansionDepth=10)]
    [HttpGet("{Projeto1}")]
    public SingleResult<Projeto> GetProjeto(int key)
    {
        var items = this.context.Projetos.Where(i=>i.Projeto1 == key);

        return SingleResult.Create(items);
    }
    partial void OnProjetoDeleted(Models.Cproj2Ds.Projeto item);

    [HttpDelete("{Projeto1}")]
    public IActionResult DeleteProjeto(int key)
    {
        var item = this.context.Projetos
            .Where(i => i.Projeto1 == key)
            .Include(i => i.Tarefas)
            .SingleOrDefault();

        if (item == null)
        {
            return NotFound();
        }

        this.OnProjetoDeleted(item);
        this.context.Projetos.Remove(item);
        this.context.SaveChanges();

        return new NoContentResult();
    }

    partial void OnProjetoUpdated(Models.Cproj2Ds.Projeto item);

    [HttpPut("{Projeto1}")]
    public IActionResult PutProjeto(int key, [FromBody]Models.Cproj2Ds.Projeto newItem)
    {
        if (newItem == null || (newItem.Projeto1 != key))
        {
            return BadRequest();
        }

        this.OnProjetoUpdated(newItem);
        this.context.Projetos.Update(newItem);
        this.context.SaveChanges();

        var itemToReturn = this.context.Projetos
            .Where(i => i.Projeto1 == key)
            .Include(i => i.Pessoa)
            .FirstOrDefault();

        return new JsonResult(itemToReturn, new Newtonsoft.Json.JsonSerializerSettings
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        })
        {
            StatusCode = 200
        };
    }

    [HttpPatch("{Projeto1}")]
    public IActionResult PatchProjeto(int key, [FromBody]Delta<Models.Cproj2Ds.Projeto> patch)
    {
        var item = this.context.Projetos.Where(i=>i.Projeto1 == key).FirstOrDefault();

        if (item == null)
        {
            return BadRequest();
        }

        patch.Patch(item);

        this.OnProjetoUpdated(item);
        this.context.Projetos.Update(item);
        this.context.SaveChanges();

        var itemToReturn = this.context.Projetos
            .Where(i => i.Projeto1 == key)
            .Include(i => i.Pessoa)
            .FirstOrDefault();

        return new JsonResult(itemToReturn, new Newtonsoft.Json.JsonSerializerSettings
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        })
        {
            StatusCode = 200
        };
    }

    partial void OnProjetoCreated(Models.Cproj2Ds.Projeto item);

    [HttpPost]
    public IActionResult Post([FromBody] Models.Cproj2Ds.Projeto item)
    {
        if (item == null)
        {
            return BadRequest();
        }

        this.OnProjetoCreated(item);
        this.context.Projetos.Add(item);
        this.context.SaveChanges();

        var key = item.Projeto1;
        var itemToReturn = this.context.Projetos
            .Where(i => i.Projeto1 == key)
            .Include(i => i.Pessoa)
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
