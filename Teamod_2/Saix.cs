﻿using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Saix_ML= new int[] {0xEA0/* 00A */,0xF150/* 01A */,0xF150/* 01A */,0x1A580/* 03A */,0x26A80/* 04A */,0x31EE0/* 05A */,0x3E920/* 20A */,0x4C490/* 21A */,0x5B4A0/* 22A */,0x69580/* 23A */,0x77E30/* 24A */,0x82680/* 25A */,0x8D530/* 30A */,0x96900/* 31A */,0xA6890/* 32A */,0xB0210/* 33A */,0x8D530/* 30A */,0xA6890/* 32A */,0xC1400/* 80A */,0x3E920/* 20A */,0x77E30/* 24A */,0x77E30/* 24A */,0x8D530/* 30A */,0x96900/* 31A */,0x22D220/* 50A */,0x244870/* 51A */,0x2611D0/* 70A */,0x2746A0/* 81A */,0xE1A10 /* 02A */};
		int[] Saix_ML_Length = new int[] {0xE2B0/* 00A */,0xB42C/* 01A */,0xB42C/* 01A */,0xC4FA/* 03A */,0xB460/* 04A */,0xCA36/* 05A */,0xDB64/* 20A */,0xF004/* 21A */,0xE0D4/* 22A */,0xE8B0/* 23A */,0xA850/* 24A */,0xAEB0/* 25A */,0x93D0/* 30A */,0xFF84/* 31A */,0x9980/* 32A */,0x111E4/* 33A */,0x93D0/* 30A */,0x9980/* 32A */,0xE84C/* 80A */,0xDB64/* 20A */,0xA850/* 24A */,0xA850/* 24A */,0x93D0/* 30A */,0xFF84/* 31A */,0x17648/* 50A */,0x1C95C/* 51A */,0x134C4/* 70A */,0x1F5B2/* 81A */,0xADD8 /* 02A */};
		byte[] SaixPAXAlgo = new byte[] {09,0x07,0x4A,0x00,0x80,0x00,0xA5,0x00,0x0A,0x02,0x67,0x05,0x06,0x00,0x01,0x00,0xB4,0x00,0x03,0x00,0x00,0x00,0xFF,0xFF,0x1B,0x00,0x00,0x00,0x03,0x00,0x17,0x01,0x21,0x00,0x03,0x00,0x60,0x00,0x17,0x01,0x20,0x00,0x61,0x00,0xB5,0x00,0x17,0x01,0x20,0x00,0xB5,0x00,0xCF,0x00,0x17,0x01,0x4B,0x00,0xB5,0x00,0xCF,0x00,0x17,0x01,0x4C,0x00,0x03,0x00,0xB5,0x00,0x17,0x01,0x55,0x00,0x86,0x00,0x09,0x00,0x73,0x00,0x0D,0x02,0x38,0x00,0x00,0x00,0x7E,0x00,0x01,0x01,0x08,0x00,0x7E,0x00,0x01,0x01,0x15,0x00,0xB4,0x00,0x08,0x04,0x42,0x01,0x21,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x17,0x01,0x00,0x00,0x83,0x00,0x18,0x00,0x03,0x00,0x00};
		int[] Saix_ECL = new int[] {0xE2A0,0xB410,0xB410,0xC4E0,0xB460,0xCA20,0xDB40,0xEFE0,0xE0B0,0xE890,0xA830,0xAE90,0x93B0,0xFF70,0x9960,0x111C0,0x93B0,0x9960,0xE830,0xDB40,0xA830,0xA830,0x93B0,0xFF70,0x175A0,0x1C8D0,0x13490,0x1F530,0xADE0};
		int[] Saix_ECL_Length = new int[] {0x10,0x1C,0x1C,0x14,0x0,0x16,0x24,0x24,0x24,0x20,0x20,0x20,0x20,0x14,0x20,0x24,0x20,0x20,0x1C,0x24,0x20,0x20,0x20,0x14,0xA8,0x8C,0x34,0x82,0x28};
		
		
		void SaixFilesFix()
		{
			UpdateFilesSeeking(true);
			ResetMset(Saix_ML,Saix_ECL,Saix_ECL_Length);
			/* MSET Fixes */
			SetMSET11(0x38,Saix_ML[28],Saix_ML_Length[28]);
			WriteBytes(msetAddress+0xEC7F0,new byte [] {01,0x03,0x0A,0x00,0x00,0x00,0xFF,0xFF,0x00,0x00,0x01,0x00,0x08,0x04,0x42,0x01,0x28,0x00,0x00,0x00,0x00,0x00,0x0C,0x00,0x08,0x04,0x42,0x01,0x29,0x00,0x00,0x00,0x00,0x00,0x1C,0x00,0x08,0x04,0x42,0x01,0x28,0x00});
			
			/* MDLX Fixes */
				
			/* A.FM Fixes */
		}
		
		public void SaixSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			//Idle
			if (IsANBPlaying(player_Ptr,Saix_ML[0]))
		    {
				
		    }
			
			//Falling
			if (IsANBPlaying(player_Ptr,Saix_ML[4]))
		    {
		    	SetAnimationState(player_Ptr,0x40);
		    }
			
			//Drive Transition (When the character appears from drive)
			if (IsANBPlaying(player_Ptr,Saix_ML[27]))
		    {
				if (isInvisible(player_Ptr)&&GetFrame(player_Ptr)<110)
				{
					WriteInteger(msetAddress+Saix_ML[27]+0x28,msetAddress-0x20000000+0x293BD0);
					SetFrame(player_Ptr,110);
				}	
			}
			
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}
