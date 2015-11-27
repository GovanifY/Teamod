using System;
using System.Collections.Generic;

namespace Teamod_2
{
	public partial class MainForm
	{
		List<int> IopVoices = new List<int>(0);
		List<float> IopStartFrame = new List<float>(0);
		string already_played = "";
		
		//List every voices of current effect caster algorithm
		void IopMakeList()
		{
			Console.WriteLine("New ANB buffer detected. Source offset : "+ReadInt32(Pointer(player_Ptr,0x2000014C)).ToString("X8"));
			IopVoices.Clear();
			IopStartFrame.Clear();
			int address_start = ReadInt32(Pointer(player_Ptr,0x20000150))+0x20000000;
			byte[] buffer = ReadBytes(address_start,520);
			byte group_ec_2 = buffer[1];
			for (int i=0,offset=0;i<500&&i<(group_ec_2*4)+offset;i += 4)
			{
				if (buffer[buffer[2]+i+2]==13)
				{
					IopStartFrame.Add((float)BitConverter.ToInt16(new byte[] {buffer[buffer[2]+i],buffer[buffer[2]+i+1]},0));
					IopVoices.Add((int)buffer[buffer[2]+i+4]);
					if (IopStartFrame[IopStartFrame.Count-1]<2)
						IopPlay(player_Ptr,IopStartFrame[IopStartFrame.Count-1],IopVoices[IopVoices.Count-1]);
					Console.WriteLine("Order voice \""+(int)buffer[buffer[2]+i+4]+".vag\" for frame: "+(float)BitConverter.ToInt16(new byte[] {buffer[buffer[2]+i],buffer[buffer[2]+i+1]},0));
				}
				offset += 2*(buffer[3+i+buffer[2]]);
				i += 2*(buffer[3+i+buffer[2]]);
			}
		}
		
		//Manually play a voice
		void IopPlay(int pointeur, float when_has_it_been_played, int index)
		{
			if (!already_played.Contains(when_has_it_been_played.ToString()+":"+index.ToString()))
			{
				WriteInteger(Pointer(pointeur,0x200009C4),index);
				WriteInteger(Pointer(pointeur,0x200009D1),(byte)127);
				WriteInteger(Pointer(pointeur,0x200009D4),ReadInt32(pointeur));
			
			}
			already_played+=when_has_it_been_played.ToString()+":"+index.ToString()+"_";
		}
		
		//Checks, according to current animation frame if a voice index has to be played
		void IopCallBack()
		{
			for (int i=0;i<IopStartFrame.Count;i++)
			{
				float frame = IopStartFrame[i];
				float currFrame = GetFrame(player_Ptr);
				if (currFrame>=frame&&currFrame<frame+2)
					IopPlay(player_Ptr,frame,IopVoices[i]);
			}
		}
		float frameHistory = 0;
		
		//Voice player algorithm
		void IopPlayer()
		{
			if (GetFrame(player_Ptr)<frameHistory)
				already_played="";
			if (ReadInt32(Pointer(player_Ptr,0x2000014C))!=ANB_history)
			{
				already_played="";
				IopMakeList();
				ANB_history=0;
			}
			IopCallBack();
			if (ANB_history==0)
			ANB_history = ReadInt32(Pointer(player_Ptr,0x2000014C));
			frameHistory = GetFrame(player_Ptr);
		}
	}
}
