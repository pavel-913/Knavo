## EF Core & Database Migrations
# Add a new migration (run from src/backend)
dotnet ef migrations add InitialCreate --project Infrastructure --startup-project Api

# Apply migrations to the PostgreSQL database
dotnet ef database update --project Infrastructure --startup-project Api

# Revert the last applied migration from DB (target previous migration name)
dotnet ef database update PreviousMigrationName --project Infrastructure --startup-project Api

# Remove the last migration file (only works if not applied to DB yet)
dotnet ef migrations remove --project Infrastructure --startup-project Api

# Generate raw SQL script of migrations for inspection
dotnet ef migrations script --project Infrastructure --startup-project Api -o docs/architecture/migration.sql

## Docker & Infrastructure
# Start background services
docker compose -f docker/docker-compose.yml up -d

# Stop running services
docker compose -f docker/docker-compose.yml down

# Stop and wipe database volume (clean reset)
docker compose -f docker/docker-compose.yml down -v

# View live logs for a specific container (e.g., PostgreSQL or Ollama)
docker logs -f saas_postgres
docker logs -f saas_ollama

# Open an interactive PostgreSQL shell directly inside the container
docker exec -it saas_postgres psql -U saas_user -d ai_support_saas

## Ollama
# Download the embedding model (used for RAG vectors)
docker exec -it saas_ollama ollama pull nomic-embed-text

# Download the chat model (e.g., Llama 3 or Mistral)
docker exec -it saas_ollama ollama pull llama3

# Test chat generation directly in terminal
docker exec -it saas_ollama ollama run llama3 "Hello, are you running properly?"

# List downloaded models
docker exec -it saas_ollama ollama list


## Angular CLI
# Generate a standalone component
ng g c features/chat/components/chat-box

# Generate an injectable service
ng g s core/auth/services/auth

# Generate a functional route guard
ng g g core/guards/auth

# Generate a functional HTTP interceptor
ng g interceptor core/interceptors/tenant

# Run tests
npm test

# Build production bundle
npm run build

## Git
# Create and switch to a new feature branch
git checkout -b feature/tenant-entity

# Check modified and untracked files
git status -s

# Stage all changes and commit using Conventional Commits
git add .
git commit -m "feat(domain): add Tenant and User entities"

# Push branch to remote repository
git push -u origin feature/tenant-entity

# Switch back to main and pull latest updates
git checkout main
git pull origin main