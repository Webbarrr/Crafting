using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crafting.WPF.Screens.WalletScreen
{
    public class WalletViewModel : ViewModelBase
    {
        private int _gold;

        public int Gold
        {
            get { return _gold; }
            set 
            { 
                _gold = value;
                base.RaisePropertyChanged();
            }
        }

        private int _silver;

        public int Silver
        {
            get { return _silver; }
            set 
            { 
                _silver = value;
                base.RaisePropertyChanged();
            }
        }

        private int _copper;

        public int Copper
        {
            get { return _copper; }
            set 
            { 
                _copper = value;
                base.RaisePropertyChanged();
            }
        }



    }
}
