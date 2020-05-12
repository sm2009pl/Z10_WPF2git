using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Z10_WPF2
{
    public partial class Watcher : Window
    {
        private Content _fileContent = new Content();
        private FileSystemWatcher _watcher = new FileSystemWatcher();
        public Watcher()
        {
            InitializeComponent();
            fileContentTextBox.DataContext = _fileContent;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Changed += _watcher_Changed;
        }
        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            LoadFile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Wybierz plik do obserwowania",
                Filter = "Textfile|*.txt"
            };
            var result = openFileDialog.ShowDialog(this);
            if (!result.HasValue || !result.Value)
            {
                return;
            }
            _fileContent.Path = openFileDialog.FileName;
            _watcher.Path = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, string.Empty);
            _watcher.EnableRaisingEvents = true;
            LoadFile();
        }
        private void LoadFile()
        {
            var text = File.ReadAllText(_fileContent.Path);
            _fileContent.ContentText = text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadFile();
        }
    }
}
