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

namespace work_5
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

        private void btn_OF_Click(object sender, RoutedEventArgs e)
        {
            // 檔案開啟物件
            var fd = new Microsoft.Win32.OpenFileDialog();
            // 設定檔案過濾
            fd.Filter = "音訊檔案(*.mp3,*.3gp,*.wma)|*.mp3; *.3gp; *.wma|影片檔案(*.mp4, *.avi, *.mpeg, *.wmv)|*.mp4; *.avi; *.mpeg; *.wmv|所有檔案(*.*)|*.*";
            //fd.Filter = "MP3(*.mp3)|*.mp3|MP4(*.mp4)|*.mp4|3GP(*.3gp)|*.3gp|WMA(*.wma)|*.wma|MOV(*.mov)|*.mov|AVI(*.avi)|*.avi|WMV(*.wmv)|*.wmv|MPEG(*.mpeg)|*.mpeg|所有檔案(*.*)|*.*";
            // 設定預設開啟檔案位置，設定為桌面
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // 開啟對話框
            fd.ShowDialog();
            // 如果使用者有選取檔案，就把檔案位置與檔名儲存到filename中
            string filename = fd.FileName;
            if (filename != "")
            {
                // 將檔案位置與檔名顯示在輸入文字框裡面
                txt_FL.Text = filename;
                // 將檔案位置與檔名轉化成URI，一種用來設定檔案資源定位的位置資料 
                Uri u = new Uri(filename);
                // 將URI放進影音元件中
                MediaShow.Source = u;
                // 設定這個影音的聲音大小（可有可無）
                MediaShow.Volume = 0.5f;
                // 將影音進行播放
                MediaShow.LoadedBehavior = MediaState.Play;
            }
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            MediaShow.LoadedBehavior = MediaState.Play;
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            MediaShow.LoadedBehavior = MediaState.Pause;
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            MediaShow.LoadedBehavior = MediaState.Stop;
        }

        private void btn_leave_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

