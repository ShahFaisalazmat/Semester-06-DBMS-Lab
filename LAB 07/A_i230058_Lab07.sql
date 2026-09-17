CREATE DATABASE CinemaManagement;
GO
USE CinemaManagement;
GO
CREATE TABLE Movies (
    id INT IDENTITY(1,1) PRIMARY KEY,  
    title VARCHAR(100) NOT NULL,
    genre VARCHAR(50),
    duration_minutes INT,
    rating DECIMAL(3,1)
);
GO
CREATE TABLE Screens (
    id INT IDENTITY(1,1) PRIMARY KEY,  
    screen_number INT NOT NULL,
    capacity INT CHECK (capacity > 0),  
    type VARCHAR(50)
);
GO
CREATE TABLE Showtimes (
    id INT IDENTITY(1,1) PRIMARY KEY,  
    movie_id INT NOT NULL,
    screen_id INT NOT NULL,
    show_date DATE NOT NULL,
    start_time TIME NOT NULL,
    ticket_price DECIMAL(8,2) CHECK (ticket_price > 0), 
    FOREIGN KEY (movie_id) REFERENCES Movies(id),  
    FOREIGN KEY (screen_id) REFERENCES Screens(id)  
);
GO
CREATE TABLE Bookings (
    id INT IDENTITY(1,1) PRIMARY KEY, 
    showtime_id INT NOT NULL,
    customer_name VARCHAR(100) NOT NULL,
    seats_booked INT CHECK (seats_booked >= 1), 
    total_price DECIMAL(10,2),
    booking_status VARCHAR(20) DEFAULT 'Confirmed', 
    FOREIGN KEY (showtime_id) REFERENCES Showtimes(id)
);
GO
CREATE TABLE Payments (
    id INT IDENTITY(1,1) PRIMARY KEY, 
    booking_id INT NOT NULL,
    payment_date DATE NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    method VARCHAR(50),
    FOREIGN KEY (booking_id) REFERENCES Bookings(id) 
);
GO
ALTER TABLE Movies
ADD language VARCHAR(50);
GO
ALTER TABLE Showtimes
ALTER COLUMN ticket_price DECIMAL(8,2);
GO
SELECT 'Tables created successfully' AS Status;
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';
GO