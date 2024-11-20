//using Microsoft.Win32;
//using System.IO;
//using System.Windows;

//namespace MigrationsTool
//{
//    internal class CreateFolder : MainWindow
//    {
//        public void MakeFolder(object sender, RoutedEventArgs e)
//        //{
//            OpenFolderDialog openFolderDialog = new();

//            if (openFolderDialog.ShowDialog() == true)
//            {
//                string selectedPath = openFolderDialog.FolderName;
//                string newFolderName = folderName.Text.Trim();
//                string newFolderPath = Path.Combine(selectedPath, newFolderName);

//                if (string.IsNullOrEmpty(newFolderName))
//                {
//                    MessageBox.Show("You forgot the foldername");
//                    return;
//                }

//                if (Directory.Exists(newFolderPath))
//                {
//                    MessageBox.Show("The path already exists");
//                    return;
//                }

//                DirectoryInfo directoryInfo = Directory.CreateDirectory(newFolderPath);
//                MessageBox.Show($"Done");
//            }

//        }

//    }

//}

