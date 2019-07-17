use burgershack123;

CREATE TABLE stores
(
    id INT AUTO_INCREMENT,
    location VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);
-- ONE TO MANY
CREATE TABLE bouquets
(
    id INT AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    storeId INT NOT NULL,
    FOREIGN KEY (storeId)
        REFERENCES stores(id)
        ON DELETE CASCADE,
    PRIMARY KEY (id)
);
CREATE TABLE flowers
(
    id INT AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    price DECIMAL(6, 2),
    PRIMARY KEY (id)
);
-- MANY TO MANY TABLE
CREATE TABLE flowerbouquets
(
    id INT AUTO_INCREMENT,
    bouquetId INT NOT NULL,
    flowerId INT NOT NULL,

    INDEX (bouquetId),

    FOREIGN KEY (bouquetId)
        REFERENCES bouquets(id)
        ON DELETE CASCADE,

    FOREIGN KEY (flowerId)
        REFERENCES flowers(id)
        ON DELETE CASCADE,

    PRIMARY KEY (id)

);





