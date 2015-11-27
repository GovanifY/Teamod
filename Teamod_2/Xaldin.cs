using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] Xaldin_ML= new int[] {0x1010/* 00A */,0xC490/* 01A */,0x1B420/* 02A */,0x307A0/* 24A */,0x3C8B0/* 25A */,0x3C8B0/* 25A */,0x307A0/* 24A */,0x307A0/* 24A */,0x3C8B0/* 25A */,0x485C0/* 30A */,0x51A00/* 31A */,0x60A60/* 32A */,0x6DCD0/* 33A */,0x485C0/* 30A */,0x60A60/* 32A */,0x7E530/* 80A */,0x307A0/* 24A */,0x3C8B0/* 25A */,0x83800/* 70A */,0xC490/* 01A */,0xA0B70/* 01B */,0xAA090/* 50A */,0xC3D30/* 51A */,0xDF860/* 52A */,0xF2DA0/* 53A */,0x1070A0/* 55A */,0x11DD40/* 56A */,0x141D70/* 56B */,0x185A40/* 56C */,0x1B3910/* 51B */,0xF2DA0/* 53A */,0x1D2BC0/* 53B */,0x1D8760/* 53C */,0x1DE400/* 53D */,0x1E42F0/* 53E */,0x1EA280/* 53F */,0x1F0390/* 53G */,0x1F6630/* 53H */};
		int[] Xaldin_ML_Length = new int[] {0xB480/* 00A */,0xEF82/* 01A */,0x1537C/* 02A */,0xC110/* 24A */,0xBD10/* 25A */,0xBD10/* 25A */,0xC110/* 24A */,0xC110/* 24A */,0xBD10/* 25A */,0x9440/* 30A */,0xF054/* 31A */,0xD270/* 32A */,0x10854/* 33A */,0x9440/* 30A */,0xD270/* 32A */,0x52CC/* 80A */,0xC110/* 24A */,0xBD10/* 25A */,0x1D364/* 70A */,0xEF82/* 01A */,0x9520/* 01B */,0x19C94/* 50A */,0x1BB2C/* 51A */,0x1353C/* 52A */,0x142F8/* 53A */,0x16C96/* 55A */,0x2402C/* 56A */,0x43CC2/* 56B */,0x2DEC2/* 56C */,0x1F2A2/* 51B */,0x142F8/* 53A */,0x5B96/* 53B */,0x5CA0/* 53C */,0x5EEA/* 53D */,0x5F84/* 53E */,0x6108/* 53F */,0x6296/* 53G */,0x158BA/* 53H */};
		byte[] XaldinPAXAlgo = new byte[0];
		int[] Xaldin_ECL = new int[] {0xB480,0xEF70,0x15370,0xC0F0,0xBCF0,0xBCF0,0xC0F0,0xC0F0,0xBCF0,0x9420,0xF030,0xD250,0x10830,0x9420,0xD250,0x52C0,0xC0F0,0xBCF0,0x1D350,0xEF70,0x9520,0x19BF0,0x1BA60,0x134F0,0x14260,0x16C50,0x23ED0,0x43BC0,0x2DE30,0x1F1E0,0x14260,0x5B50,0x5C20,0x5E30,0x5E90,0x6020,0x6270,0x15800};
		int[] Xaldin_ECL_Length = new int[] {0x0,0x12,0xC,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x24,0x20,0x24,0x20,0x20,0xC,0x20,0x20,0x14,0x12,0x0,0xA4,0xCC,0x4C,0x98,0x46,0x15C,0x102,0x92,0xC2,0x98,0x46,0x80,0xBA,0xF4,0xE8,0x26,0xBA};
		
		
		void XaldinFilesFix()
		{
			UpdateFilesSeeking(true);
			ResetMset(Xaldin_ML,Xaldin_ECL,Xaldin_ECL_Length);
			/* MSET Fixes */
			SetMSET11(0x38,Xaldin_ML[1],Xaldin_ML_Length[1]);
			SetMSET11(0x48,Xaldin_ML[30],Xaldin_ML_Length[30]);
			SetMSET11(0x58,Xaldin_ML[0],Xaldin_ML_Length[0]);
			
				WriteInteger(msetAddress+Xaldin_ML[20]+0x28,msetAddress-0x20000000+Xaldin_ML[20]+0x50);
				WriteInteger(msetAddress+Xaldin_ML[20]+0x2C,16);
				WriteBytes(msetAddress+Xaldin_ML[20]+0x50,new byte[] {1,0,0,0,30,0,255,255,0,0});
				
				byte[] old_ec = ReadBytes(Pointer(msetAddress+Xaldin_ML[37]+0x28,0x20000000),ReadInt32(msetAddress+Xaldin_ML[37]+0x2C));
				byte[] new_ec = CombineEC(old_ec,new byte[] {121,0,255,255,0,0},0);
				SetEffectCaster(msetAddress+Xaldin_ML[37],new_ec);
			
				old_ec = ReadBytes(Pointer(msetAddress+Xaldin_ML[30]+0x28,0x20000000),ReadInt32(msetAddress+Xaldin_ML[30]+0x2C));
				new_ec = CombineEC(old_ec,new byte[] {100,0,255,255,1,0},0);
				SetEffectCaster(msetAddress+Xaldin_ML[30],new_ec);
				
			
			/* MDLX Fixes */
				
			/* A.FM Fixes */
		}
		
		public void XaldinSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			
			//If walking
			if (IsANBPlaying(player_Ptr,Xaldin_ML[1]))
		    {
				SetMSET11(0x18,Xaldin_ML[20],Xaldin_ML_Length[20]);
		    }
			
			//Enf of walking
			if (IsANBPlaying(player_Ptr,Xaldin_ML[20]))
		    {
				SetMSET11(0x18,Xaldin_ML[0],Xaldin_ML_Length[0]);
		    }
			
			//Jump
			if (IsANBPlaying(player_Ptr,Xaldin_ML[30]))
		    {
				SetMSET11(0x48,Xaldin_ML[37],Xaldin_ML_Length[37]);
			}
			
			//De-Jump
			if (IsANBPlaying(player_Ptr,Xaldin_ML[37]))
		    {
				SetMSET11(0x48,Xaldin_ML[30],Xaldin_ML_Length[30]);
			}
			
			JumpLength(player_Ptr,0);
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
		}
	}
}
