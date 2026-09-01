1. Branch Naming Best Practices
Use kebab-case (lowercase-with-hyphens) and prefix the branch with the category of work:
feature/ – A new feature or capability.
    Example: feature/tenant-middleware, feature/ollama-service

fix/ or bugfix/ – Fixing a bug.
    Example: fix/cors-origin-issue, fix/token-expiration

chore/ – Maintenance, setup, tooling, or package updates.
    Example: chore/docker-compose-setup, chore/angular-scaffold

docs/ – Writing or updating documentation.
    Example: docs/adr-001-multi-tenancy, docs/setup-guide

refactor/ – Restructuring code without changing its external behavior.
    Example: refactor/efcore-query-filters
    
Rule of thumb: Keep names short and descriptive (e.g., git checkout -b feature/auth-jwt-handler).

2. Commit Message Best Practices (Conventional Commits)Follow the standard structured format:
Plaintext
<type>(<scope>): <short summary in imperative mood>
[optional body providing context/why]

Common      Commit  Types:
Type        When to Use                                     Example
feat        Adding a new feature                            feat(auth): add JWT token generation with TenantId claim
fix         Fixing a bug                                    fix(api): correct pgvector embedding distance calculation
docs        Documentation changes                           docs(adr): document multi-tenancy architectural decision
chore       Tooling, config, dependencies                   chore(docker): add postgres pgvector and ollama services
refactor    Code restructure without feature/bug change     refactor(db): extract IMustHaveTenant into shared domain
style       Formatting, white-space, missing semi-colons    style(angular): format chat component SCSS
test        Adding or updating tests                        test(auth): add unit tests for tenant resolution middleware
