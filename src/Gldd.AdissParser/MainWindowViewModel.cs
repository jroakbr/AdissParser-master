using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Gldd.AdissParser
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IAdissCsvFileParser adissCsvFileParser;
        private readonly IDredgeRecordExtractor dredgeRecordExtractor;
        private readonly IOutputDataGenerator outputDataGenerator;
        private readonly IOutputDataCsvFileWriter outputDataCsvFileWriter;
        private AdissCsvFile adissCsvFile;

        public MainWindowViewModel(
            IAdissCsvFileParser adissCsvFileParser,
            IDredgeRecordExtractor dredgeRecordExtractor,
            IOutputDataGenerator outputDataGenerator,
            IOutputDataCsvFileWriter outputDataCsvFileWriter)
        {
            this.adissCsvFileParser = adissCsvFileParser;
            this.dredgeRecordExtractor = dredgeRecordExtractor;
            this.outputDataGenerator = outputDataGenerator;
            this.outputDataCsvFileWriter = outputDataCsvFileWriter;

            BrowseAdditionalDredgeDataFilesCommand = new DelegateCommand(BrowseAdditionalDredgeDataFiles);
            DeleteSelectedDredgeDataFileCommand = new DelegateCommand(DeleteSelectedDredgeDataFile);
            BrowseAdissCsvFileCommand = new DelegateCommand(BrowseAdissCsvFile);
            GenerateOutputCsvFileCommand = new DelegateCommand(GenerateOutputCsvFile, CanGenerateOutputCsvFile);

            DredgeDataFiles.CollectionChanged += (s, e) => GenerateOutputCsvFileCommand?.RaiseCanExecuteChanged();
            UserInputViewModel.PropertyChanged += UserInputViewModel_PropertyChanged;
        }

        private void UserInputViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UserInputViewModel.Dredge))
            {
                if(UserInputViewModel.Dredge.DredgeType == DredgeType.Mechanical)
                {
                    DredgeDataFileDescription = "DRG Files";
                }
                else if(UserInputViewModel.Dredge.DredgeType == DredgeType.Hydraulic)
                {
                    DredgeDataFileDescription = "MDB Files";
                }
                else
                {
                    throw new NotSupportedException($"Dredge type {UserInputViewModel.Dredge.DredgeType} not yet supported for data extraction.");
                }
            }
        }

        public UserInputViewModel UserInputViewModel { get; } = new UserInputViewModel();

        private string dredgeDataFileDescription = "MDB Files";
        public string DredgeDataFileDescription { get => dredgeDataFileDescription; set => SetProperty(ref dredgeDataFileDescription, value); }

        public ObservableCollection<string> DredgeDataFiles { get; } = new ObservableCollection<string>();

        public ICommand BrowseAdditionalDredgeDataFilesCommand { get; }

        private void BrowseAdditionalDredgeDataFiles()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = GetDredgeDataFileFilter(UserInputViewModel.Dredge),
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    if (!DredgeDataFiles.Contains(fileName))
                    {
                        DredgeDataFiles.Add(fileName);
                    }
                }
            }
        }

        private string GetDredgeDataFileFilter(Dredge dredge)
        {
            if (dredge.DredgeType == DredgeType.Mechanical)
            {
                return "DRG File (*.drg)|*.drg";
            }
            else if(dredge.DredgeType == DredgeType.Hydraulic)
            {
                return "CSD MDB File (*.mdb)|*.mdb";
            }
            else
            {
                throw new NotSupportedException($"Dredge type {dredge.DredgeType} not yet supported for data extraction.");
            }
        }

        public string SelectedDredgeDataFile { get; set; }

        public ICommand DeleteSelectedDredgeDataFileCommand { get; }

        private void DeleteSelectedDredgeDataFile()
        {
            DredgeDataFiles.Remove(SelectedDredgeDataFile);
        }

        private string adissCsvFilePath;
        public string AdissCsvFilePath
        {
            get => adissCsvFilePath;
            private set => SetProperty(ref adissCsvFilePath, value);
        }

        public ICommand BrowseAdissCsvFileCommand { get; }

        private void BrowseAdissCsvFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "ADISS CSV File (*.csv)|*.csv"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                AdissCsvFilePath = openFileDialog.FileName;
                LoadAddisCsvFile(AdissCsvFilePath);
            }
        }

        private void LoadAddisCsvFile(string addisCsvFilePath)
        {
            AdissCsvFile newAdissCsvFile = null;
            try
            {
                newAdissCsvFile = adissCsvFileParser.Parse(adissCsvFilePath);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unable to parse ADISS CSV file. Please send it to JanGo@gldd.com for diagnostic purposes.\r\n\r\nException message: {e.GetInnerMostException().Message}");
            }

            adissCsvFile = newAdissCsvFile;
            AdissCsvFileViewModel = newAdissCsvFile != null 
                ? new AdissCsvFileViewModel(adissCsvFile) 
                : null;

            GenerateOutputCsvFileCommand.RaiseCanExecuteChanged();
        }

        private AdissCsvFileViewModel addisCsvFileViewModel;
        public AdissCsvFileViewModel AdissCsvFileViewModel
        {
            get => addisCsvFileViewModel;
            private set => SetProperty(ref addisCsvFileViewModel, value);
        }

        public DelegateCommand GenerateOutputCsvFileCommand { get; }

        private void GenerateOutputCsvFile()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Output CSV File (*.csv)|*.csv",
                FileName = "ADISS Parser Output.csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                DredgeRecord dredgeRecord = null;
                try
                {
                    dredgeRecord = dredgeRecordExtractor.ExtractNearestRecord(UserInputViewModel.Dredge, DredgeDataFiles, adissCsvFile.StartTransitToDisposalAreaDateTime);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unable to query dredge data file/s. Please send it/those to JanGo@gldd.com for diagnostic purposes.\r\n\r\nException message: {e.GetInnerMostException().Message}");
                }

                try
                {
                    outputDataCsvFileWriter.Write(
                        saveFileDialog.FileName,
                        outputDataGenerator.Generate(UserInputViewModel.ToUserInput(), dredgeRecord, adissCsvFile));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unable to generate output data. Please send input data/files to JanGo@gldd.com for diagnostic purposes.\r\n\r\nException message: {e.GetInnerMostException().Message}");
                }
            }
        }

        private bool CanGenerateOutputCsvFile() => adissCsvFile != null && DredgeDataFiles.Count > 0;
    }
}
