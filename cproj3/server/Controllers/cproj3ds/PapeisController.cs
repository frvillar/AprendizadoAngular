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

  [ODataRoutePrefix("odata/cproj3ds/Papeis")]
  [Route("mvc/odata/cproj3ds/Papeis")]
  public partial class PapeisController : ODataController
  {
    private Data.Cproj3DsContext context;

    public PapeisController(Data.Cproj3DsContext context)
    {
      this.context = context;
    }
    // GET /odata/Cproj3Ds/Papeis
    [EnableQuery(MaxExpansionDepth=10)]
    [HttpGet]
    public IEnumerable<Models.Cproj3Ds.Papei> GetPapeis()
    {
      var items = this.context.Papeis.AsQueryable<Models.Cproj3Ds.Papei>();

      this.OnPapeisRead(ref items);

      return items;
    }

    partial void OnPapeisRead(ref IQueryable<Models.Cproj3Ds.Papei> items);

    [EnableQuery(MaxExpansionDepth=10)]
    [HttpGet("{Papel}")]
    public SingleResult<Papei> GetPapei(int key)
    {
        var items = this.context.Papeis.Where(i=>i.Papel == key);

        return SingleResult.Create(items);
    }
    partial void OnPapeiDeleted(Models.Cproj3Ds.Papei item);

    [HttpDelete("{Papel}")]
    public IActionResult DeletePapei(int key)
    {
        var item = this.context.Papeis
            .Where(i => i.Papel == key)
            .Include(i => i.Pessoas)
            .SingleOrDefault();

        if (item == null)
        {
            return NotFound();
        }

        this.OnPapeiDeleted(item);
        this.context.Papeis.Remove(item);
        this.context.SaveChanges();

        return new NoContentResult();
    }

    partial void OnPapeiUpdated(Models.Cproj3Ds.Papei item);

    [HttpPut("{Papel}")]
    public IActionResult PutPapei(int key, [FromBody]Models.Cproj3Ds.Papei newItem)
    {
        if (newItem == null || (newItem.Papel != key))
        {
            return BadRequest();
        }

        this.OnPapeiUpdated(newItem);
        this.context.Papeis.Update(newItem);
        this.context.SaveChanges();

        return new NoContentResult();
    }

    [HttpPatch("{Papel}")]
    public IActionResult PatchPapei(int key, [FromBody]Delta<Models.Cproj3Ds.Papei> patch)
    {
        var item = this.context.Papeis.Where(i=>i.Papel == key).FirstOrDefault();

        if (item == null)
        {
            return BadRequest();
        }

        patch.Patch(item);

        this.OnPapeiUpdated(item);
        this.context.Papeis.Update(item);
        this.context.SaveChanges();

        return new NoContentResult();
    }

    partial void OnPapeiCreated(Models.Cproj3Ds.Papei item);

    [HttpPost]
    public IActionResult Post([FromBody] Models.Cproj3Ds.Papei item)
    {
        if (item == null)
        {
            return BadRequest();
        }

        this.OnPapeiCreated(item);
        this.context.Papeis.Add(item);
        this.context.SaveChanges();

        return Created($"odata/Cproj3Ds/Papeis/{item.Papel}", item);
    }
  }
}
