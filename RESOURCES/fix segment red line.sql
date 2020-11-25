SELECT DISTINCT
tblILD.Item,tblILD.Item_Type,tblILD.Loop_Name AS [New Segment]
,ILDOLD.Segment AS [OLD Segment]
FROM tblILD
INNER JOIN tblILD AS ILDOLD
ON tblILD.Item=ILDOLD.Item
WHERE tblILD.Loop_Name LIKE 'S-%'
AND ILDOLD.Segment LIKE 'S-%'
AND ILDOLD.Segment<>tblILD.Loop_Name
AND TBLILD.Item_Type LIKE 'INS%' AND TBLILD.Item_Type <>'Ins Cable-Multi Pair' AND TBLILD.Item_Type <> 'Ins Cable-Vendor'
go
select 
* from tblILD
where Loop_Name like 's-%'
and Segment like 's-%'
and Loop_Name <> Segment