SELECT t3.name, t1.date, t1.high, t2.volume, t1.high*t2.volume as value_USD 
FROM dbo.Ticker_prices t1 
inner join dbo.Ticker_volumes t2 on t1.sub_id = t2.id
inner join dbo.Ticker_names t3 on t1.sub_id = t3.id
WHERE date = 
(select MIN(date)
from dbo.Ticker_prices s1 
where s1.sub_id = t1.sub_id)
order by t1.sub_id;

SELECT t3.name, t1.date, t1.high, t2.volume, t1.high*t2.volume as value_USD 
FROM dbo.Ticker_prices t1 
inner join dbo.Ticker_volumes t2 on t1.sub_id = t2.id
inner join dbo.Ticker_names t3 on t1.sub_id = t3.id
WHERE date = 
(select MAX(date)
from dbo.Ticker_prices s1 
where s1.sub_id = t1.sub_id)
order by t1.sub_id;

SELECT t3.name, t1.date, t1.high, t2.volume, t1.high*t2.volume as value_USD 
FROM dbo.Ticker_prices t1 
inner join dbo.Ticker_volumes t2 on t1.sub_id = t2.id
inner join dbo.Ticker_names t3 on t1.sub_id = t3.id
order by t1.sub_id;

select *
from dbo.Currency_exchange_rate