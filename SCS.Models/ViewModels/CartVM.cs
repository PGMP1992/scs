namespace SCS.Models.ViewModels
{
    public class BuyCartVM
    {
        public IEnumerable<Cart> CartList { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
