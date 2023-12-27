using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;

namespace kursach
{
    class MainWindowViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ObservableCollection<Doc> docs = DataAccess.LoadUserData();
        Doc selectedDoc;
        public MainWindowViewModel() { }
        public RelayCommand AddCommand =>
            new RelayCommand(execute => AddDoc());
        public RelayCommand OpenCommand =>
        new RelayCommand(execute => OpenDoc(), 
            canExecute => selectedDoc != null);
        public RelayCommand DeleteCommand =>
        new RelayCommand(execute => DeleteDoc(),
            canExecute => selectedDoc != null);
        public RelayCommand CloseCommand =>
            new RelayCommand(execute => OnWindowClosing());

        public ObservableCollection<Doc> Docs 
        {
            get 
            {  
                return docs;
            } 
            set
            {
                docs = value;
                OnPropertyChanged("Docs");
            }
        }
        public Doc SelectedDoc
        {
            get
            {
                return selectedDoc;
            }
            set
            {
                selectedDoc = value;
                OnPropertyChanged("SelectedDoc");
            }
        }
        public void AddDoc()
        {
            Redactor redactor = new Redactor();
            redactor.DocumentSaved += (sender, args) =>
            {
                Docs.Add(args.SavedDocument);
            };
            redactor.ShowDialog();
        }
        public void OpenDoc()
        {
            if (SelectedDoc != null)
            {
                Redactor redactor = new Redactor();
                try
                {
                    if (File.Exists(SelectedDoc.Path))
                    {
                        FileStream fileStream = new FileStream(SelectedDoc.Path, FileMode.Open);
                        TextRange range = new TextRange(redactor.rtbEditor.Document.ContentStart, redactor.rtbEditor.Document.ContentEnd);
                        range.Load(fileStream, DataFormats.Rtf);
                        redactor.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("File does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void DeleteDoc()
        {
            if (SelectedDoc != null)
            {
                try
                {
                    File.Delete(SelectedDoc.Path);
                    Docs.Remove(SelectedDoc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void OnWindowClosing()
        {
            DataAccess.SaveUserData(Docs);
        }

    }
}
