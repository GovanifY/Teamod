using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Lexaeus_ML= new int[] {0x1000/* 00A */,0x2AA80/* 04A */,0x322C0/* 05A */,0x3B3D0/* 20A */,0x42F70/* 21A */,0x4C700/* 22A */,0x54170/* 23A */,0x5C360/* 24A */,0x63190/* 25A */,0x69D20/* 30A */,0x72EE0/* 31A */,0x7CA30/* 32A */,0x85710/* 33A */,0x69D20/* 30A */,0x7CA30/* 32A */,0x3B3D0/* 20A */,0x5C360/* 24A */,0x8FA30/* 70A */,0xA0210/* 40A */,0xA8BB0/* 41A */,0xB0840/* 50A */,0xBE9E0/* 51A */,0xCB550/* 53A */,0xD3CE0/* 54A */,0xF0A20/* 55A */,0xFCA50/* 56A */,0x10C510/* 57A */,0x11A840/* 58A */,0x125800/* 59A */,0x13B260/* 60A */,0x157140/* 61A */,0x1607E0/* 62A */,0x17B150/* 80A */};
		int[] Lexaeus_ML_Length= new int[] {0x29A80/* 00A */,0x7840/* 04A */,0x9106/* 05A */,0x7B98/* 20A */,0x9788/* 21A */,0x7A68/* 22A */,0x81E8/* 23A */,0x6E28/* 24A */,0x6B88/* 25A */,0x91B8/* 30A */,0x9B50/* 31A */,0x8CD8/* 32A */,0xA318/* 33A */,0x91B8/* 30A */,0x8CD8/* 32A */,0x7B98/* 20A */,0x6E28/* 24A */,0x107DA/* 70A */,0x8992/* 40A */,0x7C84/* 41A */,0xE1A0/* 50A */,0xCB70/* 51A */,0x878A/* 53A */,0x1CD38/* 54A */,0xC022/* 55A */,0xFAB4/* 56A */,0xE32E/* 57A */,0xAFC0/* 58A */,0x15A52/* 59A */,0x1BEDE/* 60A */,0x9698/* 61A */,0x1A96E/* 62A */,0x12DF6/* 80A */};
		byte[] LexaeusPAXAlgo = new byte[0];
		byte[] LexaeusRunFix = new byte[] {08,0x02,0x85,0x01,0x18,0x00,0x29,0x00,0x08,0x02,0x85,0x01,0x12,0x00,0x50,0x00,0x08,0x02,0x85,0x01,0x14,0x00,0x44,0x00,0x08,0x02,0x85,0x01,0x15,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};
		int[] Lexaeus_ECL = new int[] {0x29A70,0x7840,0x90F0,0x7B70,0x9760,0x7A40,0x81B0,0x6E00,0x6B60,0x9190,0x9B20,0x8CB0,0xA2E0,0x9190,0x8CB0,0x7B70,0x6E00,0x10740,0x8950,0x7C60,0xE130,0xCB30,0x8730,0x1CC90,0xBFB0,0xFA30,0xE2C0,0xAF80,0x159B0,0x1BEA0,0x9640,0x1A920,0x12DA0};
		int[] Lexaeus_ECL_Length = new int[] {0x10,0x0,0x16,0x28,0x28,0x28,0x38,0x28,0x28,0x28,0x30,0x28,0x38,0x28,0x28,0x28,0x28,0x9A,0x42,0x24,0x70,0x40,0x5A,0xA8,0x72,0x84,0x6E,0x40,0xA2,0x3E,0x58,0x4E,0x56};
		
		void LexaeusFilesFix()
		{
			UpdateFilesSeeking(true);
			ResetMset(Lexaeus_ML,Lexaeus_ECL,Lexaeus_ECL_Length);
			/* MSET Fixes */
			WriteBytes(msetAddress+0x1257C4,new byte[] {95,0,255,255,0,0});
			WriteBytes(msetAddress+0x11A810,LexaeusRunFix);
			WriteInteger(msetAddress+Lexaeus_ML[26]+0x2C,GetECLength(msetAddress+0x11A7D0,3));
			//WriteInteger(msetAddress+0x11A7D1,(byte)6);
			WriteInteger(msetAddress+0x18DEF1,(byte)0x0B);
			WriteInteger(msetAddress+0x18DEF0+0x24,(byte)0x50);
			WriteBytes(msetAddress+0x18DEF0+0x4C,new byte[] {0x08,0x02,0x85,0x01,0x14,0x00,0x00,0x00,0x17,0x01,0x00,0x00,0x58,0x00,0x18,0x00,0x04,0x00,0x00,0x00});
			/* MDLX Fixes */
				
			/* A.FM Fixes */
		}
		
		public void LexaeusSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			
			//Idle
			if (IsANBPlaying(player_Ptr,Lexaeus_ML[0]))
			{
				if (GetFrame(player_Ptr)>10) //Reinitialisation des changements d'opacité de l'anim d'apparition
				WriteInteger(msetAddress+0x18DEF1,(byte)0x09);
				TurnStep(player_Ptr,0);
				WalkStep(player_Ptr,0.001f);
				RunStep(player_Ptr,0.001f);
			}
			else if (!IsANBPlaying(player_Ptr,Lexaeus_ML[26])^GetFrame(player_Ptr)>30)
			{
				TurnStep(player_Ptr,0.1963495463f);
				WalkStep(player_Ptr,2f);
				RunStep(player_Ptr,8f);
			}
			
			//Landing
			if (IsANBPlaying(player_Ptr,Lexaeus_ML[1]))
		    {
		    	SetAnimationState(player_Ptr,0x40);
		    }
			
			//Walking
			if (IsANBPlaying(player_Ptr,Lexaeus_ML[26]))
		    {
				SetMSET11(0x18,Lexaeus_ML[27],Lexaeus_ML_Length[27]);
			}
			
			//end of walking
			else 
		    {
				if (IsANBPlaying(player_Ptr,Lexaeus_ML[27])&&GetFrame(player_Ptr)<10) Translation(player_Ptr,1,30);
				if (ReadInt32(msetAddress+0x18)==msetAddress-0x20000000+Lexaeus_ML[27]) //Reset de la marche
					SetMSET11(0x18,Lexaeus_ML[0],Lexaeus_ML_Length[0]);
				
		    }
			
			//Backwards jump
			if (IsANBPlaying(player_Ptr,Lexaeus_ML[29]))
		    {
				SetMSET11(0x58,Lexaeus_ML[30],Lexaeus_ML_Length[30]);
				SetMSET11(0x18,Lexaeus_ML[30],Lexaeus_ML_Length[30]);
			}
			
			//In airs hit
			if (IsANBPlaying(player_Ptr,Lexaeus_ML[30]))
		    {
				SetMSET11(0x58,Lexaeus_ML[1],Lexaeus_ML_Length[1]);
				SetMSET11(0x18,Lexaeus_ML[0],Lexaeus_ML_Length[0]);
			}
			
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}
