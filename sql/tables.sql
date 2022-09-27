CREATE TABLE users
(
    id       INT GENERATED ALWAYS AS IDENTITY NOT NULL
        CONSTRAINT users_pk PRIMARY KEY,
    username VARCHAR(256)                     NOT NULL,
    email    VARCHAR(256)                     NOT NULL,
    password VARCHAR(256)                     NOT NULL
);

CREATE UNIQUE INDEX users_email_index
    ON users (email);

CREATE TABLE user_feeds
(
    id       INT GENERATED ALWAYS AS IDENTITY NOT NULL
        CONSTRAINT user_feeds_pk PRIMARY KEY,
    user_id  INT                              NOT NULL
        CONSTRAINT user_cargos_user_id_fk REFERENCES users
            ON UPDATE CASCADE ON DELETE CASCADE,
    rss_feed VARCHAR(2048)                    NOT NULL
);

CREATE UNIQUE INDEX user_feeds_rss_feed_index
    ON user_feeds (user_id, rss_feed);

CREATE TABLE cargos
(
    id   INT GENERATED ALWAYS AS IDENTITY NOT NULL
        CONSTRAINT cargos_pk PRIMARY KEY,
    name VARCHAR(512)                     NOT NULL
);

CREATE UNIQUE INDEX cargos_name_index
    ON cargos (name);

CREATE TABLE cargo_feeds
(
    id       INT GENERATED ALWAYS AS IDENTITY NOT NULL
        CONSTRAINT cargo_feeds_pk PRIMARY KEY,
    cargo_id INT                              NOT NULL
        CONSTRAINT cargo_feeds_cargo_id_fk REFERENCES cargos
            ON UPDATE CASCADE ON DELETE CASCADE,
    rss_feed VARCHAR(2048)                    NOT NULL
);

CREATE UNIQUE INDEX cargo_feeds_rss_feed_index
    ON cargo_feeds (cargo_id, rss_feed);

CREATE TABLE user_cargos
(
    id       INT GENERATED ALWAYS AS IDENTITY NOT NULL
        CONSTRAINT user_cargos_pk PRIMARY KEY,
    user_id  INT                              NOT NULL
        CONSTRAINT user_cargos_user_id_fk REFERENCES users
            ON UPDATE CASCADE ON DELETE CASCADE,
    cargo_id INT                              NOT NULL
        CONSTRAINT user_cargos_cargo_id_fk REFERENCES cargos
            ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE UNIQUE INDEX user_cargos_cargo_id_index
    ON user_cargos (user_id, cargo_id);

