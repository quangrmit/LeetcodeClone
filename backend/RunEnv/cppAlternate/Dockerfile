# Use an official C++ image
FROM gcc:latest

# Set working directory
WORKDIR /app

# Copy source files
COPY . .

# Compile the program
RUN g++ main.cpp -o app -std=c++11

# Set entrypoint
# ENTRYPOINT ["./app"]
