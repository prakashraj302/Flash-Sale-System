
select count(*) as total_delivers,SUM(CASE WHEN delivery_status = 'COMPLETED' THEN 1 ELSE 0 END) / COUNT(*) * 100 AS success_rate from deliveries 
where attempt_timestamp >= '2024-09-01' AND attempt_timestamp <= '2024-09-31' GROUP BY driver_id HAVING
SUM(CASE WHEN delivery_status = 'COMPLETED' THEN 1 ELSE 0 END) >=5 AND CAST (SUM(CASE WHEN delivery_status = 'COMPLETED' THEN 1 ELSE 0 END))/COUNT(*)* 100>=90 order by success_Rate Desc