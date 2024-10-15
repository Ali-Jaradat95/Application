#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 44f45d9f-0a3a-4dcf-b016-abfc70d01cfe -t
    fi
    cd ../
fi

docker-compose up -d
