FROM registry.travco.co.uk/aspnet-grunt-docker:1.0.0-rc1

ENV MICRO_SERVICE Travco.Hotel

WORKDIR /

COPY src/ app/
COPY dnx_daemon.sh app/$MICRO_SERVICE/

WORKDIR /app

RUN dnu restore -s http://tfs.travco.co.uk:3279/nuget/Packages --no-cache

WORKDIR /app/$MICRO_SERVICE

# RUN dnu build

RUN npm install

RUN apt-get install -y procps
RUN chmod a+x dnx_daemon.sh

EXPOSE 5000 5001

ENTRYPOINT  ["./dnx_daemon.sh"]
CMD ["Development"]