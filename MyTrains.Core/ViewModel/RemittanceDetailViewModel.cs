﻿using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Model;
using MvvmCross.Platform.Platform;

namespace MyTrains.Core.ViewModel
{
    public class RemittanceDetailViewModel : BaseViewModel, IRemittanceDetailViewModel
    {
        private readonly IRemittanceDataService _remittanceDataService;
        private readonly ISavedRemittanceDataService _savedRemittanceDataService;
        private readonly IDialogService _dialogService;
        private readonly IBeneficiaryDataService _beneficiaryDataService;
        private readonly ICityDataService _cityDataService;
        private readonly ICountryDataService _countryDataService;
        private readonly IServiceDataService _serviceDataService;
        private readonly IUserDataService _userDataService;
        private Remittance _selectedRemittance;
        private int _remittanceId;
        private int _beneficiaryId;
        private int _cityId;
        private int _countryId;
        private int _serviceId;
        
        public MvxCommand AddToSavedRemittancesCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    await _savedRemittanceDataService.AddSavedRemittance
                    (_userDataService.GetActiveUser().UserId, SelectedRemittance.RemittanceId, SelectedRemittance.BeneficiaryId, SelectedRemittance.CountryId, SelectedRemittance.CityId, SelectedRemittance.ServiceId);

                    //Hardcoded text, better with resx translations
                    //await
                    //    _dialogService.ShowAlertAsync("This journey is now in your Saved Journeys!", "My Trains says...", "OK");

                    await
                        _dialogService.ShowAlertAsync
                        (TextSource.GetText("AddedToSavedRemittancesMessage"),
                         TextSource.GetText("AddedToSavedRemittancesTitle"),
                         TextSource.GetText("AddedToSavedRemittancesButton"));
                });
            }
        }

        public MvxCommand CloseCommand
        { get { return new MvxCommand(() => Close(this)); } }

        public Remittance SelectedRemittance
        {
            get { return _selectedRemittance; }
            set
            {
                _selectedRemittance = value;
                RaisePropertyChanged(() => SelectedRemittance);
            }
        }

        public int BeneficiaryId
        {
            get { return _beneficiaryId; }
            set
            {
                _beneficiaryId = value;
                RaisePropertyChanged(() => BeneficiaryId);
            }
        }
        public int CityId
        {
            get { return _cityId; }
            set
            {
                _cityId = value;
                RaisePropertyChanged(() => CityId);
            }
        }
        public int ServiceId
        {
            get { return _serviceId; }
            set
            {
                _serviceId = value;
                RaisePropertyChanged(() => ServiceId);
            }
        }
        public int CountryId
        {
            get { return _countryId; }
            set
            {
                _countryId = value;
                RaisePropertyChanged(() => CountryId);
            }
        }

        public RemittanceDetailViewModel(IMvxMessenger messenger,
            IRemittanceDataService remittanceDataService,
            ISavedRemittanceDataService savedRemittanceDataService,
            IDialogService dialogService,
            IUserDataService userDataService) : base(messenger)
        {
            _remittanceDataService = remittanceDataService;
            _savedRemittanceDataService = savedRemittanceDataService;
            _dialogService = dialogService;
            _userDataService = userDataService;
        }

        public void Init(int remittanceId)
        {
            _remittanceId = remittanceId;
        }

        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            SelectedRemittance = await _remittanceDataService.GetRemittanceDetails(_remittanceId);
        }

        public class SavedState
        {
            public int RemittanceId { get; set; }
        }

        public SavedState SaveState()
        {
            MvxTrace.Trace("SaveState called");
            return new SavedState { RemittanceId = _remittanceId };
        }

        public void ReloadState(SavedState savedState)
        {
            MvxTrace.Trace("ReloadState called with {0}",
                savedState.RemittanceId);
            _remittanceId = savedState.RemittanceId;
        }
    }
}