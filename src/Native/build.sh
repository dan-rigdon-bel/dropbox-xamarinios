#!/bin/bash
set -e

BUILDDIR=build
PROJNAME=DropboxSDK

PROJDIR=dropbox-ios-sdk-1.3.11/$PROJNAME
MTPROJDIR=../$PROJNAME
PROJ=$PROJNAME.xcodeproj
TARGET=S$PROJNAME

function createBuildFoldersForIOS () {

	if test ! -d build
	then
		mkdir build
	fi
	
	#check to make sure the folder was created successfully
	if test ! -d build
	then
		echo "ERROR: Unable to create build folders.  Please make sure you have admin privileges and try again."
		exit 1;
	fi
	
	cd build
	
	if test ! -d Release-ios
	then
		mkdir Release-ios
	fi
	
	#check to make sure the folder was created successfully
	if test ! -d Release-ios
	then
		echo "ERROR: Unable to create build folders.  Please make sure you have admin privileges and try again."
		exit 1;
	fi
	
	cd ..
}

cd $PROJDIR	
createBuildFoldersForIOS
cd ../..

echo ""
echo "iOS Build-------------------------------------------------------"
echo "Making static libDropboxSDK.a for iOS..."
	
#printf " Compiling i386 version                "
# add: > /dev/null  to suppress output on xcodeBuilds
#xcodebuild -project $PROJDIR/$PROJ -target $TARGET -sdk iphonesimulator -arch i386 -configuration Release clean build > /dev/null
#printf "...Done\n";
#cd $PROJDIR/build/Release-iphonesimulator
#mv libSDropboxSDK.a libDropboxSDK-i386.a
#mv libDropboxSDK-i386.a ../Release-ios
#cd ../../../..

printf " Compiling x86_64 version              "
xcodebuild -project $PROJDIR/$PROJ -target $TARGET -sdk iphonesimulator -arch x86_64 -configuration Release clean build > /dev/null
printf "...Done\n";
cd $PROJDIR/build/Release-iphonesimulator
mv libSDropboxSDK.a libDropboxSDK-x86_64.a
mv libDropboxSDK-x86_64.a ../Release-ios
cd ../../../..

printf " Compiling arm64 version               "
xcodebuild -project $PROJDIR/$PROJ -target $TARGET -sdk iphoneos -arch arm64 -configuration Release clean build > /dev/null
printf "...Done\n";
cd $PROJDIR/build/Release-iphoneos
mv libSDropboxSDK.a libDropboxSDK-arm64.a
mv libDropboxSDK-arm64.a ../Release-ios
	
printf " Creating Universal Binary             "
cd ../Release-ios
lipo -create -output libDropboxSDK.a libDropboxSDK-x86_64.a libDropboxSDK-arm64.a
printf "...Done\n";

printf " Copying to binding project            "
cp libDropboxSDK.a ../../../../../DropboxSDK
printf "...Done\n";