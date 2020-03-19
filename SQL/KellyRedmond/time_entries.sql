CREATE SCHEMA hour_tracker;

USE hour_tracker;

CREATE TABLE user_type
	(
    user_type VARCHAR(16) NOT NULL,
    CONSTRAINT user_type_pk
		PRIMARY KEY(user_type)
    );

CREATE TABLE users
	(
    user_id INT UNSIGNED AUTO_INCREMENT,
    fname VARCHAR(40) NOT NULL,
    lname VARCHAR(40) NOT NULL,
    phone CHAR(12) NOT NULL,
    email VARCHAR(75) NOT NULL,
    pass VARCHAR(255) NOT NULL,
    user_type VARCHAR(16) NOT NULL,
    CONSTRAINT users_pk
		PRIMARY KEY(user_id),
	CONSTRAINT users_fk_1
		FOREIGN KEY(user_type)
			REFERENCES user_type(user_type)
	);
    
CREATE TABLE gender
	(
    gender VARCHAR(10),
    CONSTRAINT gender_pk
		PRIMARY KEY(gender)
    );
    
CREATE TABLE role
	(
    role VARCHAR(10),
    CONSTRAINT role_pk
		PRIMARY KEY(role)
    );
    
CREATE TABLE state
	(
    state CHAR(2),
    CONSTRAINT state_pk
		PRIMARY KEY(state)
    );

CREATE TABLE employees
	(
    emp_id INT UNSIGNED AUTO_INCREMENT,
    user_id INT UNSIGNED NOT NULL UNIQUE,
    street_address VARCHAR(75) NOT NULL,
    city VARCHAR(30) NOT NULL,
    state CHAR(2) NOT NULL,
    zip_code CHAR (5) NOT NULL,
    hire_date DATE NOT NULL,
    gender VARCHAR(10) NOT NULL,
    role VARCHAR(10) NOT NULL,
    CONSTRAINT employees_pk
		PRIMARY KEY(emp_id),
	CONSTRAINT employees_fk_1
		FOREIGN KEY(user_id)
			REFERENCES users(user_id),
	CONSTRAINT employees_fk_2
		FOREIGN KEY(state)
			REFERENCES state(state)
				ON UPDATE CASCADE,
	CONSTRAINT employees_fk_3
		FOREIGN KEY(gender)
			REFERENCES gender(gender)
				ON UPDATE CASCADE,
	CONSTRAINT employees_fk_4
		FOREIGN KEY(role)
			REFERENCES role(role)
				ON UPDATE CASCADE
    );
    
CREATE TABLE apprentices
	(
    emp_id INT UNSIGNED NOT NULL,
    man_id INT UNSIGNED NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE,
    instructional_time SMALLINT UNSIGNED DEFAULT 0,
    CONSTRAINT apprentices_pk
		PRIMARY KEY(emp_id),
	CONSTRAINT apprentices_fk_1
		FOREIGN KEY(emp_id)
			REFERENCES employees(emp_id),
	CONSTRAINT apprentices_fk_2
		FOREIGN KEY(man_id)
			REFERENCES employees(emp_id)
    );
    

CREATE TABLE companies
	(
    comp_id INT UNSIGNED AUTO_INCREMENT,
    comp_name VARCHAR(70) UNIQUE NOT NULL,
    street_address VARCHAR(100),
    city VARCHAR(50) NOT NULL,
    state CHAR(2) NOT NULL,
    zip_code CHAR(5),
    CONSTRAINT companies_pk
		PRIMARY KEY(comp_id),
	CONSTRAINT companies_fk_1
		FOREIGN KEY(state)
			REFERENCES state(state)
				ON UPDATE CASCADE
    );

CREATE TABLE point_of_contact
	(
    user_id INT UNSIGNED NOT NULL,
    comp_id INT UNSIGNED NOT NULL,
    CONSTRAINT point_of_contact_pk
		PRIMARY KEY(user_id),
	CONSTRAINT point_of_contact_fk_1
		FOREIGN KEY(user_id)
			REFERENCES users(user_id),
	CONSTRAINT point_of_contact_fk_2
		FOREIGN KEY(comp_id)
			REFERENCES companies(comp_id)
    );
    
CREATE TABLE projects
	(
    proj_id INT UNSIGNED AUTO_INCREMENT,
    proj_name VARCHAR(70) UNIQUE NOT NULL,
    comp_id INT UNSIGNED NOT NULL,
    start_date DATE,
    end_date DATE,
    bill_rate SMALLINT UNSIGNED DEFAULT 0,
    projected_hours SMALLINT UNSIGNED DEFAULT 0,
    CONSTRAINT projects_pk
		PRIMARY KEY(proj_id),
	CONSTRAINT projects_fk_1
		FOREIGN KEY(comp_id)
			REFERENCES companies(comp_id)
    );
    
CREATE TABLE time_type
	(
    time_type VARCHAR(13),
    CONSTRAINT time_type_pk
		PRIMARY KEY(time_type)
    );
    
CREATE TABLE time_entry
	(
    time_id INT UNSIGNED AUTO_INCREMENT,
    emp_id INT UNSIGNED NOT NULL,
    proj_id INT UNSIGNED NOT NULL,
    time_start DATETIME NOT NULL,
    time_end DATETIME NOT NULL,
    time_type VARCHAR(13) NOT NULL,
    approved_date DATETIME,
    CONSTRAINT time_entry_pk
		PRIMARY KEY(time_id),
	CONSTRAINT time_entry_fk_1
		FOREIGN KEY(emp_id)
			REFERENCES employees(emp_id),
	CONSTRAINT time_entry_fk_2
		FOREIGN KEY(proj_id)
			REFERENCES projects(proj_id),
	CONSTRAINT time_entry_fk_3
		FOREIGN KEY(time_type)
			REFERENCES time_type(time_type),
	CONSTRAINT time_entry_constraint UNIQUE(emp_id, time_start, time_end)
    );
    
CREATE TABLE projects_employees
	(
    emp_id INT UNSIGNED NOT NULL,
    proj_id INT UNSIGNED NOT NULL,
    CONSTRAINT projects_employees_pk
		PRIMARY KEY(emp_id, proj_id),
	CONSTRAINT projects_employees_fk_1
		FOREIGN KEY(emp_id)
			REFERENCES employees(emp_id),
	CONSTRAINT projects_employees_fk_2
		FOREIGN KEY(proj_id)
			REFERENCES projects(proj_id)
    );
    
CREATE TABLE projects_poc
	(
    user_id INT UNSIGNED NOT NULL,
    proj_id INT UNSIGNED NOT NULL,
	CONSTRAINT projects_poc_pk
		PRIMARY KEY(user_id, proj_id),
	CONSTRAINT projects_poc_fk_1
		FOREIGN KEY(user_id)
			REFERENCES users(user_id),
	CONSTRAINT projects_poc_fk_2
		FOREIGN KEY(proj_id)
			REFERENCES projects(proj_id)
    );