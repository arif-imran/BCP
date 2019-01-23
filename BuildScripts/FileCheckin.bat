set configuration=%1

IF "%configuration%"== "Release_Production" (
git checkout -b develop
git add -u
git status
git commit "-m" "commit files"
git remote -v
git pull
git push -u origin --all
)