﻿using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Axel_ML = new int[] {0x1010/* 00A */,0x10900/* 01A */,0x10900/* 01A */,0x18C20/* 04A */,0x21800/* 05A */,0x2AA10/* 20A */,0x34D00/* 21A */,0x407E0/* 22A */,0x4A810/* 23A */,0x54ED0/* 24A */,0x5DD90/* 25A */,0x67390/* 30A */,0x6F7A0/* 31A */,0x7D7A0/* 32A */,0x85740/* 33A */,0x67390/* 30A */,0x7D7A0/* 32A */,0x91E80/* 80A */,0x2AA10/* 20A */,0x54ED0/* 24A */,0x9F5D0/* 70A */,0xBBD70/* 10A */,0xCB330/* 11A */,0xDA420/* 12A */,0xE5B90/* 40A */,0xF0280/* 41A */,0xFA900/* 50A */,0x10B150/* 51A */,0x1159F0/* 52A */,0x11E8D0/* 53A */,0x1309F0/* 54A */,0x14C470/* 55A */,0x155510/* 56A */,0x1681A0/* 57A */,0x16F8E0/* 58A */,0x17DE60/* 59A */,0x18E8E0/* 54B */,0x19A430/* 54C */,0x1B6F30/* 90A */,0x1CFCA0/* 91A */};
		int[] Axel_ML_Length = new int[] {0xF8F0/* 00A */,0x831C/* 01A */,0x831C/* 01A */,0x8BE0/* 04A */,0x920A/* 05A */,0xA2F0/* 20A */,0xBAE0/* 21A */,0xA030/* 22A */,0xA6C0/* 23A */,0x8EC0/* 24A */,0x9600/* 25A */,0x8408/* 30A */,0xE000/* 31A */,0x7F98/* 32A */,0xC740/* 33A */,0x8408/* 30A */,0x7F98/* 32A */,0xD744/* 80A */,0xA2F0/* 20A */,0x8EC0/* 24A */,0x1C7A0/* 70A */,0xF5B4/* 10A */,0xF0E4/* 11A */,0xB768/* 12A */,0xA6EE/* 40A */,0xA674/* 41A */,0x10844/* 50A */,0xA898/* 51A */,0x8EDC/* 52A */,0x12116/* 53A */,0x1BA72/* 54A */,0x909C/* 55A */,0x12C8A/* 56A */,0x773C/* 57A */,0xE57C/* 58A */,0x10A78/* 59A */,0xBB48/* 54B */,0x1CAF8/* 54C */,0x18D64/* 90A */,0x10E4A/* 91A */};
		byte[] AxelPAXAlgo = new byte[] {0x05,0x0C,0x2C,0x00,0x4A,0x00,0xFF,0xFF,0x00,0x00,0x00,0x00,0x50,0x00,0x24,0x01,0x03,0x00,0x1B,0x00,0x28,0x00,0x0A,0x02,0xC6,0x07,0x06,0x00,0x1B,0x00,0x28,0x00,0x0A,0x02,0xC6,0x07,0x07,0x00,0x00,0x00,0x20,0x00,0x01,0x00,0x3C,0x00,0x09,0x00,0x00,0x00,0x01,0x01,0x17,0x00,0x00,0x00,0x01,0x01,0x18,0x00,0x00,0x00,0x01,0x01,0x19,0x00,0x20,0x00,0x01,0x01,0x1A,0x00,0x05,0x00,0x01,0x01,0x1B,0x00,0x00,0x00,0x01,0x01,0x1C,0x00,0x00,0x00,0x01,0x01,0x1D,0x00,0x00,0x00,0x01,0x01,0x1E,0x00,0x00,0x00,0x01,0x01,0x1F,0x00,0x00,0x00,0x17,0x01,0x00,0x00,0x05,0x00,0x18,0x00,0x08,0x00};
		int[] Axel_ECL = new int[] {0xF8F0,0x8300,0x8300,0x8BE0,0x91F0,0xA2D0,0xBAC0,0xA010,0xA6A0,0x8EA0,0x95E0,0x83E0,0xDFE0,0x7F70,0xC720,0x83E0,0x7F70,0xD730,0xA2D0,0x8EA0,0x1C760,0xF570,0xF0A0,0xB730,0xA6C0,0xA660,0x10790,0xA860,0x8ED0,0x120C0,0x1B990,0x9060,0x12C40,0x7710,0xE510,0x10A10,0xBB00,0x1CA40,0x18D30,0x10E10};
		int[] Axel_ECL_Length = new int[] {0x0,0x1C,0x1C,0x0,0x1A,0x20,0x20,0x20,0x20,0x20,0x20,0x28,0x20,0x28,0x20,0x28,0x28,0x14,0x20,0x20,0x40,0x44,0x44,0x38,0x2E,0x14,0xB4,0x38,0xC,0x56,0xE2,0x3C,0x4A,0x2C,0x6C,0x68,0x48,0xB8,0x34,0x3A};
		
		void AxelFilesFix()
		{
			UpdateFilesSeeking(true);
			ResetMset(Axel_ML,Axel_ECL,Axel_ECL_Length);
			/* MSET Fixes */
				//Appearance
				WriteBytes(msetAddress+0x18E870,AxelPAXAlgo);
				//Disappearance
				WriteBytes(msetAddress+0x16F8B0,new byte[] {0x00,0x05,0x04,0x00,0x01,0x00,0x01,0x01,0x17,0x00,0x12,0x00,0x01,0x01,0x1B,0x00,0x12,0x00,0x17,0x01,0x06,0x00,0x12,0x00,0x00,0x00,0x12,0x00,0x0D,0x02,0x11,0x00,0x00,0x00,0x11,0x00,0x08,0x04,0x06,0x01,0x34,0x00,0x00});
				//Disparition BAR Index
				SetMSET11(0x48,Axel_ML[33],Axel_ML_Length[33]);
			/* MDLX Fixes */
				
			/* A.FM Fixes */
			SetPAXFixedToLocal(0x1B);
			SetPAXSound(0x1B,0x03FF96);
		}
		
		public void AxelSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			
			//Chute
			if (IsANBPlaying(player_Ptr,Axel_ML[3]))
				SetAnimationState(player_Ptr,0x40);
		    
			//Drive Transition (When the character appears from drive) & Appareance
			if (IsANBPlaying(player_Ptr,Axel_ML[35]))
		    {
				AnimAterrissage(player_Ptr,-1);
				SetMSET11(0x48,Axel_ML[33],Axel_ML_Length[33]);
				WriteInteger(GetPAXIndexAddress(player_Ptr,0x17)+0x10,(byte)0x41);
				WriteInteger(msetAddress+Axel_ML[35]+0x28,msetAddress+0x18E870-0x20000000);
				if (GetFrame(player_Ptr)>20) WriteInteger(msetAddress+0x58,msetAddress-0x20000000+Axel_ML[3]);
				else WriteInteger(msetAddress+0x58,msetAddress-0x20000000+Axel_ML[35]);
				if (isInvisible(player_Ptr)) SetLocation(player_Ptr,2,positionSol-300);
			}
			else {if (isInvisible(player_Ptr)) SetMSET11(0x48,Axel_ML[35],Axel_ML_Length[35]);
				AnimAterrissage(player_Ptr,(int)(5*GetOpacity(player_Ptr)));}
			
			//Disappearance
			if (IsANBPlaying(player_Ptr,Axel_ML[33]))
		    {
				if (GetFrame(player_Ptr)>17) Translation(player_Ptr,1,-30f);
				if (GetFrame(player_Ptr)>22) WriteInteger(GetPAXIndexAddress(player_Ptr,0x17)+0x10,(byte)3);
			}
			else
			//Manual appearance
			if (Pad("Circle",true)&&isInvisible(player_Ptr)&&!IsANBPlaying(player_Ptr,Axel_ML[35]))
			{
				do {
					SetAnimationState(player_Ptr,0x80);
					SetMSET11(0x58,Axel_ML[35],Axel_ML_Length[35]);
					SetLocation(player_Ptr,2,positionSol-300); SetAnimationState(player_Ptr,0x30);
				} while (IsTitlePassed&&!IsANBPlaying(player_Ptr,Axel_ML[35])&&GetFrame(player_Ptr)<2);
			}
			
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}