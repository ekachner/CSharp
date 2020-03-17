CREATE DATABASE brett_apprenticeship;

USE brett_apprenticeship;

CREATE TABLE employees
	(
	employee_id INT2 UNSIGNED AUTO_INCREMENT NOT NULL,
    first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
    role ENUM('Designer', 'Developer') NOT NULL,
    emp_status ENUM('Fired', 'Apprentice', 'Completed Program', 'Mentor') NOT NULL,
    end_date DATETIME,
    start_date DATETIME NOT NULL,
    hourly_rate INT1 NOT NULL DEFAULT 15,
	phone_number INT3(10) UNSIGNED ZEROFILL NOT NULL, 
	email VARCHAR(95) NOT NULL,
    
    CONSTRAINT employee_pk
		PRIMARY KEY(employee_id)
    );
    
    CREATE TABLE apprentices
		(
        apprentice_id INT2 UNSIGNED NOT NULL,
        mentor_id INT2 UNSIGNED NOT NULL,
        instructional_time INT1 UNSIGNED NOT NULL DEFAULT 0,
        
        CONSTRAINT apprentice_pk
			PRIMARY KEY(apprentice_id),
        CONSTRAINT apprentice_fk1
			FOREIGN KEY(apprentice_id)
            REFERENCES employees(employee_id),
		CONSTRAINT apprentice_fk2
			FOREIGN KEY(mentor_id)
            REFERENCES employees(employee_id)
        );


CREATE TABLE states
	(
    state_id INT2 UNSIGNED AUTO_INCREMENT NOT NULL,
    state_initials CHAR(2) NOT NULL,
    
    CONSTRAINT states_pk
		PRIMARY KEY(state_id)
	);
    
        
CREATE TABLE clients
	(
	client_id INT2 UNSIGNED AUTO_INCREMENT NOT NULL,
	state_id INT1 UNSIGNED NOT NULL,
	city VARCHAR(35) NOT NULL,
	street VARCHAR(95) NOT NULL,
	zip INT3(10) UNSIGNED ZEROFILL, 
	
    CONSTRAINT clients_pk
		PRIMARY KEY(client_id)
	);
    
    
CREATE TABLE pocs
	(
	poc_id INT2 UNSIGNED AUTO_INCREMENT NOT NULL,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	email VARCHAR(95) NOT NULL,
	phone_number INT3(10) UNSIGNED ZEROFILL NOT NULL, 
	
    CONSTRAINT poc_pk
		PRIMARY KEY(poc_id)
	);
    
    
CREATE TABLE projects
	(
	project_id INT2 UNSIGNED AUTO_INCREMENT UNIQUE NOT NULL,
    client_id INT2 UNSIGNED NOT NULL,
    poc_id INT2 UNSIGNED NOT NULL,
    project_hours DECIMAL UNSIGNED DEFAULT 0,
	start_date DATETIME NOT NULL,
    end_date DATETIME,
    billing_rate DECIMAL NOT NULL,
    project_name VARCHAR(35) NOT NULL,
    project_status ENUM('Pending', 'Ongoing', 'Completed', 'Cancelled') DEFAULT 'Pending',
    
    
    CONSTRAINT projects_pk
		PRIMARY KEY(project_id),
	CONSTRAINT projects_fk1
		FOREIGN KEY(client_id)
        REFERENCES clients(client_id),
	CONSTRAINT projects_fk2
		FOREIGN KEY(poc_id)
        REFERENCES pocs(poc_id)
    );
    
    
CREATE TABLE employee_projects
	(
    employee_id INT2 UNSIGNED NOT NULL,
    project_id INT2 UNSIGNED NOT NULL,
    
    CONSTRAINT employee_projects_pk
		PRIMARY KEY(employee_id, project_id),
	CONSTRAINT employee_projects_fk1
		FOREIGN KEY(employee_id)
		REFERENCES employees(employee_id),
	CONSTRAINT employee_projects_fk2
		FOREIGN KEY(project_id)
		REFERENCES projects(project_id)
    );
    

CREATE TABLE time_entries
	(
    project_id INT2 UNSIGNED NOT NULL,
    apprentice_id INT2 UNSIGNED NOT NULL,
    mentor_id INT2 UNSIGNED NOT NULL,
    start_date DATETIME NOT NULL,
    end_date DATETIME NOT NULL,
    verification_date DATETIME,
    CONSTRAINT time_entries_ck
		PRIMARY KEY(project_id, apprentice_id, mentor_id),
    CONSTRAINT time_entries_fk1
		FOREIGN KEY(mentor_id)
        REFERENCES employees(employee_id),
	CONSTRAINT time_entries_fk2
		FOREIGN KEY(apprentice_id)
        REFERENCES employees(employee_id),
	CONSTRAINT time_entries_fk3
		FOREIGN KEY(project_id)
        REFERENCES projects(project_id)
    );
    



    