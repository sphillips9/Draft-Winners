using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Draft_Winners
{
    public partial class Showdown_Player_Form : Form
    {

        List<Player> mPlayers;

        public Showdown_Player_Form(List<Player> players)
        {
            InitializeComponent();
            mPlayers = new List<Player>();
            mPlayers.AddRange(players);
            fillComboBox(player1Box, players);
            fillComboBox(player2Box, players);
            fillComboBox(player3Box, players);
            fillComboBox(player4Box, players);
            fillComboBox(player5Box, players);
            fillComboBox(player6Box, players);
        }

        private void CreateTeamButton_Click(object sender, EventArgs e)
        {
            ShowdownTeamGenerator gen = new ShowdownTeamGenerator(50_000, 1000);
            // Ideally this should be dynamically created with an array of CheckBoxes, and then filter through all of them in a loop, instead of this garbage broken out if-statement code.
            Player p1 = parseComboBox(player1Box, mPlayers);
            if (p1 != null)
            {
                gen.addPlayerToFixedList(p1);
            }
            Player p2 = parseComboBox(player2Box, mPlayers);
            if (p2 != null)
            {
                gen.addPlayerToFixedList(p2);
            }
            Player p3 = parseComboBox(player3Box, mPlayers);
            if (p3 != null)
            {
                gen.addPlayerToFixedList(p3);
            }
            Player p4 = parseComboBox(player4Box, mPlayers);
            if (p4 != null)
            {
                gen.addPlayerToFixedList(p4);
            }
            Player p5 = parseComboBox(player5Box, mPlayers);
            if (p5 != null)
            {
                gen.addPlayerToFixedList(p5);
            }
            Player p6 = parseComboBox(player6Box, mPlayers);
            if (p6 != null)
            {
                gen.addPlayerToFixedList(p6);
            }

            foreach (Player pl in mPlayers)
            {
                gen.addPlayer(pl);
            }

            Thread generatorThread = new Thread(() =>
            {
                gen.createTeams(null, GenerateTeams.League.Professional);
                this.Invoke((MethodInvoker)delegate
                {
                    createTeamButton.Visible = true;
                    MainForm.saveFile(gen.convertTeamsToCSVStrings());
                });
            });

            createTeamButton.Visible = false;
            generatorThread.Start();
        }

        private void fillComboBox(ComboBox box, List<Player> list)
        {
            foreach (Player player in list)
            {
                box.Items.Add(player.getName());
            }
        }

        private Player parseComboBox(ComboBox box, List<Player> list)
        {
            if (String.IsNullOrEmpty(box.Text))
            {
                return null;
            }

            foreach (Player player in list)
            {
                if (box.SelectedItem.ToString() == player.getName())
                {
                    return player;
                }
            }
            return null;
        }
    }
}
