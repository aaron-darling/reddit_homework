using RedTrack.Models;
using RedTrack.Services;
using RedTrack.Services.Moniters;
using RedTrack.Services.Handlers;
using System.ComponentModel;
using System.Configuration;

namespace reTrack.WinForm
{
    public partial class frmMain : Form
    {
        PostAnalyticsMonitor _monitor;
        
        string[] subredditNames = ConfigurationManager.AppSettings["Subreddits"].Split(',');

        public frmMain()
        {
            InitializeComponent();

            timer1.Interval = int.Parse(ConfigurationManager.AppSettings["UpdateInterval"]) * 100;
            timer1.Tick += TimerTick;
            timer1.Enabled = true;
            btnRun.Enabled = true;
        }

        void TimerTick(object sender, EventArgs e)
        {
            if (_monitor is not null && _monitor.IsMonitoring)
            {
                
                lblDownVotesPostName.Text = _monitor.MostDownVotes is null ? "" : _monitor.MostDownVotes.Title;
                lblDownVotesNum.Text = _monitor.MostDownVotes is null ? "" : _monitor.MostDownVotes.Downs.ToString();
                lblUpVotesPostName.Text = _monitor.MostUpVotes is null ? "" : _monitor.MostUpVotes.Title;
                lblUpVotesNum.Text = _monitor.MostUpVotes is null ? "" : _monitor.MostUpVotes.Ups.ToString();
                lblLastUpdate.Text = _monitor.LastUpdated.ToString();
                lblMostPostsAuthor.Text = _monitor.MostPostsAuthor;
                lblMostPostsNum.Text = _monitor.MostPostsNumber.ToString();
                lblLastUpdate.Text = _monitor.LastUpdated.ToString();
              
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnRun.Enabled = false;
                if (_monitor is null)
                {
                    string appId = ConfigurationManager.AppSettings["AppId"];
                    string refreshToken = ConfigurationManager.AppSettings["RefreshToken"];
                    RateLimiter rateLimiter = new RateLimiter();
                    ApiRequestHandler handler = new ApiRequestHandler(rateLimiter, appId, refreshToken);
                    
                    RedditApiService redditService = new RedditApiService(handler);
                    
                    _monitor = new PostAnalyticsMonitor(redditService, subredditNames[0]);

                  

                }
                if (!_monitor.IsMonitoring)
                {
                    _monitor.StartMonitoring();
                }
                btnStop.Enabled = true;
                Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnRun.Enabled = false;
                if (_monitor is not null)
                {
                    _monitor.StopMonitoring();
                }
                btnRun.Enabled = true;
                Cursor.Current = Cursors.Arrow;

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (_monitor is not null)
                    _monitor.StopMonitoring();

                base.OnFormClosing(e);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _monitor.StopMonitoring();
            btnRun.Enabled = true;
            btnStop.Enabled = false;
            Cursor.Current = Cursors.Arrow;

        }
    }
}