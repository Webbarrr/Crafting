using Crafting.WPF.Screens.RawDataScreens.ReagentScreen;
using Crafting.WPF.Utilties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crafting.WPF.Screens.RawDataScreens
{
    public class RawDataViewModel : ViewModelBase
    {
        private ICommand _reagentNavigationCommand;

        public ICommand ReagentNavigationCommand
        {
            get
            {
                if (_reagentNavigationCommand == null)
                {
                    _reagentNavigationCommand = new RelayCommand(
                        p => this.ExecuteReagentNavigationCommand());
                }

                return _reagentNavigationCommand;
            }
        }

        private void ExecuteReagentNavigationCommand()
        {
            ApplicationViewModel.TopLevelViewModel.CurrentPage = new ReagentPage();
        }
    }
}
