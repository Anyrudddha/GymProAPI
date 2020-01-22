insert into tbl_ContactUs values('PratikRaje Nimbalkar','Hi I Want To Join Any GYM Near By Me.Can You Help Me','95520652****','raje@gmail.com','1',22-01-2020)


select * from tbl_SubcribedByGym   WHERE Subscription_end_date<=(SELECT GETDATE()+2)
union
select * from tbl_SubcribedByUser WHERE Subscription_end_date<=(SELECT GETDATE()+2)