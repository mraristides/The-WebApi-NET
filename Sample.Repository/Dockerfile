FROM mysql:5.7.35
EXPOSE 3306
COPY ./Sample.Repository/db/migrations /home/database
COPY ./Sample.Repository/db/dataset /home/database
COPY ./Sample.Api/CI/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh