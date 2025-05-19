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
    availability tinyint(1) NOT NULL DEFAULT 1
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
    day_of_week VARCHAR(10),
    start_time TIME,
    end_time TIME,
    no_of_patient INT,
    FOREIGN KEY (doctor_id) REFERENCES users(id)
);

CREATE TABLE appointment (
    id INT AUTO_INCREMENT PRIMARY KEY, 
    patient_id INT NOT NULL, 
    doctor_id INT NOT NULL, 
    schedule_id INT NOT NULL, 
    appointment_date DATETIME DEFAULT CURRENT_TIMESTAMP, 
    status VARCHAR(20) NOT NULL DEFAULT 'upcoming', 
    FOREIGN KEY (patient_id) REFERENCES users(id), 
    FOREIGN KEY (doctor_id) REFERENCES users(id), 
    FOREIGN KEY (schedule_id) REFERENCES doctor_schedule(id) 
);

CREATE TABLE prescription (
    id INT AUTO_INCREMENT PRIMARY KEY,
    appointment_id INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (appointment_id) REFERENCES appointment(id)
);

CREATE TABLE medicine (
    id INT AUTO_INCREMENT PRIMARY KEY,
    prescription_id INT NOT NULL,
    name varchar(255) NOT NULL,
    dosage varchar(255) NOT NULL,
    instruction varchar(255) NOT NULL,
    FOREIGN KEY (prescription_id) REFERENCES prescription(id)
);

INSERT INTO users (name, password, age, gender, contact, type)
VALUES ('Admin Name', 'admin123', 30, 'Male', '1234567890', 'admin');
