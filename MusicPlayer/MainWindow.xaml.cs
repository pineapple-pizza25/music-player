using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps;
using System.Xml.Linq;
using System.Media;

namespace MusicPlayer
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

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string[] music = Directory.GetFiles(dir, "*.wav");
            string firstSong = Directory.GetFiles(dir).FirstOrDefault();
            Song head = null;
           // head = push(head, firstSong);
            int i = 0;

            foreach (string song  in music)
            {
                head = push(head, music[i]);
                i++;
            }


           // head = push(head, firstSong);
          //  head = push(head, "C:/snmis/Music/Music/Mastodon - Blood And Thunder.mp3");
           // head = push(head, "C:/Users/snmis/Music/Music/Scourge of Iron.mp3");
           // head = push(head, "C:/Users/snmis/Music/Music/Transilvanian Hunger (Studio).mp3");


            txtSong.Text = "Contents of Circular "
                          + "Linked List\n ";

            playSongs(head);
        }

        static Song push(Song head_ref, string songURL)
        {
            Song ptr1 = new Song();
            Song temp = head_ref;
            ptr1.songURL = songURL;
            ptr1.next = head_ref;

            // If linked list is not 
            // null then set the next 
            // of last node 
            if (head_ref != null)
            {
                while (temp.next != head_ref)
                {
                    temp = temp.next;
                }
                
                temp.next = ptr1;
            }

            // For the first node 
            else
                ptr1.next = ptr1;

            head_ref = ptr1;
            return head_ref;
        }

        // Function to print nodes in 
        // the Circular Linked List 
        void playSongs(Song head)
        {
            Song temp = head;

            if (head != null)
            {
                do
                {
                    SoundPlayer musicPlayer = new SoundPlayer();
                    musicPlayer.SoundLocation = temp.songURL;
                    musicPlayer.Play();

                    txtSong.Text = temp.songURL;
                    temp = temp.next;
                } while (temp != head);
            }
        }
    }
}