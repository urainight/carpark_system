--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: car_parking; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA car_parking;


ALTER SCHEMA car_parking OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: customers; Type: TABLE; Schema: car_parking; Owner: postgres
--

CREATE TABLE car_parking.customers (
    id integer NOT NULL,
    uid character varying(300),
    license_plate character varying(300),
    username character varying(300),
    gender character varying(100),
    phone character varying(100),
    date_created date,
    date_paycheck date,
    date_end date,
    month_ticket boolean,
    gate_in boolean
);


ALTER TABLE car_parking.customers OWNER TO postgres;

--
-- Name: customers_id_seq; Type: SEQUENCE; Schema: car_parking; Owner: postgres
--

CREATE SEQUENCE car_parking.customers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE car_parking.customers_id_seq OWNER TO postgres;

--
-- Name: customers_id_seq; Type: SEQUENCE OWNED BY; Schema: car_parking; Owner: postgres
--

ALTER SEQUENCE car_parking.customers_id_seq OWNED BY car_parking.customers.id;


--
-- Name: users; Type: TABLE; Schema: car_parking; Owner: postgres
--

CREATE TABLE car_parking.users (
    num integer NOT NULL,
    id integer,
    username character varying(400),
    phone character varying(40),
    email character varying(500),
    password character varying(900),
    date_create date,
    date_edited date,
    is_admin boolean,
    is_login boolean,
    gender character varying(300)
);


ALTER TABLE car_parking.users OWNER TO postgres;

--
-- Name: users_num_seq; Type: SEQUENCE; Schema: car_parking; Owner: postgres
--

CREATE SEQUENCE car_parking.users_num_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE car_parking.users_num_seq OWNER TO postgres;

--
-- Name: users_num_seq; Type: SEQUENCE OWNED BY; Schema: car_parking; Owner: postgres
--

ALTER SEQUENCE car_parking.users_num_seq OWNED BY car_parking.users.num;


--
-- Name: customers id; Type: DEFAULT; Schema: car_parking; Owner: postgres
--

ALTER TABLE ONLY car_parking.customers ALTER COLUMN id SET DEFAULT nextval('car_parking.customers_id_seq'::regclass);


--
-- Name: users num; Type: DEFAULT; Schema: car_parking; Owner: postgres
--

ALTER TABLE ONLY car_parking.users ALTER COLUMN num SET DEFAULT nextval('car_parking.users_num_seq'::regclass);


--
-- Data for Name: customers; Type: TABLE DATA; Schema: car_parking; Owner: postgres
--

COPY car_parking.customers (id, uid, license_plate, username, gender, phone, date_created, date_paycheck, date_end, month_ticket, gate_in) FROM stdin;
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: car_parking; Owner: postgres
--

COPY car_parking.users (num, id, username, phone, email, password, date_create, date_edited, is_admin, is_login, gender) FROM stdin;
5	34	thong	0905123456	thong@gmail.com	k3B1fIVshW2fS3ZUdbKUPpGTndkhRdeSHUfjQDtw99nmfO+2	2025-01-11	\N	t	t	Male
13	78	hien	0905467897	hien@gmail.com	jEvQwxyKhrpotYXBytRmmXKUn6d1Vd++xjFpolrsg1MJ4tc7	2025-01-14	2025-01-15	t	f	Female
9	65	thao	131232131231	thao@gmail.com	9sCXYLbSi1O2LYYgreq5fDywXe15ep9dnhzJaW8Mz1+ja61G	2025-01-11	\N	f	f	Male
7	68	lan	0804273142	lan@gmail.com	QcsdvdANsn2lcQH+aGH6/psFQx5Jz/BTRlIuy/arLhbyiw5X	2025-01-11	2025-01-12	t	f	Female
6	56	tung	0905654789	tung@gmail.com	b++/uxxzK7GudCoBlsfq/9yZxPNMhd7A+qDP+BLdxqSv+huL	2025-01-11	2025-01-12	f	f	Male
3	43	linh	0905345678	linh@gmail.com	kVCEv07XQwrh3tSQxijOxydgALMBiabHOXnEY/OpGe+qimiS	2025-01-11	\N	f	f	female
\.


--
-- Name: customers_id_seq; Type: SEQUENCE SET; Schema: car_parking; Owner: postgres
--

SELECT pg_catalog.setval('car_parking.customers_id_seq', 29, true);


--
-- Name: users_num_seq; Type: SEQUENCE SET; Schema: car_parking; Owner: postgres
--

SELECT pg_catalog.setval('car_parking.users_num_seq', 15, true);


--
-- Name: customers customers_pkey; Type: CONSTRAINT; Schema: car_parking; Owner: postgres
--

ALTER TABLE ONLY car_parking.customers
    ADD CONSTRAINT customers_pkey PRIMARY KEY (id);


--
-- Name: users unique_email; Type: CONSTRAINT; Schema: car_parking; Owner: postgres
--

ALTER TABLE ONLY car_parking.users
    ADD CONSTRAINT unique_email UNIQUE (email);


--
-- Name: users unique_id; Type: CONSTRAINT; Schema: car_parking; Owner: postgres
--

ALTER TABLE ONLY car_parking.users
    ADD CONSTRAINT unique_id UNIQUE (id);


--
-- Name: users unique_username; Type: CONSTRAINT; Schema: car_parking; Owner: postgres
--

ALTER TABLE ONLY car_parking.users
    ADD CONSTRAINT unique_username UNIQUE (username);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: car_parking; Owner: postgres
--

ALTER TABLE ONLY car_parking.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (num);


--
-- PostgreSQL database dump complete
--

