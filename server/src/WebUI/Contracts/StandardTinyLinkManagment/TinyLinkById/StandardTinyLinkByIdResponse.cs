using System;

namespace WebUI.Contracts.StandardTinyLinkManagement.TinyLinkById
{
    public class StandardTinyLinkByIdResponse
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}