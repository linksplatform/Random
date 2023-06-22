cmake_minimum_required(VERSION 3.8)

project(Platform.Random)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

# Set compiler flags for x86_64 architecture
if(CMAKE_SYSTEM_PROCESSOR STREQUAL "x86_64")
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -march=haswell")
endif()

# Set compiler flags for armv7 architecture
if(CMAKE_SYSTEM_PROCESSOR STREQUAL "armv7")
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -march=armv7")
endif()

# Set compiler flags for armv8 architecture
if(CMAKE_SYSTEM_PROCESSOR STREQUAL "armv8")
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -march=armv8-a")
endif()

find_package(Platform.Ranges REQUIRED CONFIG)
find_package(GTest REQUIRED)

add_library(${PROJECT_NAME}.Library INTERFACE)
target_include_directories(${PROJECT_NAME}.Library INTERFACE ${PROJECT_NAME})
target_link_libraries(${PROJECT_NAME}.Library INTERFACE Platform.Ranges::Platform.Ranges)

if(${LINKS_PLATFORM_TESTS})
    add_executable(${PROJECT_NAME}.Tests ${PROJECT_NAME}.Tests/AllTests.cpp)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE ${PROJECT_NAME}.Library)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE GTest::gtest)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE GTest::gtest_main)
    set_target_properties(${PROJECT_NAME}.Tests PROPERTIES CXX_STANDARD 20)
endif()
