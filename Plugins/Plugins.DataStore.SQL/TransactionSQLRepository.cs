using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class TransactionSQLRepository : ITransactionRepository
{
    private readonly MarketContext db;

    public TransactionSQLRepository(MarketContext db)
    {
        this.db = db;
    }

    public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
        {
            return db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
        }
        else
        {
            return db.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%")&&
                                               x.TimeStamp.Date == date.Date);
        }
    }

    public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
        {
            return db.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date
            && x.TimeStamp.Date <= endDate.Date);
        }
        else
        {
            return db.Transactions.Where(
                x => EF.Functions.Like(x.CashierName,$"%{cashierName}%")
                     && x.TimeStamp.Date >= startDate.Date
                     && x.TimeStamp.Date <= endDate.Date);
        }
    }

    public void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
    {
        var transaction = new Transaction
        {
            CashierName = cashierName,
            ProductId = productId,
            ProductName = productName,
            Price = price,
            BeforeQty = beforeQty,
            SoldQty = soldQty,
            TimeStamp = DateTime.Now
        };
        
        db.Transactions.Add(transaction);
        db.SaveChanges();
    }
}