create table accounts (
  id varchar(255) not null primary key,
  account_name varchar(255)
);

create table equipments (
  id varchar(255) not null primary key,
  equipment_type int not null,
  equipment_name varchar(255) not null
);

create table reservations (
  id varchar(255) not null primary key,
  accounts_id varchar(255) not null references accounts(id),
  equipments_id varchar(255) not null references equipments(id),
  start_date_time timestamp not null,
  end_date_time timestamp not null,
  purpose_of_use varchar(255)
);

create table reservations_status (
  reservations_id varchar(255) not null references reservations(id),
  status int not null,
  primary key (reservations_id)
);
