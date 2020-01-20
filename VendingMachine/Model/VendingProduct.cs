namespace VendingMachine.Model
{
    public class VendingProduct
    {
        public int Id { get; }
        public string Cola { get; }

        public VendingProduct(int id, string cola)
        {
            Id = id;
            Cola = cola;
            
            MonetaryValue = id switch
            {
                1 => 0.1,
                2 => 0.5,
                3 => 0.65,
                _ => 0
            };
        }

        public double MonetaryValue { get; private set; }
    }
}