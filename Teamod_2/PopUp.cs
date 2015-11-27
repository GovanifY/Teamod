using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace Teamod_2
{
	public partial class MainForm : Form
	{
		private ListView PopUpListView;
		private ColumnHeader columnHeader1;
		private Button PopUpValid;
		private Form PopUpMainForm;
		
		private void PopUpInitializeComponent()
		{
			this.PopUpMainForm = new Form();
			this.PopUpListView = new ListView();
			this.columnHeader1 = new ColumnHeader();
			this.PopUpValid = new Button();
			PopUpMainForm.SuspendLayout();
			// 
			// PopUpListView
			// 
			this.PopUpListView.BackColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.PopUpListView.BackgroundImageTiled = true;
			this.PopUpListView.Columns.Clear();
			this.PopUpListView.Columns.AddRange(new ColumnHeader[] {
			this.columnHeader1});
			this.PopUpListView.Dock = DockStyle.Top;
			this.PopUpListView.ForeColor = Color.White;
			this.PopUpListView.FullRowSelect = true;
			this.PopUpListView.HeaderStyle = ColumnHeaderStyle.None;
			this.PopUpListView.HideSelection = false;
			this.PopUpListView.Location = new Point(13, 13);
			this.PopUpListView.MultiSelect = false;
			this.PopUpListView.Name = "PopUpListView";
			this.PopUpListView.ShowGroups = false;
			this.PopUpListView.ShowItemToolTips = true;
			this.PopUpListView.Size = new Size(204, 162);
			this.PopUpListView.TabIndex = 2;
			this.PopUpListView.UseCompatibleStateImageBehavior = false;
			this.PopUpListView.View = View.Details;
			this.PopUpListView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.PopUpListViewItemSelectionChanged);
			this.PopUpListView.DoubleClick+= new System.EventHandler(this.PopUpValidClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 200;
			// 
			// PopUpValid
			// 
			this.PopUpValid.BackColor = Color.Transparent;
			this.PopUpValid.Dock = DockStyle.Bottom;
			this.PopUpValid.FlatAppearance.BorderColor = Color.White;
			this.PopUpValid.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.PopUpValid.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.PopUpValid.FlatStyle = FlatStyle.Flat;
			this.PopUpValid.ForeColor = Color.White;
			this.PopUpValid.Location = new Point(13, 180);
			this.PopUpValid.Name = "PopUpValid";
			this.PopUpValid.Size = new Size(204, 37);
			this.PopUpValid.TabIndex = 3;
			this.PopUpValid.Text = "Set";
			this.PopUpValid.UseVisualStyleBackColor = false;
			this.PopUpValid.Click+= new System.EventHandler(this.PopUpValidClick);
			this.PopUpValid.Enabled= false;
			// 
			// PopUpMainForm
			// 
			PopUpValid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PopUpMainFormKeyDown);
			PopUpListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PopUpMainFormKeyDown);
			PopUpMainForm.AutoScaleDimensions = new SizeF(6F, 13F);
			PopUpMainForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			PopUpMainForm.AutoScaleMode = AutoScaleMode.Font;
			PopUpMainForm.BackgroundImage = ((Image)(resourcesFaces.GetObject("PopUpMainForm.BackgroundImage")));
			PopUpMainForm.ClientSize = new Size(230, 230);
			PopUpMainForm.Controls.Add(this.PopUpValid);
			PopUpMainForm.Controls.Add(this.PopUpListView);
			PopUpMainForm.FormBorderStyle = FormBorderStyle.None;
			PopUpMainForm.MaximumSize = new Size(230, 230);
			PopUpMainForm.MinimumSize = new Size(230, 230);
			PopUpMainForm.Name = "PopUpMainForm";
			PopUpMainForm.Padding = new Padding(13);
			PopUpMainForm.Text = "PopUp";
			PopUpMainForm.ResumeLayout(false);
		}
		
		void PopUpMainFormKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Escape)
			{
				PopUpListView.SelectedItems.Clear();
				PopUpListView.Items.Clear();
				PopUpListView.Columns.Clear();
				PopUpMainForm.Visible = false;
				PopUpMainForm.Close();
			}
		}
		
		public void OpenPopUp(ListViewItem[] listeAfficher)
		{
			PopUpInitializeComponent();
			Bitmap fond = (Bitmap)PopUpMainForm.BackgroundImage;
			PopUpListView.BackgroundImage = fond.Clone(new Rectangle(13,13,204,162),fond.PixelFormat);
			PopUpListView.SelectedItems.Clear();
			PopUpListView.Items.Clear();
			PopUpListView.Items.AddRange(listeAfficher);
			PopUpListView.Items[0].Selected = true;
			SetForegroundWindow(Handle);
			PopUpMainForm.ShowDialog();
		}
		
		void PopUpListViewItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			PopUpValid.Enabled= PopUpListView.SelectedItems.Count==1;
		}
		
		void PopUpValidClick(object sender, EventArgs e)
		{
			int ValidIndex = PopUpListView.SelectedItems[0].Index;
			PopUpListView.SelectedItems.Clear();
			PopUpListView.Items.Clear();
			PopUpListView.Columns.Clear();
			PopUpMainForm.Visible = false;
			PopUpMainForm.Close();
			switch (toolIndex)
			{
				case 0: //Warp
					PopUpWarpValid(ValidIndex);
				break;
				case 1: //BGM
					PopUpBGMValid(ValidIndex);
				break;
			}
		}
	}
}
