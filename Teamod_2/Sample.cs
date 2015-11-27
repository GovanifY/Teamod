using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Sample_ML = new int[] {};
		int[] Sample_ML_Length = new int[] {};
		byte[] SamplePAXAlgo = new byte[] {};
		
		
		void SampleFilesFix()
		{
			/* MSET Fixes */
			
			/* MDLX Fixes */
				
			/* A.FM Fixes */
		}
		
		public void SampleSection()
		{
			msetAddress = GetMSETAddress(player_Ptr);
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			
			//Chute
			if (IsANBPlaying(player_Ptr,Sample_ML[4]))
		    {
		    	SetAnimationState(player_Ptr,0x40);
		    }
			//Transition Drive
			if (IsANBPlaying(player_Ptr,Sample_ML[25]))
		    {
				
			}
			
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}
