using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draft_Winners
{
    public partial class BasketballChooserForm : Form
    {
        List<Player> mForwardList;
        List<Player> mGuardList;
        List<Player> mUtilList;

        Player[] mFixedGuards = new Player[3];
        Player[] mFixedForwards = new Player[3];

        public BasketballChooserForm(List<Player> forwardList, List<Player> guardList)
        {
            InitializeComponent();
            fillComboBox(guard1Box, guardList);
            fillComboBox(guard2Box, guardList);
            fillComboBox(guard3Box, guardList);
            fillComboBox(forward1Box, forwardList);
            fillComboBox(forward2Box, forwardList);
            fillComboBox(forward3Box, forwardList);

            mForwardList = forwardList;
            mGuardList = guardList;
            mUtilList = forwardList.Concat(guardList).ToList();
        }

        private void fillComboBox(ComboBox box, List<Player> list)
        {
            foreach (Player player in list)
            {
                box.Items.Add(player.getName());
            }
        }

        private Player parseComboBox(ComboBox box)
        {
            foreach (Player player in mUtilList)
            {
                if (box.SelectedItem.ToString() == player.getName())
                {
                    return player;
                }
            }
            return null;
        }

        private void fillPlayerArrays()
        {
            mFixedForwards[0] = parseComboBox(forward1Box);
            mFixedForwards[1] = parseComboBox(forward2Box);
            mFixedForwards[2] = parseComboBox(forward3Box);

            mFixedGuards[0] = parseComboBox(guard1Box);
            mFixedGuards[1] = parseComboBox(guard2Box);
            mFixedGuards[2] = parseComboBox(guard3Box);
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            fillPlayerArrays();
        }
    }
}
