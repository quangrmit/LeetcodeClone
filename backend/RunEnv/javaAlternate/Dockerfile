FROM openjdk:latest

WORKDIR /usr/src/app

COPY . .

RUN javac *.java

ENTRYPOINT [ "java", "App" ]