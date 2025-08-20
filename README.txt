**Docker**
postgre
docker run -d --name my-postgres-db -p 5432:5432 -e POSTGRES_PASSWORD=mysecretpassword -v /path/on/host/data:/var/lib/postgresql/data postgres
RabbitMQ
docker run -d --name my-rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management


**** Migrations ****

Update-database

para criação das tabelas

