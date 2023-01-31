namespace SpeedDL
{
    public partial class speedDLForm : MetroFramework.Forms.MetroForm
    {
        public speedDLForm()
        {
            InitializeComponent();
        }

        private void speedDLForm_Load(object sender, EventArgs e)
        {
            string fileName = string.Format("{0}/data.dat", Application.StartupPath);
            if(File.Exists(fileName))
                App.DB.ReadXml(fileName);

            foreach(Database.FilesRow row in App.DB.Files)
            {
                ListViewItem item = new ListViewItem(row.Id.ToString());
                item.SubItems.Add(row.Url);
                item.SubItems.Add(row.FileName);
                item.SubItems.Add(row.FileSize);
                item.SubItems.Add(row.DateTime.ToLongDateString());
                listView1.Items.Add(item);
            }
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsSettings_Click(object sender, EventArgs e)
        {
            using(frmSetting frm = new frmSetting())
            {
                frm.ShowDialog();
            }
        }

        private void metroListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsAddUrl_Click(object sender, EventArgs e)
        {
            using(frmAddUrl frm = new frmAddUrl())
            {
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    frmDownload frmDownload = new frmDownload(this);
                    frmDownload.Url = frm.Url;
                    frmDownload.Show();
                }
            }
        }

        private void tsRemove_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for(int i = listView1.SelectedItems.Count; i > 0; i--)
                {
                    ListViewItem item = listView1.SelectedItems[i - 1];
                    App.DB.Files.Rows[item.Index].Delete();
                    listView1.Items[item.Index].Remove();
                }

                // Save
                App.DB.AcceptChanges();
                App.DB.WriteXml(string.Format("{0}/data.dat", Application.StartupPath));
            }
        }
    }
}