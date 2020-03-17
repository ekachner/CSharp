CREATE TABLE employees

(
employee_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
f_name varchar(20)NOT NULL,
n_intitial CHAR(1) DEFAULT ' ',
l_name VARCHAR(40)NOT NULL,
street VARCHAR(20) NOT NULL,
state CHAR(2) NOT NULL,
country CHAR(20) NOT NULL,
phone VARCHAR(12) NOT NULL,
z_code INT(5) NOT NULL,
ment_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
proj_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
hire_date DATE NOT NULL,
term_date DATE NULL,
	CONSTRAINT employee_pk
		PRIMARY KEY (employee_id)
);

CREATE TABLE apprentice

(
apprentice_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
ment_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
inst_time TIME NOT NULL,
	CONSTRAINT apprentice_pk
		PRIMARY KEY (apprentice_id),
	CONSTRAINT apprentice_fk
		FOREIGN KEY (apprentice_id)
	REFERENCES employees(employee_id)
);

CREATE TABLE projects

(
project_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
street VARCHAR(20) NOT NULL,
state CHAR(2) NOT NULL,
country CHAR(20) NOT NULL,
z_code INT(5) NOT NULL,
email VARCHAR(40) NOT NULL,
emp_id INT UNSIGNED NOT NULL,
start_date DATE NOT NULL,
end_date DATE NULL,
bill_date DATE NOT NULL,
	CONSTRAINT project_pk
		PRIMARY KEY (project_id)
);

CREATE TABLE clients

(
client_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
proj_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
emp_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
street VARCHAR(20) NOT NULL,
state CHAR(2) NOT NULL,
country CHAR(20) NOT NULL,
z_code INT(5) NOT NULL,
email VARCHAR(40) NOT NULL,
start_date DATE NOT NULL,
end_date DATE NOT NULL,
bill_date DATE NOT NULL,
poc_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
proj_state DATE NOT NULL,
	CONSTRAINT client_pk
		PRIMARY KEY (client_id)
);

CREATE TABLE point_of_contact

(
point_of_contact_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
f_name CHAR(20) NOT NULL,
m_initial CHAR(1) NOT NULL,
l_name CHAR(20) NOT NULL,
email VARCHAR(40) NOT NULL,
phone INT(14) NOT NULL,
	CONSTRAINT point_of_contact_pk
		PRIMARY KEY (point_of_contact_id)
);

CREATE TABLE time_entries

(
proj_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
emp_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
appr_date DATE NOT NULL,
start_time TIME NOT NULL,
end_time TIME NOT NULL,
	CONSTRAINT hours_id_pk
		PRIMARY KEY (hours_id)
);
