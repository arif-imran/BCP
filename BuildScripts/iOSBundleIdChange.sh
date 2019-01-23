#!/bin/bash

    defaults read $2/BCP/BCP/BCP.iOS/Info CFBundleVersion
       
    buildNumber=$(/usr/libexec/PlistBuddy -c "Print CFBundleVersion" "$2/BCP/BCP/BCP.iOS/Info.plist")
    buildNumber=$(($buildNumber + 1))
/usr/libexec/PlistBuddy -c "Set :CFBundleVersion $buildNumber" "$2/BCP/BCP/BCP.iOS/Info.plist"
defaults read $2/BCP/BCP/BCP.iOS/Info CFBundleVersion

if [ "$1" = "Release_Dev" ]
        then 
        sed -i.bu 's/gasiabcp/dgasiabcp/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu
        sed -i.bu 's/>GAsiaBCP/>BCP_Dev/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu
        
elif [ "$1" = "HA_Dev" ]
        then 
        sed -i.bu 's/gasiabcp/dgasiabcp/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu
        sed -i.bu 's/>GAsiaBCP/>BCP_Dev/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu

elif [ "$1" = "HA_Staging" ]
        then 
        sed -i.bu 's/gasiabcp/sgasiabcp/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu
        sed -i.bu 's/>GAsiaBCP/>BCP_Staging/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu

elif [ "$1" = "Release_Staging" ]
        then
        sed -i.bu 's/gasiabcp/sgasiabcp/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu
        sed -i.bu 's/>GAsiaBCP/>BCP_Staging/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu

elif [ "$1" = "Release_Test" ]
        then
        sed -i.bu 's/gasiabcp/tgasiabcp/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu
        sed -i.bu 's/>GAsiaBCP/>BCP_Staging/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu

elif [ "$1" = "Release_Production" ]
        then
        git checkout -b develop
git add -u
git status
git commit "-m" "commit files"
git remote -v
git push -u origin --all
        sed -i.bu 's/gasiabcp/gasiabcp/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu
        sed -i.bu 's/>GAsiaBCP/>GAsia BCP/g' $2/BCP/BCP/BCP.iOS/Info.plist
        rm $2/BCP/BCP/BCP.iOS/Info.plist.bu
fi