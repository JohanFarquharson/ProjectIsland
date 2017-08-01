using System;
using System.Windows.Forms;

namespace GameServer
{
    public partial class GameServerSettingsForm : Form
    {
        private GameServerForm GameServerForm { get; set; }

        public GameServerSettingsForm(GameServerForm gameServerForm)
        {
            InitializeComponent();
            GameServerForm = gameServerForm;
        }

        private void frmServerSettings_Load(object sender, EventArgs e)
        {
            nudHeight.Value = GameServerForm.MapHeight;
            nudWidth.Value = GameServerForm.MapWidth;
            nudSeed.Value = GameServerForm.MapSeed;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            GameServerForm.MapHeight = (int)nudHeight.Value;
            GameServerForm.MapWidth = (int)nudWidth.Value;
            GameServerForm.MapSeed = (int)nudSeed.Value;

            Hide();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
