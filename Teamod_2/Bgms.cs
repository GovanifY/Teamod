using System;
using System.Windows.Forms;

namespace Teamod_2
{
	/// <summary>
	/// Description of Bgms.
	/// </summary>
	public partial class MainForm : Form
	{
		byte[] musicDigits = new byte[] {0,50,51,52,53,54,55,56,57,59,60,61,62,63,64,65,66,67,68,69,81,82,84,85,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,127,128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,144,145,146,147,148,149,151,152,153,154,155,156,158,159,162,164,185,186,187,188,189,190};
		ListViewItem[] musicNames = new ListViewItem[] {new ListViewItem("♪ No music"),new ListViewItem("♪ Dive into The Heart -Destati-"),new ListViewItem("♪ Fragment of Sorrow"),new ListViewItem("♪ The Afternoon Streets"),new ListViewItem("♪ Working Together"),new ListViewItem("♪ Sacred Moon"),new ListViewItem("♪ Deep Drive"),new ListViewItem("♪ Nights of the Cursed"),new ListViewItem("♪ He's a Pirate"),new ListViewItem("♪ A fight to Death"),new ListViewItem("♪ Darkness of the Unknown"),new ListViewItem("♪ Darkness of the Unknown 2"),new ListViewItem("♪ Darkness of the Unknown 3"),new ListViewItem("♪ The 13th Reflection"),new ListViewItem("♪ What a Surprise !"),new ListViewItem("♪ Happy hollidays !"),new ListViewItem("♪ The Other Promise"),new ListViewItem("♪ Rage Awekened"),new ListViewItem("♪ Cavern Of Remembrance"),new ListViewItem("♪ Deep Anxiety"),new ListViewItem("♪ Colisée de L'Olympe combat"),new ListViewItem("♪ The Escapade"),new ListViewItem("♪ Arabian Daydream"),new ListViewItem("♪ Byte Striking"),new ListViewItem("♪ Disapeared"),new ListViewItem("♪ Sora"),new ListViewItem("♪ Friends in my heart"),new ListViewItem("♪ Riku"),new ListViewItem("♪ Kairi"),new ListViewItem("♪ A Walk in Andante"),new ListViewItem("♪ Hésitation"),new ListViewItem("♪ L'Organisation XIII"),new ListViewItem("♪ Aprehension"),new ListViewItem("♪ Xigbar"),new ListViewItem("♪ La rivière Intemporelle"),new ListViewItem("♪ Strange Whispers"),new ListViewItem("♪ Missing You"),new ListViewItem("♪ The Underworld"),new ListViewItem("♪ Waltz of the Damned"),new ListViewItem("♪ What Lies Beneath"),new ListViewItem("♪ Olympus Coliseum"),new ListViewItem("♪ Dance of the Daring"),new ListViewItem("♪ Under the Sea"),new ListViewItem("♪ Ursula's Revenge"),new ListViewItem("♪ Part of The World"),new ListViewItem("♪ Atlantica Karaoké"),new ListViewItem("♪ The Encounter"),new ListViewItem("♪ Sinister Shadows"),new ListViewItem("♪ Fiels od Honor"),new ListViewItem("♪ Anew Day is dawning"),new ListViewItem("♪ Tension Rising"),new ListViewItem("♪ The Corrupted"),new ListViewItem("♪ The Home of Dragons"),new ListViewItem("♪ Rowdy Rumble"),new ListViewItem("♪ Lazy Afternoons"),new ListViewItem("♪ Sinister Sundown"),new ListViewItem("♪ Beneath the Ground"),new ListViewItem("♪ Desire for All That I Lost"),new ListViewItem("♪ Let's Sing and Dance loop"),new ListViewItem("♪ Let's Sing and Dance"),new ListViewItem("♪ Let's Sing and Dance loop"),new ListViewItem("♪ Let's Sing and Dance Fin"),new ListViewItem("♪ A Day in Agrabah"),new ListViewItem("♪ Arabian Dream"),new ListViewItem("♪ Isn't It Lovely ?"),new ListViewItem("♪ Never Land Sky"),new ListViewItem("♪ Dance to The Death"),new ListViewItem("♪ Beauty and the Beast"),new ListViewItem("♪ Magical Mystery"),new ListViewItem("♪ Working Together"),new ListViewItem("♪ Space Paranoids"),new ListViewItem("♪ Byte bashing"),new ListViewItem("♪ ATwinkle in the Sky"),new ListViewItem("♪ Shipmeister's Shanty"),new ListViewItem("♪ Gearing Up"),new ListViewItem("♪ Under the Sea"),new ListViewItem("♪ Winnih the Pooh"),new ListViewItem("♪ Crossing the Finish Line"),new ListViewItem("♪ Mickey Mouse Club March"),new ListViewItem("♪ This is Halloween"),new ListViewItem("♪ Vim ang Vigor"),new ListViewItem("♪ Roxas"),new ListViewItem("♪ An Adventure In Atlantica"),new ListViewItem("♪ Blast off!"),new ListViewItem("♪ Spooks of Halloween Town"),new ListViewItem("♪ The 13th Struggle"),new ListViewItem("♪ Reviving Hollow Bastion"),new ListViewItem("♪ Scherzo Di Notte"),new ListViewItem("♪ Nights of the Cursed"),new ListViewItem("♪ He's a Pirate"),new ListViewItem("♪ Guardando nel Buio"),new ListViewItem("♪ Bounce-O-Rama"),new ListViewItem("♪ Bounce-O-Rama (Speed up ver.)"),new ListViewItem("♪ Villains of a Sort"),new ListViewItem("♪ Road to a Hero"),new ListViewItem("♪ The 13th Dilemma"),new ListViewItem("♪ Adventures in the Savannah"),new ListViewItem("♪ Savannah Pride"),new ListViewItem("♪ One Winged Angel"),new ListViewItem("♪ Monochrome Dreams"),new ListViewItem("♪ Old Friends, Old Rivals")};
		byte customizedBGMDigit = 255;
		
		public void PopUpBGMValid(int validIndex)
		{
			customizedBGMDigit = musicDigits[validIndex];
			ToolCloseClick(null,null);
		}
		
		public void BGMVolumeTick(object sender, EventArgs e)
		{
			byte Vol = ReadBytes(0x24193815,1)[0];
			if (Vol>0)
				WriteBytes(0x24193815,new byte[] {(byte)(Vol-1)});
			else
				BGMVolume.Enabled = false;
		}
		public void MusicUpdate()
		{
			if (ReadBytes(0x24193815,1)[0]>0&&ReadBytes(0x241937E0,1)[0]!=ReadBytes(0x21C6CC48,1)[0])
				BGMVolume.Enabled = true;
			
			if (customizedBGMDigit==0) WriteBytes(0x24193815,new byte[] {0});
			if (customizedBGMDigit<255)
			{
				WriteBytes(0x21C6CC48,new byte[] {customizedBGMDigit});
				WriteBytes(0x21C6CC4A,new byte[] {customizedBGMDigit});
			}
		}
	}
}
