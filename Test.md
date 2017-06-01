# JRTP Compile

> use Gyp to manage Jrtp project. Jrtp project generate by cmake, however i want use gyp to manage this project, so i use cmake to generate a windows project firstly and get some header file, then use the duilb vcbuild framework to generate jrtp project.

## Use Cmake To Generate jrtp project

> Install Cmake, and set source directory path and build directory, generate jrtp project. When the project generate finished we get some headers, in jthread we get:jthreadconfig.h,and jrtp we get :rtptypes.h,rtplibraryversioninternal.h,rtpconfig.h.

## Write Gyp File

> The Jrtp project not contains jthread, and jrtp will use static lib of jthread. I don't want add another project which build jthread, so i merge the jthread project into jtrp project. Such file As I check in are refer to jthread build and cmake generate. 


## Build Project

> cd to project and run vcbuild.bat.
