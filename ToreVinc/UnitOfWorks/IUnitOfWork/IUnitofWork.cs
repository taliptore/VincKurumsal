namespace KurumsalWebVinc.UnitOfWorks.IUnitOfWork
{
	public interface IUnitofWork
	{
		/*
           Bunun amacı tüm yapılan değişiklikler hepisi birden tek transection ile gönderilsin birinde hata varsa hiç biri kayıt edilmesin
          amaç tek bir noktada kayıtların tutarlı ve düzngün transactionlar ile yapılması nı olanak saglar
           */
		Task CommitAsycn();
		void Commit();
	}

}
