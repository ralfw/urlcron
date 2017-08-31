#!/bin/bash
cp ../src/urlcron/tests/acceptance/urlcron_acceptance.config ../bin/urlcron.config
cd ../bin
mono urlcron.exe http://localhost:8080