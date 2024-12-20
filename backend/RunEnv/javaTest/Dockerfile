# FROM mcr.microsoft.com/devcontainers/java:1-21-bullseye
FROM maven:3.8.7-eclipse-temurin-17




# Define default command.
# CMD ["mvn", "--version"]

WORKDIR /usr/src/app

COPY . .

# CMD ["mvn", "compile"]
RUN mvn compile
CMD ["mvn", "exec:java", "-Dexec.mainClass=com.example.app.App"]
