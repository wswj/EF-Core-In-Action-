public class PlaceOrderDbAccess : IPlaceOrderDbAccess
{
 private readonly EfCoreContext _context;
 public PlaceOrderDbAccess(EfCoreContext context)
 {
 _context = context;
 }
 public IDictionary<int, Book> 
 FindBooksByIdsWithPriceOffers 
 (IEnumerable<int> bookIds) 
 {
 return _context.Books 
 .Where(x => bookIds.Contains(x.BookId)) 
 .Include(r => r.Promotion) 
 .ToDictionary(key => key.BookId); 
 }
 public void Add(Order newOrder) 
 { 
 _context.Add(newOrder); 
 } 
}