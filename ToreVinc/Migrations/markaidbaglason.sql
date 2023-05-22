select * from AracMarkas ;
select *  from AracModels  ;

select * from AracModels
join AracMarkas on AracMarkaId=MarkaKodu
;


select  (select AracMarkaId from AracMarkas where  AracMarkas.MarkaKodu=AracModels.AracMarkaKodu  )
from AracModels
;
select  * from AracModels where  AracModels.Id=2;

update AracModels set  AracMarkaId=ISNULL((select  top 1 Id from AracMarkas where  AracMarkas.MarkaKodu=AracModels.AracMarkaKodu ),1)
where exists ( select 1 from  AracMarkas tt where tt.MarkaKodu=AracModels.AracMarkaKodu) 

update AracModels set AracMarkaKodu=AracMarkaId