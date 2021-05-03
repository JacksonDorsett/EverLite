#!/bin/bash
echo "enter commit message: "
read message

git add -A
git commit -m "$message"
git push
./updateScript.sh
