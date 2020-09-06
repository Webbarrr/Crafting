using Crafting.Library.Currency;

namespace Crafting.Library.Data.Deserialized
{
    public class Vial : IData
    {
        public int VialId { get; set; }
        public string Name { get; set; }
        public Wallet Cost { get; set; }
    }
}