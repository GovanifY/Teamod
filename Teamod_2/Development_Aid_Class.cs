using System;
using System.Windows.Forms;

namespace Teamod_2
{
	public partial class MainForm
	{
		//This function Clipboards a C# code with current Ingame character's moveset move offsets from PCSX2
		//(Offset of character animation data subfiles to the main moveset file in the RAM of PCSX2)
		void GetMsetShortcut()
		{
			string output = "= new int[] {";
			int address=Pointer(Pointer(player_Ptr,0x20000140),0x20000000);
			for (int i=0;i<ReadInt32(address+4);i++)
			{
				int ptr = ReadInt32(24+address+i*16);
				if (ptr>0&&ReadBytes(ptr+0x20000010,1)[0]==9)
					output+="0x"+(ptr-(address-0x20000000)).ToString("X")+"/* "+ReadString(20+address+i*16,4)+" */,";
			}
			output=output.Substring(0,output.Length-1);
			output+="};\r\n= new int[] {";
			for (int i=0;i<ReadInt32(address+4);i++)
			{
				int ptr = ReadInt32(24+address+i*16);
				if (ptr>0&&ReadBytes(ptr+0x20000010,1)[0]==9)
					output+="0x"+(ReadInt32(28+address+i*16)).ToString("X")+"/* "+ReadString(20+address+i*16,4)+" */,";
			}
			output=output.Substring(0,output.Length-1);
			output+="};";
			Clipboard.SetText(output);
		}
	}
}
