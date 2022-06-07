git clone https://github.com/linksplatform/conan-center-index
cd conan-center-index && git checkout only-development && cd recipes
conan create platform.ranges/all platform.ranges/0.1.3@ -pr=linksplatform
