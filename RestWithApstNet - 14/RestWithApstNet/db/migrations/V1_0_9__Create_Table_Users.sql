CREATE TABLE `users` (
	`Id` INT(10) AUTO_INCREMENT PRIMARY KEY,
	`Login` VARCHAR(50) UNIQUE NOT NULL,
	`AccessKey` VARCHAR(50) NOT NULL
)
COLLATE='utf8mb4_0900_ai_ci'
;