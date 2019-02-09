CREATE TABLE `books` (
	`Id` INT(10) AUTO_INCREMENT PRIMARY KEY,
	`Author` LONGTEXT,
	`LanchDate` DATETIME(6) NOT NULL,
	`Price` DECIMAL(65,2) NOT NULL,
	`Title` LONGTEXT
)
COLLATE='utf8mb4_0900_ai_ci'
;
