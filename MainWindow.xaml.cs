using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace MigrationsTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void MakeFolder(object sender, RoutedEventArgs e)
        {
            /////////////////////////////////////////////
            OpenFolderDialog openFolderDialog = new();

            if (openFolderDialog.ShowDialog() == true)
            {
                string selectedPath = openFolderDialog.FolderName;
                string newFolderName = folderName.Text.Trim();
                string structure = @"BLL\Controllers\";
                string newFolderPath = Path.Combine(selectedPath, newFolderName, structure);

                if (string.IsNullOrEmpty(newFolderName))
                {
                    MessageBox.Show("You forgot the foldername");
                    return;
                }

                if (Directory.Exists(newFolderPath))
                {
                    MessageBox.Show("The path already exists");
                    return;
                }

                DirectoryInfo directoryInfo = Directory.CreateDirectory(newFolderPath);
                MessageBox.Show($"Done");
                ////////////////////////////////////////////////
                OpenFileDialog openFileDialog = new();

                if (openFileDialog.ShowDialog() == true)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    MessageBox.Show($"Selected file: {selectedFilePath}");

                    string[] lines = File.ReadAllLines(selectedFilePath);
                    List<string> newLines = new List<string>();

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }

                        newLines.Add(line);
                        if (line.Trim() == "}")
                        {
                            newLines.Add("");
                        }
                    }

                    string newContent = string.Join(Environment.NewLine, newLines);

                    string newFilePath = Path.Combine(newFolderPath, Path.GetFileName(selectedFilePath));

                    File.WriteAllText(newFilePath, newContent);
                    MessageBox.Show($"File saved at: {newFilePath}");

                }
            }

        }

    }

}
