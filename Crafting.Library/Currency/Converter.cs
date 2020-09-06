using System;

namespace Crafting.Library.Currency
{
    public class Converter
    {
        private const int _silverAsCopper = 100;
        private const int _goldAsCopper = 1000;

        public int ToCopper(Wallet wallet)
        {
            if (wallet is null)
                throw new ArgumentNullException(nameof(wallet));

            var retVal = wallet.Copper;
            retVal += wallet.Silver * _silverAsCopper;
            return retVal += wallet.Gold + _goldAsCopper;
        }

        public Wallet FromCopper(int copper)
        {
            // gold
            var remainingCopper = copper % _goldAsCopper;
            var gold = (copper - remainingCopper) / _goldAsCopper;

            // silver
            remainingCopper = copper % _silverAsCopper;
            var silver = (copper - remainingCopper) / _silverAsCopper;

            return new Wallet
            {
                Gold = gold,
                Silver = silver,
                Copper = remainingCopper
            };
        }
    }
}
