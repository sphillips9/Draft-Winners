using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Draft_Winners
{
    public partial class MainForm : Form
    {
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

        private static Stopwatch watch;
        int uniqueID = 0;

        public delegate void ProgressBarIncrement(int progress);
        public ProgressBarIncrement updateBar;

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

        public MainForm()
        {
            updateBar = new ProgressBarIncrement(updateProgressBar);
            InitializeComponent();
            uniqueID = 0;
            watch = new Stopwatch();
        }

        // Opens NFL team file
        private void openCSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FootballTeamGenerator teamGenerator = (FootballTeamGenerator)parseFile(Leagues.NFL);
            if (teamGenerator == null)
            {
                return;
            }

            TeamCompleteListener listener = new TeamCompleteListener();
            listener.Subscribe(teamGenerator);
            Thread generationThread = new Thread(() =>
            {
                teamGenerator.generateTopNFLTeams(updateBar);
                this.Invoke((MethodInvoker)delegate
                {
                    menuStrip1.Visible = true;
                });
            });

            menuStrip1.Visible = false;
            generationThread.IsBackground = true;
            generationThread.Start();
        }

        private void openCollegeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FootballTeamGenerator teamGenerator = (FootballTeamGenerator)parseFile(Leagues.NFL);
            if (teamGenerator == null)
            {
                return;
            }

            TeamCompleteListener listener = new TeamCompleteListener();
            listener.Subscribe(teamGenerator);
            Thread generationThread = new Thread(() =>
            {
                teamGenerator.generateTopCollegeTeams(updateBar);
                this.Invoke((MethodInvoker)delegate
                {
                    menuStrip1.Visible = true;
                });
            });

            menuStrip1.Visible = false;
            generationThread.IsBackground = true;
            generationThread.Start();
        }

        private void openNHLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHLTeamGenerator teamGenerator = (NHLTeamGenerator)parseFile(Leagues.NHL);
            if (teamGenerator == null)
            {
                return;
            }

            TeamCompleteListener listener = new TeamCompleteListener();
            listener.Subscribe(teamGenerator);
            Thread generationThread = new Thread(() =>
            {
                teamGenerator.generateNFLTeams(updateBar);
                this.Invoke((MethodInvoker)delegate
                {
                    menuStrip1.Visible = true;
                });
            });

            menuStrip1.Visible = false;
            generationThread.IsBackground = true;
            generationThread.Start();
        }

        private void footballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTeams teamGen = parseFile(Leagues.NFL);
            if (teamGen != null)
            {
                saveFile(teamGen.convertPlayersToValues());
            }
        }

        private void hockeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTeams teamGen = parseFile(Leagues.NHL);
            if (teamGen != null)
            {
                saveFile(teamGen.convertPlayersToValues());
            }
        }

        private GenerateTeams parseFile(Leagues league)
        {
            startTime();
            workingProgressLabel.Text = "Starting Calculations";
            GenerateTeams teamGenerator;

            if (league == Leagues.NFL)
            {
                teamGenerator = new FootballTeamGenerator(Convert.ToInt32(salaryCapTextBox.Text), Convert.ToInt32(salaryThresholdTextBox.Text));
            }
            else if (league == Leagues.NHL) {
                teamGenerator = new NHLTeamGenerator(Convert.ToInt32(salaryCapTextBox.Text), Convert.ToInt32(salaryThresholdTextBox.Text));
            }
            else
            {
                teamGenerator = null;
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


                    Player.Positions pos = convertToEnum(values[0]);
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

        private Player.Positions convertToEnum(String playerPosition)
        {
            if (playerPosition == Player.Positions.QB.ToString())
            {
                return Player.Positions.QB;
            }
            else if (playerPosition == Player.Positions.RB.ToString())
            {
                return Player.Positions.RB;
            }
            else if (playerPosition == Player.Positions.DST.ToString())
            {
                return Player.Positions.DST;
            }
            else if (playerPosition == Player.Positions.TE.ToString())
            {
                return Player.Positions.TE;
            }
            else if (playerPosition == Player.Positions.WR.ToString())
            {
                return Player.Positions.WR;
            }
            else if (playerPosition == Player.Positions.C.ToString())
            {
                return Player.Positions.C;
            }
            else if (playerPosition == Player.Positions.RW.ToString())
            {
                return Player.Positions.RW;
            }
            else if (playerPosition == Player.Positions.LW.ToString())
            {
                return Player.Positions.LW;
            }
            else if (playerPosition == Player.Positions.D.ToString())
            {
                return Player.Positions.D;
            }
            else if (playerPosition == Player.Positions.G.ToString())
            {
                return Player.Positions.G;
            }

            return Player.Positions.INVALID;
        }

        public enum Leagues {NHL, NFL}
    }
}
