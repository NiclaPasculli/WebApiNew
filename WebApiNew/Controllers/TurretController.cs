using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiNew.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace WebApiNew.Controllers
{
    public class TurretController : ApiController
    {
        TurretRepository turretRepo = new TurretRepository();

        [HttpGet]
        [Route("api/turret/id")]
        public IHttpActionResult GetAllId()
        {
            List<string> turretIds = turretRepo.GetAllTurretIds();
            return Ok<List<string>>(turretIds);
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(turretRepo.GetById(id));
        }

    }
}