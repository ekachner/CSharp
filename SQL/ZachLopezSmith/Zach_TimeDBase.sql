CREATE SCHEMA zach_time_entry;
USE zach_time_entry;

CREATE TABLE employees
	(
    emp_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    fname VARCHAR(40) NOT NULL,
    lname VARCHAR(40) NOT NULL,
    title VARCHAR(20) NOT NULL,
    emp_status VARCHAR(15) NOT NULL,
    phone CHAR(12) NOT NULL,
    email VARCHAR(40) NULL,
    gender CHAR(1) NOT NULL,
    hire_date DATE NOT NULL,
    end_date DATE NULL,
    CONSTRAINT employees_pk
		PRIMARY KEY(emp_id)
    );
    
    
CREATE TABLE projects
	(
    proj_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    client_id INT UNSIGNED NOT NULL,
    emp_id INT UNSIGNED NOT NULL,
    poc_id INT UNSIGNED NOT NULL,
    proj_name VARCHAR(40) NOT NULL,
    start_date DATE NOT NULL,
	end_date DATE NULL,
    bill_rate INT NOT NULL,
    CONSTRAINT projects_pk
		PRIMARY KEY(proj_id),
	CONSTRAINT projects_fk1
		FOREIGN KEY(client_id)
			REFERENCES clients(client_id),
	CONSTRAINT projects_fk2
		FOREIGN KEY(emp_id)
			REFERENCES employees(emp_id),
	CONSTRAINT projects_fk3
		FOREIGN KEY(poc_id)
			REFERENCES point_of_contact(poc_id)
    );
    
    
CREATE TABLE clients
	(
    client_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    poc_id INT UNSIGNED NOT NULL,
    client_name VARCHAR(40) NOT NULL,
    street VARCHAR(40) NOT NULL,
    city VARCHAR(30) NOT NULL,
    state CHAR(2) NOT NULL,
    zip CHAR(5) NOT NULL,
    CONSTRAINT clients_pk
		PRIMARY KEY(client_id),
	CONSTRAINT clients_fk
		FOREIGN KEY(poc_id)
			REFERENCES point_of_contact(poc_id)
	);
    
    
CREATE TABLE time_entries
	(
	time_entry_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
	emp_id INT UNSIGNED NOT NULL,
	proj_id INT UNSIGNED NOT NULL,
	start_date DATETIME NULL,
	end_date DATETIME NULL,
	approved_date DATETIME NULL,
	time_types VARCHAR(20) NOT NULL,
	CONSTRAINT time_entries_pk
		PRIMARY KEY(time_entry_id),
	CONSTRAINT time_entries_fk1
		FOREIGN KEY(emp_id)
			REFERENCES employees(emp_id),
	CONSTRAINT time_entries_fk2
		FOREIGN KEY(proj_id)
			REFERENCES projects(proj_id)
	);
        
        
CREATE TABLE point_of_contact
	(
    poc_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    proj_id INT UNSIGNED NOT NULL,
    client_id INT UNSIGNED NOT NULL,
    fname VARCHAR(40) NOT NULL,
    lname VARCHAR(40) NOT NULL,
    email VARCHAR(40) NOT NULL,
    phone CHAR(12) NOT NULL,
    CONSTRAINT point_of_contact_pk
		PRIMARY KEY(poc_id)
	);
    

CREATE TABLE apprentices
	(
    appr_id INT UNSIGNED NOT NULL,
    man_id INT UNSIGNED NOT NULL,
    inst_time TIME NULL,
    CONSTRAINT apprentices_pk
		PRIMARY KEY(appr_id),
	CONSTRAINT apprentices_fk1
		FOREIGN KEY(appr_id)
			REFERENCES employees(emp_id),
	CONSTRAINT apprentices_fk2
		FOREIGN KEY(man_id)
			REFERENCES employees(emp_id)
	);
    

CREATE TABLE employees_projects
	(
    emp_id INT UNSIGNED NOT NULL,
    proj_id INT UNSIGNED NOT NULL,
    CONSTRAINT employees_projects_pk
		PRIMARY KEY(emp_id, proj_id),
	CONSTRAINT employees_projects_fk1
		FOREIGN KEY(emp_id)
			REFERENCES employees(emp_id),
	CONSTRAINT employees_projects_fk2
		FOREIGN KEY(proj_id)
			REFERENCES projects(proj_id)
	);
    
    
CREATE TABLE time_type
	(
	entry_type VARCHAR(20) NOT NULL,
	CONSTRAINT time_type_pk
		PRIMARY KEY(entry_type)
	);


CREATE TABLE state
	(
    state_abbr CHAR(2) NOT NULL,
    state_name VARCHAR(20) NULL,
    CONSTRAINT state_pk
		PRIMARY KEY(state_abbr)
	);
    
    
    
ALTER TABLE time_entries
	ADD CONSTRAINT time_entries_fk3
		FOREIGN KEY (time_types)
			REFERENCES time_type(entry_type);    