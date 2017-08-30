#!/bin/sh
cp .dropstack.json ../bin
cp Dockerfile ../bin
cd ../bin

dropstack deploy --verbose

cp .dropstack.json ../deploy