CMAKE_MINIMUM_REQUIRED(VERSION 3.19)

set(VCPKG_FEATURE_FLAGS manifests)
set(VCPKG_OVERLAY_PORTS ${CMAKE_CURRENT_LIST_DIR}/ports)

set(PROJECT_NAME Platform.Random)
project(${PROJECT_NAME})

add_subdirectory(${PROJECT_NAME})

macro(INCLUDE_EXTENSION EXT_NAME)
    add_subdirectory(${PROJECT_NAME}.${EXT_NAME})
    target_link_libraries(${PROJECT_NAME}.${EXT_NAME} PUBLIC ${PROJECT_NAME}.Library)
endmacro()

INCLUDE_EXTENSION(Tests)
