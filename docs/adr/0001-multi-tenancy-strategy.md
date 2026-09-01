# ADR 1:  Shared Database, Shared Schema Multi-Tenancy
## Context
We need a data isolation strategy for our multi tenant SaaS

## Decision
We chose a **Shared Database, Shared Schema** mode using a `TenantId` discriminator on all tenant-specific tables.
- Isolation is enforced globally via EF Core `HasQueryFilter`.
- Automatic tenant resolution is handled via an HTTP context extractor and base repository interceptors.

## Consequences
- **Positive:** Single database instance, effortless migrations, minimal operational cost.
- **Negative:** Requires rigorous automated testing and global querty filters to ensure zero data leakage between tenants.