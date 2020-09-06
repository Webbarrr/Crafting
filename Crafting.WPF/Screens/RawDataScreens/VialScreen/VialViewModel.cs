using Crafting.Library.Currency;
using Crafting.Library.Data.DataWrappers;
using Crafting.Library.Data.Deserialized;
using Crafting.WPF.Screens.WalletScreen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Crafting.WPF.Screens.RawDataScreens.VialScreen
{
    public class VialViewModel : ViewModelBase
    {
        /// <summary>
        /// Data wrapper to read / write the vial data
        /// </summary>
        private readonly DataWrapper<Vial> _dataWrapper;

        /// <summary>
        /// Binding for the wallet
        /// </summary>
        private Page _walletPage;

        public Page WalletPage
        {
            get { return _walletPage; }
            set 
            { 
                _walletPage = value;
                base.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Binding for the vials data
        /// </summary>
        private ObservableCollection<Vial> _vials;

        public ObservableCollection<Vial> Vials
        {
            get { return _vials; }
            set 
            { 
                _vials = value;
                base.RaisePropertyChanged();
            }
        }


        /// <summary>
        /// Default constructor
        /// </summary>
        public VialViewModel()
        {
            this.WalletPage = new WalletPage();

            try
            {
                _dataWrapper = new DataWrapper<Vial>();
            }
            catch (Exception)
            {
                // design time
            }

            try
            {
                this.Vials = new ObservableCollection<Vial>(this._dataWrapper.Get());
            }
            catch (Exception)
            {
                this.Vials = new ObservableCollection<Vial>(this.GetDummyData());
            }
            
        }

        /// <summary>
        /// Used when there is no data available / at design time
        /// </summary>
        /// <returns></returns>
        private List<Vial> GetDummyData()
        {
            return new List<Vial>
            {
                new Vial
                {
                    VialId = 0,
                    Name = "No vial data available",
                    Cost = new Wallet
                    {
                        Gold = 0,
                        Silver = 0,
                        Copper = 0
                    }
                }
            };
        }
    }
}