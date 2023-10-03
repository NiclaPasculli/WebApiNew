using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiNew.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace WebApiNew.Controllers
{
    public class ToolController : ApiController
    {
       ToolRepository toolRepo = new ToolRepository();


        public IHttpActionResult Get()
        {
            return Ok(toolRepo.ReadAll());
        }

        
        public IHttpActionResult Get(string id) 
        {
            return Ok(toolRepo.GetById(id));
        }

        [HttpGet]
        [Route("api/tool/search")]
        public IHttpActionResult Search(string id, string turretcode)
        {
            return Ok(toolRepo.Search(id, turretcode));
        }

        public HttpResponseMessage Post ([FromBody] Tool tool)
        {
            if(tool == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Tool non inserito");
            }
            try
            {
                toolRepo.Insert(tool);
                return Request.CreateResponse(HttpStatusCode.OK, "Tool inserito");
            }
            catch (Exception)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "errore");
            }
        }

        public  IHttpActionResult Put(string id,[FromBody] Tool tool)
        {
            if (tool.IdTool != id)
            {
                return BadRequest("L'id del Tool nel body della richiesta non corrisponde all'id specificato nell'URL");
            }

            bool success = toolRepo.UpdateT(id, tool, out string errorMessage);
            if (success)
            {
                return Ok("Tool modificato");
            }
            else
            {
                return BadRequest(errorMessage);
            }



        }

        public HttpResponseMessage Delete(string id)
        {
            Tool tools = toolRepo.GetById(id);
            if (tools == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Tool non presente");
            }
            try
            {
                toolRepo.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Tool eliminato");
            }
            catch (Exception)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "errore");
            }
        }
    }
}