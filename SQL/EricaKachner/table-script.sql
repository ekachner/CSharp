USE erica_tracks_time;


CREATE TABLE employees
	(
    emp_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    first_name VARCHAR(20) NOT NULL,
    last_name VARCHAR(20) NOT NULL,
    role VARCHAR(20) NOT NULL, 
    phone CHAR(14),
    email VARCHAR(30) NOT NULL,
    permissions TINYINT(1) NOT NULL,
    CONSTRAINT employees_pk
		PRIMARY KEY(emp_id),
	CONSTRAINT role_check
		CHECK (role IN('Manager', 'Apprentice'))
    );
 

CREATE TABLE managers
	(
    emp_id INT UNSIGNED NOT NULL,
    hire_date DATE NOT NULL,
    term_date DATE,
    CONSTRAINT managers_pk
		PRIMARY KEY (emp_id),
	CONSTRAINT managers_fk
		FOREIGN KEY (emp_id)
			REFERENCES employees(emp_id)
    );
    

CREATE TABLE apprentices
	(
    emp_id INT UNSIGNED NOT NULL,
    man_id INT UNSIGNED NOT NULL,
    instruction_time INT UNSIGNED,
    hire_date DATE NOT NULL,
    term_date DATE,
    CONSTRAINT apprentices_pk
		PRIMARY KEY (emp_id),
	CONSTRAINT apprentices_fk1
		FOREIGN KEY (emp_id)
			REFERENCES employees(emp_id),
	CONSTRAINT apprentices_fk2
		FOREIGN KEY (man_id)
			REFERENCES managers(emp_id)
    );

 
CREATE TABLE employee_projects
	(
    emp_id INT UNSIGNED NOT NULL,
    proj_id INT UNSIGNED NOT NULL,
    CONSTRAINT employee_projects_pk
		PRIMARY KEY (emp_id, proj_id),
	CONSTRAINT employee_projects_fk1
		FOREIGN KEY (emp_id)
			REFERENCES employees(emp_id),
	CONSTRAINT employee_projects_fk2
		FOREIGN KEY (proj_id)
			REFERENCES projects(proj_id)
    );


CREATE TABLE projects
	(
    proj_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    proj_name VARCHAR(40) NOT NULL,
    client_id INT UNSIGNED NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE,
    bill_rate DECIMAL(5, 2) UNSIGNED NOT NULL,
    time_id INT UNSIGNED NOT NULL,
    poc_id INT UNSIGNED,
    CONSTRAINT projects_pk
		PRIMARY KEY(proj_id),
	CONSTRAINT projects_fk1
		FOREIGN KEY (client_id)
			REFERENCES clients(client_id),
	CONSTRAINT projects_fk2
		FOREIGN KEY (time_id)
			REFERENCES time_entries(time_id),
	CONSTRAINT projects_fk3
		FOREIGN KEY (poc_id)
			REFERENCES point_of_contact(poc_id)
    );
    
    
CREATE TABLE clients
	(
	client_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    client_org VARCHAR(40) NOT NULL,
    address_id  VARCHAR(40) NOT NULL,
    CONSTRAINT clients_pk
		PRIMARY KEY (client_id),
	CONSTRAINT clients_fk
		FOREIGN KEY (address_id)
			REFERENCES address(address_id)
    );


CREATE TABLE address
	(
    address_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    street_address VARCHAR(40) NOT NULL,
    city VARCHAR(20) NOT NULL,
    state_initials CHAR(2) NOT NULL,
    zip CHAR(5) NOT NULL,
    CONSTRAINT address_pk
		PRIMARY KEY (address_id),
	CONSTRAINT address_fk
		FOREIGN KEY (state_initials)
			REFERENCES states(state_initials)
    );
    
    
CREATE TABLE states
	(
    state_initials CHAR(2) NOT NULL,
    state_name VARCHAR(20) NOT NULL,
    CONSTRAINT states_pk
		PRIMARY KEY (state_initials)
    );
    
    
CREATE TABLE point_of_contact
	(
    poc_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    first_name VARCHAR(20) NOT NULL,
    last_name VARCHAR(20) NOT NULL,
    email VARCHAR(30) NOT NULL,
    phone CHAR(14),
    client_id INT UNSIGNED NOT NULL,
    CONSTRAINT point_of_contact_pk
		PRIMARY KEY (poc_id),
	CONSTRAINT point_of_contact_fk
		FOREIGN KEY (client_id)
			REFERENCES clients(client_id)
    );


CREATE TABLE time_entries
	(
	time_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    emp_id INT UNSIGNED NOT NULL,
    start_time TIMESTAMP NOT NULL,
    end_time TIMESTAMP,
    entry_type VARCHAR(20) NOT NULL,
    CONSTRAINT time_entries_pk
		PRIMARY KEY (time_id),
	CONSTRAINT time_entries_fk
		FOREIGN KEY (emp_id)
			REFERENCES employees(emp_id),
	CONSTRAINT entry_type_check
		CHECK (entry_type IN ('Instructional', 'Project'))
    );
