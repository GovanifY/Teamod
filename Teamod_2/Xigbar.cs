﻿using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Xigbar_ML= new int[] {0x1020/* 00A */,0xF770/* 01A */,0xF770/* 01A */,0x1020/* 00A */,0x1020/* 00A */,0x18E00/* 20A */,0x246E0/* 22A */,0x246E0/* 22A */,0x18E00/* 20A */,0x18E00/* 20A */,0x246E0/* 22A */,0x1020/* 00A */,0x1020/* 00A */,0x18E00/* 20A */,0x18E00/* 20A */,0x2FEC0/* 53A */,0x46650/* 53B */,0x4FD80/* 53C */,0x58160/* 53D */,0x61CA0/* 53E */,0x7A550/* 53F */,0x81200/* 40A */,0x9EBB0/* 51A */,0xA8AE0/* 52A */,0xB8240/* 52B */,0xC4140/* 54A */,0xD17E0/* 54B */,0xD6C60/* 55A */,0xDFC20/* 55B */,0xE92F0/* 60A */,0xF6F50/* 60B */,0xF9810/* 60C */,0xFCBB0/* 50A */,0x10DC20/* 50B */,0x11A3C0/* 50C */,0x125810/* 50D */,0x12FC10/* 80A */,0x13E3F0/* 81A */,0x14CAB0/* 82A */};
		int[] Xigbar_ML_Length= new int[] {0xE750/* 00A */,0x9690/* 01A */,0x9690/* 01A */,0xE750/* 00A */,0xE750/* 00A */,0xB8E0/* 20A */,0xB7E0/* 22A */,0xB7E0/* 22A */,0xB8E0/* 20A */,0xB8E0/* 20A */,0xB7E0/* 22A */,0xE750/* 00A */,0xE750/* 00A */,0xB8E0/* 20A */,0xB8E0/* 20A */,0x1678A/* 53A */,0x9722/* 53B */,0x83DA/* 53C */,0x9B32/* 53D */,0x188A6/* 53E */,0x6CAC/* 53F */,0x1D9A2/* 40A */,0x9F22/* 51A */,0xF752/* 52A */,0xBEFA/* 52B */,0xD69C/* 54A */,0x5480/* 54B */,0x8FB4/* 55A */,0x96D0/* 55B */,0xDC60/* 60A */,0x28C0/* 60B */,0x33A0/* 60C */,0x11064/* 50A */,0xC79C/* 50B */,0xB444/* 50C */,0xA3F4/* 50D */,0xE7DC/* 80A */,0xE6B4/* 81A */,0x2B44/* 82A */};
		byte[] XigbarPAXAlgo = new byte[] {0x00,0x05,0x04,0x00,0x00,0x00,0x17,0x01,0x00,0x00,0x05,0x00,0x0D,0x01,0x1C,0x00,0x08,0x00,0x01,0x01,0x32,0x00,0x08,0x00,0x01,0x01,0x33,0x00,0x10,0x00,0x18,0x01,0x10,0x00};
		int[] Xigbar_ECL = new int[] {0xE750,0x9690,0x9690,0xE750,0xE750,0xB8C0,0xB7C0,0xB7C0,0xB8C0,0xB8C0,0xB7C0,0xE750,0xE750,0xB8C0,0xB8C0,0x16680,0x96C0,0x8350,0x9AD0,0x18830,0x6CA0,0x1D930,0x9EB0,0xF700,0xBEE0,0xD650,0x5460,0x8F90,0x96C0,0xDC10,0x2870,0x3350,0x10FD0,0xC730,0xB3D0,0xA380,0xE7D0,0xE660,0x2B40};
		int[] Xigbar_ECL_Length = new int[] {0x0,0x0,0x0,0x0,0x0,0x20,0x20,0x20,0x20,0x20,0x20,0x0,0x0,0x20,0x20,0x10A,0x62,0x8A,0x62,0x76,0xC,0x72,0x72,0x52,0x1A,0x4C,0x20,0x24,0x10,0x50,0x50,0x50,0x94,0x6C,0x74,0x74,0xC,0x54,0x4};
		
		
		void XigbarFilesFix()
		{
			UpdateFilesSeeking(true);
			ResetMset(Xigbar_ML,Xigbar_ECL,Xigbar_ECL_Length);
			/* MSET Fixes */
			
			/* MDLX Fixes */
				
			/* A.FM Fixes */
		}
		
		public void XigbarSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			
			//Drive Transition (When the character appears from drive)
			if (IsANBPlaying(player_Ptr,Xigbar_ML[0])&&GetFrame(player_Ptr)>20)
		    {
				WriteInteger(msetAddress+Xigbar_ML[0]+0x28,msetAddress-0x20000000+Xigbar_ML[0]+0x50);
				SetPaxAlgoAddress(player_Ptr,msetAddress-0x20000000+Xigbar_ML[0]+0x50);
			}
			
			JumpLength(player_Ptr,0);
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}