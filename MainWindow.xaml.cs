using CrawlerByCSharp.Views;
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
using System.Windows.Controls.Primitives;

namespace CrawlerByCSharp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        StatementPage statementPage = new StatementPage();
        SettingPage settingPage = new SettingPage();
        FilterPage filterPage = new FilterPage();

        ToggleButton toggleButton = null;
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            this.frame.Content = statementPage;
        }

        /// <summary>
        /// 窗口最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 窗口最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maximize_Click(object sender, RoutedEventArgs e)
        {
            //判断窗口状态
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                maximize.Content = "\xe73a;";
            }
            else
            {
                this.WindowState = WindowState.Normal;
                maximize.Content = "\xe659;";
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, RoutedEventArgs e)
        {
            filterPage.globalDataClose();
            Close();
        }

        /// <summary>
        /// 移动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //判断窗口状态
            if (this.WindowState == WindowState.Normal)
            {
                DragMove();
            }
           
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (toggleButton != null)
                toggleButton.IsChecked = false;

            toggleButton = sender as ToggleButton;
        }


        private void statementButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = statementPage;
        }

        private void settingButton_Click(object sender, RoutedEventArgs e)
        {
            settingPage.LoadSettingFromUI(this.backBorder.Background.Opacity);
            frame.Content = settingPage;
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = filterPage;
        }
    }
}
