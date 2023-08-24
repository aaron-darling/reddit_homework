using Reddit;
using reddit_tracker.Service;
using System.ComponentModel;
using System.Configuration;

namespace reTrack.WinForm
{
    public partial class frmMain : Form
    {
        SubredditClient _subClient;
        RedditClient _client;
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
            if (_subClient is not null && _subClient.IsMonitoring)
            {

                lblDownVotesPostName.Text = _subClient.MostDownPost is null ? "" : _subClient.MostDownPost.Title;
                lblDownVotesNum.Text = _subClient.MostDownPost is null ? "" : _subClient.MostDownPost.Downs.ToString();
                lblUpVotesPostName.Text = _subClient.MostUpPost is null ? "" : _subClient.MostUpPost.Title;
                lblUpVotesNum.Text = _subClient.MostUpPost is null ? "" : _subClient.MostUpPost.Ups.ToString();
                lblLastUpdate.Text = _subClient.LastUpdate.ToString();
                lblMostPostsAuthor.Text = _subClient.MostPostsAuthor;
                lblMostPostsNum.Text = _subClient.MostPostsNum.ToString();
              
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnRun.Enabled = false;
                if (_client is null)
                {
                    string appId = ConfigurationManager.AppSettings["AppId"];
                    string refreshToken = ConfigurationManager.AppSettings["RefreshToken"];
                    string accessToken = ConfigurationManager.AppSettings["AccessToken"];
                    _client = new RedditClient(appId: appId, refreshToken: refreshToken, accessToken: accessToken);
                    _subClient = new SubredditClient(_client.Subreddit(subredditNames[0]));


                }
                if (!_subClient.IsMonitoring)
                {
                    _subClient.StartMonitoring();
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
                if (_subClient is not null)
                {
                    _subClient.StopMonitoring();
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
                if (_subClient is not null)
                    _subClient.StopMonitoring();

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
            _subClient.StopMonitoring();
            btnRun.Enabled = true;
            btnStop.Enabled = false;
            Cursor.Current = Cursors.Arrow;

        }
    }
}