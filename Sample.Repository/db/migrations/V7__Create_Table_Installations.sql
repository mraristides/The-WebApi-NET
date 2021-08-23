CREATE TABLE `installations` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`local_installation` VARCHAR(50) NULL DEFAULT NULL,
	`item_objeto` VARCHAR(10) NULL DEFAULT NULL,
	`local_sup` VARCHAR(50) NULL DEFAULT NULL,
	`abc` VARCHAR(5) NULL DEFAULT NULL,
	`description` VARCHAR(100) NULL DEFAULT NULL,
	`room` VARCHAR(50) NULL DEFAULT NULL,
	`work_center` VARCHAR(50) NULL DEFAULT NULL,
	`tag` VARCHAR(50) NULL DEFAULT NULL,
	`cost_center` VARCHAR(50) NULL DEFAULT NULL,
	`catalog_profile` VARCHAR(50) NULL DEFAULT NULL,
	`status_sys` VARCHAR(50) NULL DEFAULT NULL,
	`status_usu` VARCHAR(50) NULL DEFAULT NULL,
	`creation_date` VARCHAR(50) NULL DEFAULT NULL,
	PRIMARY KEY (`id`),
	UNIQUE `local_installation` (`local_installation`)
)