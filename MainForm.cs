using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace KancolleSuspender
{
    public partial class MainForm : Form
    {

        private WindowItem monitoredWindow;
        private FakeWindow fakeWindow = new FakeWindow();
        private bool running = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            intervalInput.Value = 5;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            RefreshWindowList();
        }

        private void RefreshWindowList()
        {
            windowSelector.Items.Clear();
            Helper.EnumWindowsProc callback = (hWnd, lParam) =>
            {
                if (Helper.IsWindowVisible(hWnd))
                    windowSelector.Items.Add(new WindowItem(hWnd));
                return true;
            };
            Helper.EnumWindows(callback, IntPtr.Zero);
            int index = -1;
            foreach(WindowItem item in windowSelector.Items)
            {
                index++;
                string title = Helper.GetWindowText(item.hWnd);
                if (title == "提督業も忙しい！" || title == "KanColleViewer!") {
                    break;
                }
            }
            windowSelector.SelectedIndex = index;

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                startMonitor((int)intervalInput.Value * 1000);
            }
            else
            {
                stopMonitor();
                
            }
        }


        private void startMonitor(int interval)
        {
            running = true;
            windowSelector.Enabled = false;
            intervalInput.Enabled = false;
            startButton.Text = "Stop";
            monitoredWindow = (WindowItem)windowSelector.SelectedItem;

            if (!Helper.IsWindow(monitoredWindow.hWnd))
            {
                MessageBox.Show(this, "invalid window");
            }

            detectionTimer.Interval = interval;
            detectionTimer.Enabled  = true;
        }

        private void stopMonitor()
        {
            running = false;
            detectionTimer.Enabled = false;
            windowSelector.Enabled = true;
            intervalInput.Enabled = true;
            startButton.Text = "Start";
        }

        private void monitor()
        {
            if (!Helper.IsWindow(monitoredWindow.hWnd))
                stopMonitor();
            if(Helper.IsIconic(monitoredWindow.hWnd) && !fakeWindow.Visible)
            {
                List<IntPtr> targetWindows = new List<IntPtr>();
                Debug.WriteLine("hide & suspending {0} {1}", monitoredWindow.hWnd, monitoredWindow.ownerProcess.Id);
                Helper.EnumWindows((hWnd, lParam) => {
                    if (Helper.IsWindowVisible(hWnd) && Helper.ProcessFromWindow(hWnd).Id == monitoredWindow.ownerProcess.Id)
                        targetWindows.Add(hWnd);
                    return true;
                }, IntPtr.Zero);
                foreach (var hWnd in targetWindows)
                {
                    Helper.ShowWindow(hWnd, Helper.ShowWindowCommands.Hide);
                }
                Helper.SuspendProcess(monitoredWindow.ownerProcess);
                monitoredWindow.processSuspended = true;
                fakeWindow.ActivateCallback = () => {
                    Helper.ResumeProcess(monitoredWindow.ownerProcess);
                    monitoredWindow.processSuspended = false;
                    foreach (var hWnd in targetWindows)
                    {
                        Helper.ShowWindow(hWnd, Helper.ShowWindowCommands.Show);
                    }
                    Helper.ShowWindow(monitoredWindow.hWnd, Helper.ShowWindowCommands.Restore);
                    fakeWindow.Close();
                    fakeWindow = new FakeWindow();
                    detectionTimer.Enabled = true;
                };
                detectionTimer.Enabled = false;
                fakeWindow.Show();
            }

        }

        private void detectionTimer_Tick(object sender, EventArgs e)
        {
            monitor();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshWindowList();
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            if(monitoredWindow != null && Helper.IsWindow(monitoredWindow.hWnd))
            {
                Helper.ResumeProcess(monitoredWindow.ownerProcess);
                Helper.ShowWindow(monitoredWindow.hWnd, Helper.ShowWindowCommands.Show);
                Helper.ShowWindow(monitoredWindow.hWnd, Helper.ShowWindowCommands.Restore);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Icon = this.Icon;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = this.Text;
                notifyIcon.BalloonTipText = "Click the tray icon to restore.";
                notifyIcon.ShowBalloonTip(2000);
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Icon = null;
        }
    }

    public class WindowItem
    {
        public WindowItem(IntPtr hWnd_ctor)
        {
            hWnd = hWnd_ctor;
            processSuspended = false;
        }
        public WindowItem(){}
        private IntPtr _hWnd;
        public IntPtr hWnd {
            get { return _hWnd; }
            set
            {
                ownerProcess = Helper.ProcessFromWindow(value);
                _hWnd = value;
            }
        }

        public Process ownerProcess { get; private set; }
        public bool processSuspended { get; set; }
        public override string ToString()
        {
            string result = String.Format("{0:X8} - {1} - {2}", (uint)hWnd, ownerProcess.ProcessName, Helper.GetWindowText(hWnd));
            return result;
        }
    }
}
