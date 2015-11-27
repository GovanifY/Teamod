using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Teamod_2
{
	public partial class MainForm : Form
	{
		IPersonnage[] Liste_Principale;
		IPersonnage personnageActuel;
		IPersonnage Xemnas_II;
		IPersonnage Xemnas_I;
		IPersonnage Xigbar;
		IPersonnage Xaldin;
		IPersonnage Vexen;
		IPersonnage Lexaeus;
		IPersonnage Zexion;
		IPersonnage Saix;
		IPersonnage Axel;
		IPersonnage Demyx;
		IPersonnage Luxord;
		IPersonnage Marluxia;
		IPersonnage Larxene;
		IPersonnage OrganisationRoxas;
		IPersonnage Empty;
		
		public void LoadPersonnages()
		{
			// Chargement des personnages | Loading bitmaps of characters
			//Xemnas_II = new IPersonnage("Xemnas","B_EX170_LAST",2079,(Bitmap)resources.GetObject("Xemnas_II"),XemnasString,true);
			Xemnas_I = new IPersonnage("Xemnas","B_EX170_LV99","B_EX170",2505,(Bitmap)resourcesFaces.GetObject("Xemnas_I"),XemnasString,true);
			Xigbar = new IPersonnage("Xigbar","B_EX140_LV99","B_EX140",2501,(Bitmap)resourcesFaces.GetObject("Xigbar"),XigbarString,true);
			Xaldin = new IPersonnage("Xaldin","B_EX130_LV99","B_EX130",2507,(Bitmap)resourcesFaces.GetObject("Xaldin"),XaldinString,true);
			Vexen = new IPersonnage("Vexen","N_CM040_BTL","N_CM040_BTL",2355,(Bitmap)resourcesFaces.GetObject("Vexen"),VexenString,true);
			Lexaeus = new IPersonnage("Lexaeus","N_CM020_BTL","N_CM020_BTL",2357,(Bitmap)resourcesFaces.GetObject("Lexaeus"),LexaeusString,true);
			Zexion = new IPersonnage("Zexion","B_EX370","B_EX370",2427,(Bitmap)resourcesFaces.GetObject("Zexion"),ZexionString,true);
			Saix = new IPersonnage("Saix","B_EX160_LV99","B_EX160",2502,(Bitmap)resourcesFaces.GetObject("Saix"),SaixString,true);
			Axel = new IPersonnage("Axel","B_EX110_LV99","B_EX110_LV99",2500,(Bitmap)resourcesFaces.GetObject("Axel"),AxelString,true);
			Demyx = new IPersonnage("Demyx","B_EX120_HB_LV99","B_EX120_HB",2508,(Bitmap)resourcesFaces.GetObject("Demyx"),DemyxString,true);
			Luxord = new IPersonnage("Luxord","B_EX150_LV99","B_EX150",2504,(Bitmap)resourcesFaces.GetObject("Luxord"),LuxordString,true);
			Marluxia = new IPersonnage("Marluxia","N_CM000_BTL","N_CM000_BTL",2339,(Bitmap)resourcesFaces.GetObject("Marluxia"),MarluxiaString,true);
			Larxene = new IPersonnage("Larxene","B_EX400","B_EX400",2402,(Bitmap)resourcesFaces.GetObject("Larxene"),LarxeneString,true);
			OrganisationRoxas = new IPersonnage("Roxas","B_EX390","B_EX390",2385,(Bitmap)resourcesFaces.GetObject("Roxas"),RoxasString,true);
			Empty = new IPersonnage("Empty","EMPTY","EMPTY",0,new Bitmap(76,95),XigbarString,false);
			Liste_Principale = new IPersonnage[] {OrganisationRoxas,Larxene,Marluxia,Luxord,Demyx,Axel,Saix,Zexion,Lexaeus,Vexen,Xaldin,Xigbar,Xemnas_I,Empty,Empty};
			personnageActuel = new IPersonnage("Sora","P_EX100","P_EX100",84,(Bitmap)resourcesFaces.GetObject("Sora"),SoraString,true);
		}
		string allclip = "";
		public MainForm()
		{
			InitializeComponent();
			OldLocation = Location;
			LoadPersonnages();
			LoadBitmaps();
			InitWarpStrings();
			SeekPCSX2(Title);
			GameStateACK();
			ChangeGameSettings();
			//GetMsetShortcut();
		}
		byte[] field0x18 = new byte[0];
		byte[] field0x19 = new byte[0];
		
		int msetAddress = -1;
		int mdlxAddress = -1;
		int afmAddress = -1;
		byte ISO_Language = 0;
		byte keybladeDigit = 0;
		int ANB_history = 0;
		float positionSol = 0;
		List<int> allocatedEC = new List<int>(0);
		
		void MainTick(object sender, EventArgs e)
		{
			SeekPCSX2(Title);
			GameStateACK();
			if (!IsTitlePassed) return;
			WorldPicUpdate();
			WarpLock();
			RelachementTouches();
			MusicUpdate();
			
			//Detect the language of the ISO
			if (ReadBytes(Pointer(Pointer(0x20347EA8,0x20024c58),0x20000000),1)[0] == 0x2E) ISO_Language = 1;
			
			//Tells the game current character is not coming from a drive
			WriteInteger(0x2032F054,(byte)0);
			
			//Get current keyblade digit
			if (keybladeDigit==0) keybladeDigit = ReadBytes(0x2032E020,1)[0];
			
			//Get distance between jump-height of current character and floor
			float positionSolTmp = DistanceSol(player_Ptr);
			positionSol = Math.Round(positionSolTmp,2).ToString()!="320000" ? positionSolTmp : positionSol;
			
			if (enTrainDeFaireFusion())
			{
				HPInitWaitCount = 0;
				msetAddress=-1;
				arriveParFusion=true;
				do
				msetAddress = SearchResource("obj/"+personnageActuel.getMsetName()+".mset");
				while (IsTitlePassed&&msetAddress==-1);
				mdlxAddress = SearchResource("obj/"+personnageActuel.getMdlxName()+".mdlx");
				CharacterCollisionWidth();
				DriveApparition();
				while (enTrainDeFaireFusion()||(IsTitlePassed&&ReadString(Pointer(Pointer(player_Ptr,0x2000014C),0x1fffffd0),3)!="BAR")) {}
				DebutDeMap();
			}
			
			//Which character ?
			if (IsMapLoaded)
			switch (GetModelName(player_Ptr))
			{
				case "B_EX390": //Organisation Roxas
					OrganisationRoxasSection();
				break;
				case "B_EX400": //Larxene
					LarxeneSection();
				break;
				case "N_CM000_BTL": //Marluxia
					MarluxiaSection();
				break;
				case "B_EX150_LV99": //Luxord
					LuxordSection();
				break;
				case "B_EX120_HB_LV99": //Demyx
					DemyxSection();
				break;
				case "B_EX110_LV99": //Axel
					AxelSection();
				break;
				case "B_EX160_LV99": //Saix
					SaixSection();
				break;
				case "B_EX370": //Zexion
					ZexionSection();
				break;
				case "N_CM020_BTL": //Lexaeus
					LexaeusSection();
				break;
				case "N_CM040_BTL": //Vexen
					VexenSection();
				break;
				case "B_EX130_LV99": //Xaldin
					XaldinSection();
				break;
				case "B_EX140_LV99": //Xigbar
					XigbarSection();
				break;
				case "B_EX170_LV99": //Xemnas
					XemnasSection();
				break;
				
			}
			
			if (isModelNPC(player_Ptr))
			{
				var sonnnaAddress = Pointer(Pointer(0x20347EA8,0x20000dd8),0x20000000);
				if (ReadUShort(sonnnaAddress)==0xBD9E)
					WriteBytes(sonnnaAddress,new byte[1]);
				KillBitches();
				WriteBytes(0x21C5FF48,new byte[12]); //Deactivate Reaction commands
				WatchTStance(player_Ptr);
			}
			if (GetModelName(player_Ptr)==personnageActuel.getMdlxName())
				UpdateCutomizedHP();
			
			ChangeGameSettings();
		}
		
		
		bool arriveParFusion = false;
		int firstMoveLoaded = 0;
		
		//Click on a character
		void SelectionPeronnage()
		{
			while (IsTitlePassed&&GetModelName(player_Ptr).Length==0) {}
			WriteInteger(0x21ce0b68,(short)personnageActuel.getDigit());
			WriteInteger(0x21C6CC28,(short)personnageActuel.getDigit());
			WriteInteger(0x21CE0B70,(short)personnageActuel.getDigit());
			if (isModelSoras(player_Ptr))
			{
				bool selectedModel = personnageActuel.getMdlxName()=="P_EX100";
				if (selectedModel)
				{
					WriteInteger(0x21ce0b68,(short)84);
					WriteInteger(0x21C6CC28,(short)85);
					WriteInteger(0x21CE0B70,(short)85);
					if (keybladeDigit>0)
					WriteInteger(0x2032E020,(byte)keybladeDigit);
					WriteString(0x21C95C10,"W_EX010");
					TriangleDrive(false);
				}
				else
				TriangleDrive(true);
			}
		}
		
		void DebutDeMap()
		{
			HPInitWaitCount = 0;
			ToolSlotsUpdate();
			CheckHUDMaximums();
			field0x18 = LoadFile(@"Files\HUD\"+GetModelName(player_Ptr)+@"\texture.imgd");
			field0x19 = LoadFile(@"Files\HUD\"+GetModelName(player_Ptr)+@"\field.seqd");
			if (field0x18.Length==0||field0x19.Length==0)
			{
				field0x18 = LoadFile(@"Files\HUD\texture_bk.imgd");
				field0x19 = LoadFile(@"Files\HUD\field_bk.seqd");
			}
			if (isModelNPC(player_Ptr))
			for (int i=0;i<ReadInt32(msetAddress+4);i++)
				if (ReadInt32(msetAddress+0x1C+16*i)==0)
					WriteBytes(msetAddress+0x10+16*i,ReadBytes(msetAddress+0x360,16));
		}
		List<string> warnLog = new List<string>(0);
		
		
		//Load a byte array from a file on the computer
		byte[] LoadFile(string chemin)
		{
			byte[] output = new byte[0];
			try
			{
				output = System.IO.File.ReadAllBytes(chemin);
			}
			catch
			{
				warnLog.Add("Could not load resource at "+chemin+". The application tried to read an absent file.");
			}
			return output;
		}
	}
}