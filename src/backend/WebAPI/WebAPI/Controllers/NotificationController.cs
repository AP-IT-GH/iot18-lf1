using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Services;
using Models;


namespace WebAPI {

    [Route("api/v1/notification")]
    public class NotificationController : Controller {

        private NotificationService _service;


        public NotificationController(NotificationService service) {
            _service = service;
        }

        [HttpGet]
        public List<Notification> GetList() {
            return _service.GetAll();
        }

        [HttpGet("{authid}")]
        public List<Notification> GetAll(string authid) {
            return _service.GetAll(authid);
        }

        [HttpPost]
        public Notification Post([FromBody]Notification notification) {
            return _service.Post(notification);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id) {
            return _service.Delete(id);
        }

    }

}
