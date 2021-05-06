using System.Windows.Markup;
using Yamaha.VOCALOID.VOCALOID5;
using Yamaha.VOCALOID.VOCALOID5.Controls;
using Yamaha.VOCALOID.VOCALOID5.MusicalEditor;

namespace PluginTemplate
{
    /// <summary>
    /// Interaction logic for ExampleDialog.xaml
    /// </summary>
    public partial class ExampleDialog : DialogBase, IComponentConnector
    {
        ExampleDialogViewModel model;

        public ExampleDialog()
        {
            model = new ExampleDialogViewModel();
            DataContext = model;
            InitializeComponent();
        }

        private void On_CreateTrack(object sender, System.Windows.RoutedEventArgs e)
        {
            model.CreateTrackAndNotes();
        }

        private void ReplaceNotes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            model.RenameSelectedNotes();
        }
    }
}
