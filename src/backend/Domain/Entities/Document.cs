using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Document : IMustHaveTenant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TenantId { get; set; }
        public string Title { get; set; } = string.Empty;
        public SourceType SourceType { get; set; } = SourceType.Pdf;
        public Status Status { get; set; } = Status.Pending;
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public ICollection<DocumentChunk> Chunks { get; set; } = new List<DocumentChunk>();
        public Tenant? Tenant { get; set; }
    }
}
