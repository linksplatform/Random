cmake_minimum_required(VERSION 3.8)

project(Platform.Random)
include(${CMAKE_BINARY_DIR}/conanbuildinfo.cmake)
conan_basic_setup(TARGETS)

add_library(${PROJECT_NAME}.Library INTERFACE)
target_include_directories(${PROJECT_NAME}.Library INTERFACE ${PROJECT_NAME})
target_link_libraries(${PROJECT_NAME}.Library INTERFACE CONAN_PKG::platform.ranges)

if((DEFINED LINKS_PLATFORM_TESTS) AND (${LINKS_PLATFORM_TESTS}))
    add_executable(${PROJECT_NAME}.Tests ${PROJECT_NAME}.Tests/AllTests.cpp)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE ${PROJECT_NAME}.Library)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE CONAN_PKG::gtest)
    set_target_properties(${PROJECT_NAME}.Tests PROPERTIES CXX_STANDARD 20)
endif()
