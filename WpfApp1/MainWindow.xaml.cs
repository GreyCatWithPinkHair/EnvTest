using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Sanford.Multimedia.Midi;

namespace WpfApp1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Together_OnClick(object sender, RoutedEventArgs e) {
            using var outDevice = new OutputDevice(0);
            var baseTone = new ChannelMessageBuilder {
                Command = ChannelCommand.NoteOn,
                MidiChannel = 0,
                Data1 = 64,
                Data2 = 100
            };

            var topTone = new ChannelMessageBuilder {
                Command = ChannelCommand.NoteOn,
                MidiChannel = 0,
                Data1 = 69,
                Data2 = 100
            };
            
            baseTone.Build();
            topTone.Build();
            outDevice.Send(baseTone.Result);
            outDevice.Send(topTone.Result);

            Thread.Sleep(1400);

            baseTone.Command = ChannelCommand.NoteOff;
            topTone.Command = ChannelCommand.NoteOff;
            baseTone.Data2 = 0;
            topTone.Data2 = 0;
            baseTone.Build();
            topTone.Build();
            outDevice.Send(baseTone.Result);
            outDevice.Send(topTone.Result);
        }

        private void Separately_OnClick(object sender, RoutedEventArgs e) {
            using var outDevice = new OutputDevice(0);
            var baseTone = new ChannelMessageBuilder {
                Command = ChannelCommand.NoteOn,
                MidiChannel = 0,
                Data1 = 64,
                Data2 = 100
            };

            var topTone = new ChannelMessageBuilder {
                Command = ChannelCommand.NoteOn,
                MidiChannel = 0,
                Data1 = 69,
                Data2 = 100
            };
            
            baseTone.Build();
            outDevice.Send(baseTone.Result);
            
            Thread.Sleep(1250);
            
            baseTone.Command = ChannelCommand.NoteOff;
            baseTone.Data2 = 0;
            baseTone.Build();
            outDevice.Send(baseTone.Result);
            
            topTone.Build();
            outDevice.Send(topTone.Result);

            Thread.Sleep(1250);
            
            topTone.Command = ChannelCommand.NoteOff;
            topTone.Data2 = 0;
            topTone.Build();
            outDevice.Send(topTone.Result);
        }
    }
}
