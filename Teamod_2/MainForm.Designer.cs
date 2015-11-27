using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;

namespace Teamod_2
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		public void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.WindowContainer = new System.Windows.Forms.PictureBox();
			this.WorldPic = new System.Windows.Forms.PictureBox();
			this.WarpSet = new System.Windows.Forms.PictureBox();
			this.ToolLabel = new System.Windows.Forms.Label();
			this.ButtonTools = new System.Windows.Forms.PictureBox();
			this.LeftArrow = new System.Windows.Forms.PictureBox();
			this.FaceContainer = new System.Windows.Forms.PictureBox();
			this.Slot1 = new System.Windows.Forms.PictureBox();
			this.Slot5 = new System.Windows.Forms.PictureBox();
			this.Slot4 = new System.Windows.Forms.PictureBox();
			this.Slot3 = new System.Windows.Forms.PictureBox();
			this.Slot2 = new System.Windows.Forms.PictureBox();
			this.MinimizeButton = new System.Windows.Forms.PictureBox();
			this.CloseButton = new System.Windows.Forms.PictureBox();
			this.RightArrow = new System.Windows.Forms.PictureBox();
			this.Title = new System.Windows.Forms.Label();
			this.SlotTool5 = new System.Windows.Forms.Button();
			this.SlotTool4 = new System.Windows.Forms.Button();
			this.SlotTool3 = new System.Windows.Forms.Button();
			this.SlotTool2 = new System.Windows.Forms.Button();
			this.SlotTool1 = new System.Windows.Forms.Button();
			this.SlotTool0 = new System.Windows.Forms.Button();
			this.ToolClose = new System.Windows.Forms.Button();
			this.ToolRight = new System.Windows.Forms.PictureBox();
			this.ToolLeft = new System.Windows.Forms.PictureBox();
			this.CloseLightTMR = new System.Windows.Forms.Timer(this.components);
			this.MinimizeLightTMR = new System.Windows.Forms.Timer(this.components);
			this.BackIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.BackRunTimer = new System.Windows.Forms.Timer(this.components);
			this.LeftLightTMR = new System.Windows.Forms.Timer(this.components);
			this.RightLightTMR = new System.Windows.Forms.Timer(this.components);
			this.ListFadeIn = new System.Windows.Forms.Timer(this.components);
			this.IconOpacity = new System.Windows.Forms.Timer(this.components);
			this.ActuelFadeIn = new System.Windows.Forms.Timer(this.components);
			this.Main = new System.Windows.Forms.Timer(this.components);
			this.LeftToolLightTMR = new System.Windows.Forms.Timer(this.components);
			this.RightToolLightTMR = new System.Windows.Forms.Timer(this.components);
			this.BGMVolume = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.WindowContainer)).BeginInit();
			this.WindowContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.WorldPic)).BeginInit();
			this.WorldPic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.WarpSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ButtonTools)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftArrow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FaceContainer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightArrow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ToolRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ToolLeft)).BeginInit();
			this.SuspendLayout();
			// 
			// WindowContainer
			// 
			this.WindowContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.WindowContainer.BackColor = System.Drawing.Color.Transparent;
			this.WindowContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WindowContainer.BackgroundImage")));
			this.WindowContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.WindowContainer.Controls.Add(this.WorldPic);
			this.WindowContainer.Controls.Add(this.ToolLabel);
			this.WindowContainer.Controls.Add(this.ButtonTools);
			this.WindowContainer.Controls.Add(this.LeftArrow);
			this.WindowContainer.Controls.Add(this.FaceContainer);
			this.WindowContainer.Controls.Add(this.Slot1);
			this.WindowContainer.Controls.Add(this.Slot5);
			this.WindowContainer.Controls.Add(this.Slot4);
			this.WindowContainer.Controls.Add(this.Slot3);
			this.WindowContainer.Controls.Add(this.Slot2);
			this.WindowContainer.Controls.Add(this.MinimizeButton);
			this.WindowContainer.Controls.Add(this.CloseButton);
			this.WindowContainer.Controls.Add(this.RightArrow);
			this.WindowContainer.Controls.Add(this.Title);
			this.WindowContainer.Controls.Add(this.SlotTool5);
			this.WindowContainer.Controls.Add(this.SlotTool4);
			this.WindowContainer.Controls.Add(this.SlotTool3);
			this.WindowContainer.Controls.Add(this.SlotTool2);
			this.WindowContainer.Controls.Add(this.SlotTool1);
			this.WindowContainer.Controls.Add(this.SlotTool0);
			this.WindowContainer.Controls.Add(this.ToolClose);
			this.WindowContainer.Controls.Add(this.ToolRight);
			this.WindowContainer.Controls.Add(this.ToolLeft);
			this.WindowContainer.Image = ((System.Drawing.Image)(resources.GetObject("WindowContainer.Image")));
			this.WindowContainer.Location = new System.Drawing.Point(0, 0);
			this.WindowContainer.Name = "WindowContainer";
			this.WindowContainer.Size = new System.Drawing.Size(500, 280);
			this.WindowContainer.TabIndex = 0;
			this.WindowContainer.TabStop = false;
			// 
			// WorldPic
			// 
			this.WorldPic.Controls.Add(this.WarpSet);
			this.WorldPic.Location = new System.Drawing.Point(10, 30);
			this.WorldPic.Name = "WorldPic";
			this.WorldPic.Size = new System.Drawing.Size(90, 90);
			this.WorldPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.WorldPic.TabIndex = 4;
			this.WorldPic.TabStop = false;
			// 
			// WarpSet
			// 
			this.WarpSet.BackColor = System.Drawing.Color.Transparent;
			this.WarpSet.Location = new System.Drawing.Point(53, 63);
			this.WarpSet.MaximumSize = new System.Drawing.Size(33, 16);
			this.WarpSet.MinimumSize = new System.Drawing.Size(33, 16);
			this.WarpSet.Name = "WarpSet";
			this.WarpSet.Size = new System.Drawing.Size(33, 16);
			this.WarpSet.TabIndex = 4;
			this.WarpSet.TabStop = false;
			this.WarpSet.Visible = false;
			this.WarpSet.Click += new System.EventHandler(this.WarpSetClick);
			// 
			// ToolLabel
			// 
			this.ToolLabel.ForeColor = System.Drawing.Color.White;
			this.ToolLabel.Location = new System.Drawing.Point(103, 98);
			this.ToolLabel.Name = "ToolLabel";
			this.ToolLabel.Size = new System.Drawing.Size(385, 26);
			this.ToolLabel.TabIndex = 10;
			this.ToolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ButtonTools
			// 
			this.ButtonTools.Location = new System.Drawing.Point(103, 125);
			this.ButtonTools.Name = "ButtonTools";
			this.ButtonTools.Size = new System.Drawing.Size(335, 28);
			this.ButtonTools.TabIndex = 4;
			this.ButtonTools.TabStop = false;
			this.ButtonTools.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonToolMouseDown);
			this.ButtonTools.MouseLeave += new System.EventHandler(this.ButtonToolMouseLeave);
			this.ButtonTools.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonToolMouseLight);
			this.ButtonTools.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonToolMouseUp);
			// 
			// LeftArrow
			// 
			this.LeftArrow.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LeftArrow.Location = new System.Drawing.Point(111, 198);
			this.LeftArrow.Name = "LeftArrow";
			this.LeftArrow.Size = new System.Drawing.Size(17, 21);
			this.LeftArrow.TabIndex = 14;
			this.LeftArrow.TabStop = false;
			this.LeftArrow.Click += new System.EventHandler(this.LeftArrowClick);
			this.LeftArrow.MouseEnter += new System.EventHandler(this.LeftArrowMouseEnter);
			this.LeftArrow.MouseLeave += new System.EventHandler(this.LeftArrowMouseLeave);
			// 
			// FaceContainer
			// 
			this.FaceContainer.BackColor = System.Drawing.Color.Transparent;
			this.FaceContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FaceContainer.BackgroundImage")));
			this.FaceContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.FaceContainer.Image = ((System.Drawing.Image)(resources.GetObject("FaceContainer.Image")));
			this.FaceContainer.ImageLocation = "";
			this.FaceContainer.Location = new System.Drawing.Point(4, 134);
			this.FaceContainer.Name = "FaceContainer";
			this.FaceContainer.Size = new System.Drawing.Size(100, 117);
			this.FaceContainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.FaceContainer.TabIndex = 4;
			this.FaceContainer.TabStop = false;
			this.FaceContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.FaceContainerPaint);
			// 
			// Slot1
			// 
			this.Slot1.BackColor = System.Drawing.Color.Transparent;
			this.Slot1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Slot1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Slot1.Location = new System.Drawing.Point(129, 162);
			this.Slot1.Name = "Slot1";
			this.Slot1.Size = new System.Drawing.Size(50, 95);
			this.Slot1.TabIndex = 5;
			this.Slot1.TabStop = false;
			this.Slot1.Click += new System.EventHandler(this.SlotClick);
			this.Slot1.Paint += new System.Windows.Forms.PaintEventHandler(this.SlotPaint);
			this.Slot1.MouseEnter += new System.EventHandler(this.SlotMouseEnter);
			this.Slot1.MouseLeave += new System.EventHandler(this.SlotMouseLeave);
			// 
			// Slot5
			// 
			this.Slot5.BackColor = System.Drawing.Color.Transparent;
			this.Slot5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Slot5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Slot5.Location = new System.Drawing.Point(413, 145);
			this.Slot5.Name = "Slot5";
			this.Slot5.Size = new System.Drawing.Size(50, 95);
			this.Slot5.TabIndex = 9;
			this.Slot5.TabStop = false;
			this.Slot5.Click += new System.EventHandler(this.SlotClick);
			this.Slot5.Paint += new System.Windows.Forms.PaintEventHandler(this.SlotPaint);
			this.Slot5.MouseEnter += new System.EventHandler(this.SlotMouseEnter);
			this.Slot5.MouseLeave += new System.EventHandler(this.SlotMouseLeave);
			// 
			// Slot4
			// 
			this.Slot4.BackColor = System.Drawing.Color.Transparent;
			this.Slot4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Slot4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Slot4.Location = new System.Drawing.Point(338, 158);
			this.Slot4.Name = "Slot4";
			this.Slot4.Size = new System.Drawing.Size(58, 103);
			this.Slot4.TabIndex = 8;
			this.Slot4.TabStop = false;
			this.Slot4.Click += new System.EventHandler(this.SlotClick);
			this.Slot4.Paint += new System.Windows.Forms.PaintEventHandler(this.SlotPaint);
			this.Slot4.MouseEnter += new System.EventHandler(this.SlotMouseEnter);
			this.Slot4.MouseLeave += new System.EventHandler(this.SlotMouseLeave);
			// 
			// Slot3
			// 
			this.Slot3.BackColor = System.Drawing.Color.Transparent;
			this.Slot3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Slot3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Slot3.Location = new System.Drawing.Point(261, 162);
			this.Slot3.Name = "Slot3";
			this.Slot3.Size = new System.Drawing.Size(70, 115);
			this.Slot3.TabIndex = 7;
			this.Slot3.TabStop = false;
			this.Slot3.Click += new System.EventHandler(this.SlotClick);
			this.Slot3.Paint += new System.Windows.Forms.PaintEventHandler(this.SlotPaint);
			this.Slot3.MouseEnter += new System.EventHandler(this.SlotMouseEnter);
			this.Slot3.MouseLeave += new System.EventHandler(this.SlotMouseLeave);
			// 
			// Slot2
			// 
			this.Slot2.BackColor = System.Drawing.Color.Transparent;
			this.Slot2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Slot2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Slot2.Location = new System.Drawing.Point(196, 162);
			this.Slot2.Name = "Slot2";
			this.Slot2.Size = new System.Drawing.Size(58, 103);
			this.Slot2.TabIndex = 6;
			this.Slot2.TabStop = false;
			this.Slot2.Click += new System.EventHandler(this.SlotClick);
			this.Slot2.Paint += new System.Windows.Forms.PaintEventHandler(this.SlotPaint);
			this.Slot2.MouseEnter += new System.EventHandler(this.SlotMouseEnter);
			this.Slot2.MouseLeave += new System.EventHandler(this.SlotMouseLeave);
			// 
			// MinimizeButton
			// 
			this.MinimizeButton.BackColor = System.Drawing.Color.Transparent;
			this.MinimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeButton.Image")));
			this.MinimizeButton.Location = new System.Drawing.Point(374, 4);
			this.MinimizeButton.Name = "MinimizeButton";
			this.MinimizeButton.Size = new System.Drawing.Size(62, 23);
			this.MinimizeButton.TabIndex = 4;
			this.MinimizeButton.TabStop = false;
			this.MinimizeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimizeButtonMouseDown);
			this.MinimizeButton.MouseEnter += new System.EventHandler(this.MinimizeButtonMouseEnter);
			this.MinimizeButton.MouseLeave += new System.EventHandler(this.MinimizeButtonMouseLeave);
			this.MinimizeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MinimizeButtonMouseUp);
			// 
			// CloseButton
			// 
			this.CloseButton.BackColor = System.Drawing.Color.Transparent;
			this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
			this.CloseButton.Location = new System.Drawing.Point(435, 4);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(62, 23);
			this.CloseButton.TabIndex = 1;
			this.CloseButton.TabStop = false;
			this.CloseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseButtonMouseDown);
			this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButtonMouseEnter);
			this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButtonMouseLeave);
			this.CloseButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CloseButtonMouseUp);
			// 
			// RightArrow
			// 
			this.RightArrow.Cursor = System.Windows.Forms.Cursors.Hand;
			this.RightArrow.Location = new System.Drawing.Point(477, 178);
			this.RightArrow.Name = "RightArrow";
			this.RightArrow.Size = new System.Drawing.Size(17, 21);
			this.RightArrow.TabIndex = 13;
			this.RightArrow.TabStop = false;
			this.RightArrow.Click += new System.EventHandler(this.RightArrowClick);
			this.RightArrow.MouseEnter += new System.EventHandler(this.RightArrowMouseEnter);
			this.RightArrow.MouseLeave += new System.EventHandler(this.RightArrowMouseLeave);
			// 
			// Title
			// 
			this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Title.ForeColor = System.Drawing.Color.White;
			this.Title.Location = new System.Drawing.Point(0, 4);
			this.Title.Name = "Title";
			this.Title.Size = new System.Drawing.Size(500, 23);
			this.Title.TabIndex = 36;
			this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleMouseDown);
			this.Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleMouseMove);
			this.Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleMouseUp);
			// 
			// SlotTool5
			// 
			this.SlotTool5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SlotTool5.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.SlotTool5.FlatAppearance.BorderSize = 0;
			this.SlotTool5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SlotTool5.Location = new System.Drawing.Point(408, 45);
			this.SlotTool5.Name = "SlotTool5";
			this.SlotTool5.Size = new System.Drawing.Size(50, 50);
			this.SlotTool5.TabIndex = 9;
			this.SlotTool5.TabStop = false;
			this.SlotTool5.Visible = false;
			this.SlotTool5.Click += new System.EventHandler(this.ToolClick);
			this.SlotTool5.MouseEnter += new System.EventHandler(this.ToolMouseOver);
			// 
			// SlotTool4
			// 
			this.SlotTool4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SlotTool4.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.SlotTool4.FlatAppearance.BorderSize = 0;
			this.SlotTool4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SlotTool4.Location = new System.Drawing.Point(352, 45);
			this.SlotTool4.Name = "SlotTool4";
			this.SlotTool4.Size = new System.Drawing.Size(50, 50);
			this.SlotTool4.TabIndex = 8;
			this.SlotTool4.TabStop = false;
			this.SlotTool4.Visible = false;
			this.SlotTool4.Click += new System.EventHandler(this.ToolClick);
			this.SlotTool4.MouseEnter += new System.EventHandler(this.ToolMouseOver);
			// 
			// SlotTool3
			// 
			this.SlotTool3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SlotTool3.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.SlotTool3.FlatAppearance.BorderSize = 0;
			this.SlotTool3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SlotTool3.Location = new System.Drawing.Point(296, 45);
			this.SlotTool3.Name = "SlotTool3";
			this.SlotTool3.Size = new System.Drawing.Size(50, 50);
			this.SlotTool3.TabIndex = 7;
			this.SlotTool3.TabStop = false;
			this.SlotTool3.Visible = false;
			this.SlotTool3.Click += new System.EventHandler(this.ToolClick);
			this.SlotTool3.MouseEnter += new System.EventHandler(this.ToolMouseOver);
			// 
			// SlotTool2
			// 
			this.SlotTool2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SlotTool2.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.SlotTool2.FlatAppearance.BorderSize = 0;
			this.SlotTool2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SlotTool2.Location = new System.Drawing.Point(240, 45);
			this.SlotTool2.Name = "SlotTool2";
			this.SlotTool2.Size = new System.Drawing.Size(50, 50);
			this.SlotTool2.TabIndex = 6;
			this.SlotTool2.TabStop = false;
			this.SlotTool2.Visible = false;
			this.SlotTool2.Click += new System.EventHandler(this.ToolClick);
			this.SlotTool2.MouseEnter += new System.EventHandler(this.ToolMouseOver);
			// 
			// SlotTool1
			// 
			this.SlotTool1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SlotTool1.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.SlotTool1.FlatAppearance.BorderSize = 0;
			this.SlotTool1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SlotTool1.Location = new System.Drawing.Point(184, 45);
			this.SlotTool1.Name = "SlotTool1";
			this.SlotTool1.Size = new System.Drawing.Size(50, 50);
			this.SlotTool1.TabIndex = 5;
			this.SlotTool1.TabStop = false;
			this.SlotTool1.Visible = false;
			this.SlotTool1.Click += new System.EventHandler(this.ToolClick);
			this.SlotTool1.MouseEnter += new System.EventHandler(this.ToolMouseOver);
			// 
			// SlotTool0
			// 
			this.SlotTool0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SlotTool0.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.SlotTool0.FlatAppearance.BorderSize = 0;
			this.SlotTool0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.SlotTool0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SlotTool0.Location = new System.Drawing.Point(128, 45);
			this.SlotTool0.Name = "SlotTool0";
			this.SlotTool0.Size = new System.Drawing.Size(50, 50);
			this.SlotTool0.TabIndex = 4;
			this.SlotTool0.TabStop = false;
			this.SlotTool0.Visible = false;
			this.SlotTool0.Click += new System.EventHandler(this.ToolClick);
			this.SlotTool0.MouseEnter += new System.EventHandler(this.ToolMouseOver);
			// 
			// ToolClose
			// 
			this.ToolClose.BackColor = System.Drawing.Color.Transparent;
			this.ToolClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToolClose.BackgroundImage")));
			this.ToolClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ToolClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ToolClose.Location = new System.Drawing.Point(466, 36);
			this.ToolClose.Name = "ToolClose";
			this.ToolClose.Size = new System.Drawing.Size(20, 20);
			this.ToolClose.TabIndex = 4;
			this.ToolClose.TabStop = false;
			this.ToolClose.UseVisualStyleBackColor = false;
			this.ToolClose.Visible = false;
			this.ToolClose.Click += new System.EventHandler(this.ToolCloseClick);
			// 
			// ToolRight
			// 
			this.ToolRight.BackColor = System.Drawing.Color.Transparent;
			this.ToolRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToolRight.BackgroundImage")));
			this.ToolRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ToolRight.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ToolRight.Location = new System.Drawing.Point(468, 61);
			this.ToolRight.Name = "ToolRight";
			this.ToolRight.Size = new System.Drawing.Size(14, 18);
			this.ToolRight.TabIndex = 16;
			this.ToolRight.TabStop = false;
			this.ToolRight.Visible = false;
			this.ToolRight.Click += new System.EventHandler(this.RightToolArrowClick);
			this.ToolRight.MouseEnter += new System.EventHandler(this.RightToolMouseEnter);
			this.ToolRight.MouseLeave += new System.EventHandler(this.RightToolMouseLeave);
			// 
			// ToolLeft
			// 
			this.ToolLeft.BackColor = System.Drawing.Color.Transparent;
			this.ToolLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToolLeft.BackgroundImage")));
			this.ToolLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ToolLeft.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ToolLeft.Location = new System.Drawing.Point(105, 61);
			this.ToolLeft.Name = "ToolLeft";
			this.ToolLeft.Size = new System.Drawing.Size(14, 18);
			this.ToolLeft.TabIndex = 15;
			this.ToolLeft.TabStop = false;
			this.ToolLeft.Visible = false;
			this.ToolLeft.Click += new System.EventHandler(this.LeftToolArrowClick);
			this.ToolLeft.MouseEnter += new System.EventHandler(this.LeftToolMouseEnter);
			this.ToolLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LeftToolMouseLeave);
			// 
			// CloseLightTMR
			// 
			this.CloseLightTMR.Interval = 1;
			this.CloseLightTMR.Tick += new System.EventHandler(this.CloseLightTMRTick);
			// 
			// MinimizeLightTMR
			// 
			this.MinimizeLightTMR.Interval = 1;
			this.MinimizeLightTMR.Tick += new System.EventHandler(this.MinimizeLightTMRTick);
			// 
			// BackIcon
			// 
			this.BackIcon.DoubleClick += new System.EventHandler(this.BackIconDoubleClick);
			// 
			// BackRunTimer
			// 
			this.BackRunTimer.Interval = 1000;
			this.BackRunTimer.Tick += new System.EventHandler(this.BackgroundMode);
			// 
			// LeftLightTMR
			// 
			this.LeftLightTMR.Interval = 1;
			this.LeftLightTMR.Tick += new System.EventHandler(this.LeftLightTMRTick);
			// 
			// RightLightTMR
			// 
			this.RightLightTMR.Interval = 1;
			this.RightLightTMR.Tick += new System.EventHandler(this.RightLightTMRTick);
			// 
			// ListFadeIn
			// 
			this.ListFadeIn.Interval = 1;
			this.ListFadeIn.Tick += new System.EventHandler(this.ListFadeInTick);
			// 
			// IconOpacity
			// 
			this.IconOpacity.Interval = 1;
			this.IconOpacity.Tick += new System.EventHandler(this.IconOpacityTick);
			// 
			// ActuelFadeIn
			// 
			this.ActuelFadeIn.Enabled = true;
			this.ActuelFadeIn.Interval = 1;
			this.ActuelFadeIn.Tick += new System.EventHandler(this.ActuelFadeInTick);
			// 
			// Main
			// 
			this.Main.Enabled = true;
			this.Main.Interval = 1;
			this.Main.Tick += new System.EventHandler(this.MainTick);
			// 
			// LeftToolLightTMR
			// 
			this.LeftToolLightTMR.Interval = 1;
			this.LeftToolLightTMR.Tick += new System.EventHandler(this.LeftToolLightTMRTick);
			// 
			// RightToolLightTMR
			// 
			this.RightToolLightTMR.Interval = 1;
			this.RightToolLightTMR.Tick += new System.EventHandler(this.RightToolLightTMRTick);
			// 
			// BGMVolume
			// 
			this.BGMVolume.Interval = 1;
			this.BGMVolume.Tick += new System.EventHandler(this.BGMVolumeTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.ForestGreen;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(500, 280);
			this.ControlBox = false;
			this.Controls.Add(this.WindowContainer);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(500, 280);
			this.MinimumSize = new System.Drawing.Size(500, 280);
			this.Name = "MainForm";
			this.Text = "Teamod 2";
			this.TransparencyKey = System.Drawing.Color.ForestGreen;
			this.Leave += new System.EventHandler(this.MainFormLeave);
			this.Resize += new System.EventHandler(this.MainFormResize);
			((System.ComponentModel.ISupportInitialize)(this.WindowContainer)).EndInit();
			this.WindowContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.WorldPic)).EndInit();
			this.WorldPic.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.WarpSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ButtonTools)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftArrow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FaceContainer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Slot2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightArrow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ToolRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ToolLeft)).EndInit();
			this.ResumeLayout(false);

		}
		
		private System.Windows.Forms.NotifyIcon BackIcon;
		private System.Windows.Forms.Timer BackRunTimer;
		private System.Windows.Forms.Timer LeftLightTMR;
		private System.Windows.Forms.Timer RightLightTMR;
		private System.Windows.Forms.Timer ListFadeIn;
		private System.Windows.Forms.Label Title;
		private System.Windows.Forms.PictureBox WindowContainer;
		private System.Windows.Forms.PictureBox RightArrow;
		private System.Windows.Forms.PictureBox LeftArrow;
		private System.Windows.Forms.PictureBox Slot5;
		private System.Windows.Forms.PictureBox Slot4;
		private System.Windows.Forms.PictureBox Slot3;
		private System.Windows.Forms.PictureBox Slot2;
		private System.Windows.Forms.PictureBox Slot1;
		private System.Windows.Forms.PictureBox FaceContainer;
		private System.Windows.Forms.PictureBox MinimizeButton;
		private System.Windows.Forms.PictureBox CloseButton;
		private System.Windows.Forms.Timer CloseLightTMR;
		private System.Windows.Forms.Timer MinimizeLightTMR;
		private System.Windows.Forms.Timer IconOpacity;
		private System.Windows.Forms.Timer ActuelFadeIn;
		private System.Windows.Forms.Timer Main;
		private System.Windows.Forms.PictureBox WarpSet;
		private System.Windows.Forms.PictureBox ButtonTools;
		private System.Windows.Forms.PictureBox WorldPic;
		private System.Windows.Forms.Button SlotTool0;
		private System.Windows.Forms.Button SlotTool1;
		private System.Windows.Forms.Button SlotTool2;
		private System.Windows.Forms.Button SlotTool3;
		private System.Windows.Forms.Button SlotTool4;
		private System.Windows.Forms.Button SlotTool5;
		private System.Windows.Forms.Label ToolLabel;
		private System.Windows.Forms.Button ToolClose;
		private System.Windows.Forms.PictureBox ToolLeft;
		private System.Windows.Forms.PictureBox ToolRight;
		private System.Windows.Forms.Timer LeftToolLightTMR;
		private System.Windows.Forms.Timer RightToolLightTMR;
		private System.Windows.Forms.Timer BGMVolume;
		
	}


}
