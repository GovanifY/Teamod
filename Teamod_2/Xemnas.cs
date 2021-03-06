﻿using System;
using System.Windows.Forms;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Xemnas_ML= new int[] {0x1010/* 00A */,0x7000/* 01A */,0x7000/* 01A */,0xF8D0/* 04A */,0x1AD30/* 05A */,0x24D20/* 20A */,0x2EC80/* 21A */,0x39BA0/* 22A */,0x42DC0/* 23A */,0x4EFB0/* 24A */,0x587C0/* 25A */,0x61990/* 30A */,0x6C950/* 31A */,0x79890/* 32A */,0x845E0/* 33A */,0x61990/* 30A */,0x79890/* 32A */,0x24D20/* 20A */,0x39BA0/* 22A */,0x24D20/* 20A */,0x4EFB0/* 24A */,0x93310/* 40A */,0x9BDE0/* 41A */,0xA7BC0/* 50A */,0xB9CB0/* 51A */,0xCF8B0/* 52A */,0x120560/* 60A */,0x134230/* 62A */,0x157AE0/* 63A */,0x165910/* 63B */,0x177500/* 63C */};
		int[] Xemnas_ML_Length= new int[] {0x5FF0/* 00A */,0x88CC/* 01A */,0x88CC/* 01A */,0xB460/* 04A */,0x9FF0/* 05A */,0x9F60/* 20A */,0xAF20/* 21A */,0x9220/* 22A */,0xC1F0/* 23A */,0x9810/* 24A */,0x91D0/* 25A */,0xAFC0/* 30A */,0xCF38/* 31A */,0xAD50/* 32A */,0xED24/* 33A */,0xAFC0/* 30A */,0xAD50/* 32A */,0x9F60/* 20A */,0x9220/* 22A */,0x9F60/* 20A */,0x9810/* 24A */,0x8ACC/* 40A */,0xBDD4/* 41A */,0x120F0/* 50A */,0x15BFA/* 51A */,0x50CAC/* 52A */,0x13CCC/* 60A */,0x238AE/* 62A */,0xDE28/* 63A */,0x11BE2/* 63B */,0x2253C/* 63C */};
		byte[] XemnasPAXAlgo = new byte[] {0x00,0x05,0x04,0x00,0x00,0x00,0x17,0x01,0x00,0x00,0x01,0x00,0x01,0x01,0x01,0x00,0x01,0x00,0x01,0x01,0x02,0x00,0x3C,0x00,0x18,0x01,0x05,0x00,0x01,0x00,0x01,0x01,0x10,0x00};
		int[] Xemnas_ECL = new int[] {0x5FF0,0x88B0,0x88B0,0xB460,0x9FE0,0x9F40,0xAF00,0x9200,0xC1D0,0x97F0,0x91B0,0xAFA0,0xCF00,0xAD30,0xECE0,0xAFA0,0xAD30,0x9F40,0x9200,0x9F40,0x97F0,0x8AB0,0xBDB0,0x12080,0x15B70,0x50BA0,0x13C70,0x23810,0xDE10,0x11B80,0x224D0};
		int[] Xemnas_ECL_Length = new int[] {0x0,0x1C,0x1C,0x0,0x10,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x38,0x20,0x44,0x20,0x20,0x20,0x20,0x20,0x20,0x1C,0x24,0x70,0x8A,0x10C,0x5C,0x9E,0x18,0x62,0x6C};
		
		
		void XemnasFilesFix()
		{
			UpdateFilesSeeking(true);
			ResetMset(Xemnas_ML,Xemnas_ECL,Xemnas_ECL_Length);
			/* MSET Fixes */
			SetMSET11(0x48,Xemnas_ML[23],Xemnas_ML_Length[23]);
			byte[] guard = ReadBytes(msetAddress+0xB9C40,ReadInt32(msetAddress+Xemnas_ML[23]+0x2C));
			guard = CombineEC(guard,new byte[] {110,0,255,255,0,0},0);
			guard = CombineEC(guard,new byte[] {0x14,0x00,0x01,0x01,0x0B,0x00},1);
			guard = CombineEC(guard,new byte[] {0x14,0x00,0x01,0x01,0x0C,0x00},1);
			guard = CombineEC(guard,new byte[] {0x14,0x00,0x01,0x01,0x0D,0x00},1);
			SetEffectCaster(msetAddress+Xemnas_ML[23],guard);
			/* MDLX Fixes */
				
			/* A.FM Fixes */
				SetPAXFixedToTempFloor(0x10);
				for (int i=0x0B;i<0x0D;i++)
				{
					SetPAXAttachement(i,0x00A2,0x0AA3);
					SetPAXLocation(i,20f,30f,30f);
					SetPAXRotation(i,-0.77f,-0.05f,0.43f);
				}
		}
		
		public void XemnasSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			
			//Landing
			if (IsANBPlaying(player_Ptr,Xemnas_ML[3]))
		    {
		    	SetAnimationState(player_Ptr,0x40);
		    }
			
			//Drive Transition animation (When the character appears from drive)
			if (IsANBPlaying(player_Ptr,Xemnas_ML[25]))
		    {
				
			}
			
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}
