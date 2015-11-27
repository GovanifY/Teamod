using System;
using System.Text;
using System.Windows.Forms;

namespace Teamod_2
{
	public partial class MainForm : Form
	{
		string[] worlds = new string[] {"The World of Darkness","Twilight Town","Destiny Islands","Hollow Bastion","Beast's Castle","Olympus Colisseum","Agrabah","Land of Dragons","100 Acre Wood","Pride Lands","Atlantica","Disney Castle","Timeless River","Halloween Town","World Map","Port Royal","Space Paranoids","The World That Never Was"};
		string[][] room_names =
		{
			/*string[] world_01 =*/ new string[] {"The Dark Margin","Loop Demo"}
			,/*string[] world_02 =*/ new string[] {"The Empty Realm","Roxas's Room","The Usual Spot","Back Alley","Sandlot","Sandlot","Market Street: Station Heights","Market Street: Tram Common","Station Plaza","Central Station","Sunset Terrace","Sunset Station","Sunset Hill","The Woods","The Old Mansion","Mansion: Foyer","Mansion: Dining Room","Mansion: Library","Mansion: The White Room","Mansion: Basement Hall","Mansion: Basement Hall","Mansion: Computer Room","Mansion: Basement Corridor","Mansion: Pod Room","On the Train","The Tower","Tower: Entryway","Tower: Sorcerer's Loft","Tower: Wardrobe","Tower: Star Chamber","Tower: Moon Chamber","Tower: Wayward Stairs","Station of Serenity","Station of Calling","Station of Awakening","The Mysterial Train","Tunnelway","Underground Concourse","Tower: Wayward Stairs","Tower: Wayward Stairs","Between and Betwix"}
			,/*string[] world_03 =*/ new string[] {"Beach","Main Island: Ocean's Road","Main Island: Shore"}
			,/*string[] world_04 =*/ new string[] {"Villain's Vale","The Dark Depths","The Great Maw","Crystal Fissure","Castle Gate","Ansem's Study","Postern","Restoration Site","Bailey","Borough","Marketplace","Corridors","Heartless Manufactory","Merlin's House","Castle Oblivion","Ansem's Study","Ravine Trail","The Great Maw","Restoration Site","Bailey","Corridors","Cavern of Remembrance: Depths","Cavern of Remembrance: Mining Area","Cavern of Remembrance: Engine Chamber","Cavern of Remembrance: Mineshaft","Transport to Remembrance","Garden of Assemblage","The Underground","Memory's Contortion","The World of Nothing","Hall of Empty Melodies","??","Front Mansion","Station of Remembrance","Destiny Islands","Addled Impasse","Mansion: Basement Hall","Havoc's Divide","Station of Oblivion"}
			,/*string[] world_05 =*/ new string[] {"Entrance Hall","Parlor","Belle's Room","Beast's Room","Ballroom","Ballroom","Courtyard","The East Wing","The West Hall","The West Wing","Dungeon","Undercroft","Secret Passage","Bridge","Ballroom","Bridge"}
			,/*string[] world_06 =*/ new string[] {"The Coliseum","Colliseum Gates","Colliseum Gates","Underworld Entrance","Colliseum Foyer","Valley of the Dead","Hades' Chamber","Cave of the Dead: Entrance","Well of Captivity","The Underdrome","Cave of the Dead: Inner Chamber","Underworld Caverns: Entrance","The Lock","The Underdrome","Colliseum Gates","Cave of the Dead: Passage","Underworld Caverns: The Lost Road","Underworld Caverns: Atrium","Coliseum Gates","The Underdrome"}
			,/*string[] world_07 =*/ new string[] {"Agrabah","Bazaar","The Peddler's Shop","The Palace","Vault","Above Agrabah","Palace Walls","The Cave of Wonders: Entrance","Freeze","The Cave of Wonders: Stone Guardians","The Cave of Wonders: Treasure Room","Ruined Chamber","The Cave of Wonders: Valley of Stone","The Cave of Wonders: Chasm of Challenges","Sandswept Ruins","The Peddler's Shop"}
			,/*string[] world_08 =*/ new string[] {"Bamboo Grove","Encampment","Checkpoint","Mountain Trail","Village","Village Cave","Ridge","Summit","Imperial Square","Palace Gate","Antechamber","Throne Room","Village"}
			,/*string[] world_09 =*/ new string[] {"The Hundred Acre Wood","Starry Hill","Pooh Bear's House","Rabbit's House","Piglet's House","Kanga's House","A Windsday Tale","The Honey Hunt","Blossom Valley","The Spooky Cave"}
			,/*string[] world_0A =*/ new string[] {"Pride Rock","Stone Hollow","The King's Den","Wildebeest Valley","The Savannah","Elephant Graveyard","Gorge","Wastelands","Jungle","Oasis","Pride Rock","Oasis","Overlook","Peak","Scar's Darkness","The Savannah","Wildebeest Valley"}
			,/*string[] world_0B =*/ new string[] {"Triton's Throne","Ariel's Grotto","Undersea Courtyard","Undersea Courtyard","The Palace: Performace Hall","Sunken Ship","The Shore","The Shore","The Shore","Wrath of the Sea","Wedding Ship"}
			,/*string[] world_0C =*/ new string[] {"Audience Chamber","Library","Colonnade","Courtyard","The Hall of the Cornerstone","The Hall of the Cornerstone","Gummi Hangar","Gathering Place"}
			,/*string[] world_0D =*/ new string[] {"Cornerstone Hill","Pier","Waterway","Wharf","Lilliput","Building Site","Scene of the Fire","Mickey's House","Villian's Vale"}
			,/*string[] world_0E =*/ new string[] {"Halloween Town Square","Dr. Finkelstein's Lab","Graveyard","Curly Hill","Hinterlands","Yuletide Hill","Candy Cane Lane","Christmas Tree Plaza","Santa's House","Toy Factory: Shipping and Receiving","Toy Factory: The Wrapping Room"}
			,/*string[] world_0F =*/ new string[] {"","DUMMY"}
			,/*string[] world_10 =*/ new string[] {"Rampart","Harbor","Town","The Interceptor","The Interceptor: Ship's Hold","The Black Pearl","The Black Pearl: Captain's Stateroom","The Interceptor","Isla de Muerta: Rock Face","Isla de Muerta: Cave Mouth","Isla de Muerta: Treasure Heap","Ship Graveyard: The Interceptor's Hold","Isla de Muerta: Powder Store","Isla de Muerta: Moonlight Nook","Ship Graveyard: Seadrift Keep","Ship GraveYard: Seadrift Row","Isla de Muerta: Rock Face","Isla de Muerta: Treasure Heap","The Black Pearl","The Black Pearl","The Black Pearl","The Interceptor","The Interceptor","The Black Pearl: Captain's Stateroom","Harbor","Isla de Muerta: Rock Face"}
			,/*string[] world_11 =*/ new string[] {"Pit Cell","Canyon","Game Grid","Dataspace","I/O Tower: Hallway","I/O Tower: Communications Room","Simulation Hangar","Solar Sailer Simulation","Central Computer Mesa","Central Computer Core","Solar Sailer Simulation"}
			,/*string[] world_12 =*/ new string[] {"Where Nothing Gathers","Alley to Between","Fragment Crossing","Memory's Skyscraper","The Brink of Despair","The Soundless Prison","Nothing's Call","Crooked Ascension","Crooked Ascension","Twilight's View","Hall of Empty Melodies","Hall of Empty Melodies","Naught's Skyway","Proof of Existance","Havoc's Divide","Addled Impasse","Naught's Approach","Ruin and Creation's Passage","The Alter of Naught","Memory's Contortion","The World of Nothing","Station of Awakening","The World of Nothing","The World of Nothing","The World of Nothing","The World of Nothing","The World of Nothing","The World of Nothing","The World of Nothing","Alter of Naught"}
		};
		
		const int player_Ptr = 0x20341708;
		const int partner1_Ptr = 0x2034170C;
		const int partner2_Ptr = 0x20341710;
		const int room_HistoryPtr = 0x21D48DA0;
		const int keyblade_Ptr = 0x21D48DA4;
		
		bool IsEmulationRunning = false;
		bool IsKH2Running = false;
		bool IsTitlePassed = false;
		bool IsMapLoaded = false;
		bool IsPlayerInMap = false;
		bool autoSelect = true;
		
		//Acknoledge running states
		void GameStateACK()
		{
			IsEmulationRunning = ReadInt32(0x20000000) != 0;
			IsKH2Running = IsEmulationRunning&&ReadInt32(0x21C94008) == 0x2E32484B;
			IsTitlePassed = IsKH2Running&&ReadInt32(0x21D9EAAC) != 0;
			
			if (IsTitlePassed&&!IsMapLoaded)
			{
				arriveParFusion=false;
				firstMoveLoaded=0;
				allocatedEC.Clear();
				msetAddress = mdlxAddress = afmAddress = -1;
				loadedCorrectly=false;
				if (ReadBytes(0x21C6CAF7,1)[0] == 1) //If character is in a map
				{
					//Auto selection of current character in Teamod interface when first opened
					if (autoSelect)
					{
						string mdNameHistory = GetModelName(player_Ptr);
						for (int i=0;i<Liste_Principale.Length;i++)
						if (Liste_Principale[i].getMdlxName()==mdNameHistory)
						{
							var actuel = personnageActuel;
							personnageActuel = Liste_Principale[i];
							Liste_Principale[i] = actuel;
					    	opacitePersonnageActuel=0;
							ActuelFadeIn.Enabled = true;
						}
						autoSelect=false;
					}
					SelectionPeronnage();
				}
			}
			//Initialisation of current character in the map
			if (IsMapLoaded&&msetAddress==-1&&ReadInt32(Pointer(player_Ptr,0x20000148))==ReadInt32(player_Ptr))
			{
				while (IsTitlePassed&&ReadString(GetMSETAddress(player_Ptr),3)!="BAR") {}
				msetAddress = GetMSETAddress(player_Ptr);
				while (IsTitlePassed&&ReadString(GetMDLXAddress(player_Ptr),3)!="BAR") {}
				mdlxAddress = GetMDLXAddress(player_Ptr);
				while (IsTitlePassed&&ReadString(GetAFMAddress(player_Ptr),3)!="BAR") {}
					afmAddress = GetAFMAddress(player_Ptr);
				if (isModelNPC(player_Ptr))
					DriveApparition();
				
				DebutDeMap();
				if (isModelNPC(player_Ptr))
				{
					SetPaxAlgoAddress(player_Ptr,ReadInt32(Pointer(msetAddress+0x18,0x20000028)));
					SetFrame(player_Ptr,-1);
				}
			}
			
			IsMapLoaded = IsTitlePassed&&ReadBytes(0x21C6CAF7,1)[0] == 1;
			IsPlayerInMap = IsMapLoaded&&ReadInt32(player_Ptr)>0&&ReadInt32(Pointer(player_Ptr,0x20000148))==ReadInt32(player_Ptr);
		}
		bool loadedCorrectly = false;
		byte[] vaillanceBackup = new byte[1];
		int vaillanceLocation = 0;
		
		//Make the drive reaction command appear
		void TriangleDrive(bool onOff)
		{
			if (vaillanceLocation==0)
			{
				byte[] chercherVaillance = ReadBytes(Pointer(0x21C61978,0x20006730),500);
				int resultatVaillance=0;
				byte count = 0;
				while (IsTitlePassed&&resultatVaillance<500&&count<new int[] {46,27}[ISO_Language])
				{
					if (chercherVaillance[resultatVaillance]==0) 
					count++;
					resultatVaillance++;
				}
				vaillanceBackup = ReadBytes(Pointer(0x21C61978,0x20006730)+resultatVaillance,16);
				vaillanceLocation = Pointer(0x21C61978,0x20006730)+resultatVaillance;
			}
			if (onOff)
			{
				WriteInteger(0x21C6C901,8);
				WriteBytes(vaillanceLocation,personnageActuel.getBarString(ISO_Language));
				WriteBytes(0x21C5FF48,new byte[] {0,0,0,0,0,0,6,0,0,0,0,0,0}); //Affichage Reaction command
			}
			else
			{
				WriteInteger(0x21C5FF48,1);
				WriteBytes(vaillanceLocation,vaillanceBackup);
			}
		}
		
		//Get Current object name
		string GetModelName(int pointer)
		{
			return ReadString(Pointer(Pointer(pointer,0x20000008),0x20000008),32);
		}
		
		//Get Current MDLX Address
		int GetMDLXAddress(int pointer)
		{
			return Pointer(Pointer(pointer,0x200007AC),0x20000000);
		}
		
		//Get Current MSET Address
		int GetMSETAddress(int pointer)
		{
			return Pointer(Pointer(pointer,0x20000140),0x20000000);
		}
		
		//Get Current AFM Address
		int GetAFMAddress(int pointer)
		{
			return Pointer(Pointer(pointer,0x200007B0),0x20000000);
		}
		
		//Get Playing animation BAR address
		int GetBAR11Address(int pointer)
		{
			return GetANBPointer(pointer)+0x1FFFFFD0;
		}
		
		//Get current ANB location
		int GetANBPointer(int pointer)
		{
			return ReadInt32(Pointer(pointer,0x2000014C));
		}
		
		//Force ANB to play
		void SetANBPointer(int pointer,int valeur)
		{
			WriteInteger(Pointer(pointer,0x2000014C),valeur);
		}
		
		//Get current PAX algo of playing animation
		int GetPaxAlgoAddress(int pointer)
		{
			return Pointer(Pointer(pointer,0x20000150),0x20000000);
		}
		
		//Set current PAX algo of playing animation
		void SetPaxAlgoAddress(int pointer,int valeur)
		{
			WriteInteger(Pointer(pointer,0x20000150),valeur);
		}
		
		//Get current Animation playing frame
		float GetFrame(int pointer)
		{
			return ReadFloat(Pointer(pointer,0x20000170));
		}
		
		//Set current Animation playing frame
		void SetFrame(int pointer, float valeur)
		{
			WriteFloat(Pointer(pointer,0x20000170),valeur);
		}
		
		//Get current Animation max frame
		float GetMaxFrame(int pointer)
		{
			return ReadFloat(Pointer(pointer,0x2000016C));
		}
		
		//Set current Animation max frame
		void SetMaxFrame(int pointer, float valeur)
		{
			WriteFloat(Pointer(pointer,0x2000016C),valeur);
		}
		
		//Get location character
		float GetLocation(int pointer, byte which)
		{
			return ReadFloat(Pointer(pointer,0x20000540+new int[]{/*X*/0,/*Y*/8,/*Z*/4}[which]));
		}
		
		//Set location of current character
		void SetLocation(int pointer, byte which, float valeur)
		{
			WriteFloat(Pointer(pointer,0x20000540+new int[]{/*X*/0,/*Y*/8,/*Z*/4}[which]),valeur);
		}
		
		//Check if Sora is driving
		public bool enTrainDeFaireFusion()
		{
			return ReadString(Pointer(Pointer(player_Ptr,0x2000014c),0x1ffffff4),4)=="A120";
		}
		
		//Search a buffered resource (Model, map, sound...) in KH2FM resource list (In the RAM)
		int SearchResource(string name)
		{
			//Start method 1 (From x20381340 data base)
			byte[] buffer = ReadBytes(0x20381340,0x5000);
			int SearchOffset = 0;
			int result_test = 0;
			if (arriveParFusion)
			{
				SearchOffset =	SearchBytes(buffer,Encoding.ASCII.GetBytes(name));
				result_test = Som(ReadInt32(0x20381340+SearchOffset+0x2C),0x20000000);
				
				if (ReadString(result_test,3)=="BAR"&&Som(ReadInt32(result_test+8),0x20000000)==result_test)
				{
					buffer=null;
					return result_test;
				}
				else if (GetModelName(player_Ptr)!="P_EX100"&&SearchOffset>-1&&ReadBytes(0x21C6CAF7,1)[0] == 1)
				{
					WriteBytes(0x20381340+SearchOffset,new byte[] {0});
					SearchResource(name);
				}
			}
			//Start method 1 (From x204F6300 data base)
			
			buffer = ReadBytes(0x204F6300,0x5000);
			SearchOffset = SearchBytes(buffer,Encoding.ASCII.GetBytes(name));
			result_test = Som(ReadInt32(0x204F6300+SearchOffset+0x2C),0x20000000);
			if (ReadString(result_test,3)=="BAR"&&Som(ReadInt32(result_test+8),0x20000000)==result_test)
			{
				buffer=null;
				return result_test;
			}
			else if (GetModelName(player_Ptr)!="P_EX100"&&SearchOffset>-1&&ReadBytes(0x21C6CAF7,1)[0] == 1)
			{
				WriteBytes(0x204F6300+SearchOffset,new byte[] {0});
				SearchResource(name);
			}
			ConsoleWriteLine("Waiting for \""+name+"...");
       		return -1;
		}
		
		
		//Define if the characters must walk or fall
		void SetAnimationState(int pointeur, byte valeur)
		{
			WriteInteger(Pointer(pointeur,0x2000000C),valeur);
		}
		
		//Check if the character is attacking, walking, falling, or climbing
		byte GetAnimationState(int pointeur)
		{
			return ReadBytes(Pointer(pointeur,0x2000000C),1)[0];
		}
		
		//Define the animation index played when the character is landing
		void AnimAterrissage(int pointeur, int valeur)
		{
			WriteInteger(Pointer(pointeur,0x20000104),valeur);
		}
		
		//Define the animation index played when the character is falling
		void AnimChute(int pointeur, int valeur)
		{
			WriteInteger(Pointer(pointeur,0x20000100),valeur);
		}
		
		//Get the distance between current character jump-height and the floor
		float DistanceSol(int pointeur)
		{
			return ReadFloat(Pointer(pointeur,0x200005f8));
		}
		
		//Returns true if current character is touching the floor
		bool EstAuSol(int pointeur)
		{
			return (decimal)positionSol==(decimal)GetLocation(pointeur,2);
		}
		
		//Returns true if current character jump-height is near to the floor
		bool EstProcheDuSol(int pointeur)
		{
			string distance = Math.Round(DistanceSol(pointeur),2).ToString();
			return distance!="320000";
		}
		
		//Check & fixes T stances
		void WatchTStance(int pointeur)
		{
			if (GetANBPointer(pointeur)==0)
			{
				WriteFloat(Pointer(0x20348058,0x2000a710),1f);
				SetAnimationState(pointeur,0x30);
				SetModelTarget(player_Ptr,0);
				WalkStep(player_Ptr,2f);
				RunStep(player_Ptr,8f);
				TurnStep(player_Ptr,0.1963495463f);
				WriteInteger(Pointer(pointeur,0x2000023C),0);
				WriteInteger(Pointer(pointeur,0x20000240),0);
				if (EstAuSol(pointeur)) AnimAterrissage(pointeur,0);
				SetAnimationState(pointeur,0x40);
				Console.WriteLine("Null ANB Pointer detected & fixed. (BAR+0x18)");
			}
		}
		
		//Define which character are attacks directed to
		void SetModelTarget(int pointeur, int id)
		{
			WriteInteger(Pointer(pointeur,0x200009F4),id);
		}
		
		//Activate/Deactivate commands from command menu (If Sora or not Sora)
		void CommandsActivation(bool activate)
		{
			if (activate)
			{
				WriteInteger(0x2032D8c0,-1);
				WriteInteger(0x2032D809,(byte)0xFF);
				WriteInteger(0x2032D864,-1);
				WriteInteger(0x21C5FEF0,(byte)0);
			}
			else
			{
				WriteInteger(0x2032D8c0,0);
				WriteInteger(0x2032D809,(byte)0);
				WriteInteger(0x2032D864,0);
				WriteInteger(0x21C5FEF0,(byte)7);
			}
		}
		
		//Make current character invincible (Boss effects)
		void Invulnerability(bool ouiOuNon)
		{
			WriteBytes(0x21F001A8,ouiOuNon?new byte[7]:new byte[] {100,0,0,0,0,100,100});
		}
		
		//Set HP and MP to 2000 and 400
		void CheckHUDMaximums()
		{
			if (ReadInt32(0x21F00004)!=2000)
			{
				WriteInteger(0x21F00000,2000);
				WriteInteger(0x21F00004,2000);
				Invulnerability(false);
			}
			if (ReadInt32(0x21F00184)!=400)
			{
				WriteInteger(0x21F00180,400);
				WriteInteger(0x21F00184,400);
				Invulnerability(false);
			}
		}
		
		//Update customized HUD HP/MP values
		int HPInitWaitCount = 0;
		public void UpdateCutomizedHP()
		{
			int commandAddress = Pointer(0x20347FD8,0x20000000);
			if (ReadInt32(commandAddress+0x2C)==53572)
			{
				if (field0x18.Length>0&&field0x19.Length>0&&HPInitWaitCount<10)
				{
					HPInitWaitCount++;
					WriteBytes(Pointer(commandAddress+0x18,0x20000000),field0x18);
					WriteBytes(Pointer(commandAddress+0x28,0x20000000),field0x19);
				}
			}
			else if (isModelNPC(player_Ptr))
			SetHUDOpacity(0);
			CommandsActivation(isModelSoras(player_Ptr));
			
			if (ReadInt32(commandAddress+0x2C)!=53572||isModelSoras(player_Ptr)) return;
			WriteInteger(Pointer(0x20347EA8,0x20000de0),500); //Virer "sonna messe-ji..."
			WriteInteger(Pointer(player_Ptr,0x2000048c),0x1F00000);
			WriteBytes(0x21C5F55C,new byte[] {0x01,0x00,0x00,0x00,0x00,0x00,0x68,0x02}); //Blocage du nombre de commandes à 1
			
			int CmdPTR = Pointer(Pointer(0x20347FD8,0x20000028),0x20000000);
			double HPRatio = (double)GetHP()/(double)GetHPMax();
			double MPRatio = (double)GetMP()/(double)GetMPMax();
			int niveauHP = (int)(10+(double)(102*HPRatio));
			int niveauMP = (int)((double)(128*MPRatio));
			
			WriteInteger(CmdPTR+0x2528,niveauHP);
			WriteInteger(CmdPTR+0x2534,niveauHP);
			WriteInteger(CmdPTR+0x253C,niveauHP+5);
			
			WriteInteger(CmdPTR+0x37D4,niveauHP);
			WriteInteger(CmdPTR+0x37E0,niveauHP);
			WriteInteger(CmdPTR+0x37E8,niveauHP+5);
			
			WriteInteger(CmdPTR+0x33D8,niveauHP);
			WriteInteger(CmdPTR+0x33E4,niveauHP);
			WriteInteger(CmdPTR+0x33EC,niveauHP+5);
			
			WriteInteger(CmdPTR+0x262C,5+niveauMP);
			WriteInteger(CmdPTR+0x27C8,-30+niveauMP);
			WriteInteger(CmdPTR+0x27D0,-30+niveauMP+2);
			
			WriteInteger(CmdPTR+0x34DC,5+niveauMP);
			WriteInteger(CmdPTR+0x27DC,-30+niveauMP);
			WriteInteger(CmdPTR+0x27E4,-30+niveauMP+2);
			
			WriteInteger(CmdPTR+0x38D8,5+niveauMP);
			WriteInteger(CmdPTR+0x27F0,-30+niveauMP);
			WriteInteger(CmdPTR+0x27F8,-30+niveauMP+2);
			
			if (HPRatio<0.25)
			{
				byte CyanChannel = (decimal)HPRatio==0 ? (byte)20 :(byte)(60+(65*GetSeed(32)));
				WriteBytes(CmdPTR+0x154,new byte[] {128,CyanChannel,CyanChannel,128,128,CyanChannel,CyanChannel,128,128,CyanChannel,CyanChannel,128,128,CyanChannel,CyanChannel,128});
				WriteBytes(CmdPTR+0x19E8,new byte[] {128,CyanChannel,CyanChannel,128,128,CyanChannel,CyanChannel,128,128,CyanChannel,CyanChannel,128,128,CyanChannel,CyanChannel,128});
				WriteBytes(CmdPTR+0x2330,new byte[] {128,CyanChannel,CyanChannel,128,128,CyanChannel,CyanChannel,128,128,CyanChannel,CyanChannel,128,128,CyanChannel,CyanChannel,128});
			}
			else if (ReadBytes(CmdPTR+0x155,1)[0]<128)
			{
				WriteBytes(CmdPTR+0x154,new byte[] {128,128,128,128,128,128,128,128,128,128,128,128,128,128,128,128});
				WriteBytes(CmdPTR+0x19E8,new byte[] {128,128,128,128,128,128,128,128,128,128,128,128,128,128,128,128});
				WriteBytes(CmdPTR+0x2330,new byte[] {128,128,128,128,128,128,128,128,128,128,128,128,128,128,128,128});
			}
			ushort mp = GetMP();
			if (mp<GetMPMax()&&ReadBytes(0x20349E04,1)[0]>seedOffset)
				WriteInteger(0x21F00180,mp+1);
			
			seedOffset = ReadBytes(0x20349E04,1)[0];
		}
		
		byte seedOffset=0;
		//Get a ingame syncronized timer value (Speed is the repetition frequency)
		double GetSeed(byte speed)
		{
			return (double)(ReadBytes(0x20349E04,1)[0]%speed)/(double)speed;
		}
		
		//Get current character HP value
		ushort GetHP()
		{
			return ReadUShort(0x21F00000);
		}
		
		//Get current character max HP value
		ushort GetHPMax()
		{
			ushort hp = ReadUShort(0x21F00004);
			return hp>0?hp:(ushort)1;
		}
		
		//Get current character MP value
		ushort GetMP()
		{
			return ReadUShort(0x21F00180);
		}
		
		//Get current character max MP value
		ushort GetMPMax()
		{
			ushort mp = ReadUShort(0x21F00184);
			return mp>0?mp:(ushort)1;
		}
		
		//Get the number of instructions of an effect caster algorithm according to its ingame address
		//("Effect Caster" or "EC" = Algorithm of Sounds, sprites, opacity change, etc. during an animation)	
		int GetECLength(int address_start, int which)
		{
			byte[] buffer = ReadBytes(address_start,520);
			return GetBufferECLength(buffer,which);
		}
		
		//Get the number of instructions of an effect caster algorithm according to a buffer of it
		int GetBufferECLength(byte[] buffer, int which)
		{
			int longueur_cum=4;
			byte group_ec_1 = buffer[0];
			byte group_ec_2 = buffer[1];
			try {
			//Navigation groupe 1
			for (int i=0,offset = 0;(which==1||which==3)&&i<buffer.Length&&i<(group_ec_1*6)+offset;i += 6)
			{
				//Décalage selon la longueur si superieure à 6 octets
				offset += 2*(buffer[9+i]);
				longueur_cum+=6+2*(buffer[9+i]);
				i += 2*(buffer[9+i]);
			}
			for (int i=0,offset=0;(which==2||which==3)&&i<buffer.Length&&i<(group_ec_2*4)+offset;i += 4)
			{
				//Décalage selon la longueur si superieure à 4 octets
				offset += 2*(buffer[3+i+buffer[2]]);
				longueur_cum+=4+2*(buffer[3+i+buffer[2]]);
				i += 2*(buffer[3+i+buffer[2]]);
			}
			} catch {}
			return longueur_cum;
		}
		
		//This is where what happends when the character is appearing after called by a drive is managed
		void DriveApparition()
		{
			firstMoveLoaded=0;
			var transitionAddress = new int[] {0,0,0,-1};
			int[] idleAddress = new int[] {0,0,0,-1};
			int[] walkAddress = new int[] {0,0,0,-1};
			int[] chuteAddress = new int[] {0,0,0,-1};
			int[] jumpAddress = new int[] {0,0,0,-1};
			var PAXAlgo = new byte[1];
			//Quel personnage ?
			switch (personnageActuel.getMsetName())
			{
				//Organisation Roxas
				case "B_EX390":
					idleAddress[0] = msetAddress-0x20000000+OrgRoxas_ML[0]; idleAddress[1] = OrgRoxas_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+OrgRoxas_ML[1]; walkAddress[1] = OrgRoxas_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+OrgRoxas_ML[3]; chuteAddress[1] = OrgRoxas_ML_Length[3];
					jumpAddress[0] = msetAddress-0x20000000+OrgRoxas_ML[28]; jumpAddress[1] = OrgRoxas_ML_Length[28]; jumpAddress[2] = 15;
					transitionAddress[0] = msetAddress-0x20000000+OrgRoxas_ML[39]; transitionAddress[1] = OrgRoxas_ML_Length[39];
					PAXAlgo = OrgRoxasPAXAlgo;
					OrgRoxasFilesFix();
				break;
				//Larxene
				case "B_EX400":
					idleAddress[0] = msetAddress-0x20000000+Larxene_ML[0]; idleAddress[1] = Larxene_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Larxene_ML[1]; walkAddress[1] = Larxene_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Larxene_ML[3]; chuteAddress[1] = Larxene_ML_Length[3];
					//jumpAddress[0] = msetAddress-0x20000000+Larxene_ML[14]; jumpAddress[1] = Larxene_ML_Length[14]; jumpAddress[2] = 25;
					transitionAddress[0] = msetAddress-0x20000000+Larxene_ML[25]; transitionAddress[1] = Larxene_ML_Length[25];
					PAXAlgo = LarxenePAXAlgo;
					LarxeneFilesFix();
				break;
				//Marluxia
				case "N_CM000_BTL":
					idleAddress[0] = msetAddress-0x20000000+Marluxia_ML[0]; idleAddress[1] = Marluxia_ML_Length[0];
					Console.WriteLine(idleAddress[0].ToString("X8"));
					walkAddress[0] = msetAddress-0x20000000+Marluxia_ML[1]; walkAddress[1] = Marluxia_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Marluxia_ML[4]; chuteAddress[1] = Marluxia_ML_Length[4];
					//jumpAddress[0] = msetAddress-0x20000000+Marluxia_ML[3]; jumpAddress[1] = Marluxia_ML_Length[3]; jumpAddress[2] = 10;
					transitionAddress[0] = msetAddress-0x20000000+Marluxia_ML[0]; transitionAddress[1] = Marluxia_ML_Length[0];
					PAXAlgo = MarluxiaPAXAlgo;
					MarluxiaFilesFix();
				break;
				//Luxord
				case "B_EX150":
					idleAddress[0] = msetAddress-0x20000000+Luxord_ML[0]; idleAddress[1] = Luxord_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Luxord_ML[1]; walkAddress[1] = Luxord_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Luxord_ML[4]; chuteAddress[1] = Luxord_ML_Length[4];
					//jumpAddress[0] = msetAddress-0x20000000+Luxord_ML[3]; jumpAddress[1] = Luxord_ML_Length[3]; jumpAddress[2] = 13;
					transitionAddress[0] = msetAddress-0x20000000+Luxord_ML[31]; transitionAddress[1] = Luxord_ML_Length[31];
					PAXAlgo = LuxordPAXAlgo;
					LuxordFilesFix();
				break;
				//Demyx
				case "B_EX120_HB":
					idleAddress[0] = msetAddress-0x20000000+Demyx_ML[0]; idleAddress[1] = Demyx_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Demyx_ML[1]; walkAddress[1] = Demyx_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Demyx_ML[4]; chuteAddress[1] = Demyx_ML_Length[4];
					transitionAddress[0] = msetAddress-0x20000000+Demyx_ML[30]; transitionAddress[1] = Demyx_ML_Length[30];
					PAXAlgo = DemyxPAXAlgo;
					DemyxFilesFix();
				break;
				//Axel
				case "B_EX110_LV99":
					idleAddress[0] = msetAddress-0x20000000+Axel_ML[0]; idleAddress[1] = Axel_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Axel_ML[1]; walkAddress[1] = Axel_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Axel_ML[3]; chuteAddress[1] = Axel_ML_Length[3];
					transitionAddress[0] = msetAddress-0x20000000+Axel_ML[35]; transitionAddress[1] = Axel_ML_Length[35];
					PAXAlgo = AxelPAXAlgo;
					AxelFilesFix();
				break;
				//Saix
				case "B_EX160":
					idleAddress[0] = msetAddress-0x20000000+Saix_ML[0]; idleAddress[1] = Saix_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Saix_ML[1]; walkAddress[1] = Saix_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Saix_ML[4]; chuteAddress[1] = Saix_ML_Length[4];
					jumpAddress[0] = msetAddress-0x20000000+Saix_ML[3]; jumpAddress[1] = Saix_ML_Length[3]; jumpAddress[2] = 30;
					transitionAddress[0] = msetAddress-0x20000000+Saix_ML[27]; transitionAddress[1] = Saix_ML_Length[27];
					PAXAlgo = SaixPAXAlgo;
					SaixFilesFix();
				break;
				//Zexion
				case "B_EX370":
					idleAddress[0] = msetAddress-0x20000000+Zexion_ML[0]; idleAddress[1] = Zexion_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Zexion_ML[1]; walkAddress[1] = Zexion_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Zexion_ML[3]; chuteAddress[1] = Zexion_ML_Length[3];
					jumpAddress[0] = msetAddress-0x20000000+Zexion_ML[17]; jumpAddress[1] = Zexion_ML_Length[17]; jumpAddress[2] = 99;
					transitionAddress[0] = msetAddress-0x20000000+Zexion_ML[21]; transitionAddress[1] = Zexion_ML_Length[21];
					PAXAlgo = ZexionPAXAlgo;
					ZexionFilesFix();
				break;
				//Lexaeus
				case "N_CM020_BTL":
					idleAddress[0] = msetAddress-0x20000000+Lexaeus_ML[0]; idleAddress[1] = Lexaeus_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Lexaeus_ML[26]; walkAddress[1] = Lexaeus_ML_Length[26]; walkAddress[2] = 42;
					chuteAddress[0] = msetAddress-0x20000000+Lexaeus_ML[1]; chuteAddress[1] = Lexaeus_ML_Length[1];
					jumpAddress[0] = msetAddress-0x20000000+Lexaeus_ML[29]; jumpAddress[1] = Lexaeus_ML_Length[29]; jumpAddress[2] = 221;
					transitionAddress[0] = msetAddress-0x20000000+Lexaeus_ML[32]; transitionAddress[1] = Lexaeus_ML_Length[32];
					PAXAlgo = LexaeusPAXAlgo;
					LexaeusFilesFix();
				break;
				//Vexen
				case "N_CM040_BTL":
					idleAddress[0] = msetAddress-0x20000000+Vexen_ML[0]; idleAddress[1] = Vexen_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Vexen_ML[1]; walkAddress[1] = Vexen_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Vexen_ML[2]; chuteAddress[1] = Vexen_ML_Length[2];
					//jumpAddress[0] = msetAddress-0x20000000+Vexen_ML[0]; jumpAddress[1] = Vexen_ML_Length[0]; jumpAddress[2] = 99;
					transitionAddress[0] = msetAddress-0x20000000+Vexen_ML[24]; transitionAddress[1] = Vexen_ML_Length[24];
					PAXAlgo = VexenPAXAlgo;
					VexenFilesFix();
				break;
				//Xaldin
				case "B_EX130":
					idleAddress[0] = msetAddress-0x20000000+Xaldin_ML[0]; idleAddress[1] = Xaldin_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Xaldin_ML[1]; walkAddress[1] = Xaldin_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Xaldin_ML[0]; chuteAddress[1] = Xaldin_ML_Length[0]; chuteAddress[2] = 0;
					//jumpAddress[0] = msetAddress-0x20000000+Xaldin_ML[0]; jumpAddress[1] = Xaldin_ML_Length[0]; jumpAddress[2] = 99;
					transitionAddress[0] = msetAddress-0x20000000+Xaldin_ML[37]; transitionAddress[1] = Xaldin_ML_Length[37];
					PAXAlgo = XaldinPAXAlgo;
					XaldinFilesFix();
				break;
				//Xigbar
				case "B_EX140":
					idleAddress[0] = msetAddress-0x20000000+Xigbar_ML[0]; idleAddress[1] = Xigbar_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Xigbar_ML[1]; walkAddress[1] = Xigbar_ML_Length[1];
					//chuteAddress[0] = msetAddress-0x20000000+Xigbar_ML[0]; chuteAddress[1] = Xigbar_ML_Length[0];
					jumpAddress[0] = msetAddress-0x20000000+Xigbar_ML[37]; jumpAddress[1] = Xigbar_ML_Length[37]; jumpAddress[2] = 115;
					transitionAddress[0] = msetAddress-0x20000000+Xigbar_ML[0]; transitionAddress[1] = Xigbar_ML_Length[0];
					PAXAlgo = XigbarPAXAlgo;
					XigbarFilesFix();
				break;
				//Xemnas
				case "B_EX170":
					idleAddress[0] = msetAddress-0x20000000+Xemnas_ML[0]; idleAddress[1] = Xemnas_ML_Length[0];
					walkAddress[0] = msetAddress-0x20000000+Xemnas_ML[1]; walkAddress[1] = Xemnas_ML_Length[1];
					chuteAddress[0] = msetAddress-0x20000000+Xemnas_ML[3]; chuteAddress[1] = Xemnas_ML_Length[3];
					//jumpAddress[0] = msetAddress-0x20000000+Xemnas_ML[23]; jumpAddress[1] = Xemnas_ML_Length[23]; jumpAddress[2] = 110;
					transitionAddress[0] = msetAddress-0x20000000+Xemnas_ML[22]; transitionAddress[1] = Xemnas_ML_Length[22];
					PAXAlgo = XemnasPAXAlgo;
					XemnasFilesFix();
				break;
				
			}
			foreach (int[] address in new int[][] {idleAddress,walkAddress,chuteAddress,jumpAddress})
			if (address[0]>0)
			{
				byte[] start = BitConverter.GetBytes((short)address[2]);
				byte[] end = BitConverter.GetBytes((short)address[3]);
				if (ReadInt32(address[0]+0x20000028)>0&&ReadInt32(address[0]+0x2000002C)>0&&ReadBytes(ReadInt32(address[0]+0x20000028)+0x20000000,1)[0]>0)
				{
					byte[] old_ec = ReadBytes(Pointer(address[0]+0x20000028,0x20000000),ReadInt32(address[0]+0x2000002C));
					byte[] new_ec = CombineEC(old_ec,new byte[] {start[0],start[1],end[0],end[1],0,0},0);
					SetEffectCaster(address[0]+0x20000000,new_ec);
				}
				else
				{
					WriteInteger(address[0]+0x20000028,address[0]+0x50);
					WriteInteger(address[0]+0x2000002C,8);
					WriteBytes(address[0]+0x20000050,new byte[] {1,0,0,0,start[0],start[1],end[0],end[1],0,0});
				}
			}
			//Marche
			if (walkAddress[0]>0)
			{
				if (ReadInt32(msetAddress+0x28)==0) SetMSET11Drive(0x28,walkAddress[0],walkAddress[1]);
				if (ReadInt32(msetAddress+0x38)==0) SetMSET11Drive(0x38,walkAddress[0],walkAddress[1]);
			}
			
			//Saut
			if (jumpAddress[0]>0) SetMSET11Drive(0x48,jumpAddress[0],jumpAddress[1]);
			//Drive > Idle
			if (idleAddress[0]>0) SetMSET11Drive(0x78,idleAddress[0],idleAddress[1]);
			//Menu start
			if (!arriveParFusion) return;
			//DriveApparition
			if (EstAuSol(player_Ptr)&&transitionAddress[0]>0)
			{
				SetMSET11Drive(0x368,transitionAddress[0],transitionAddress[1]);
				if (PAXAlgo.Length>0) WriteInteger(transitionAddress[0]+0x20000028,0x1C93A00);
			}
			else if (chuteAddress[0]>0)
				SetMSET11Drive(0x368,chuteAddress[0],chuteAddress[1]);
			//Algo PAX d'apparition
			if (PAXAlgo.Length>0) WriteBytes(0x21C93A00,PAXAlgo);
		}
		
		//Set a effect caster algorithm
		public void SetEffectCaster(int address, byte[] EC)
		{
			if (EC.Length<=0x60)
			{
				WriteInteger(address+0x28,address-0x20000000+0x50);
				WriteInteger(address+0x2C,EC.Length);
				WriteBytes(address+0x50,EC);
			}
			else if (allocatedEC.Count==0||allocatedEC[allocatedEC.Count-1]+EC.Length<=0x21c93a00)
			{
				if (allocatedEC.Count==0) allocatedEC.Add(0x21C92D00);
				allocatedEC.Add(allocatedEC[allocatedEC.Count-1]+EC.Length);
				WriteInteger(address+0x28,allocatedEC[allocatedEC.Count-2]-0x20000000);
				WriteInteger(address+0x2C,0);
				WriteBytes(allocatedEC[allocatedEC.Count-2],EC);
			}
		}
		
		//Reset every values changed by Teamod in the moveset main list
		void ResetMset(int[] movelist,int[] eclist,int[] eclistLength)
		{
			WriteBytes(0x21C92D00,new byte[0xD00]);
			for (int i=0;i<movelist.Length;i++)
			{
				WriteInteger(msetAddress+movelist[i]+0x28,msetAddress-0x20000000+movelist[i]+eclist[i]);
				WriteInteger(msetAddress+movelist[i]+0x2C,eclistLength[i]);
				WriteBytes(msetAddress+movelist[i]+0x50,new byte[0x60]);
			}
		}
		
		//Get attack sprite offset from the animation file offset plus 0x20000000
		public int GetCurrentECAddress(int address)
		{
			return Pointer(address+0x28,0x20000000);
		}
		
		//Get attack sprite offset from the animation file offset
		public int GetECValue(int address)
		{
			return ReadInt32(address+0x28);
		}
		
		//Get attack sprite offset from the animation file
		public int GetInsideECAddress(int address)
		{
			return Pointer(address+0x18,0x20000000)+ReadInt32(address+0x1C);
		}
		
		//Retourne un EC avec insertion
		public byte[] CombineEC(byte[] A_entry,byte[] B_entry, int lequel)
		{
			if (SearchBytes(A_entry,B_entry)>-1) return A_entry;
			var output = new byte[0];
			if (A_entry.Length==0)
				output = Combine(new byte[] {0,0,4,0},B_entry);
			else
			{
				int first_length = GetBufferECLength(A_entry,1);
				int second_length = GetBufferECLength(A_entry,2);
				if (lequel==0)
				{
					output = SubArray(A_entry,0,first_length);
					output = Combine(output,B_entry);
					output = Combine(output,SubArray(A_entry,first_length,A_entry.Length-(first_length)));
					output[2] = (byte)(output[2]+B_entry.Length);
				}
				else
				{
					output = Combine(A_entry,B_entry);
				}
			}
			output[lequel]++;
			return output;
		}
		
		//Check if an animation is playing
		bool IsANBPlaying(int pointeur, int valeur)
		{
			return GetBAR11Address(pointeur)==msetAddress+valeur;
		}
		
		//Set current character animation speed
		void SetSpeed(int pointer, float valeur)
		{
			WriteFloat(Pointer(pointer,0x20000234),valeur);
		}
		
		//Get current character animation speed
		float GetSpeed(int pointer)
		{
			return ReadFloat(Pointer(pointer,0x20000234));
		}
		
		//Get current character used PAX file (Attack sprites file)
		int GetPAXAddress(int pointeur)
		{
			int PAX_swap = SearchResource("obj/"+personnageActuel.getMdlxName()+".a.fm");
			int PAX_address = -1;
			
			for (int i=0;PAX_swap>-1&&i<ReadInt32(PAX_swap+4)&&PAX_address==-1;i++)
				if (ReadBytes(16+PAX_swap+i,1)[0]==0x12)
					PAX_address = 0x20000000+ReadInt32(16+PAX_swap+8);
			return PAX_address;
		}
		
		//Get PAX index address in main list according to the index
		int GetPAXIndexAddress(int pointeur, int index)
		{
			return GetPAXAddress(pointeur)+0x10+index*0x50;
		}
		
		//Set the translation offset of an attack sprite
		void SetPAXLocation(int which,float x,float y, float z)
		{
			int address = GetPAXIndexAddress(player_Ptr,which);
			WriteFloat(address+0x1C,x);
			WriteFloat(address+0x1C+8,y);
			WriteFloat(address+0x1C+4,z);
		}
		
		//Set the rotation of an attack sprite
		void SetPAXRotation(int which,float x,float y, float z)
		{
			int address = GetPAXIndexAddress(player_Ptr,which);
			WriteFloat(address+0x28,x);
			WriteFloat(address+0x28+8,y);
			WriteFloat(address+0x28+4,z);
		}
		
		//Set the size of an attack sprite
		void SetPAXSize(int which,float x,float y, float z)
		{
			int address = GetPAXIndexAddress(player_Ptr,which);
			WriteFloat(address+0x34,x);
			WriteFloat(address+0x34+8,y);
			WriteFloat(address+0x34+4,z);
		}
		
		//Attach an attack sprite to the floor under current character
		void SetPAXFixedToLocalFloor(int which)
		{
			int address = GetPAXIndexAddress(player_Ptr,which);
			WriteBytes(address+4,new byte[] {0,0,0,0x40,0,0,0});
			WriteBytes(address+16,new byte[] {3,0,0,0});
		}
		
		//Attach an attack sprite on current character
		void SetPAXFixedToLocal(int which)
		{
			int address = GetPAXIndexAddress(player_Ptr,which);
			WriteBytes(address+4,new byte[] {0,0,0,0,0,0,0});
			WriteBytes(address+16,new byte[] {3,0,0,0});
		}
		
		//Attach an attack sprite to the floor and make it disappear after shown
		void SetPAXFixedToTempLocalFloor(int which)
		{
			int address = GetPAXIndexAddress(player_Ptr,which);
			WriteBytes(address+4,new byte[] {0,0,0,0x40,0,0,0});
			WriteBytes(address+16,new byte[] {0x61,0,0,0});
		}
		
		//Attach an attack sprite to the floor at the middle of the map and make it disappear after shown
		void SetPAXFixedToTempFloor(int which)
		{
			int address = GetPAXIndexAddress(player_Ptr,which);
			WriteBytes(address+4,new byte[] {0,0,0,0x40,0,0,0});
			WriteBytes(address+16,new byte[] {0xA3,0,0,0});
		}
		
		//Change the way attack sprites are shown
		void SetPAXAttachement(int which, short valeur1, short valeur2)
		{
			int address = GetPAXIndexAddress(player_Ptr,which);
			if (valeur1!=-1) WriteInteger(address+6,valeur1);
			if (valeur2!=-1) WriteInteger(address+16,valeur2);
		}
		
		//Change the sound produced by an attack sprite
		void SetPAXSound(int which, int valeur)
		{
			int address = GetPAXIndexAddress(player_Ptr,which);
			WriteInteger(address+0x18,valeur);
		}
		
		//Get current Character opacity
		float GetOpacity(int pointeur)
		{
			return ReadFloat(Pointer(pointeur,0x2000082C));
		}
		
		//Set current Character opacity
		void SetOpacity(int pointeur, float valeur)
		{
			WriteFloat(Pointer(pointeur,0x2000082C),valeur);
		}
		
		//Check if Opacity of current character equals to 0
		bool isInvisible(int pointeur)
		{
			return GetOpacity(player_Ptr)<0.02;
		}
		
		//XYZ Translation of current character
		void Translation(int pointeur, byte which, float valeur)
		{
			WriteFloat(Pointer(pointeur,0x200001E0+new int[] {0,8,4}[which]),valeur);
		}
		
		//Reduce character colision perimeter in order to allow some character access doors
		public void CharacterCollisionWidth()
		{
			int num = Pointer(mdlxAddress + 0x48,0x20000000);
			if (ReadInt32(num) < 255 & ReadInt16(num + 80) == ReadInt16(num + 82))
			{
				WriteInteger(num + 4, 1);
				WriteInteger(num + 80, (short)90);
				WriteInteger(num + 82, (short)90);
			}
		}
		
		//Set walk speed
		public void WalkStep(int pointeur, float valeur)
		{
			WriteFloat(Pointer(pointeur,0x20000110),valeur);
		}
		
		//Set run speed
		public void RunStep(int pointeur, float valeur)
		{
			WriteFloat(Pointer(pointeur,0x20000114),valeur);
		}
		
		//Set jump height
		public void JumpLength(int pointeur, float valeur)
		{
			WriteFloat(Pointer(pointeur,0x20000118),valeur);
		}
		
		//Set the ingame timer before the jump to start after pressing circle
		public void JumpCountDown(int pointeur, float valeur)
		{
			WriteFloat(Pointer(pointeur,0x200000D0),valeur);
		}
		
		
		//Change character rotation speed (According to left joystick)
		public void TurnStep(int pointeur, float valeur)
		{
			WriteFloat(Pointer(pointeur,0x2000011C),valeur);
		}
		
		//Change gravity speed of current character
		public void GravityStep(int pointeur, float valeur)
		{
			WriteFloat(Pointer(pointeur,0x20000120),valeur);
		}
		
		//Get current character MDLX, A.FM, and MSET files by character filename (e.g: "P_EX100" for Sora)
		void UpdateFilesSeeking(bool loop)
		{
			do
			{
				msetAddress = SearchResource("obj/"+personnageActuel.getMsetName()+".mset");
				mdlxAddress = SearchResource("obj/"+personnageActuel.getMdlxName()+".mdlx");
				afmAddress = SearchResource("obj/"+personnageActuel.getMdlxName()+".a.fm");
			}
			while (IsTitlePassed&&loop&&(ReadString(msetAddress,3)!="BAR"||ReadString(mdlxAddress,3)!="BAR"||ReadString(afmAddress,3)!="BAR"));
		}
		
		//Check if a file at certain address is a moveset
		public bool isMset(int address)
		{
			return ReadString(address,3)=="BAR"&&ReadString(Pointer(address+0x18,0x20000000),3)=="BAR"&&ReadInt32(address+8)==address-0x20000000;
		}
		
		float Joystick() {return ReadFloat(0x2034D3FC);} //Get left joystick remoteness from middle
		float LeftJoystickX() {return ReadFloat(0x2034D3F0);} //Get left joystick X value
		float LeftJoystickY() {return ReadFloat(0x2034D3F4);} //Get left joystick Y value
		float RightJoystickX() {return ReadFloat(0x2034D3E0);} //Get right joystick X value
		float RightJoystickY() {return ReadFloat(0x2034D3E4);} //Get right joystick Y value
		
		//Turn camera
		void SetCamera(float valeur)
		{
			WriteFloat(0x20348760,valeur);
		}
		
		//Get Camera rotation value
		float GetCamera()
		{
			return ReadFloat(0x20348760);
		}
		
		//Rotate current character
		void SetRotationPerso(int pointeur, float valeur, bool all)
		{
			if (all) WriteFloat(Pointer(pointeur,0x2000055C),valeur);
			WriteFloat(Pointer(pointeur,0x2000066C),valeur);
		}
		
		//connaitre la rotation du Perso
		float GetRotationPerso(int pointeur)
		{
			return ReadFloat(Pointer(pointeur,0x2000055C));
		}
		
		//Make a camera zoom in
		void ZoomIn()
		{
			WriteFloat(0x203487EC,1.9f);
			/*float zoom = ReadFloat(0x2036A0B8);
			if (zoom > 300) WriteFloat(0x2036A0B8,zoom-3);*/
		}
		
		//Make a camera zoom out
		void ZoomOut()
		{
			WriteFloat(0x203487EC,1.5f);
			/*float zoom = ReadFloat(0x2036A0B8);
			if (zoom < 512) WriteFloat(0x2036A0B8,zoom+3);*/
		}
		
		//Change camera speed
		void CameraSpeed(float valeur)
		{
			WriteFloat(0x2036ADEC, valeur);
		}
		
		//Change Mset Bar11 line
		void SetMSET11(int offset,int pointeur,int length)
		{
			WriteInteger(msetAddress+offset,msetAddress-0x20000000+pointeur);
			WriteInteger(msetAddress+offset+4,length);
		}
		
		
		//Prevent footstep annoying noise
		void Quiet(int pointeur)
		{
			WriteBytes(Pointer(pointeur,0x20000154),new byte[8]);
		}
		
		//Return to Idle animation
		void Idle(int pointeur)
		{
			WriteBytes(0x21C93A00,new byte[] {1,0,0,0,0,0,255,255,0,0});
			SetPaxAlgoAddress(pointeur,0x1C93A00);
		}
		
		//Automatically return to Idle animation
		void SeekIdle(int pointeur)
		{
			if (GetFrame(pointeur)>GetMaxFrame(pointeur)-3)
				Idle(pointeur);
		}
		
		//Change Mset line offset in moveset main list
		void SetMSET11Drive(int offset,int pointeur,int length)
		{
			WriteInteger(msetAddress+offset,pointeur);
			WriteInteger(msetAddress+offset+4,length);
		}
		
		//Directly change Mset line offset in moveset main list
		void Set3MSET11Now(int pointeur,int length)
		{
			Quiet(player_Ptr);
			Idle(player_Ptr);
			WriteInteger(msetAddress+0x18,msetAddress-0x20000000+pointeur);
			WriteInteger(msetAddress+0x18+4,length);
			WriteInteger(msetAddress+0x28,msetAddress-0x20000000+pointeur);
			WriteInteger(msetAddress+0x28+4,length);
			WriteInteger(msetAddress+0x38,msetAddress-0x20000000+pointeur);
			WriteInteger(msetAddress+0x38+4,length);
			Quiet(player_Ptr);
		}
		
		//Force an animation
		public void ForceAnimation(int pointeur,int MLIndex,float start,float max, bool block)
		{
		    SetAnimationState(player_Ptr,0x80);
			SetPaxAlgoAddress(pointeur,ReadInt32(msetAddress+MLIndex+0x28));
			SetANBPointer(pointeur,msetAddress-0x20000000+MLIndex+0x30);
			SetFrame(pointeur,start);
			SetMaxFrame(pointeur,max);
			while (IsTitlePassed&&GetFrame(pointeur)>start+1) {}
			if (!block)
		    SetAnimationState(player_Ptr,0x30);
		}
		
		//Save pads state
		public void RelachementTouches()
		{
			//Pad
			int count = 0;
			for (int i = 0; i < 12; i++)
			{
				if (ReadBytes(padAddresses[i], 1)[0]==0)
					count++;
			}
			padOk |= count==13;
		}
		
		//Change command menu to KH1 skin to enable custom HUD for characters
		public void ChangeGameSettings()
		{
			byte settings = ReadBytes(0x2032FCD4,1)[0];
			WriteBytes(0x2032FCD4,new byte[] {(byte)(settings|((byte)64))});
		}
		
		
		//Make Donald and Goofy disappear
		void KillBitches()
		{
			int ptr1 = Pointer(partner1_Ptr,0x200008d0);
			int ptr2 = Pointer(partner2_Ptr,0x200008d0);
			if ((decimal)ReadFloat(ptr1)==1&&GetModelName(partner1_Ptr)=="P_EX020")
				WriteFloat(ptr1,0f);
			if ((decimal)ReadFloat(ptr2)==1&&GetModelName(partner2_Ptr)=="P_EX030")
				WriteFloat(ptr2,0f);
		}
		
		//Returns true if current character is not Sora
		bool isModelNPC(int player_Ptr)
		{
			var buffer = new byte[2];
			ReadProcessMemory(PCSX2_Id, new IntPtr(Pointer(Pointer(player_Ptr,0x20000008),0x20000008)), buffer, 2, out player_Ptr);
			return buffer[0]!=80&&buffer[1]==95;
		}
		
		//Returns true if current character is Sora
		bool isModelSoras(int player_Ptr)
		{
			return GetModelName(player_Ptr)=="P_EX100";
		}
		
		//Set opacity of command menu
		void SetHUDOpacity(float niveau)
		{
			for (int i=0;i<3;i++)
			WriteFloat(Pointer(0x20348058,0x2000a70c+i*4),niveau);
		}
	}
}
