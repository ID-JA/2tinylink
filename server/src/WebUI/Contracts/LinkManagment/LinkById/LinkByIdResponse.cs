using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Contracts.LinkManagment.LinkById
{
    public class LinkByIdResponse
    {
        public Guid Id { get; set; }
        public string Uri { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}