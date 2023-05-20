namespace API.Models
{
    public class CustomerOrderModel
    {
        public List<MenuItem> OrderedItems { get; set; }
    }

    public class MenuItem
    {
        public int ItemId { get; set; }
        public List<int> CustomProductsIds { get; set; }
    }
}
