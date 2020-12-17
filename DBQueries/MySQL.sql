--1. Select users whose id is either 3,2 or 4

SELECT * FROM users WHERE id IN (2,3,4)

--2. Count how many basic and premium listings each active user has

SELECT first_name, last_name, SUM(Basic) AS 'Basic', SUM(Premium) AS 'Premium'
FROM
(
SELECT u.id, u.first_name, u.last_name, CASE WHEN l.status = 2 THEN 1 END AS 'Basic', CASE WHEN l.status = 3 THEN 1 END AS 'Premium'
from listings l
inner join users u on u.id = l.user_id
where u.status=2
) dt
group by id


--3. Show the same count as before but only if they have at least ONE premium listing

SELECT first_name, last_name, SUM(Basic) AS 'Basic', SUM(Premium) AS 'Premium'
FROM
(
SELECT u.id, u.first_name, u.last_name, CASE WHEN l.status = 2 THEN 1 END AS 'Basic', CASE WHEN l.status = 3 THEN 1 END AS 'Premium'
from listings l
inner join users u on u.id = l.user_id
where u.status=2
) dt
group by id
having Premium >=1 


--4. How much revenue has each active vendor made in 2013

select u.first_name, u.last_name, c.currency, SUM(c.price) AS 'revenue'
from clicks c
inner join listings l on l.id = c.listing_id
inner join users u on u.id = l.user_id
where u.status = 2 and YEAR(c.created) = 2013
group by u.id, c.currency


--5. Insert a new click for listing id 3, at $4.00

insert into clicks (listing_id,price,currency,created) values (3,4.00,'USD',now())
SELECT LAST_INSERT_ID();


--6. Show listings that have not received a click in 2013

select l.name
from listings l
left join clicks c on c.listing_id = l.id AND YEAR(c.created) = 2013
where c.id is null


--7. For each year show number of listings clicked and number of vendors who owned these listings

select Year as 'date', Sum(total_listings_clicked) as 'total_listings_clicked' , SUM(total_vendors_affected) as 'total_vendors_affected'
from
(
select YEAR(c.created) as 'Year', CASE WHEN c.id IS NOT NULL THEN 1 ELSE 0 END as 'total_listings_clicked' , CASE WHEN l.user_id IS NOT NULL THEN 1 ELSE 0 END as 'total_vendors_affected'
from listings l
inner join clicks c on c.listing_id = l.id
) dt
group by Year


--8. Return a comma separated string of listing names for all active vendors

select u.first_name, u.last_name, GROUP_CONCAT(l.name) as 'listing_names'
from listings l 
inner join users u on u.id = l.user_id
where u.status = 2
GROUP BY u.id

