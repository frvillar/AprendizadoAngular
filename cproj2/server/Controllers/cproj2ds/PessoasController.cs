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

  [ODataRoutePrefix("odata/cproj2ds/Pessoas")]
  [Route("mvc/odata/cproj2ds/Pessoas")]
  public partial class PessoasController : ODataController
  {
    private Data.Cproj2DsContext context;

    public PessoasController(Data.Cproj2DsContext context)
    {
      this.context = context;
    }
    // GET /odata/Cproj2Ds/Pessoas
    [EnableQuery(MaxExpansionDepth=10)]
    [HttpGet]
    public IEnumerable<Models.Cproj2Ds.Pessoa> GetPessoas()
    {
      var items = this.context.Pessoas.AsQueryable<Models.Cproj2Ds.Pessoa>();

      this.OnPessoasRead(ref items);

      return items;
    }

    partial void OnPessoasRead(ref IQueryable<Models.Cproj2Ds.Pessoa> items);

    [EnableQuery(MaxExpansionDepth=10)]
    [HttpGet("{Pessoa1}")]
    public SingleResult<Pessoa> GetPessoa(int key)
    {
        var items = this.context.Pessoas.Where(i=>i.Pessoa1 == key);

        return SingleResult.Create(items);
    }
    partial void OnPessoaDeleted(Models.Cproj2Ds.Pessoa item);

    [HttpDelete("{Pessoa1}")]
    public IActionResult DeletePessoa(int key)
    {
        var item = this.context.Pessoas
            .Where(i => i.Pessoa1 == key)
            .Include(i => i.Projetos)
            .Include(i => i.Tarefas)
            .SingleOrDefault();

        if (item == null)
        {
            return NotFound();
        }

        this.OnPessoaDeleted(item);
        this.context.Pessoas.Remove(item);
        this.context.SaveChanges();

        return new NoContentResult();
    }

    partial void OnPessoaUpdated(Models.Cproj2Ds.Pessoa item);

    [HttpPut("{Pessoa1}")]
    public IActionResult PutPessoa(int key, [FromBody]Models.Cproj2Ds.Pessoa newItem)
    {
        if (newItem == null || (newItem.Pessoa1 != key))
        {
            return BadRequest();
        }

        this.OnPessoaUpdated(newItem);
        this.context.Pessoas.Update(newItem);
        this.context.SaveChanges();

        var itemToReturn = this.context.Pessoas
            .Where(i => i.Pessoa1 == key)
            .Include(i => i.Papei)
            .FirstOrDefault();

        return new JsonResult(itemToReturn, new Newtonsoft.Json.JsonSerializerSettings
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        })
        {
            StatusCode = 200
        };
    }

    [HttpPatch("{Pessoa1}")]
    public IActionResult PatchPessoa(int key, [FromBody]Delta<Models.Cproj2Ds.Pessoa> patch)
    {
        var item = this.context.Pessoas.Where(i=>i.Pessoa1 == key).FirstOrDefault();

        if (item == null)
        {
            return BadRequest();
        }

        patch.Patch(item);

        this.OnPessoaUpdated(item);
        this.context.Pessoas.Update(item);
        this.context.SaveChanges();

        var itemToReturn = this.context.Pessoas
            .Where(i => i.Pessoa1 == key)
            .Include(i => i.Papei)
            .FirstOrDefault();

        return new JsonResult(itemToReturn, new Newtonsoft.Json.JsonSerializerSettings
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        })
        {
            StatusCode = 200
        };
    }

    partial void OnPessoaCreated(Models.Cproj2Ds.Pessoa item);

    [HttpPost]
    public IActionResult Post([FromBody] Models.Cproj2Ds.Pessoa item)
    {
        if (item == null)
        {
            return BadRequest();
        }

        this.OnPessoaCreated(item);
        this.context.Pessoas.Add(item);
        this.context.SaveChanges();

        var key = item.Pessoa1;
        var itemToReturn = this.context.Pessoas
            .Where(i => i.Pessoa1 == key)
            .Include(i => i.Papei)
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
