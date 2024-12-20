cmake_minimum_required(VERSION 3.10)
project(MyProject)

set(CMAKE_CXX_STANDARD 11)

# -DCMAKE_TOOLCHAIN_FILE=/usr/local/vcpkg/scripts/buildsystems/vcpkg.cmake

# Add executable and its source files

set(CMAKE_TOOLCHAIN_FILE "/usr/local/vcpkg/scripts/buildsystems/vcpkg.cmake" CACHE STRING "Vcpkg toolchain file")


set(CMAKE_PREFIX_PATH "/usr/local/vcpkg/packages/nlohmann-json_x64-linux")

find_package(nlohmann_json REQUIRED)


# set(CMAKE_PREFIX_PATH "/usr/local/vcpkg/packages/ponder_x64-linux")
# find_package(ponder REQUIRED)

add_executable(my_program main.cpp)

target_link_libraries(my_program nlohmann_json::nlohmann_json)
# target_link_libraries(my_program ponder::ponder)
