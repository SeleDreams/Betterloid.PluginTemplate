using System;
using Yamaha.VOCALOID.VDM;
using Yamaha.VOCALOID.VOCALOID5;
using Yamaha.VOCALOID.VOCALOID5.MusicalEditor;
using Yamaha.VOCALOID.VOCALOID5.TrackEditor;
using Yamaha.VOCALOID.VSM;
using Yamaha.VOCALOID.VSStyle;

namespace PluginTemplate
{
    public class ExampleDialogViewModel
    {
        MainWindow MainWindow;
        TrackEditorDivision TrackEditorDivision;
        TrackEditorViewModel TrackEditorViewModel;
        MusicalEditorDivision MusicalEditorDivision;
        MusicalEditorViewModel MusicalEditor;
        VoiceBank DefaultVoicebank;


        public ExampleDialogViewModel()
        {
            // If you need to find the name of a specific property you can rely on DNSpy or the visual studio WPF debugger to find it
            MainWindow = App.Current.MainWindow as MainWindow;
            MusicalEditorDivision = MainWindow.FindName("xMusicalEditorDiv") as MusicalEditorDivision;
            MusicalEditor = MusicalEditorDivision.DataContext as MusicalEditorViewModel;
            TrackEditorDivision = MainWindow.FindName("xTrackEditorDiv") as TrackEditorDivision;
            TrackEditorViewModel = TrackEditorDivision.DataContext as TrackEditorViewModel;
            DefaultVoicebank = App.DatabaseManager.DefaultVoiceBank;
        }

        public void CreateTrackAndNotes()
        {
            using (Transaction transaction = new Transaction(TrackEditorViewModel.Sequence)) // This is important, without using a transaction your modifications won't be applied immediately
            {
                try
                {
                    // Create the new track and set its effect block
                    WIVSMMidiTrack track = TrackEditorViewModel.AddTrack(VSMTrackType.Midi) as WIVSMMidiTrack;
                    App.EffectEngine.SetEffectBlock(track);

                    // Now create the VOCALOID part and set its effect block
                    WIVSMMidiPart part = track.InsertPart(VSMAbsTick.Zero, new VSMRelTick(7680), "Created by ExamplePlugin");
                    var partEffectBlock = App.EffectEngine.SetEffectBlock(part);

                    // We need to assign a voicebank to the VOCALOID part as well as a style, we'll use the default voicebank and the default style
                    part.SetVoiceBankID(DefaultVoicebank.CompID);
                    part.EffectManager.InsertVoiceDefaultStyleEffects(DefaultVoicebank);
                    Style voiceDefaultStyle = part.EffectManager.GetVoiceDefaultStyle(App.DatabaseManager.DefaultVoiceBank);
                    part.StyleName = voiceDefaultStyle.Name;

                    // Now let's insert the notes !
                    var note1 = part.InsertNote(new VSMRelTick(0), new VSMNoteEvent(1000, 60, 100), part.GetDefaultNoteExpression(), "he", "h e", true);
                    part.InsertNote(new VSMRelTick(1001), new VSMNoteEvent(1000, 62, 100), part.GetDefaultNoteExpression(), "ro", "4 o", true);
                }
                catch (Exception ex) // Don't forget to catch errors if you don't want the whole software to crash in case of an error
                {
                    MessageBoxDeliverer.GeneralError("An error occurred while adding the track !");
                    MessageBoxDeliverer.GeneralError(ex.GetType().ToString() + " : " + ex.Message);
                }

            }
        }

        public void RenameSelectedNotes()
        {
            using (Transaction transaction = new Transaction(TrackEditorViewModel.Sequence))
            {
                WIVSMMidiPart activePart = MusicalEditor.ActivePart;
                if (activePart == null)
                {
                    MessageBoxDeliverer.GeneralError("No active part selected !");
                    return;
                }
                foreach (WIVSMNote note in activePart.Notes)
                {
                    if (note.IsSelected)
                    {
                        note.Lyric = "la";
                        note.SetPhonemes("4 a", true);
                    }
                }
            }
        }
    }
}
