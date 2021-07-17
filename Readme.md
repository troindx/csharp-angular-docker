## Quickstart Instructions ##
Step 1 - clone this repository into your local machines. To develop , you will need
- Dotnet core installed in your machine => https://dotnet.microsoft.com/download
- npm (node packet manager) with Node installed => https://nodejs.org/es/
- Docker (for containers)

Step 2 - navigate with your cli / terminal to Translator folder and run "dotnet restore"
Step 3 - navigate with your cli / terminal to frontend folder and run "npm install"

## Developing from your local machine
- For backend, in Translator folder, execute "dotnet run"
- For frontend, in fontend folder, execute "ionic serve"

## Optional - Generating Developer HTTPS certs (currently only using HTTP)
To generate a developer certificate run 'dotnet dev-certs https'. To trust the certificate (Windows and macOS only) run 'dotnet dev-certs https --trust'

## Running system in docker containers
- from this main folder, run docker-compose up (or docker compose up).
- Attention to older docker versions. If you are not running Docker desktop but are using docker-toolbox, you may have to edit the connection settings. You can find them in
frontend/src/environment
Translator/appsetings.json

## Testing the system
Integration tests have been designed using NPM junit. To run the tests, the system must be running in Docker containers (even though running them in local should also work).
In your cli, navigate to Tests folder and execute "npm install" followed by "npm test".
