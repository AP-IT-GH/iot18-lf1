using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using ViewModels;
using Services;
using Repositories;
using Microsoft.AspNetCore.Mvc;



namespace WebAPI
{
    //API endpoints
    [Route("api/lastlabfarm")]
    public class LastLabfarmDataController : ControllerBase
    {
        private LastLabfarmDataService _service;

        public LastLabfarmDataController(LastLabfarmDataService service)
        {
            _service = service;
        }

        [HttpGet("{id}")] // GET api/latestdata/5  labfarm id
        public LastLabfarmData Get(int id)
        {
            return _service.Get(id);
        }

    }
}
