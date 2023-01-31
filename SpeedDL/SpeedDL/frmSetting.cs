﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedDL
{
    public partial class frmSetting : MetroFramework.Forms.MetroForm
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog fbd = new FolderBrowserDialog() { Description="Select your path." })
            {
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                Properties.Settings.Default.Path = txtPath.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
                MessageBox.Show("Please select your path.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
