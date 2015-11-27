﻿using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Vexen_ML= new int[] {0xFF0/* 00A */,0x6080/* 02A */,0xB4A0/* 04A */,0x14D60/* 05A */,0x207A0/* 20A */,0x31B70/* 21A */,0x45010/* 22A */,0x56C40/* 23A */,0x67D50/* 24A */,0x77660/* 25A */,0x84DC0/* 30A */,0x90020/* 31A */,0xA79A0/* 32A */,0xB2FE0/* 33A */,0x84DC0/* 30A */,0xA79A0/* 32A */,0x84DC0/* 30A */,0xC4810/* 12A */,0xCA0A0/* 11A */,0x207A0/* 20A */,0x67D50/* 24A */,0xCF9A0/* 50A */,0xEB930/* 51A */,0x113510/* 52A */,0x12E600/* 53A */,0x147300/* 54A */,0x16CE20/* 55A */,0x1844C0/* 57A */,0x198170/* 58A */,0x1BDC30/* 56A */,0x1D3E00/* 56B */,0x1E8BC0/* 56C */,0x204680/* 85A */,0x204680/* 85A */,0x225E20/* 87A */,0x237A30/* 86A */,0x242380/* 86B */};
		int[] Vexen_ML_Length = new int[] {0x5084/* 00A */,0x5414/* 02A */,0x98B4/* 04A */,0xBA3E/* 05A */,0x113CC/* 20A */,0x1349C/* 21A */,0x11C30/* 22A */,0x11110/* 23A */,0xF910/* 24A */,0xD760/* 25A */,0xB260/* 30A */,0x17980/* 31A */,0xB640/* 32A */,0x11830/* 33A */,0xB260/* 30A */,0xB640/* 32A */,0xB260/* 30A */,0x5884/* 12A */,0x58F4/* 11A */,0x113CC/* 20A */,0xF910/* 24A */,0x1BF86/* 50A */,0x27BD6/* 51A */,0x1B0E4/* 52A */,0x18CF8/* 53A */,0x25B20/* 54A */,0x176A0/* 55A */,0x13CA8/* 57A */,0x25AB8/* 58A */,0x161C4/* 56A */,0x14DB8/* 56B */,0x1BAB4/* 56C */,0x2179E/* 85A */,0x2179E/* 85A */,0x11C10/* 87A */,0xA948/* 86A */,0x10674/* 86B */};
		byte[] VexenPAXAlgo = new byte[] {00,0x07,0x2C,0x00,0x00,0x00,0xFF,0xFF,0x16,0x01,0x00,0x00,0x00,0x00,0x1C,0x00,0x17,0x01,0x07,0x00,0x1C,0x00,0x52,0x00,0x17,0x01,0x41,0x00,0x00,0x00,0x1D,0x00,0x17,0x01,0x4C,0x00,0x1D,0x00,0x41,0x00,0x17,0x01,0x4B,0x00,0x22,0x00,0x0C,0x00,0x3E,0x00,0x0A,0x00,0x17,0x00,0x0D,0x02,0x02,0x00,0x00,0x00,0x1C,0x00,0x08,0x02,0x86,0x01,0x15,0x00,0x00,0x00,0x17,0x01,0x00,0x00,0x01,0x00,0x01,0x01,0x02,0x00,0x17,0x00,0x18,0x00,0x15,0x00,0x00};
		int[] Vexen_ECL = new int[] {0x5070,0x5400,0x98B0,0xBA20,0x113A0,0x13470,0x11C10,0x110F0,0xF8F0,0xD740,0xB240,0x17960,0xB620,0x11810,0xB240,0xB620,0xB240,0x5870,0x58E0,0x113A0,0xF8F0,0x1BF40,0x27BA0,0x1B090,0x18CB0,0x25AE0,0x17670,0x13C90,0x25A60,0x16190,0x14D80,0x1BA90,0x21770,0x21770,0x11BE0,0xA940,0x10660};
		int[] Vexen_ECL_Length = new int[] {0x14,0x14,0x4,0x1E,0x2C,0x2C,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x14,0x14,0x2C,0x20,0x46,0x36,0x54,0x48,0x40,0x30,0x18,0x58,0x34,0x38,0x24,0x2E,0x2E,0x30,0x8,0x14};
		
		
		void VexenFilesFix()
		{
			UpdateFilesSeeking(true);
			ResetMset(Vexen_ML,Vexen_ECL,Vexen_ECL_Length);
			/* MSET Fixes */
			
			/* MDLX Fixes */
				
			/* A.FM Fixes */
			SetPAXFixedToLocalFloor(2);
		}
		
		public void VexenSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			
			//Falling
			if (IsANBPlaying(player_Ptr,Vexen_ML[2]))
		    {
		    	SetAnimationState(player_Ptr,0x40);
		    }
			
			//Drive Transition (When the character appears from drive)
			if (IsANBPlaying(player_Ptr,Vexen_ML[25]))
		    {
				
			}
			
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}
