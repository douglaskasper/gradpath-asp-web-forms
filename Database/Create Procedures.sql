DROP PROCEDURE IF EXISTS account_create;
DELIMITER $$
CREATE PROCEDURE account_create (
    IN in_username VARCHAR(50),
    IN in_password VARCHAR(50),
    IN in_first_name VARCHAR(50),
    IN in_last_name VARCHAR(50),
    IN in_role VARCHAR(10)
	)
BEGIN
	INSERT INTO `csc394group5`.`account` (
		`username`,
		`password`,
		`first_name`,
		`last_name`,
		`role`)
	VALUES (
		'dkasper879@gmail,com',
		SHA('password'),
		'Doug',
		'Kasper',
		'STUDENT'
		);
	
    SELECT	`id` AS acc_id,
			`username` AS acc_username,
			`password` AS acc_password,
			`first_name` AS acc_first_name,
			`last_name` AS acc_last_name,
			`role` AS acc_role
	FROM csc394group5.account acc
	WHERE acc.id = LAST_INSERT_ID();
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS account_login;
DELIMITER $$
CREATE PROCEDURE account_login (
    IN in_username VARCHAR(50),
    IN in_password VARCHAR(50)
	)
BEGIN
	SELECT	`id` AS acc_id,
			`username` AS acc_username,
			`password` AS acc_password,
			`first_name` AS acc_first_name,
			`last_name` AS acc_last_name,
			`role` AS acc_role
	FROM csc394group5.account acc
	WHERE acc.username = in_username
		AND acc.password = SHA(in_password);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS account_retrieve;
DELIMITER $$
CREATE PROCEDURE account_retrieve (
	IN in_id INT,
    IN in_username VARCHAR(50),
    IN first_name VARCHAR(50),
    IN last_name VARCHAR(50),
    IN in_role VARCHAR(10)
	)
BEGIN
	IF TRIM(in_id) = '' THEN SET in_id = NULL;
	END IF;
    IF TRIM(in_username) = '' THEN SET in_username = NULL;
	END IF;
    IF TRIM(first_name) = '' THEN SET first_name = NULL;
	END IF;
    IF TRIM(last_name) = '' THEN SET last_name = NULL;
	END IF;
    IF TRIM(in_role) = '' THEN SET in_role = NULL;
	END IF;
    
	SELECT	acc.`id` AS acc_id,
			acc.`username` AS acc_username,
			acc.`first_name` AS acc_first_name,
			acc.`last_name` AS acc_last_name,
			acc.`role` AS acc_role
	FROM `csc394group5`.`account` acc
    WHERE (acc.`id` = in_id OR in_id IS NULL)
		AND (acc.`username` = in_username OR in_username IS NULL)
        AND (acc.`first_name` = first_name OR first_name IS NULL)
        AND (acc.`last_name` = last_name OR last_name IS NULL)
        AND (acc.`role` = in_role OR in_role IS NULL);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS graduation_path_search_save;
DELIMITER $$
CREATE PROCEDURE graduation_path_search_save (
    IN in_account_id INT,
    IN in_option VARCHAR(50),
    IN in_value VARCHAR(1000)
	)
BEGIN
	INSERT INTO `csc394group5`.`graduation_path_search` (
		`option`,
		`value`,
		`account_id`)
	VALUES (
		in_option,
        in_value,
		in_account_id
    );
    
	SELECT	gra.`id` AS gra_id,
			gra.`option` AS gra_option,
			gra.`value` AS gra_value,
			gra.`account_id` AS gra_account_id
	FROM `csc394group5`.`graduation_path_search` gra
    WHERE gra.`id` = LAST_INSERT_ID();
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS graduation_path_search_retrieve;
DELIMITER $$
CREATE PROCEDURE graduation_path_search_retrieve (
	IN in_path_id INT,
    IN in_account_id INT
	)
BEGIN
	IF TRIM(in_path_id) = '' THEN SET in_path_id = NULL;
	END IF;
    IF TRIM(in_account_id) = '' THEN SET in_account_id = NULL;
	END IF;
    
	SELECT	gra.`id` AS gra_id,
			gra.`option` AS gra_option,
			gra.`value` AS gra_value,
			gra.`account_id` AS gra_account_id
	FROM `csc394group5`.`graduation_path_search` gra
    WHERE (gra.`id` = in_path_id OR in_path_id IS NULL)
		AND (gra.`account_id` = in_account_id OR in_account_id IS NULL);
END$$
DELIMITER ;


DROP PROCEDURE IF EXISTS degree_retrieve;
DELIMITER $$
CREATE PROCEDURE degree_retrieve (
	IN in_degree_name VARCHAR(20),
    IN in_college VARCHAR(20)
	)
BEGIN
	IF TRIM(in_degree_name) = '' THEN SET in_degree_name = NULL;
	END IF;
    IF TRIM(in_college) = '' THEN SET in_college = NULL;
	END IF;
        
	SELECT	deg.`name` AS deg_name,
			deg.`title` AS deg_title,
			deg.`college` AS deg_college,
			deg.`concentration` AS deg_concentration,
			deg.`description` AS deg_description
	FROM `csc394group5`.`degree` deg
    WHERE (deg.`name` = in_degree_name OR in_degree_name IS NULL)
		AND (deg.`college` = in_college OR in_college IS NULL);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS course_retrieve;
DELIMITER $$
CREATE PROCEDURE course_retrieve (
	IN in_course_id INT,
    IN in_course_number INT,
    IN in_department_code CHAR(3),
	IN in_title VARCHAR(50),
	IN in_description VARCHAR(1000),
    IN in_units DECIMAL(3, 2),
    IN in_status CHAR(10),
    IN in_prerequisite_of_course_id INT,
    IN in_requirement_of_degree_name INT
	)
BEGIN
	IF TRIM(in_course_id) = '' THEN SET in_course_id = NULL;
	END IF;
    IF TRIM(in_course_number) = '' THEN SET in_course_number = NULL;
	END IF;
    IF TRIM(in_department_code) = '' THEN SET in_department_code = NULL;
	END IF;
    IF TRIM(in_title) = '' THEN SET in_title = NULL;
	END IF;
    IF TRIM(in_description) = '' THEN SET in_description = NULL;
	END IF;
    IF TRIM(in_units) = '' THEN SET in_units = NULL;
	END IF;
    IF TRIM(in_status) = '' THEN SET in_status = NULL;
	END IF;
    IF TRIM(in_prerequisite_of_course_id) = '' THEN SET in_prerequisite_of_course_id = NULL;
	END IF;
    IF TRIM(in_requirement_of_degree_name) = '' THEN SET in_requirement_of_degree_name = NULL;
	END IF;
    
	SELECT	cou.`id` AS cou_id,
			cou.`number` AS cou_number,
			cou.`department_code` AS cou_department_code,
			cou.`people_soft_number` AS cou_people_soft_number,
			cou.`title` AS cou_title,
			cou.`description` AS cou_description,
			cou.`units` AS cou_units,
			cou.`status` AS cou_status
	FROM `csc394group5`.`course` cou
    WHERE (cou.`id` = in_course_id OR in_course_id IS NULL)
		AND (cou.`in_course_number` = in_course_number OR in_course_number IS NULL)
        AND (cou.`department_code` = in_department_code OR in_department_code IS NULL)
        AND (cou.`title` = in_title OR in_title IS NULL)
        AND (cou.`description` = in_description OR in_description IS NULL)
        AND (cou.`units` = in_units OR in_units IS NULL)
        AND (cou.`status` = in_status OR in_status IS NULL)
        AND (	in_prerequisite_of_course_id IS NULL
				OR EXISTS (	SELECT *
							FROM `csc394group5`.`course_prerequisite` pre
							WHERE pre.`id` = cou.`id`
								AND pre.`course_id` = in_prerequisite_of_course_id)
			)
		AND (	in_requirement_of_degree_name IS NULL
				OR EXISTS (	SELECT *
							FROM `csc394group5`.`degree_requirement` req
							WHERE req.`course_id` = cou.`id`
								AND req.`degree_name` = in_requirement_of_degree_name)
			);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS class_retrieve;
DELIMITER $$
CREATE PROCEDURE class_retrieve (
	IN in_class_id INT,
    IN in_section_number CHAR(5),
	IN in_course_id INT,
    IN in_course_number INT,
    IN in_department_code CHAR(3),
    IN in_status CHAR(10),
    IN in_history_in_account_id INT
	)
BEGIN
	IF TRIM(in_class_id) = '' THEN SET in_class_id = NULL;
	END IF;
    IF TRIM(in_section_number) = '' THEN SET in_section_number = NULL;
	END IF;
    IF TRIM(in_course_id) = '' THEN SET in_course_id = NULL;
	END IF;
    IF TRIM(in_course_number) = '' THEN SET in_course_number = NULL;
	END IF;
    IF TRIM(in_department_code) = '' THEN SET in_department_code = NULL;
	END IF;
    IF TRIM(in_status) = '' THEN SET in_status = NULL;
	END IF;
    IF TRIM(in_history_in_account_id) = '' THEN SET in_history_in_account_id = NULL;
	END IF;
    
	SELECT	cla.`id` AS cla_id,
			cla.`section_number` AS cla_section_number,
			cou.`course_id` AS cou_course_id,
            cou.`number` AS cou_course_number,
            cou.`department_code` AS cou_course_department_code,
			cla.`date_start` AS cla_date_start,
			cla.`date_end` AS cla_date_end,
			cla.`status` AS cla_status,
			roo.`classroom_id` AS roo_classroom_id,
            roo.`number` AS roo_classroom_number,
            roo.`section` AS roo_classroom_section,
            roo.`building_name` AS roo_building_name,
            roo.`campus_name` AS roo_campus_name,
			cla.`instructor_account_id` AS cla_instructor_account_id
	FROM `csc394group5`.`course_class` cla
    INNER JOIN `csc394group5`.`course` cou ON cla.`course_id` = cou.`id`
    INNER JOIN `csc394group5`.`classroom` roo ON roo.`id` = cla.`classroom_id`
    WHERE (cla.`id` = in_class_id OR in_class_id IS NULL)
		AND (cla.`section_number` = in_section_number OR in_section_number IS NULL)
		AND (cla.`course_id` = in_course_id OR in_course_id IS NULL)
        AND (	in_course_number IS NULL
				OR EXISTS (	SELECT *
							FROM `csc394group5`.`course` cou2
							WHERE cou2.`id` = cla.`course_id`
								AND cou2.`course_number` = in_course_number)
			)
        AND (	in_department_code IS NULL
				OR EXISTS (	SELECT *
							FROM `csc394group5`.`course` cou2
							WHERE cou2.`id` = cla.`course_id`
								AND cou2.`department_code` = in_department_code)
			)
		AND (cla.`status` = in_status OR in_status IS NULL)
        AND (	in_history_in_account_id IS NULL
				OR EXISTS (	SELECT *
							FROM `csc394group5`.`account_class_history` his
							WHERE his.`class_id` = cla.`id`
								AND his.`account_id` = in_history_in_account_id)
			);
END$$
DELIMITER ;