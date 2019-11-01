using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MIPS32_Assembler.AssemblerLibrary;
using System.Text;
using System.IO;

namespace AssemblerDemo_Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string FileLocation;

        public MainWindow()
        {
            InitializeComponent();
        }



        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog newDialog = new Microsoft.Win32.OpenFileDialog();
            newDialog.ShowDialog();
            FileLocation = newDialog.FileName;
            int i = 1;
            foreach (var Line in File.ReadAllLines(FileLocation))
            {
                InstructionLine.AppendText(i.ToString());
                InstructionLine.AppendText(Environment.NewLine);
                // InstructionLine.AppendText(Environment.NewLine);

                AssemblyTextBox.AppendText(Line);
                AssemblyTextBox.AppendText(Environment.NewLine);
                // AssemblyTextBox.AppendText(Environment.NewLine);
                i++;
            }

        }

        private void CompileButton_Click(object sender, RoutedEventArgs e)
        {
            AssemblerPass1 newPass = new AssemblerPass1(FileLocation);

            int i = 1;
            foreach (var Line in newPass.replaceLabelInstr)
            {
                resolvedLineNumbers.AppendText(i.ToString());
                resolvedLineNumbers.AppendText(Environment.NewLine);

                resolvedLabelsNoWhiteSpace.AppendText(Line);
                resolvedLabelsNoWhiteSpace.AppendText(Environment.NewLine);
                i++;
            }
            string filepath3 = System.IO.Path.GetDirectoryName(FileLocation) + @"\" + System.IO.Path.GetFileNameWithoutExtension(FileLocation) + ".mac";
            foreach (var Line in File.ReadAllLines(filepath3))
            {
                MachineCodeTextBox.AppendText(Line);
                MachineCodeTextBox.AppendText(Environment.NewLine);
                //MachineCodeTextBox.AppendText(Environment.NewLine);
            }



        }
    }
}

