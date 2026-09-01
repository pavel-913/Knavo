## Git
# 1. Initialize Git repository
git init ai-support-saas
cd ai-support-saas

# 2. Create the documentation, docker, and source folders
mkdir -p docs/adr docs/api docs/architecture docs/guides docs/progress docker src/backend src/frontend



## Back End
cd src/backend

# 1. Create the solution file
dotnet new sln -n AiSupportSaas

# 2. Create the individual architectural layers
dotnet new webapi -n Api -o Api
dotnet new classlib -n Application -o Application
dotnet new classlib -n Domain -o Domain
dotnet new classlib -n Infrastructure -o Infrastructure

# 3. Add projects to the solution
dotnet sln add Api/Api.csproj Application/Application.csproj Domain/Domain.csproj Infrastructure/Infrastructure.csproj

# 4. Configure project references
dotnet add Api/Api.csproj reference Application/Application.csproj Infrastructure/Infrastructure.csproj
dotnet add Application/Application.csproj reference Domain/Domain.csproj
dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj Application/Application.csproj

# 5. Return to project root
cd ../..

## Front end
cd src

# 1. Generate standalone Angular application with routing and SCSS
npx @angular/cli@latest new frontend --routing --style=scss --standalone --skip-git --directory=frontend

cd frontend

# 2. Scaffold core, feature, and shared directories
mkdir -p src/app/core/auth src/app/core/guards src/app/core/interceptors src/app/core/services
mkdir -p src/app/features/auth src/app/features/dashboard src/app/features/documents src/app/features/chat src/app/features/settings
mkdir -p src/app/shared/components src/app/shared/directives src/app/shared/pipes

# 3. Return to project root
cd ../..

## Docker
# 1. Start containers in detached mode
docker compose -f docker/docker-compose.yml up -d

# 2. Verify containers are running and healthy
docker ps

## NuGet Packages
# 1. Navigate to Infrastructure and install database dependencies
cd src/backend/Infrastructure
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Pgvector.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design

# 2. Navigate to Api project and install design/runtime dependencies
cd ../Api
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# 3. Return to root
cd ../../..

## Verification & Run Commands
# Start Docker services
docker compose -f docker/docker-compose.yml up -d

# Run the Backend API (from src/backend/Api)
cd src/backend/Api
dotnet run

# Run the Angular Frontend (from src/frontend)
cd src/frontend
npm start


