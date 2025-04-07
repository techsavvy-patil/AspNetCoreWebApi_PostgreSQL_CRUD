--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

-- Started on 2025-04-07 11:11:46

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
-- TOC entry 223 (class 1255 OID 16455)
-- Name: create_user(character varying, character varying, character varying, text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.create_user(_fullname character varying, _email character varying, _phone character varying, _password text) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
DECLARE
    inserted_count INT := 0;
BEGIN
    INSERT INTO Registrations (FullName, Email, Phone, Password)
    VALUES (_fullname, _email, _phone, _password);

    GET DIAGNOSTICS inserted_count = ROW_COUNT;
    RETURN inserted_count > 0;
END;
$$;


ALTER FUNCTION public.create_user(_fullname character varying, _email character varying, _phone character varying, _password text) OWNER TO postgres;

--
-- TOC entry 224 (class 1255 OID 16454)
-- Name: delete_user(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.delete_user(_id integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
DECLARE
    deleted_count INT := 0;
BEGIN
    DELETE FROM Registrations WHERE Id = _id;

    GET DIAGNOSTICS deleted_count = ROW_COUNT;
    RETURN deleted_count > 0;
END;
$$;


ALTER FUNCTION public.delete_user(_id integer) OWNER TO postgres;

--
-- TOC entry 220 (class 1255 OID 16449)
-- Name: get_all_users(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_all_users() RETURNS TABLE(id integer, fullname character varying, email character varying, phone character varying, password text, createdat timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT * FROM Registrations;
END;
$$;


ALTER FUNCTION public.get_all_users() OWNER TO postgres;

--
-- TOC entry 221 (class 1255 OID 16450)
-- Name: get_user_by_id(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_user_by_id(_id integer) RETURNS TABLE(id integer, fullname character varying, email character varying, phone character varying, password text, createdat timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT * FROM Registrations WHERE Id = _id;
END;
$$;


ALTER FUNCTION public.get_user_by_id(_id integer) OWNER TO postgres;

--
-- TOC entry 219 (class 1255 OID 16448)
-- Name: sp_get_all_users(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_users() RETURNS TABLE(id integer, fullname character varying, email character varying, phone character varying, password text, createdat timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT * FROM Registrations;
END;
$$;


ALTER FUNCTION public.sp_get_all_users() OWNER TO postgres;

--
-- TOC entry 225 (class 1255 OID 16456)
-- Name: update_user(integer, character varying, character varying, character varying, text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.update_user(_id integer, _fullname character varying, _email character varying, _phone character varying, _password text) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
DECLARE
    updated_count INT := 0;
BEGIN
    UPDATE Registrations
    SET FullName = _fullname,
        Email = _email,
        Phone = _phone,
        Password = _password
    WHERE Id = _id;

    GET DIAGNOSTICS updated_count = ROW_COUNT;

    RETURN updated_count > 0;
END;
$$;


ALTER FUNCTION public.update_user(_id integer, _fullname character varying, _email character varying, _phone character varying, _password text) OWNER TO postgres;

--
-- TOC entry 222 (class 1255 OID 16453)
-- Name: user_by_id(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.user_by_id(_id integer) RETURNS TABLE(id integer, fullname character varying, email character varying, phone character varying, password text, createdat timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        r.Id, r.FullName, r.Email, r.Phone, r.Password, r.CreatedAt
    FROM Registrations r
    WHERE r.Id = _id;
END;
$$;


ALTER FUNCTION public.user_by_id(_id integer) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 16436)
-- Name: registrations; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.registrations (
    id integer NOT NULL,
    fullname character varying(100),
    email character varying(100),
    phone character varying(20),
    password text,
    createdat timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.registrations OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16435)
-- Name: registrations_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.registrations_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.registrations_id_seq OWNER TO postgres;

--
-- TOC entry 4907 (class 0 OID 0)
-- Dependencies: 217
-- Name: registrations_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.registrations_id_seq OWNED BY public.registrations.id;


--
-- TOC entry 4749 (class 2604 OID 16439)
-- Name: registrations id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.registrations ALTER COLUMN id SET DEFAULT nextval('public.registrations_id_seq'::regclass);


--
-- TOC entry 4901 (class 0 OID 16436)
-- Dependencies: 218
-- Data for Name: registrations; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.registrations (id, fullname, email, phone, password, createdat) FROM stdin;
6	Vaibhav	Vaibhav@gm.com	6364747524	473287f8298dba7163a897908958f7c0eae733e25d2e027992ea2edc9bed2fa8	2025-04-06 23:13:02.782486
7	string	string	string	473287f8298dba7163a897908958f7c0eae733e25d2e027992ea2edc9bed2fa8	2025-04-06 23:45:26.625698
8	string	user@example.com	6364747524	6243effb808af94184b444f71f944cea59c2ce240688a4f94192f08393e20c1e	2025-04-07 09:24:00.75929
\.


--
-- TOC entry 4908 (class 0 OID 0)
-- Dependencies: 217
-- Name: registrations_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.registrations_id_seq', 8, true);


--
-- TOC entry 4752 (class 2606 OID 16446)
-- Name: registrations registrations_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.registrations
    ADD CONSTRAINT registrations_email_key UNIQUE (email);


--
-- TOC entry 4754 (class 2606 OID 16444)
-- Name: registrations registrations_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.registrations
    ADD CONSTRAINT registrations_pkey PRIMARY KEY (id);


-- Completed on 2025-04-07 11:11:46

--
-- PostgreSQL database dump complete
--



