# docker/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
EXPOSE 80

# Create a script to run the project with the correct path
RUN echo '#!/bin/bash\n\
PROJECT_FILE=${PROJECT_PATH:-$(find /app -name "*.csproj" -type f -print -quit)}\n\
\n\
if [ -z "$PROJECT_FILE" ]; then\n\
    echo "No .csproj file found in /app directory"\n\
    exit 1\n\
fi\n\
\n\
echo "Starting project: $PROJECT_FILE"\n\
dotnet watch run --project "$PROJECT_FILE" --urls "http://0.0.0.0:80"\n\
' > /entrypoint.sh && chmod +x /entrypoint.sh

ENTRYPOINT ["/entrypoint.sh"]
