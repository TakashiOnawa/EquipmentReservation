drop database if exists EquipmentReservation;
go

create database EquipmentReservation;
go

use EquipmentReservation;
go

create table accounts (
  id varchar(255) not null primary key,
  account_name nvarchar(255) not null
);
go

create table equipments (
  id varchar(255) not null primary key,
  equipment_type int not null,
  equipment_name nvarchar(255) not null
);
go

create table reservations (
  id varchar(255) not null primary key,
  accounts_id varchar(255) not null references accounts(id),
  equipments_id varchar(255) not null references equipments(id),
  start_date_time datetime not null,
  end_date_time datetime not null,
  purpose_of_use nvarchar(255)
);
go
