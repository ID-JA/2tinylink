using System;

namespace WebUI.Contracts.StandardTinyLinkManagement.TinyLinkById
{
    public class StandardTinyLinkByIdResponse
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}