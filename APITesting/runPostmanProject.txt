@echo off

cd "APITesting"

newman run "Music Shop.postman_collection.json" -e "MusicShop.postman_environment.json" --insecure --reporters=cli,htmlextra

echo Postman collection execution completed.