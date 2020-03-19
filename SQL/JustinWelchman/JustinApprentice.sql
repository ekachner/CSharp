use justin_apprenticeship;

-- employees table
create table employees
(
	emp_id int unsigned not null auto_increment,
    fname varchar(20) not null,
    lname varchar(40) not null,
    title varchar(40) not null,
    phone char(12) not null,
    email varchar(40) not null,
    constraint emp_pk
		primary key(emp_id)
);

-- apprentices table
create table apprentices
(
	emp_id int unsigned not null auto_increment,
    fname varchar(20) not null,
    lname varchar(40) not null,
    title varchar(40) not null,
	phone char(12) not null,
    email varchar(40) not null,
    mentor varchar(40) not null,
    constraint emp_pk
		primary key(emp_id)
);

-- managers table
create table managers
(
	emp_id int unsigned not null auto_increment,
    fname varchar(20) not null,
    lname varchar(40) not null,
    title varchar(40) not null,
	phone char(12) not null,
    email varchar(40) not null,
    constraint emp_pk
		primary key(emp_id)
);

-- projects table
create table projects
(
	proj_id int unsigned not null auto_increment,
    client_id int unsigned not null,
    emp_id int unsigned not null,
    poc_id int unsigned not null,
    proj_name varchar(20) not null,
    in_progress varchar(15) not null,
    start_date date not null,
    end_date date not null,
    bill_rate int(11) not null,
    constraint proj_pk
		primary key(proj_id),
        foreign key(emp_id) references employees(emp_id),
        foreign key(poc_id) references point_of_contact(poc_id)
);

-- clients table
create table clients
(
	client_id int unsigned not null auto_increment,
    client_name varchar(40) not null,
    street varchar(40) not null,
    city varchar(40) not null,
    state varchar(40) not null,
    zip int(5) not null,
    constraint client_pk
		primary key(client_id)
);

-- time entries table
create table time_entries
(
	time_id int unsigned not null auto_increment,
    emp_id int unsigned not null,
    proj_id int unsigned not null,
    start_time datetime,
    end_time datetime,
    apprentice_date date,
    constraint time_pk
		primary key(time_id),
        foreign key(emp_id) references employees(emp_id),
        foreign key(proj_id) references projects(proj_id)
);

-- point of contact table
create table point_of_contact
(
	poc_id int unsigned not null auto_increment,
	fname varchar(20) not null,
    lname varchar(40) not null,
    phone char(12) not null,
    email varchar(40) not null,
    constraint poc_pk
		primary key(poc_id)
);