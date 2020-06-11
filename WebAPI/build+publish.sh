#!/bin/bash

if [ $EUID -ne 0 ]
then
	printf "ERROR:\tThis script must be run as priviledged user...\nExiting...\n"
	exit 1
fi

sudo dotnet build
sudo dotnet publish --output /var/dotnet/WebAPI/
sudo systemctl restart apache2.service supervisor.service

