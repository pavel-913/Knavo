using Domain.Common;
using Pgvector;


namespace Domain.Entities
{
    public class DocumentChunk : IMustHaveTenant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TenantId {  get; set; }
        public Guid DocumentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int ChunkIndex { get; set; } = 0;

        public Vector? Embedding { get; set; }
        public Document? Document { get; set; }
    }
}
