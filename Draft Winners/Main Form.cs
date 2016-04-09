using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Draft_Winners
{
    public partial class MainForm : Form
    {

        #region variables

        private static Stopwatch watch;
        int uniqueID = 0;

        public delegate void ProgressBarIncrement(int progress);
        public ProgressBarIncrement updateBar;

        public enum Sports { Hockey, Football, Basketball, Golf }
        #endregion

        #region constructor
        public MainForm()
        {
            updateBar = new ProgressBarIncrement(updateProgressBar);
            InitializeComponent();
            uniqueID = 0;
            watch = new Stopwatch();
        }
        #endregion

        #region Progress Bar Logic
        private class TeamCompleteListener
        {
            public void Subscribe(GenerateTeams teamGen)
            {
                teamGen.completeEvent += new GenerateTeams.TeamCompleteHandler(saveTeams);
            }

            public void saveTeams(GenerateTeams teamGen, EventArgs e)
            {
                Thread thread = new Thread(() =>
                {
                    String teamList = teamGen.convertTeamsToCSVStrings();
                    saveFile(teamList);
                });

                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        public void updateProgressBar(int progress)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate {
                    Thread.Sleep(1000);

                    if (progress == 0)
                    {
                        workingProgressLabel.Text = "Calculating.";
                    }
                    if (progress == 1)
                    {
                        workingProgressLabel.Text = "Calculating..";
                    }
                    if (progress == 2)
                    {
                        workingProgressLabel.Text = "Calculating...";
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }
        #endregion

        #region StopWatch Setup

        [ConditionalAttribute("DEBUG")]
        private static void startTime()
        {
            watch = new Stopwatch();
            watch.Start();
        }

        [ConditionalAttribute("DEBUG")]
        private static void finishedTime()
        {
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Operation Length: " + elapsedTime);
        }
        #endregion

        #region Calculate Player Values
        private void footballPlayerStatsCalculator(object sender, EventArgs e)
        {
            calculatePlayerStats(Sports.Football);
        }

        private void hockeyPlayerStatsCalculator(object sender, EventArgs e)
        {
            calculatePlayerStats(Sports.Hockey);
        }

        private void basketballPlayerStatsCalculator(object sender, EventArgs e)
        {
            calculatePlayerStats(Sports.Basketball);
        }

        private void golfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculatePlayerStats(Sports.Golf);
        }

        private void calculatePlayerStats(Sports sport)
        {
            GenerateTeams teamGen = parseFile(sport);
            if (teamGen != null)
            {
                saveFile(teamGen.convertPlayersToValues());
            }
        }
        #endregion

        #region File Parsing
        private GenerateTeams parseFile(Sports league)
        {
            startTime();

            workingProgressLabel.Text = "Starting Calculations";
            GenerateTeams teamGenerator;
            int salaryCap = Convert.ToInt32(salaryCapTextBox.Text);
            int threshold = Convert.ToInt32(salaryThresholdTextBox.Text);

            if (league == Sports.Football)
            {
                teamGenerator = new FootballTeamGenerator(salaryCap, threshold);
            }
            else if (league == Sports.Hockey) {
                teamGenerator = new NHLTeamGenerator(salaryCap, threshold);
            }
            else if (league == Sports.Basketball)
            {
                teamGenerator = new BasketballTeamGenerator(salaryCap, threshold);
            }
            else if (league == Sports.Golf)
            {
                teamGenerator = new GolfTeamGenerator(salaryCap, threshold);
            }
            else
            {
                throw new NotImplementedException();
            }

            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = false;

            if (file.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(file.FileName);
                var reader = new StreamReader(File.OpenRead(file.FileName));

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Replace("\"", String.Empty);
                    }


                    Player.Positions pos = Player.convertToEnum(values[0]);
                    if (pos == Player.Positions.INVALID)
                    {
                        continue;
                    }

                    int salary;
                    Int32.TryParse(values[2], out salary);
                    double points;
                    Double.TryParse(values[4], out points);

                    Player player = new Player(pos, values[1], uniqueID++, salary, points);
                    teamGenerator.addPlayer(player);
                }
                reader.Close();
                return teamGenerator;
            }

            return null;
        }

        public static void saveFile(String str)
        {
            finishedTime();
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "CSV Files(*.csv) | *.csv";
            saveFile.Title = "Save Team List";
            saveFile.ShowDialog();

            if (saveFile.FileName != "")
            {
                using (FileStream f = new FileStream(saveFile.FileName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter s = new StreamWriter(f))
                    {
                        s.WriteLine(str);
                    }
                }
            }
        }
        #endregion

        #region Team Generation Methods
        private void openNFLTeamCalculator(object sender, EventArgs e)
        {
            FootballTeamGenerator teamGenerator = (FootballTeamGenerator)parseFile(Sports.Football);
            launchTeamGenerationThread(teamGenerator, GenerateTeams.League.Professional);
        }

        private void openCollegeFootballTeamCalculator(object sender, EventArgs e)
        {
            FootballTeamGenerator teamGenerator = (FootballTeamGenerator)parseFile(Sports.Football);
            launchTeamGenerationThread(teamGenerator, GenerateTeams.League.College);
        }

        private void openNHLTeamCalculator(object sender, EventArgs e)
        {
            NHLTeamGenerator teamGenerator = (NHLTeamGenerator)parseFile(Sports.Hockey);
            launchTeamGenerationThread(teamGenerator, GenerateTeams.League.Professional);
        }

        private void openCollegeBasketballTeamCalculator(object sender, EventArgs e)
        {
            BasketballTeamGenerator teamGenerator = (BasketballTeamGenerator)parseFile(Sports.Basketball);
            launchTeamGenerationThread(teamGenerator, GenerateTeams.League.College);
        }

        private void launchTeamGenerationThread(GenerateTeams generator, GenerateTeams.League league)
        {
            if (generator == null)
            {
                return;
            }

            TeamCompleteListener listener = new TeamCompleteListener();
            listener.Subscribe(generator);
            Thread generationThread = new Thread(() =>
            {
                generator.createTeams(updateBar, league);
                this.Invoke((MethodInvoker)delegate
                {
                    menuStrip1.Visible = true;
                });
            });

            menuStrip1.Visible = false;
            generationThread.IsBackground = true;
            generationThread.Start();
        }

        private void pickPlayersCollegeBasketball(object sender, EventArgs e)
        {
            BasketballTeamGenerator teamGenerator = (BasketballTeamGenerator)parseFile(Sports.Basketball);
            if (teamGenerator == null)
            {
                return;
            }

            BasketballChooserForm form = new BasketballChooserForm(teamGenerator.getForwards(), teamGenerator.getGuards(),
             Convert.ToInt32(salaryCapTextBox.Text), Convert.ToInt32(salaryThresholdTextBox.Text));
            form.Show();
        }

        private void nationalHockeyLeagueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHLTeamGenerator teamGenerator = (NHLTeamGenerator)parseFile(Sports.Hockey);
            if (teamGenerator == null)
            {
                return;
            }

            NHLPlayerSelectionForm form = new NHLPlayerSelectionForm(teamGenerator.getCenters(), teamGenerator.getWingers(),
             teamGenerator.getDefenses(), teamGenerator.getGoalies(), Convert.ToInt32(salaryCapTextBox.Text),
             Convert.ToInt32(salaryThresholdTextBox.Text));
            form.Show();
        }

        private void golfToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GolfTeamGenerator teamGenerator = (GolfTeamGenerator)parseFile(Sports.Golf);
            if (teamGenerator == null)
            {
                return;
            }

            GolfPlayerSelectorForm form = new GolfPlayerSelectorForm(teamGenerator.getGolfers(), Convert.ToInt32(salaryCapTextBox.Text),
             Convert.ToInt32(salaryThresholdTextBox.Text));
            form.Show();
        }
        #endregion
    }
}
