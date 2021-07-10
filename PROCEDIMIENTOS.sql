
-------------- INSERT CUSTOMER Y VIDEOGAMES

CREATE OR REPLACE PROCEDURE INSERT_CUSTOMER(
    ic integer,
    nc varchar2,
    lc varchar2,
    ac varchar2,
    pc integer,
    ec varchar2,
    uc integer
)
is 
begin
    INSERT INTO CUSTOMER values (ic,nc,lc,ac,pc,ec,uc);
    COMMIT;
end INSERT_CUSTOMER;


CREATE OR REPLACE PROCEDURE INSERT_VIDEOGAME(
    iv integer,
    nv varchar2,
    pv varchar2,
    fv varchar2,
    av date,
    gv integer,
    ev integer
)
is 
begin
    INSERT INTO VIDEOGAMES values (iv,nv,pv,fv,av,gv,ev);
    COMMIT;
end INSERT_VIDEOGAME;

-------------- DELETE VIDEOGAME Y CUSTOMER


CREATE OR REPLACE PROCEDURE DELETE_videogame ( e_id integer )
IS
BEGIN
DELETE FROM VIDEOGAMES WHERE VIDEOGAMESID = e_id;
END;

CREATE OR REPLACE PROCEDURE DELETE_CUSTOMER ( e_id integer )
IS
BEGIN
DELETE FROM CUSTOMER WHERE CUSTOMERID = e_id;
END;

-------------- LIST CUSTOMER Y VIDEOGAMES

create or replace procedure list_customer(c_cursor out sys_refcursor)
is 
begin
open c_cursor for
select*from CUSTOMER;
end;

create or replace procedure list_videogames(c_cursor out sys_refcursor)
is 
begin
open c_cursor for
select*from VIDEOGAMES;
end;

-------------- LIST VIDEOGAMES MOSTRANDO DATOS EN LUGAR DE ID 

create or replace procedure list_videogames(c_cursor out sys_refcursor)
is
begin
open c_cursor for
select p.videogamesid, p.VIDEOGAMESNAME, p.VIDEOGAMESPRICE ,p.VIDEOGAMESPHOTO, p.VIDEOGAMESDATE,p.GENEROV_GENEROID ,r.GENERONAME, p.DESARROLLADOR_DESARROLLADORID, c.DESARROLLADORNAME 
from VIDEOGAMES P, DESARROLLADOR C, GENEROV R 
where p.GENEROV_GENEROID=r.GENEROID and P.DESARROLLADOR_DESARROLLADORID=c.DESARROLLADORID;
end;

-------------- REPORTES DE VENTAS

create or replace procedure rep_ventasf(c_genero in VARCHAR2,c_cursor out sys_refcursor)
is
begin
open c_cursor for
select v.VENTAID, c.CUSTOMERNAME,t.METODOPAGO, e.VIDEOGAMESNAME, r.GENERONAME from VENTAF V, CUSTOMER C, TIPODEPAGO T, VIDEOGAMES E, GENEROV R where v.CUSTOMERID=c.CUSTOMERID and 
v.TIPODEPAGOID=t.TIPODEPAGOID and v.CUSTOMERID=c.CUSTOMERID and v.VIDEOGAMESID = e.VIDEOGAMESID and v.GENEROID =r.GENEROID and r.GENERONAME=c_genero;
end;

-------------- LISTA DE VIDEOJUEGOS POR PRECIO


create or replace procedure list_videogamesprice(c_cursor out sys_refcursor)
is
begin
open c_cursor for
select videogamesid,VIDEOGAMESNAME,VIDEOGAMESPRICE 
from VIDEOGAMES;
end;

-------------- UPDATE CUSTOMER Y VIDEOGAMES


create or replace procedure UPDATE_CUSTOMER(ic in number, nc in varchar2, lc in varchar2, ac in varchar, pc in number, ec in VARCHAR2, uc in number )
is

begin

update CUSTOMER set CUSTOMERNAME=nc, CUSTOMERLASTNAME=lc, CUSTOMERADDRESS=ac, CUSTOMERPHONE=pc,CUSTOMEREMAIL=ec,CUSTOMERAGE=uc where CUSTOMERID=ic;

end;


create or replace procedure UPDATE_VIDEOGAME(iv in number, nv in varchar2, pv in varchar2, fv in varchar, av date, gv in number, ev in number )
is

begin

update VIDEOGAMES set VIDEOGAMESNAME=nv, VIDEOGAMESPRICE=pv, VIDEOGAMESPHOTO=fv, VIDEOGAMESDATE=av,GENEROV_GENEROID=gv,DESARROLLADOR_DESARROLLADORID=ev where VIDEOGAMESID=iv;

end;

-------------- LOGIN 

create or replace procedure login_usu(c_usuario in varchar2, c_contra in varchar2, n_resp out number)
is
c_valcorr customer.usuario%TYPE;
c_valcontra customer.contrase%type;
begin
select usuario, contrase into c_valcorr, c_valcontra from CUSTOMER where  usuario=c_usuario and contrase=c_contra;
n_resp :=1;
exception
when no_data_found then n_resp :=0;
end;
