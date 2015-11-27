using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Text;

namespace Teamod_2
{
	public partial class MainForm : Form
	{
		[DllImport("USER32.DLL")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
		
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool LockWindowUpdate(IntPtr hWndLock);
		
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern IntPtr GetForegroundWindow();
		
		[DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
		
		private string GetActiveWindowTitle()
		{
			string output = " ";
			const int nChars = 256;
			StringBuilder Buff = new StringBuilder(nChars);
			try {IntPtr handle = GetForegroundWindow();
				if (GetWindowText(handle, Buff, nChars) > 0)
					output= Buff.ToString();} catch {}
			return output;
		}

		Bitmap MinimizeLightBack;
		Bitmap MinimizeLightImage;
		Bitmap CloseLightBack;
		Bitmap CloseLightImage;
		Bitmap LeftArrowLight;
		Bitmap RightArrowLight;
		ComponentResourceManager resourcesFaces = new ComponentResourceManager(typeof(Program));
		Bitmap[] ButtonToolShadows = new Bitmap[5];
		Bitmap[] ButtonToolLights = new Bitmap[5];
		
		// Chargement des bitmaps de la fenêtre | Loading bitmaps of window
		public void LoadBitmaps()
		{
			MinimizeLightBack = (Bitmap)resourcesFaces.GetObject("MinimizeLight.BackgroundImage");
			MinimizeLightImage = (Bitmap)resourcesFaces.GetObject("MinimizeLight.Image");
			CloseLightBack = (Bitmap)resourcesFaces.GetObject("CloseLight.BackgroundImage");
			CloseLightImage = (Bitmap)resourcesFaces.GetObject("CloseLight.Image");
			LeftArrowLight = (Bitmap)resourcesFaces.GetObject("LeftArrowLight");
			RightArrowLight = (Bitmap)resourcesFaces.GetObject("RightArrowLight");
			ChangeSelector();
		}
		
		//Mise à jour des fleches et des icones | Update of arrows and icons
		void ChangeSelector()
		{
			opacities = new int[] {0,0,0,0,0,0};
			ArrowsUpdate();
			ListFadeIn.Enabled = true;
		}
		
		/* ------------------------------------------------------ */
		/* MOUVEMENTS DE LA FENETRE PRINCIPALE | MAIN WINDOW MOVE */
		
		/* Variables utiles à cette section | Used variables */
		/* --------------------------------------------------*/
		bool MoveWindow = false;
		int[] MoveOffset = new int[2];
		/* --------------------------------------------------*/
		
		/* On obtient le décalage du cursor avec la position de la  fenêtre dans 'MoveOffset' et on commence la mise à jour constante de la position
					| Acknoledge of window location/cursor offset into 'MoveOffset', and start moving window */
		void TitleMouseDown(object sender, MouseEventArgs e)
		{
			if (!MoveWindow) MoveOffset = new int[] {PointToClient(Cursor.Position).X,PointToClient(Cursor.Position).Y};
			MoveWindow = true;
		}
		
		/* Arrêt du dépalacement constant de la fenêtre par rapport à son décalage */
		/* Stop moving window from offset */
		void TitleMouseUp(object sender, MouseEventArgs e)
		{MoveWindow = false;}
		void MainFormLeave(object sender, EventArgs e)
		{MoveWindow = false;}
		
		/* On bouge la fenêtre selon l'état booléen de 'MoveWindow', et un tableau d'entiers contenant le décalage XY entre la fenetre et le cursor
					/* Move window according to 'MoveWindow', an integer array containing the XY offset between window & cursor to update the new window location */
		void TitleMouseMove(object sender, MouseEventArgs e)
		{
			if (MoveWindow)
				Location = new Point(Cursor.Position.X-MoveOffset[0],Cursor.Position.Y-MoveOffset[1]);
		}
		
		/* MOUVEMENTS DE LA FENETRE PRINCIPALE | MAIN WINDOW MOVE */
		/* ------------------------------------------------------ */
		
		
		
		
		
		/* ------------------------------------------------------ */
		/* CHANGEMENTS D'OPACITES DES COMPOSANTS | COMPONENTS OPACITY CHANGES */
		
		/* Variables utiles à cette section | Used variables */
		/* --------------------------------------------------*/
		
		int opacitePersonnageActuel = 0;
		int[] opacities = new int[] {0,0,0,0,0,0};
		int[] sens = new int[] {0,0,0,0,0,0};
		int slideIndex = 0;
		int slideToolIndex = 0;
		short[] CloseButtonParams = new short[3];
		short[] MinimizeButtonParams = new short[3];
		int[] arrowsOpacity = new int[] {0,0,10,10};
		int[] arrowsToolOpacity = new int[] {0,0,10,10};
		
		/* --------------------------------------------------*/
		
		/* Changer l'opacité d'un Bitmap | Change Bitmap Opacity */
		public Bitmap ChangeOpacity(Image Source, byte Opacite)
		{
			Bitmap bmp = new Bitmap(Source.Width,Source.Height);
			Graphics graphics = Graphics.FromImage(bmp);
			ColorMatrix colormatrix = new ColorMatrix();
			colormatrix.Matrix33 = (float)(((double)Opacite)/50);
			ImageAttributes AttributsSource = new ImageAttributes();
			AttributsSource.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			graphics.DrawImage(Source, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, Source.Width, Source.Height, GraphicsUnit.Pixel, AttributsSource);
			graphics.Dispose();
			return bmp;
		}
		
		//Evènement d'entrée du curseur dans la zone du bouton Fermer | Event activated when mouse enters Close button perimeter
		void CloseButtonMouseEnter(object sender, EventArgs e)
		{CloseButtonParams[0] = 6; CloseLightTMR.Enabled = true;}
		
		//Evènement d'entrée du curseur dans la zone du bouton Reduire | Event activated when mouse enters Minimize button perimeter
		void MinimizeButtonMouseEnter(object sender, EventArgs e)
		{MinimizeButtonParams[0] = 6; MinimizeLightTMR.Enabled = true;}
		
		//Evènement de sortie du curseur de la zone du bouton Fermer | Event activated when mouse leaves Close button perimeter
		void CloseButtonMouseLeave(object sender, EventArgs e)
		{CloseButtonParams[0] = -6; CloseLightTMR.Enabled = true;}
		
		//Evènement de sortie du curseur de la zone du bouton Reduire | Event activated when mouse leaves Reduire button perimeter
		void MinimizeButtonMouseLeave(object sender, EventArgs e)
		{MinimizeButtonParams[0] = -6; MinimizeLightTMR.Enabled = true;}
		
		//Timer de pas de changement d'opacité pour le bouton Fermer | Opacity change step timer for Close button
		void CloseLightTMRTick(object sender, EventArgs e)
		{
			CloseLightTMR.Enabled = (CloseButtonParams[1]+Convert.ToSByte(CloseButtonParams[0]) > 0 && CloseButtonParams[1]+Convert.ToSByte(CloseButtonParams[0]) < 72);
			if (!CloseLightTMR.Enabled) return;
			CloseButtonParams[1] = (byte)(CloseButtonParams[1] + Convert.ToSByte(CloseButtonParams[0]));
			if (CloseButtonParams[2]==0)
				CloseButton.BackgroundImage = ChangeOpacity(CloseLightBack,(byte)CloseButtonParams[1]);
		}
		
		//Timer de pas de changement d'opacité pour le bouton Réduire | Opacity change step timer for Minimize button
		void MinimizeLightTMRTick(object sender, EventArgs e)
		{
			MinimizeLightTMR.Enabled = (MinimizeButtonParams[1]+Convert.ToSByte(MinimizeButtonParams[0]) > 0 && MinimizeButtonParams[1]+Convert.ToSByte(MinimizeButtonParams[0]) < 72);
			if (!MinimizeLightTMR.Enabled) return;
			MinimizeButtonParams[1] = (byte)(MinimizeButtonParams[1] + Convert.ToSByte(MinimizeButtonParams[0]));
			if (MinimizeButtonParams[2]==0)
				MinimizeButton.BackgroundImage = ChangeOpacity(MinimizeLightBack,(byte)MinimizeButtonParams[1]);
		}
		
		//Evènement d'enfoncement du clic gauche dans la zone du bouton Fermer | Event activated if left mouse is down in Close button perimeter
		void CloseButtonMouseDown(object sender, MouseEventArgs e) {CloseButtonParams[2] = 1; CloseButton.BackgroundImage = CloseLightImage;}
		//Evènement d'enfoncement du clic gauche dans la zone du bouton Réduire | Event activated if left mouse is down in Minimize button perimeter
		void MinimizeButtonMouseDown(object sender, MouseEventArgs e) {MinimizeButtonParams[2] = 1; MinimizeButton.BackgroundImage = MinimizeLightImage;}
		
		//Evènement de relachement du clic gauche dans la zone du bouton Fermer | Event activated if left mouse is up in Close button perimeter
		void CloseButtonMouseUp(object sender, MouseEventArgs e) {if (IsCursorOnCloseButton()) {System.Diagnostics.Process.GetCurrentProcess().Kill(); if (warnLog.Count>0) System.IO.File.WriteAllLines("Warnings.log",warnLog.ToArray());} CloseButtonParams[2] = 0;}
		//Evènement de relachement du clic gauche dans la zone du bouton Réduire | Event activated if left mouse is up in Minimize button perimeter
		void MinimizeButtonMouseUp(object sender, MouseEventArgs e)
		{
			if (IsCursorOnMinimizeButton())
			{
				LockWindowUpdate(this.Handle); FormBorderStyle = FormBorderStyle.FixedSingle;
				WindowState = FormWindowState.Minimized;
				LockWindowUpdate(IntPtr.Zero); FormBorderStyle = FormBorderStyle.None;
			}
			MinimizeButtonParams[2] = 0;
		}
		
		//Verifie sur le curseur est dans le pérmimètre du bouton fermer | Checks if cursor is in the perimeter of Close Button
		bool IsCursorOnCloseButton()
		{
			int loc_x = CloseButton.PointToClient(Cursor.Position).X;
			int loc_y = CloseButton.PointToClient(Cursor.Position).Y;
			return (CloseButtonParams[2]==1&&loc_x>0&&loc_x<CloseButton.Width&&loc_y>0&&loc_y<CloseButton.Height);
		}
		
		//Verifie sur le curseur est dans le pérmimètre du bouton réduire | Checks if cursor is in the perimeter of Minimize Button
		bool IsCursorOnMinimizeButton()
		{
			int loc_x = MinimizeButton.PointToClient(Cursor.Position).X;
			int loc_y = MinimizeButton.PointToClient(Cursor.Position).Y;
			return (MinimizeButtonParams[2]==1&&loc_x>0&&loc_x<MinimizeButton.Width&&loc_y>0&&loc_y<MinimizeButton.Height);
		}
		
		//Evenement de réduction | Minimizing Event
		void MainFormResize(object sender, EventArgs e) {BackRunTimer.Enabled = true;}
		
		//Passage en éxécution tâche de fond | Background task mode enter
		void BackgroundMode(object sender, EventArgs e)
		{
			CloseButton.BackgroundImage = null;
			MinimizeButton.BackgroundImage = null;
			BackIcon.Visible = (WindowState == FormWindowState.Minimized);
			ShowInTaskbar = (WindowState != FormWindowState.Minimized);
			BackRunTimer.Enabled = false;
		}
		
		//Sortie du mode tâche de fond | Background task mode leave
		void BackIconDoubleClick(object sender, EventArgs e)
		{
			BackIcon.Visible = false;
			ShowInTaskbar = true;
			LockWindowUpdate(this.Handle); FormBorderStyle = FormBorderStyle.FixedSingle;
			WindowState = FormWindowState.Normal;
			LockWindowUpdate(IntPtr.Zero); FormBorderStyle = FormBorderStyle.None;
		}
		
		//Verifie sur le curseur entre dans le pérmimètre du bouton "Gauche" | Checks if cursor enters the perimeter of "Left Arrow" Button
		void LeftArrowMouseEnter(object sender, EventArgs e)
		{
			arrowsOpacity[0] = 1;
			LeftLightTMR.Enabled = true;
		}
		
		//Verifie sur le curseur quitte le pérmimètre du bouton "Gauche" | Checks if cursor leaves the perimeter of "Left Arrow" Button
		void LeftArrowMouseLeave(object sender, EventArgs e)
		{
			arrowsOpacity[0] = -1;
			LeftLightTMR.Enabled = true;
		}
		
		//Verifie sur le curseur entre dans le pérmimètre du bouton "Droite" | Checks if cursor enters the perimeter of "Right Arrow" Button
		void RightArrowMouseEnter(object sender, EventArgs e)
		{
			arrowsOpacity[1] = 1;
			RightLightTMR.Enabled = true;
		}
		
		//Verifie sur le curseur quitte le pérmimètre du bouton "Droite" | Checks if cursor leaves the perimeter of "Right Arrow" Button
		void RightArrowMouseLeave(object sender, EventArgs e)
		{
			arrowsOpacity[1] = -1;
			RightLightTMR.Enabled = true;
		}
		
		//Verifie sur le curseur entre dans le pérmimètre du bouton "Gauche" | Checks if cursor enters the perimeter of "Left Arrow" Button
		void LeftToolMouseEnter(object sender, EventArgs e)
		{
			arrowsToolOpacity[0] = 1;
			LeftToolLightTMR.Enabled = true;
		}
		
		//Verifie sur le curseur quitte le pérmimètre du bouton "Gauche" | Checks if cursor leaves the perimeter of "Left Arrow" Button
		void LeftToolMouseLeave(object sender, EventArgs e)
		{
			arrowsToolOpacity[0] = -1;
			LeftToolLightTMR.Enabled = true;
		}
		
		//Verifie sur le curseur entre dans le pérmimètre du bouton "Droite" | Checks if cursor enters the perimeter of "Right Arrow" Button
		void RightToolMouseEnter(object sender, EventArgs e)
		{
			arrowsToolOpacity[1] = 1;
			RightToolLightTMR.Enabled = true;
		}
		
		//Verifie sur le curseur quitte le pérmimètre du bouton "Droite" | Checks if cursor leaves the perimeter of "Right Arrow" Button
		void RightToolMouseLeave(object sender, EventArgs e)
		{
			arrowsToolOpacity[1] = -1;
			RightToolLightTMR.Enabled = true;
		}
		
		// Timer du bouton "Gauche" | Left Button timer
		void LeftLightTMRTick(object sender, EventArgs e)
		{
			if (LeftArrow.Cursor == Cursors.Hand)
			{
				if (arrowsOpacity[2]+arrowsOpacity[0]>10&&arrowsOpacity[2]+arrowsOpacity[0]<50)
					arrowsOpacity[2]+=arrowsOpacity[0];
				else  if (arrowsOpacity[2]<10) arrowsOpacity[2]++;
				else
				{
					arrowsOpacity[0] = 0;
					LeftLightTMR.Enabled = false;
				}
			}
			else
				if (arrowsOpacity[2]>0)
					arrowsOpacity[2]--; else LeftLightTMR.Enabled = false;
			
			LeftArrow.BackgroundImage = ChangeOpacity(LeftArrowLight,(byte)arrowsOpacity[2]);
		}
		// Timer du bouton "Droite" | Left Button timer
		void LeftToolLightTMRTick(object sender, EventArgs e)
		{
			if (ToolLeft.Cursor == Cursors.Hand)
			{
				
				if (arrowsToolOpacity[2]+arrowsToolOpacity[0]>10&&arrowsToolOpacity[2]+arrowsToolOpacity[0]<50)
					arrowsToolOpacity[2]+=arrowsToolOpacity[0];
				else if (arrowsToolOpacity[2]<10) arrowsToolOpacity[2]++;
				else
				{
					arrowsToolOpacity[0] = 0;
					LeftToolLightTMR.Enabled = false;
				}
			}
			else
				if (arrowsToolOpacity[2]>0)
					arrowsToolOpacity[2]--; else LeftToolLightTMR.Enabled = false;
			ToolLeft.BackgroundImage = ChangeOpacity(LeftArrowLight,(byte)arrowsToolOpacity[2]);
		}
		
		// Timer du bouton "Droite" | Right Button timer
		void RightLightTMRTick(object sender, EventArgs e)
		{
			if (RightArrow.Cursor == Cursors.Hand)
			{
				
				if (arrowsOpacity[3]+arrowsOpacity[1]>10&&arrowsOpacity[3]+arrowsOpacity[1]<50)
					arrowsOpacity[3]+=arrowsOpacity[1];
				else if (arrowsOpacity[3]<10) arrowsOpacity[3]++;
				else
				{
					arrowsOpacity[1] = 0;
					RightLightTMR.Enabled = false;
				}
			}
			else
				if (arrowsOpacity[3]>0)
					arrowsOpacity[3]--; else RightLightTMR.Enabled = false;
			RightArrow.BackgroundImage = ChangeOpacity(RightArrowLight,(byte)arrowsOpacity[3]);
		}
		
		// Timer du bouton "Droite" | Right Button timer
		void RightToolLightTMRTick(object sender, EventArgs e)
		{
			if (ToolRight.Cursor == Cursors.Hand)
			{
				if (arrowsToolOpacity[3]+arrowsToolOpacity[1]>10&&arrowsToolOpacity[3]+arrowsToolOpacity[1]<50)
					arrowsToolOpacity[3]+=arrowsToolOpacity[1];
				else if (arrowsToolOpacity[3]<10) arrowsToolOpacity[3]++;
				else
				{
					arrowsToolOpacity[1] = 0;
					RightToolLightTMR.Enabled = false;
				}
			}
			else
				if (arrowsToolOpacity[3]>0)
					arrowsToolOpacity[3]--; else RightToolLightTMR.Enabled = false;
			ToolRight.BackgroundImage = ChangeOpacity(RightArrowLight,(byte)arrowsToolOpacity[3]);
		}
		
		//Mise à jour des flèches selon la liste suivante | Update of arrows according to next list
		void ArrowsUpdate()
		{
			RightLightTMR.Enabled = true;
			LeftLightTMR.Enabled = true;
			RightArrow.Cursor = (slideIndex+5<Liste_Principale.Length) ? Cursors.Hand : Cursors.Default;
			LeftArrow.Cursor = (slideIndex-1>0) ? Cursors.Hand : Cursors.Default;
		}
		
		string[] whoIsToolFor = new string[] {"","","","","",""};
		Bitmap[] ToolList = new Bitmap[0];
		string[] ToolListLabels = new string[0];
		
		//Mise à jour des flèches selon la liste suivante | Update of arrows according to next list
		void ToolArrowsUpdate()
		{
			RightToolLightTMR.Enabled = true;
			LeftToolLightTMR.Enabled = true;
			ToolRight.Cursor = (slideToolIndex+6<ToolList.Length) ? Cursors.Hand : Cursors.Default;
			ToolLeft.Cursor = (slideToolIndex-1>0) ? Cursors.Hand : Cursors.Default;
		}
		
		//Mise à jour des slots | Update of slots
		void ToolSlotsUpdate()
		{
			for (int i=0;i<6;i++)
			{
				if (slideToolIndex+i<ToolList.Length)
				{
					(new Button[] {SlotTool0,SlotTool1,SlotTool2,SlotTool3,SlotTool4,SlotTool5}[i]).Enabled = ((subToolLevel[0]==0&&whoIsToolFor[slideToolIndex+i].Length==0)||(whoIsToolFor[subToolLevel[1]].Contains(GetModelName(player_Ptr))&&whoIsToolFor[subToolLevel[1]].Contains(personnageActuel.getMdlxName())));
					Bitmap BG = new Bitmap(ToolList[slideToolIndex+i].Width,ToolList[slideToolIndex+i].Height);
					var BGgr = Graphics.FromImage(BG);
					ImageAttributes imgAttributes = new ImageAttributes();
					ColorMatrix matrix = new ColorMatrix();  
					
					matrix.Matrix33 = (new Button[] {
						SlotTool0,
						SlotTool1,
						SlotTool2,
						SlotTool3,
						SlotTool4,
						SlotTool5
					}[i]).Enabled ? 1f : .3f;
					
					
		            imgAttributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		            BGgr.DrawImage(matrix.Matrix33<1?MakeGrayscale3(ToolList[slideToolIndex+i]):ToolList[slideToolIndex+i],new Rectangle(0,0,BG.Width,BG.Height),0,0,BG.Width,BG.Height,GraphicsUnit.Pixel, imgAttributes);
					(new Button[] {SlotTool0,SlotTool1,SlotTool2,SlotTool3,SlotTool4,SlotTool5}[i]).BackgroundImage = BG;
					(new Button[] {SlotTool0,SlotTool1,SlotTool2,SlotTool3,SlotTool4,SlotTool5}[i]).Visible = true;
				}
				else
				{
					(new Button[] {SlotTool0,SlotTool1,SlotTool2,SlotTool3,SlotTool4,SlotTool5}[i]).BackgroundImage = null;
					(new Button[] {SlotTool0,SlotTool1,SlotTool2,SlotTool3,SlotTool4,SlotTool5}[i]).Visible = false;
					
				}
			}
		}
		
		
		
		//Apparition des icones de la liste | Appearance of list icons
		void ListFadeInTick(object sender, EventArgs e)
		{
			if (opacities[4]==20) {ListFadeIn.Enabled = false; return;}
			if (opacities[0]<20) opacities[0]++;
			for (int i=0;i<5;i++)
			{
				if (opacities[i]>4)
					if (opacities[i+1]<20) opacities[i+1]++;
				var nextIcon = new Bitmap(ChangeOpacity(Liste_Principale[slideIndex+i].getImage(),(byte)opacities[i]));
				new PictureBox[] {Slot1,Slot2,Slot3,Slot4,Slot5}[i].BackgroundImage =
					Liste_Principale[slideIndex+i].isAvailable() ? nextIcon : MakeGrayscale3(nextIcon);
			}
		}
		
		//Rendugris du Bitmap | Bitmap Grayscale
		public Bitmap MakeGrayscale3(Bitmap original)
		{
			Bitmap newBitmap = new Bitmap(original.Width, original.Height);
			Graphics g = Graphics.FromImage(newBitmap);
			ColorMatrix colorMatrix = new ColorMatrix(
				new float[][]
				{
					new float[] {.3f, .3f, .3f, 0, 0},
					new float[] {.59f, .59f, .59f, 0, 0},
					new float[] {.11f, .11f, .11f, 0, 0},
					new float[] {0, 0, 0, 1, 0},
					new float[] {0, 0, 0, 0, 1}
				});
			
			ImageAttributes attributes = new ImageAttributes();
			attributes.SetColorMatrix(colorMatrix);
			g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
			            0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
			g.Dispose();
			return newBitmap;
		}
		
		// Evenement de clic fleche gauche | Left Arrow click
		void LeftArrowClick(object sender, EventArgs e)
		{
			if (LeftArrow.Cursor == Cursors.Hand)
			{
				slideIndex-=5;
				ChangeSelector();
			}
		}
		
		// Evenement de clic fleche droite | Right Arrow click
		void RightArrowClick(object sender, EventArgs e)
		{
			if (RightArrow.Cursor == Cursors.Hand)
			{
				slideIndex+=5;
				ChangeSelector();
			}
		}
		
		// Evenement de clic fleche gauche | Left Arrow click
		void LeftToolArrowClick(object sender, EventArgs e)
		{
			if (ToolLeft.Cursor == Cursors.Hand)
			{
				slideToolIndex-=6;
				ToolArrowsUpdate();
				ToolSlotsUpdate();
			}
		}
		
		// Evenement de clic fleche droite | Right Arrow click
		void RightToolArrowClick(object sender, EventArgs e)
		{
			if (ToolRight.Cursor == Cursors.Hand)
			{
				slideToolIndex+=6;
				ToolArrowsUpdate();
				ToolSlotsUpdate();
			}
		}
		
		//Clic sur un perosnnage | Click on a character
		void SlotClick(object sender, EventArgs e)
		{
			if ((IsTitlePassed&&!IsPlayerInMap)||(arriveParFusion&&isModelSoras(player_Ptr))) return;
			ToolCloseClick(null,null);
			var icone = (sender as PictureBox);
			int iconeNum = int.Parse(icone.Name.Substring(4,1))-1;
			if (Liste_Principale[slideIndex+iconeNum].isAvailable())
			{
				var actuel = personnageActuel;
				personnageActuel = Liste_Principale[slideIndex+iconeNum];
				Liste_Principale[slideIndex+iconeNum] = actuel;
				opacitePersonnageActuel=0;
				ActuelFadeIn.Enabled = true;
				SelectionPeronnage();
			}
		}
		
		int[] subToolLevel = new int[ACCESSORYCOUNT];
		//Clic sur un carré
		void ToolClick(object sender, EventArgs e)
		{
			ToolSlotsUpdate();
			var icone = (sender as Button);
			if (!icone.Enabled) return;
			int iconeNum = int.Parse(icone.Name.Substring(8,1));
			bool subAbort = true;
			switch (toolIndex)
			{
				case 0: //Warp
					selectedWorld = slideToolIndex+iconeNum;
					WarpPopUpState = 0;
					OpenPopUp(RoomsLABELS[selectedWorld].ToArray());
				break;
				case 3:
				if (subToolLevel[0]==0)
					{
						ToolLabel.Text = LanguageStrings[24]; //Select a color
						List<Bitmap> ToolList_ = new List<Bitmap>(0);
						List<string> ToolListLabels_ = new List<string>(0);
						bool addItem = true;
						while (IsTitlePassed&&addItem)
						{
							Bitmap test = (Bitmap)resourcesFaces.GetObject("Accessory_"+(slideToolIndex+iconeNum).ToString("X2")+"_"+ToolList_.Count.ToString("X2"));
							if (test==null)
							{
								addItem=false;
								continue;
							}
							ToolList_.Add(test);
							ToolListLabels_.Add("");
						}
						subToolLevel[1]=slideToolIndex+iconeNum;
						ToolList = ToolList_.ToArray();
						ToolListLabels = ToolListLabels_.ToArray();
						subAbort=false;
					}
					else
					{
						DMABARReader couronne = new DMABARReader("Files/BDMA/Crown.bdma");
						DMABARReader glace = new DMABARReader("Files/BDMA/IceCream.bdma");
						DMABARReader[] DMAccessoires = new DMABARReader[] {couronne,glace};
						for (int i=0;i<4;i++)
							WriteInteger(GetMDLXAddress(player_Ptr)+0x667B6+i*16,(byte)3);
						for (int i=0;i<DMAccessoires[subToolLevel[1]].getCount;i++)
						{
							Clipboard.SetText((GetMDLXAddress(player_Ptr)+DMAccessoires[subToolLevel[1]].getOffset(i)).ToString("X"));
							WriteBytes(GetMDLXAddress(player_Ptr)+DMAccessoires[subToolLevel[1]].getOffset(i),DMAccessoires[subToolLevel[1]].getBuffer(i));
						}
						for (int i=0;i<4;i++)
							WriteInteger(GetMDLXAddress(player_Ptr)+0x667B6+i*16,(byte)iconeNum);
					}
				break;
			}
			if (subAbort) return;
			
			subToolLevel[0]++;
			ToolLeft.Visible = true;
			ToolRight.Visible = true;
			ToolArrowsUpdate();
			ToolSlotsUpdate();
			ToolClose.Visible = true;
		}
		
		//Apparition de l'icone du personnage actuel | Current character Icon appearance
		void ActuelFadeInTick(object sender, EventArgs e)
		{
			opacitePersonnageActuel++;
			FaceContainer.Refresh();
			if (opacitePersonnageActuel<10) return;
			ActuelFadeIn.Enabled = false;
		}
		
		public void FaceContainerPaint(object sender, PaintEventArgs e)
		{
			PictureBox senderPB = (sender as PictureBox);
			if (senderPB.BackgroundImage == null) return;
			Bitmap bk = (WindowContainer.BackgroundImage as Bitmap);
			bk = bk.Clone(new Rectangle(senderPB.Location.X,senderPB.Location.Y,senderPB.Width,senderPB.Height),bk.PixelFormat);
			e.Graphics.DrawImage(bk,new Rectangle(0,0,senderPB.Width,senderPB.Height));
			bk = (WindowContainer.Image as Bitmap);
			bk = bk.Clone(new Rectangle(senderPB.Location.X,senderPB.Location.Y,senderPB.Width,senderPB.Height),bk.PixelFormat);
			
			e.Graphics.DrawImage(bk,new Rectangle(0,0,senderPB.Width,senderPB.Height));
			
			ColorMatrix colormatrix = new ColorMatrix();
			
			colormatrix.Matrix33 = (float)(((float)((byte)opacitePersonnageActuel))/10);
			ImageAttributes AttributsSource = new ImageAttributes();
			AttributsSource.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			
			Bitmap img = personnageActuel.getImage();
			
			int height = (int)((float)(senderPB.Width)*((float)img.Height/(float)img.Width));
			
			e.Graphics.DrawImage(senderPB.BackgroundImage,new Rectangle(0,(senderPB.Height/2)-(height/2),senderPB.Width,height),0,0,senderPB.BackgroundImage.Width,senderPB.BackgroundImage.Height,GraphicsUnit.Pixel);
			height = (int)(((float)(senderPB.Width)*((float)img.Height/(float)img.Width)));
			e.Graphics.DrawImage(img,new Rectangle(0,(senderPB.Height/2)-(height/2),senderPB.Width,height),0,0,img.Width,img.Height,GraphicsUnit.Pixel, AttributsSource);
		}
		
		public void SlotPaint(object sender, PaintEventArgs e)
		{
			PictureBox senderPB = (sender as PictureBox);
			if (senderPB.BackgroundImage == null) return;
			int  slotIndex = int.Parse(senderPB.Name.Substring(4,1))-1;
			Bitmap bk = (WindowContainer.BackgroundImage as Bitmap);
			bk = bk.Clone(new Rectangle(senderPB.Location.X,senderPB.Location.Y,senderPB.Width,senderPB.Height),bk.PixelFormat);
			
			ColorMatrix colormatrix = Liste_Principale[slideIndex+slotIndex].isAvailable() ? new ColorMatrix():new ColorMatrix(
				new float[][]
				{
					new float[] {.3f, .3f, .3f, 0, 0},
					new float[] {.59f, .59f, .59f, 0, 0},
					new float[] {.11f, .11f, .11f, 0, 0},
					new float[] {0, 0, 0, 1, 0},
					new float[] {0, 0, 0, 0, 1}
				});
			colormatrix.Matrix33 = (float)(((float)((byte)opacities[slotIndex]))/50);
			ImageAttributes AttributsSource = new ImageAttributes();
			AttributsSource.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			e.Graphics.DrawImage(bk,new Rectangle(0,0,senderPB.Width,senderPB.Height));
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			
			Bitmap img = Liste_Principale[slideIndex+slotIndex].getImage();
			int height = (int)((float)senderPB.Width*((float)img.Height/(float)img.Width));
			e.Graphics.DrawImage(img,new Rectangle(0,(senderPB.Height/2)-(height/2),senderPB.Width,height),0,0,img.Width,img.Height,GraphicsUnit.Pixel, AttributsSource);
		}
		
		//Activation de la surbrillance des icones | Activation of highlighted icons
		void SlotMouseEnter(object sender, EventArgs e)
		{
			var icone = (sender as PictureBox);
			int iconeNum = int.Parse(icone.Name.Substring(4,1))-1;
			sens[iconeNum] = 1;
			IconOpacity.Enabled = true;
		}
		
		//Transitions d'opacité des icones | Icons opacity transitions
		void IconOpacityTick(object sender, EventArgs e)
		{
			int somme = 0;
			for (int i=0;i<5;i++)
			{
				if (opacities[i]<22) somme = (sens[i]==1) ? 0 : somme+1;
				if (opacities[i]+sens[i]>20&opacities[i]+sens[i]<60) opacities[i]+=sens[i]*2;
				new PictureBox[] {Slot1,Slot2,Slot3,Slot4,Slot5}[i].Refresh();
			}
			IconOpacity.Enabled &= somme != 5;
		}
		
		//Désactivation de la surbrillance des icones | Deactivation of highlighted icons
		void SlotMouseLeave(object sender, EventArgs e)
		{
			var icone = (sender as PictureBox);
			int iconeNum = int.Parse(icone.Name.Substring(4,1))-1;
			sens[iconeNum] = -1;
		}
		
		int[] LightDelimitations = new int[] {0,5,52,18,51,8,47,18,99,10,48,17,149,9,46,19,196,7,48,21,242,5,47,20,287,0,47,21};
		int[] ShadowDelimitations = new int[] {0,5,52,18,50,8,48,18,99,10,48,18,148,9,47,19,196,7,48,21,242,5,47,21,287,0,48,21};
		
//
		void ButtonToolMouseLeave(object sender, EventArgs e)
		{
			ButtonTools.BackgroundImage = null;
			down = false;
		}
		
		//
		void ButtonToolMouseLight(object sender, EventArgs e)
		{
			if (down) return;
			int index = GetAreaIndex(ButtonTools.PointToClient(Cursor.Position).X,ButtonTools.PointToClient(Cursor.Position).Y);
			if (index==-1) return;
			var fond = new Bitmap(ButtonTools.Width,ButtonTools.Height);
			var icone = (Bitmap)resourcesFaces.GetObject("0"+index.ToString()+"_Light");
			var fondGr = Graphics.FromImage(fond);
			fondGr.DrawImage(icone,new Rectangle(LightDelimitations[index*4],LightDelimitations[1+index*4],LightDelimitations[2+index*4],LightDelimitations[3+index*4]));
			ButtonTools.BackgroundImage = fond;
		}
		
		bool down = false;
		//
		void ButtonToolMouseDown(object sender, EventArgs e)
		{
			down = true;
			int index = GetAreaIndex(ButtonTools.PointToClient(Cursor.Position).X,ButtonTools.PointToClient(Cursor.Position).Y);
			if (index==-1) return;
			var fond = new Bitmap(ButtonTools.Width,ButtonTools.Height);
			var icone = (Bitmap)resourcesFaces.GetObject("0"+index.ToString()+"_Shadow");
			var fondGr = Graphics.FromImage(fond);
			fondGr.DrawImage(icone,new Rectangle(ShadowDelimitations[index*4],ShadowDelimitations[1+index*4],ShadowDelimitations[2+index*4],ShadowDelimitations[3+index*4]));
			ButtonTools.BackgroundImage = fond;
		}
		
		int toolIndex = 0; //selectedWorld
		const int ACCESSORYCOUNT = 2;
		//Selection d'un paramètre
		void ButtonToolMouseUp(object sender, EventArgs e)
		{
			subToolLevel = new int[ACCESSORYCOUNT];
			if (down)
			{
				int index = GetAreaIndex(ButtonTools.PointToClient(Cursor.Position).X,ButtonTools.PointToClient(Cursor.Position).Y);
				if (index==-1) return;
				toolIndex = index;
				slideToolIndex = 0;
				if (toolIndex==0||toolIndex==2||toolIndex==3||toolIndex==4)
				{
					switch (toolIndex)
					{
						case 0:
							whoIsToolFor = new string[] {"","","","","","","","","","","","","","","","","",""};
						ToolLabel.Text = LanguageStrings[2]; //Select a world
						ToolList = new Bitmap[18];
						ToolListLabels = new string[] {LanguageStrings[3],LanguageStrings[4],LanguageStrings[5],LanguageStrings[6],LanguageStrings[7],LanguageStrings[8],LanguageStrings[9],LanguageStrings[10],LanguageStrings[11],LanguageStrings[12],LanguageStrings[13],LanguageStrings[14],LanguageStrings[15],LanguageStrings[16],LanguageStrings[17],LanguageStrings[18],LanguageStrings[19],LanguageStrings[20]};
						for (int i=1;i<19;i++)
							ToolList[i-1] = (Bitmap)resourcesFaces.GetObject(i.ToString("X2"));
						break;
						case 3:
						whoIsToolFor = new string[] {"P_EX100","P_EX100","","","",""};
						ToolLabel.Text = LanguageStrings[21]; //Select an accesory
						ToolList = new Bitmap[ACCESSORYCOUNT];
						ToolListLabels = new string[] {LanguageStrings[22],LanguageStrings[23]};
						for (int i=0;i<2;i++)
							ToolList[i] = (Bitmap)resourcesFaces.GetObject("Accessory_"+i.ToString("X2"));
						break;
						
					}
						
					ToolLeft.Visible = true;
					ToolRight.Visible = true;
					ToolArrowsUpdate();
					ToolSlotsUpdate();
					ToolClose.Visible = true;
				}
				else
				{
					switch (toolIndex)
					{
						case 1:
							OpenPopUp(musicNames);
						break;
						
					}
					
					ToolList = new Bitmap[0];
					ToolSlotsUpdate();
					ToolLeft.Visible = false;
					ToolRight.Visible = false;
					ToolClose.Visible = false;
					ToolListLabels = new string[0];
					ToolLabel.Text = "";
				}
			}
			down = false;
		}
		
		//Fermer les images tool
		void ToolCloseClick(object sender, EventArgs e)
		{
			ToolLabel.Text = "";
			ToolClose.Visible = false;
			ToolList = new Bitmap[0];
			ToolRight.Visible = false;
			ToolLeft.Visible = false;
			ToolClose.Visible = false;
			ToolSlotsUpdate();
		}
		
		void ToolMouseOver(object sender, EventArgs e)
		{
			var icone = (sender as Button);
			int iconeNum = int.Parse(icone.Name.Substring(8,1));
			ToolLabel.Text = ToolListLabels[slideToolIndex+iconeNum];
		}
		
		//Déterminer le bouton séléctionné par rapport à la position du curseur
		int GetAreaIndex(int x,int y)
		{
			int result = -1;
			for (int i=0;result==-1&&i<7;i++)
				if (x>=ShadowDelimitations[i*4]&&x<=ShadowDelimitations[i*4]+ShadowDelimitations[2+i*4]&&y>=ShadowDelimitations[1+i*4]&&y<=ShadowDelimitations[1+i*4]+ShadowDelimitations[3+i*4])
				result = i;
			return result;
		}
		
		//int mode = 1;
		Point OldLocation = new Point(0,0);
		
		
		/* CHANGEMENTS D'OPACITES DES COMPOSANTS | COMPONENTS OPACITY CHANGES*/
		/* ------------------------------------------------------ */
		
		/* ------------------------------------------------------ */
		/* MISE A JOUR DES IMAGES DES MONDES | WORLD PICTURE UPDATE */
		byte mondeActuel = 0;
		
		public void WorldPicUpdate()
		{
			if (WarpSet.Visible)
			{
				WorldPic.Image = (Bitmap)resourcesFaces.GetObject(worldNum.ToString("X2"));
			}
			if (mondeActuel!=ReadBytes(0x2032BAE0,1)[0])
			{
				mondeActuel = ReadBytes(0x2032BAE0,1)[0];
				WorldPic.Image = (Bitmap)resourcesFaces.GetObject(mondeActuel.ToString("X2"));
			}
			
		}
		
		/* MISE A JOUR DES IMAGES DES MONDES | WORLD PICTURE UPDATE */
		/* ------------------------------------------------------ */
		
		
		System.Collections.Generic.List<string> lastLines = new  System.Collections.Generic.List<string>(0);
		void ConsoleWriteLine(string debugLine)
		{
			if (lastLines.Contains(debugLine)==false)
			{
				if (lastLines.Count==3)
				lastLines.Clear();
				Console.WriteLine(debugLine);
			}
			if (lastLines.Count<3)
			lastLines.Add(debugLine);
		}
	}
}
