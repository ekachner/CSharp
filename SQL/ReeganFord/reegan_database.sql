USE reegan_db;

CREATE TABLE state
(
state CHAR (2) NOT NULL,

CONSTRAINT state_pk
	PRIMARY KEY (state)
);

CREATE TABLE emp_type
(
emp_type VARCHAR (10) NOT NULL,

CONSTRAINT emp_type_pk
	PRIMARY KEY (emp_type)
);

INSERT INTO emp_type (emp_type)
	VALUES ('Apprentice'),('Manager');


CREATE TABLE employees
(
emp_id INT UNSIGNED AUTO_INCREMENT NOT NULL,
fname VARCHAR (40) NOT NULL,
lname VARCHAR (40) NOT NULL,
gender ENUM ('M', 'F'),
phone CHAR(14) NOT NULL,
email VARCHAR(75) NOT NULL,
street VARCHAR(75) NOT NULL,
city VARCHAR(40) NOT NULL,
zip INT (5) NOT NULL,
emp_type VARCHAR (10) NOT NULL,
state CHAR (2) NOT NULL,

CONSTRAINT employees_pk
	PRIMARY KEY (emp_id),
CONSTRAINT employees_fk1
	FOREIGN KEY (emp_type)
		REFERENCES emp_type(emp_type),
CONSTRAINT employees_fk2
	FOREIGN KEY (state)
		REFERENCES state(state)
);

CREATE TABLE managers 
(
manager_id INT UNSIGNED AUTO_INCREMENT NOT NULL,
hire_date DATE NOT NULL,
to_date DATE,

CONSTRAINT managers_pk
	PRIMARY KEY (manager_id),
CONSTRAINT managers_fk
	FOREIGN KEY (manager_id)
		REFERENCES employees(emp_id)
);

CREATE TABLE apprentices
(
app_id INT UNSIGNED AUTO_INCREMENT NOT NULL,
manager_id INT UNSIGNED NOT NULL,
instruction_hrs DECIMAL (4, 2) UNSIGNED DEFAULT 0,
hire_date DATE NOT NULL,
to_date DATE,

CONSTRAINT apprentices_pk
	PRIMARY KEY (app_id),
CONSTRAINT apprentices_fk1
	FOREIGN KEY (app_id)
		REFERENCES employees(emp_id),
CONSTRAINT apprentices_fk2
	FOREIGN KEY (manager_id)
		REFERENCES managers(manager_id)
);

CREATE TABLE companies
(
comp_id INT UNSIGNED AUTO_INCREMENT NOT NULL,
comp_name VARCHAR (40) NOT NULL,
street VARCHAR(75) NOT NULL,
city VARCHAR(40) NOT NULL,
state CHAR (2) NOT NULL,
zip INT (5) NOT NULL,

CONSTRAINT companies_pk
	PRIMARY KEY (comp_id),
CONSTRAINT companies_fk
	FOREIGN KEY (state)
		REFERENCES state(state)
);

CREATE TABLE point_of_contact
(
poc_id INT UNSIGNED AUTO_INCREMENT NOT NULL,
comp_id INT UNSIGNED NOT NULL,
fname VARCHAR (40) NOT NULL,
lname VARCHAR (40) NOT NULL,
phone CHAR (14) NOT NULL,
email VARCHAR (75) NOT NULL,

CONSTRAINT point_of_contact_pk
	PRIMARY KEY (poc_id),
CONSTRAINT point_of_contact_fk
	FOREIGN KEY (comp_id)
		REFERENCES companies(comp_id)
);

CREATE TABLE projects
(
proj_id INT UNSIGNED AUTO_INCREMENT NOT NULL,
comp_id INT UNSIGNED NOT NULL,
proj_name VARCHAR(40) NOT NULL,
est_hrs DECIMAL (5, 2) UNSIGNED,
bill_rate SMALLINT UNSIGNED,
start_date DATE NOT NULL,
end_date DATE,

CONSTRAINT projects_pk
	PRIMARY KEY (proj_id),
CONSTRAINT projects_fk
	FOREIGN KEY (comp_id)
		REFERENCES companies(comp_id)
);

CREATE TABLE poc_project
(
poc_id INT UNSIGNED NOT NULL,
proj_id INT UNSIGNED NOT NULL,

CONSTRAINT poc_project_pk
	PRIMARY KEY (poc_id, proj_id),
CONSTRAINT poc_project_fk1
	FOREIGN KEY (poc_id)
		REFERENCES point_of_contact(poc_id),
CONSTRAINT poc_project_fk2
	FOREIGN KEY (proj_id)
		REFERENCES projects(proj_id)
);

CREATE TABLE emp_project
(
emp_id INT UNSIGNED NOT NULL,
proj_id INT UNSIGNED NOT NULL,

CONSTRAINT emp_project_pk
	PRIMARY KEY (emp_id, proj_id),
CONSTRAINT emp_project_fk1
	FOREIGN KEY (emp_id)
		REFERENCES employees(emp_id),
CONSTRAINT emp_project_fk2
	FOREIGN KEY (proj_id)
		REFERENCES projects(proj_id)
);

CREATE TABLE time_entries
(
timestamp_id INT UNSIGNED AUTO_INCREMENT NOT NULL,
emp_id INT UNSIGNED NOT NULL,
start_time DATETIME NOT NULL,
end_time DATETIME,
approval_date DATETIME,
entry_type ENUM ('Instructional', 'Work'),

CONSTRAINT timestamp_id_pk
	PRIMARY KEY (timestamp_id),
CONSTRAINT timestamp_id_fk
	FOREIGN KEY (emp_id)
		REFERENCES employees(emp_id)
);
