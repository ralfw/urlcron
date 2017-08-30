FROM mono
WORKDIR /dropstack
ADD . .
EXPOSE 80
ENTRYPOINT mono urlcron.exe http://localhost:80