﻿using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Luxord_ML = new int[] {0x1020/* 00A */,0x66A0/* 01A */,0x66A0/* 01A */,0x13B10/* 03A */,0x1E710/* 04A */,0x28460/* 05A */,0x345C0/* 20A */,0x44FD0/* 21A */,0x54300/* 22A */,0x67190/* 23A */,0x76690/* 24A */,0x82190/* 25A */,0x8DDE0/* 30A */,0x98D00/* 31A */,0xA6070/* 32A */,0xB0960/* 33A */,0x8DDE0/* 30A */,0xA6070/* 32A */,0xBE270/* 80A */,0x345C0/* 20A */,0x44FD0/* 21A */,0xCFC80/* 50A */,0xED9E0/* 51A */,0x113970/* 52A */,0x1210A0/* 53A */,0x13E080/* 55A */,0x153BF0/* 56A */,0x17EE40/* 54A */,0x196250/* 54B */,0x1A3DF0/* 54C */,0x1B3BD0/* 81A */,0x1C0D00/* 82A */,0x1CE7E0/* 90A */,0x1DB1E0/* 91A */,0x1E1CC0/* 92A */,0x1F66B0/* 93A */,0x2053F0/* 94A */,0x211DF0/* 95A */,0x2188D0/* 96A */};
		int[] Luxord_ML_Length = new int[] {0x5680/* 00A */,0xD466/* 01A */,0xD466/* 01A */,0xABF8/* 03A */,0x9D50/* 04A */,0xC156/* 05A */,0x10A10/* 20A */,0xF330/* 21A */,0x12E90/* 22A */,0xF500/* 23A */,0xBB00/* 24A */,0xBC50/* 25A */,0xAF20/* 30A */,0xD36E/* 31A */,0xA8F0/* 32A */,0xD906/* 33A */,0xAF20/* 30A */,0xA8F0/* 32A */,0x11A08/* 80A */,0x10A10/* 20A */,0xF330/* 21A */,0x1DD60/* 50A */,0x25F88/* 51A */,0xD730/* 52A */,0x1CFDA/* 53A */,0x15B62/* 55A */,0x2B250/* 56A */,0x17408/* 54A */,0xDBA0/* 54B */,0xFDD2/* 54C */,0xD124/* 81A */,0xDADC/* 82A */,0xC9F4/* 90A */,0x6AD4/* 91A */,0x149EC/* 92A */,0xED40/* 93A */,0xCA00/* 94A */,0x6AE0/* 95A */,0xED54/* 96A */};
		byte[] LuxordPAXAlgo = new byte[] {0x03,0x06,0x18,0x00,0x0B,0x00,0xFF,0xFF,0x12,0x00,0x00,0x00,0xFF,0xFF,0x13,0x00,0x00,0x00,0xFF,0xFF,0x16,0x01,0x00,0x00,0x11,0x00,0x08,0x04,0x41,0x01,0x1E,0x00,0x00,0x00,0x00,0x00,0x30,0x00,0x08,0x04,0x41,0x01,0x1F,0x00,0x00,0x00,0x00,0x00,0x0A,0x00,0x08,0x04,0x41,0x01,0x2F,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x17,0x01,0x00,0x00,0x00,0x00,0x01,0x01,0x11,0x00,0x09,0x00,0x18,0x00,0x10,0x00};
		int[] Luxord_ECL = new int[] {0x5680,0xD420,0xD420,0xABD0,0x9D50,0xC140,0x109F0,0xF310,0x12E70,0xF4E0,0xBAE0,0xBC30,0xAF00,0xD340,0xA8D0,0xD8D0,0xAF00,0xA8D0,0x119C0,0x109F0,0xF310,0x1DC60,0x25F20,0xD6F0,0x1CFA0,0x15B10,0x2B1D0,0x17390,0xDB40,0xFD70,0xD0D0,0xDAA0,0xC9D0,0x6AC0,0x149D0,0xED20,0xC9D0,0x6AC0,0xED20};
		int[] Luxord_ECL_Length = new int[] {0x0,0x46,0x46,0x28,0x0,0x16,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x2E,0x20,0x36,0x20,0x20,0x48,0x20,0x20,0x100,0x68,0x40,0x3A,0x52,0x80,0x78,0x60,0x62,0x54,0x3C,0x24,0x14,0x1C,0x20,0x30,0x20,0x34};
		
		void LuxordFilesFix()
		{
			ResetMset(Luxord_ML,Luxord_ECL,Luxord_ECL_Length);
			/* MSET Fixes */
			
			/* MDLX Fixes */
				
			/* A.FM Fixes */
		}
		
		public void LuxordSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			
			//Falling
			if (IsANBPlaying(player_Ptr,Luxord_ML[4]))
		    {
		    	SetAnimationState(player_Ptr,0x40);
		    }
			
			//Drive Transition (When the character appears from drive)
			if (IsANBPlaying(player_Ptr,Luxord_ML[25]))
		    {
				
			}
			
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}
