using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDocumentsApp
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream stream = new("document.xml", FileMode.Create))
            {
                XamlWriter.Save(docViewer.Document, stream);
            }
        }
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream stream = new("document.xml", FileMode.Open))
            {
                FlowDocument document = XamlReader.Load(stream) as FlowDocument;
                docViewer.Document = document;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            docViewer.ClearValue(FlowDocumentReader.DocumentProperty);
        }


    }
}