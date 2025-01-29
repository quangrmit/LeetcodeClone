FROM mcr.microsoft.com/devcontainers/cpp:1-debian-12

ARG REINSTALL_CMAKE_VERSION_FROM_SOURCE="none"

WORKDIR /usr/src/app
COPY . .
# Optionally install the cmake for vcpkg
COPY ./reinstall-cmake.sh /tmp/


RUN if [ "${REINSTALL_CMAKE_VERSION_FROM_SOURCE}" != "none" ]; then \
        chmod +x /tmp/reinstall-cmake.sh && /tmp/reinstall-cmake.sh ${REINSTALL_CMAKE_VERSION_FROM_SOURCE}; \
    fi \
    && rm -f /tmp/reinstall-cmake.sh

# [Optional] Uncomment this section to install additional vcpkg ports.

# RUN su vscode -c "${VCPKG_ROOT}/vcpkg install nlohmann-json"

# [Optional] Uncomment this section to install additional packages.
# RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
#     && apt-get -y install --no-install-recommends <your-package-list-here>
# WORKDIR /app
RUN mkdir -p build && cd build
COPY ./res.json .
RUN cmake -DCMAKE_TOOLCHAIN_FILE=/usr/local/vcpkg/scripts/buildsystems/vcpkg.cmake .
RUN make 
CMD [ "./my_program" ]
ENTRYPOINT ["./my_program"]