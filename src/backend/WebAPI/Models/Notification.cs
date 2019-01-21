using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models {
    public class Notification {
        public int Id { get; set; }
        public string AuthId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string LinkToUrl { get; set; }
        public int Urgency { get; set; }
    }
}
