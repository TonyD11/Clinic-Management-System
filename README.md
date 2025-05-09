# CMS

MySQL

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    password VARCHAR(255) NOT NULL,
    age INT,
    gender ENUM('Male', 'Female', 'Other'),
    contact VARCHAR(15),
    type ENUM('doctor', 'patient', 'admin') NOT NULL,
    availability` tinyint(1) NOT NULL DEFAULT 1
);

CREATE TABLE doctor_specialties (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    specialty VARCHAR(100) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
);

CREATE TABLE doctor_schedule (
    id INT AUTO_INCREMENT PRIMARY KEY,
    doctor_id INT,
    day_of_week VARCHAR(10),   -- e.g., 'Monday'
    start_time TIME,
    end_time TIME,
    FOREIGN KEY (doctor_id) REFERENCES users(id)
);




INSERT INTO users (name, password, age, gender, contact, type)
VALUES ('Admin Name', 'admin123', 30, 'Male', '1234567890', 'admin');
