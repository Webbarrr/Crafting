using Crafting.Library.Data.DataWrappers;
using Crafting.Library.Data.Deserialized;
using Crafting.WPF.Utilties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crafting.WPF.Screens.RawDataScreens.ReagentScreen
{
    public class ReagentViewModel : ViewModelBase
    {
        /// <summary>
        /// Wrapper to read / write to the reagents file
        /// </summary>
        private readonly DataWrapper<Reagent> _dataWrapper;

        /// <summary>
        /// Binding for the reagents data
        /// </summary>
        private ObservableCollection<Reagent> _reagents;

        public ObservableCollection<Reagent> Reagents
        {
            get { return _reagents; }
            set
            {
                _reagents = value;
                base.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Binding for the filter on the reagents data
        /// </summary>
        private string _filter;

        public string Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                base.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReagentViewModel()
        {
            try
            {
                _dataWrapper = new DataWrapper<Reagent>();
            }
            catch (Exception)
            {
                // for design time
            }
            

            this.SetReagentsCollection();
        }

        /// <summary>
        /// Sets the contents of the reagents data binding
        /// </summary>
        private void SetReagentsCollection()
        {
            try
            {
                this.Reagents = new ObservableCollection<Reagent>(
                    _dataWrapper.Get());
            }
            catch (Exception)
            {

                this.Reagents = new ObservableCollection<Reagent>(
                    this.GetFakeReagents());
            }
        }

        /// <summary>
        /// Creates dummy reagents data for when we don't have any / at design time
        /// </summary>
        /// <returns></returns>
        private List<Reagent> GetFakeReagents()
        {
            return new List<Reagent>
            {
                new Reagent
                {
                     ReagentId = 0,
                     Name = "No reagents found..."
                }
            };
        }

        #region "Commands"
        /// <summary>
        /// Adds a new reagent
        /// </summary>
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        p => this.ExecuteAddCommand((string)p),
                        p => this.CanExecuteAddCommand((string)p));
                }

                return _addCommand;
            }
        }
        private bool CanExecuteAddCommand(string reagentName)
        {
            if (String.IsNullOrWhiteSpace(reagentName))
                return false;

            return this.Reagents.Where(p => p.Name.ToLower() == reagentName.ToLower())
                .FirstOrDefault() == null;
        }
        private void ExecuteAddCommand(string reagentName)
        {
            if (String.IsNullOrWhiteSpace(reagentName))
                return;

            var newReagent = new Reagent
            {
                ReagentId = this.Reagents.OrderByDescending(p => p.ReagentId)
                .FirstOrDefault()
                .ReagentId + 1,

                Name = reagentName
            };

            this.Reagents.Add(newReagent);

            if (this.Reagents.OrderBy(p => p.ReagentId).FirstOrDefault().ReagentId == 0)
            {
                this.Reagents.RemoveAt(0);
            }

            _dataWrapper.Set(this.Reagents.ToList());

            this.SetReagentsCollection();

            this.Filter = null;
        }

        /// <summary>
        /// Opens the raw data
        /// </summary>
        private ICommand _openDataCommand;

        public ICommand OpenDataCommand
        {
            get
            {
                if (_openDataCommand == null)
                {
                    _openDataCommand = new RelayCommand(
                        p => this.ExecuteOpenDataCommand());
                }

                return _openDataCommand;
            }
        }

        private void ExecuteOpenDataCommand()
        {
            _dataWrapper.OpenRawData();
        }

        #endregion
    }
}
