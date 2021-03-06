﻿using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Larxene_ML = new int[] {0xFE0/* 00A */,0xBCF0/* 02A */,0xBCF0/* 02A */,0x13490/* 04A */,0x1A4A0/* 05A */,0x27990/* 20A */,0x33720/* 21A */,0x3F0D0/* 22A */,0x4A180/* 23A */,0x559D0/* 24A */,0x5EDD0/* 25A */,0x67B10/* 30A */,0x6FF50/* 31A */,0x826D0/* 32A */,0x8AC50/* 33A */,0x67B10/* 30A */,0x826D0/* 32A */,0x9C7C0/* 10A */,0xACF90/* 11A */,0x27990/* 20A */,0x559D0/* 24A */,0xBC1F0/* 70A */,0xC0190/* 90A */,0xEBF30/* 91A */,0x3204F0/* 56A */,0x330EE0/* 57A */,0x344BC0/* 60A */,0x35B520/* 61A */,0x375670/* 62A */,0x382480/* 61B */,0x38D080/* 50B */,0x395780/* 55B */,0x112190/* raw */,0x1721A0/* raw */,0x1D21C0/* raw */,0x1E4A80/* raw */,0x2352F0/* raw */,0x2E2840/* raw */,0x2F5110/* raw */,0x317010/* raw */};
		int[] Larxene_ML_Length = new int[] {0xAD0A/* 00A */,0x779A/* 02A */,0x779A/* 02A */,0x700C/* 04A */,0xD4F0/* 05A */,0xBD90/* 20A */,0xB9B0/* 21A */,0xB0B0/* 22A */,0xB850/* 23A */,0x9400/* 24A */,0x8D40/* 25A */,0x8438/* 30A */,0x1277C/* 31A */,0x8578/* 32A */,0x11B64/* 33A */,0x8438/* 30A */,0x8578/* 32A */,0x107CE/* 10A */,0xF254/* 11A */,0xBD90/* 20A */,0x9400/* 24A */,0x3F94/* 70A */,0x2BD92/* 90A */,0x25464/* 91A */,0x109EC/* 56A */,0x13CDA/* 57A */,0x16952/* 60A */,0x1A14C/* 61A */,0xCE06/* 62A */,0xABFA/* 61B */,0x86F2/* 50B */,0xD410/* 55B */,0x60002/* raw */,0x60016/* raw */,0x128BC/* raw */,0x50864/* raw */,0xAD54A/* raw */,0x128CC/* raw */,0x21F00/* raw */,0x94E0/* raw */};
		byte[] LarxenePAXAlgo = new byte[] {0x04,0x0B,0x22,0x00,0x00,0x00,0xFF,0xFF,0x2C,0x00,0x00,0x00,0x5A,0x00,0x24,0x01,0x01,0x00,0x00,0x00,0x66,0x00,0x17,0x01,0x29,0x00,0x00,0x00,0x66,0x00,0x17,0x01,0x2A,0x00,0x00,0x00,0x0F,0x01,0x00,0x00,0x20,0x00,0x07,0x02,0x14,0x00,0x00,0x00,0x1A,0x00,0x0D,0x02,0x0D,0x00,0x00,0x00,0x02,0x00,0x01,0x01,0x16,0x00,0x02,0x00,0x01,0x01,0x17,0x00,0x2E,0x00,0x18,0x01,0x0F,0x00,0x55,0x00,0x08,0x04,0x88,0x01,0x12,0x00,0x00,0x00,0x00,0x00,0x1E,0x00,0x08,0x04,0x88,0x01,0x13,0x00,0x00,0x00,0x00,0x00,0x53,0x00,0x08,0x04,0x88,0x01,0x17,0x00,0x00,0x00,0x00,0x00,0x39,0x00,0x08,0x04,0x88,0x01,0x16,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x17,0x00};
		byte[] LarxeneApparitionAlgo = new byte[] {0x06,0x23,0x3A,0x00,0x22,0x00,0x2C,0x00,0x21,0x03,0x38,0x07,0x07,0x00,0x01,0x00,0x00,0x00,0x23,0x00,0x16,0x01,0x00,0x00,0x00,0x00,0xFF,0xFF,0x01,0x01,0x01,0x00,0x08,0x00,0x1C,0x00,0x0A,0x02,0x84,0x07,0x08,0x00,0x00,0x00,0x39,0x00,0x17,0x01,0x29,0x00,0x00,0x00,0x39,0x00,0x17,0x01,0x2A,0x00,0x1E,0x00,0x0D,0x02,0x01,0x00,0x00,0x00,0x36,0x00,0x09,0x00,0x02,0x00,0x01,0x01,0x28,0x00,0x28,0x00,0x01,0x01,0x29,0x00,0x00,0x00,0x08,0x04,0x88,0x01,0x12,0x00,0x00,0x00,0x00,0x00,0x2C,0x00,0x08,0x04,0x88,0x01,0x13,0x00,0x00,0x00,0x00,0x00,0x07,0x00,0x08,0x04,0x88,0x01,0x1B,0x04,0x88,0x01,0x16,0x00,0x01,0x00,0x01,0x01,0x02,0x00,0x01,0x00,0x01,0x01,0x03,0x00,0x01,0x00,0x01,0x01,0x04,0x00,0x01,0x00,0x01,0x01,0x05,0x00,0x01,0x00,0x01,0x01,0x06,0x00,0x01,0x00,0x01,0x01,0x07,0x00,0x01,0x00,0x01,0x01,0x08,0x00,0x01,0x00,0x01,0x01,0x09,0x00,0x01,0x00,0x01,0x01,0x0A,0x00,0x01,0x00,0x01,0x01,0x0B,0x00,0x06,0x00,0x18,0x01,0x13,0x00,0x39,0x00,0x03,0x01,0x00,0x00,0x35,0x00,0x01,0x01,0x01,0x00,0x35,0x00,0x01,0x01,0x02,0x00,0x35,0x00,0x01,0x01,0x03,0x00,0x35,0x00,0x01,0x01,0x04,0x00,0x35,0x00,0x01,0x01,0x05,0x00,0x35,0x00,0x01,0x01,0x06,0x00,0x35,0x00,0x01,0x01,0x07,0x00,0x35,0x00,0x01,0x01,0x08,0x00,0x35,0x00,0x01,0x01,0x09,0x00,0x35,0x00,0x01,0x01,0x0A,0x00,0x35,0x00,0x01,0x01,0x0B,0x00,0x35,0x00,0x01,0x01,0x0C,0x00,0x35,0x00,0x01,0x01,0x0D,0x00,0x35,0x00,0x01,0x01,0x0E,0x00,0x35,0x00,0x17,0x01,0x01,0x00,0x3B,0x00,0x03,0x00,0x00,0x00};
		int[] Larxene_ECL = new int[] {0xAD00,0x7770,0x7770,0x7000,0xD4C0,0xBD70,0xB990,0xB090,0xB830,0x93E0,0x8D20,0x8410,0x12730,0x8550,0x11B20,0x8410,0x8550,0x10770,0xF1F0,0xBD70,0x93E0,0x3F70,0x2BD50,0x25420,0x10980,0x13C60,0x168F0,0x1A0C0,0xCDC0,0xABE0,0x86D0,0xD3E0,0x5FFA0,0x5FFA0,0x128A0,0x50820,0xAD520,0x128A0,0x21EE0,0x94E0};
		int[] Larxene_ECL_Length = new int[] {0xA,0x2A,0x2A,0xC,0x30,0x20,0x20,0x20,0x20,0x20,0x20,0x28,0x4C,0x28,0x44,0x28,0x28,0x5E,0x64,0x20,0x20,0x24,0x42,0x44,0x6C,0x7A,0x62,0x8C,0x46,0x1A,0x22,0x30,0x62,0x76,0x1C,0x44,0x2A,0x2C,0x20,0x0};
		
		void LarxeneFilesFix()
		{
			UpdateFilesSeeking(true);
			ResetMset(Larxene_ML,Larxene_ECL,Larxene_ECL_Length);
			/* MSET Fixes */
			//Saut
			WriteBytes(msetAddress+0x9C770,new byte[] {0x00,0x08,0x04,0x00,0x04,0x00,0x08,0x04,0x88,0x01,0x12,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x01,0x01,0x03,0x00,0x01,0x00,0x01,0x01,0x04,0x00,0x01,0x00,0x01,0x01,0x05,0x00,0x01,0x00,0x01,0x01,0x06,0x00,0x01,0x00,0x01,0x01,0x07,0x00,0x06,0x00,0x17,0x01,0x05,0x00,0x04,0x00});
			WriteInteger(msetAddress+Larxene_ML[14]+0x2C,54);
			SetMSET11(0x48,Larxene_ML[14],Larxene_ML_Length[14]);
			SetMSET11(0x9E8,Larxene_ML[30],Larxene_ML_Length[30]);
			
			WriteBytes(msetAddress+Larxene_ML[36]+0x10,ReadBytes(msetAddress+Larxene_ML[0]+0x10,0x30));
			WriteBytes(msetAddress+Larxene_ML[36]+0x50,LarxeneApparitionAlgo);
			WriteInteger(msetAddress+Larxene_ML[33]+0x28,msetAddress-0x20000000+Larxene_ML[36]+0x50);
			WriteInteger(msetAddress+Larxene_ML[33]+0x2C,LarxeneApparitionAlgo.Length);
			
			 /* MDLX Fixes */
				
			/* A.FM Fixes */
		}
		
		public void LarxeneSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			
			//Falling
			if (IsANBPlaying(player_Ptr,Larxene_ML[3]))
		    {
		    	SetAnimationState(player_Ptr,0x40);
		    }
			
			//Landing
			if (IsANBPlaying(player_Ptr,Larxene_ML[4]))
		    {
				WriteInteger(msetAddress+Larxene_ML[14]+0x50,(byte)1);
				WriteInteger(msetAddress+Larxene_ML[14]+0x51,(byte)8);
		    }
			
			//Drive Transition (When the character appears from drive)
			if (IsANBPlaying(player_Ptr,Larxene_ML[25])&&ReadInt32(msetAddress+Larxene_ML[25]+0x28)==0x1C93A00)
		    {
				SetFrame(player_Ptr,25);
				WriteInteger(msetAddress+Larxene_ML[25]+0x28,msetAddress-0x20000000+0x344B40);
			}
			
			//Disappearance
			if (IsANBPlaying(player_Ptr,Larxene_ML[14]))
		    {
				SetMSET11(0x48,Larxene_ML[33],Larxene_ML_Length[33]);
		    }
			
			//Disappearance
			if (IsANBPlaying(player_Ptr,Larxene_ML[33]))
		    {
				JumpCountDown(player_Ptr,58f);
				if (GetFrame(player_Ptr)<39)
					if (Pad("Circle",true))
					{
						WriteInteger(msetAddress+Larxene_ML[36]+0x51,(byte)0x13);
						WriteInteger(msetAddress+Larxene_ML[36]+0x50+0xB8,(byte)0x39);
					}
					else
					{
						WriteInteger(msetAddress+Larxene_ML[36]+0x51,(byte)0x23);
						WriteInteger(msetAddress+Larxene_ML[36]+0x50+0xB8,(byte)0xFF);
					}
				
		    }
			
			//Disappearance
			if (IsANBPlaying(player_Ptr,Larxene_ML[30]))
			{
				if (ReadBytes(msetAddress+Larxene_ML[36]+0x51,1)[0]==0x13)
						SetMSET11(0x48,Larxene_ML[14],Larxene_ML_Length[14]);
					else 
						SetMSET11(0x48,Larxene_ML[33],Larxene_ML_Length[33]);
					if (isInvisible(player_Ptr))
		    			SetAnimationState(player_Ptr,0x40);
			}
		    
			
			if (IsANBPlaying(player_Ptr,Larxene_ML[13]))
			{
				WriteInteger(msetAddress+Larxene_ML[14]+0x50,(byte)0);
				WriteInteger(msetAddress+Larxene_ML[14]+0x51,(byte)1);
			}
			
			AnimAterrissage(player_Ptr,(int)(5*GetOpacity(player_Ptr)));
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}
