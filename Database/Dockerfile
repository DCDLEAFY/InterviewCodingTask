From mysql:8.0.30

# User is root and root_password is password
ENV MYSQL_ROOT_PASSWORD=password

# Add the setup sql file to create table
ADD db_setup.sql /docker-entrypoint-initdb.d

EXPOSE 3306:3306