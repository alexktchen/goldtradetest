-- drop the existing database
drop database mydb;

-- create the test user
create user test password 'test';

-- create the database
create database mydb owner test;
