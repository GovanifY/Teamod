using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		int[] OrgRoxas_ML = new int[] {0x1020/* 00A */,0x15DF0/* 01A */,0x15DF0/* 01A */,0x21860/* 04A */,0x29AF0/* 05A */,0x1020/* DUMM */,0x342D0/* 20A */,0x41C40/* 21A */,0x4F970/* 22A */,0x5BDA0/* 23A */,0x69A60/* 24A */,0x74D10/* 25A */,0x7F800/* 30A */,0x86CD0/* 31A */,0x95CC0/* 32A */,0x9D480/* 33A */,0x7F800/* 30A */,0x95CC0/* 32A */,0x21860/* DUMM */,0x342D0/* 20A */,0x69A60/* 24A */,0xAB520/* 70A */,0x179CA0/* 11A */,0x17E620/* 12A */,0x182F70/* 13A */,0x187A70/* 14A */,0x18C3D0/* 50A */,0x1BC1E0/* 51A */,0x1D18E0/* 52A */,0x1DA6C0/* 53A */,0x1E2C90/* 54A */,0x1EE070/* 55A */,0x211E20/* 56A */,0x219920/* 57A */,0x224B40/* 59A */,0x238CE0/* 55B */,0x2469C0/* 90A */,0x2533C0/* 90B */,0x264540/* 95A */,0x276D80/* 96A */};
		int[] OrgRoxas_ML_Length = new int[] {0x14DD0/* 00A */,0xBA6C/* 01A */,0xBA6C/* 01A */,0x8290/* 04A */,0xA7D6/* 05A */,0x0/* DUMM */,0xD970/* 20A */,0xDD30/* 21A */,0xC430/* 22A */,0xDCC0/* 23A */,0xB2B0/* 24A */,0xAAF0/* 25A */,0x74D0/* 30A */,0xEFF0/* 31A */,0x77C0/* 32A */,0xE0A0/* 33A */,0x74D0/* 30A */,0x77C0/* 32A */,0x0/* DUMM */,0xD970/* 20A */,0xB2B0/* 24A */,0x15316/* 70A */,0x497C/* 11A */,0x494C/* 12A */,0x4AFC/* 13A */,0x495C/* 14A */,0x2FE10/* 50A */,0x156F8/* 51A */,0x8DD8/* 52A */,0x85D0/* 53A */,0xB3D6/* 54A */,0x23DAC/* 55A */,0x7AFA/* 56A */,0xB21C/* 57A */,0x14198/* 59A */,0xDCE0/* 55B */,0xC9F2/* 90A */,0x11178/* 90B */,0x1283C/* 95A */,0xD30C/* 96A */};
		byte[] OrgRoxasPAXAlgo = new byte[] {0x00,0x16,0x04,0x00,0x00,0x00,0x01,0x01,0x04,0x00,0x00,0x00,0x01,0x01,0x06,0x00,0x00,0x00,0x01,0x01,0x07,0x00,0x00,0x00,0x01,0x01,0x08,0x00,0x00,0x00,0x01,0x01,0x09,0x00,0x00,0x00,0x01,0x01,0x0A,0x00,0x00,0x00,0x01,0x01,0x0B,0x00,0x00,0x00,0x01,0x01,0x0C,0x00,0x06,0x00,0x01,0x01,0x04,0x00,0x06,0x00,0x01,0x01,0x06,0x00,0x06,0x00,0x01,0x01,0x07,0x00,0x06,0x00,0x01,0x01,0x08,0x00,0x06,0x00,0x01,0x01,0x09,0x00,0x06,0x00,0x01,0x01,0x0A,0x00,0x06,0x00,0x01,0x01,0x0B,0x00,0x04,0x00,0x01,0x01,0x0C,0x00,0x06,0x00,0x01,0x01,0x04,0x00,0x06,0x00,0x01,0x01,0x04,0x00,0x06,0x00,0x01,0x01,0x13,0x00,0x06,0x00,0x01,0x01,0x14,0x00,0x00,0x00,0x01,0x01,0x38,0x00,0x00,0x00,0x01,0x01,0x39,0x00,0x00};
		int[] OrgRoxas_ECL = new int[] {0x14DD0,0xBA50,0xBA50,0x8290,0xA7C0,0x14DD0,0xD960,0xDD20,0xC420,0xDCB0,0xB2A0,0xAAE0,0x74C0,0xEFE0,0x77B0,0xE090,0x74C0,0x77B0,0x8290,0xD960,0xB2A0,0x152D0,0x4970,0x4940,0x4AF0,0x4950,0x2FC50,0x15660,0x8DB0,0x8570,0xB3A0,0x23CF0,0x7AF0,0xB1C0,0x14130,0xDCC0,0xC9D0,0x11160,0x12800,0xD2A0};
		int[] OrgRoxas_ECL_Length = new int[] {0x0,0x1C,0x1C,0x0,0x16,0x0,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x0,0x10,0x10,0x46,0xC,0xC,0xC,0xC,0x1C0,0x98,0x28,0x60,0x36,0xBC,0xA,0x5C,0x68,0x20,0x22,0x18,0x3C,0x6C};
		
		void OrgRoxasFilesFix()
		{
			ResetMset(OrgRoxas_ML,OrgRoxas_ECL,OrgRoxas_ECL_Length);
			
			/* MSET Fixes */
			SetPAXAttachement(0x0D,(short)-1,0x0161);
			SetPAXAttachement(0x05,(short)-1,0x0161);
			SetPAXSize(0x05,0.5f,0.5f,0.5f);
			SetPAXAttachement(0x2C,(short)-1,0x0161);
			
			SetMSET11(0x38,OrgRoxas_ML[24],OrgRoxas_ML_Length[24]);
			for (int i=22;i<26;i++)
				SetEffectCaster(msetAddress+OrgRoxas_ML[i],new byte[] {0x01,0x04,0x0A,0x00,0x00,0x00,0xFF,0xFF,0x00,0x00,0x06,0x00,0x01,0x01,0x0D,0x00,0x06,0x00,0x01,0x01,0x05,0x00,0x06,0x00,0x01,0x01,0x2C,0x00,0x06,0x00,0x01,0x01,0x01,0x00,0x00});
			WriteFloat(msetAddress+0x283FE8,-73); //Move Roxas's drive appearance animation point to center
			WriteInteger(GetInsideECAddress(msetAddress+OrgRoxas_ML[29])+0x1C,(byte)0);
			byte[] newCrossAttackBytes = CombineEC(ReadBytes(GetInsideECAddress(msetAddress+OrgRoxas_ML[26]),0x1C0),new byte[] {0x19,0x00,0x1E,0x00,0x01,0x00,0x2E,0x00,0x32,0x00,0x01,0x00,0x4B,0x00,0x50,0x00,0x01,0x00,0x62,0x00,0x66,0x00,0x01,0x00,0x78,0x00,0x8C,0x00,0x01,0x00,0xC7,0x00,0xCB,0x00,0x01,0x00},0);
			newCrossAttackBytes[0]+=6;
			SetEffectCaster(msetAddress+OrgRoxas_ML[26],newCrossAttackBytes);
			
			/* MDLX Fixes */
			
			/* A.FM Fixes */
		}
		
		
			int RoxasGlideSens = 24;
		public void OrganisationRoxasSection()
		{
			mdlxAddress = GetMDLXAddress(player_Ptr);
			afmAddress = GetAFMAddress(player_Ptr);
			bool SpeedChange = false;
			bool invulnerable = false;
			bool isIdle = IsANBPlaying(player_Ptr,OrgRoxas_ML[0])||IsANBPlaying(player_Ptr,OrgRoxas_ML[1]);
			
			//Falling
			if (IsANBPlaying(player_Ptr,OrgRoxas_ML[3]))
				SetAnimationState(player_Ptr,0x40);
			
			//Activate Glide
			if (Pad("L2",true)&&EstAuSol(player_Ptr))
			{
				WalkStep(player_Ptr,35f);
				RunStep(player_Ptr,35f);
				SetMSET11(0x38,OrgRoxas_ML[RoxasGlideSens],OrgRoxas_ML_Length[RoxasGlideSens]);
			}
			else
			{
				WalkStep(player_Ptr,4f);
				RunStep(player_Ptr,4f);
				SetMSET11(0x38,OrgRoxas_ML[1],OrgRoxas_ML_Length[1]);
			}
			
			//Glide direction
			if (LeftJoystickX()<-.5f)
				RoxasGlideSens = 22;
			else if (LeftJoystickX()>.5f) 
				RoxasGlideSens = 23;
			else if (LeftJoystickY()<-.5f) 
				RoxasGlideSens = 24;
			else if (LeftJoystickY()>.5f) 
				RoxasGlideSens = 25;
			
			//Gliding
			if (IsANBPlaying(player_Ptr,OrgRoxas_ML[22])||
			    IsANBPlaying(player_Ptr,OrgRoxas_ML[23])||
			    IsANBPlaying(player_Ptr,OrgRoxas_ML[24])||
			    IsANBPlaying(player_Ptr,OrgRoxas_ML[25]))
			{
				ZoomIn();
				SetSpeed(player_Ptr,4f);
				SpeedChange=true;
				
				if (RoxasGlideSens==22||RoxasGlideSens==23)
				{
					CameraSpeed(500f);
					TurnStep(player_Ptr,-.05f);
				}
				else
				{
					CameraSpeed(1f);
					TurnStep(player_Ptr,0f);
					SetCamera(GetRotationPerso(player_Ptr)+(float)Math.PI);
					WriteFloat(Pointer(player_Ptr,0x2000066c),ReadFloat(Pointer(player_Ptr,0x2000055c)));
				}
			}
			else
			{
				CameraSpeed(1f);
				TurnStep(player_Ptr,0.1963495463f);
				ZoomOut();
			}
			
			//Jump
			if (IsANBPlaying(player_Ptr,OrgRoxas_ML[28]))
			{
				WalkStep(player_Ptr,30f);
				RunStep(player_Ptr,30f);
			}
			
			//Allow turning-and-falling attack 
			if (Pad("L2",true)&&GetLocation(player_Ptr,2)<DistanceSol(player_Ptr)-80)
				AnimChute(player_Ptr,204);
			
			//Durring turning-and-falling attack 
			if (IsANBPlaying(player_Ptr,OrgRoxas_ML[29]))
			{
				float frame = GetFrame(player_Ptr);
				if (frame < 20f)
					frame = -frame;
				else
				{
					frame = 16f;
					Translation(player_Ptr,1,50f);
				}
				GravityStep(player_Ptr,frame);
				SetMSET11(0x68,OrgRoxas_ML[30],OrgRoxas_ML_Length[30]);
			}
			else
				GravityStep(player_Ptr,16f);
			
			//Stop turning-and-falling attack
			if (IsANBPlaying(player_Ptr,OrgRoxas_ML[30])) {
				SetMSET11(0x68,OrgRoxas_ML[4],OrgRoxas_ML_Length[4]);
				SetMSET11(0x58,OrgRoxas_ML[3],OrgRoxas_ML_Length[3]);}
			
			
			//Interrupt current attacks to allow turning-and-falling attack
			if ((IsANBPlaying(player_Ptr,OrgRoxas_ML[10])||IsANBPlaying(player_Ptr,OrgRoxas_ML[11])|| IsANBPlaying(player_Ptr,OrgRoxas_ML[12])||IsANBPlaying(player_Ptr,OrgRoxas_ML[14])))
			{
				if (Pad("Circle",true))
				{
					AnimChute(player_Ptr,204);
					SetMSET11(0x58,OrgRoxas_ML[29],OrgRoxas_ML_Length[29]);
					SetAnimationState(player_Ptr,0x40);
					SetAnimationState(player_Ptr,0x30);
				}
			}
			
			
			if (isIdle&&Pad("Cross",true)&&EstAuSol(player_Ptr)) Set3MSET11Now(OrgRoxas_ML[26],OrgRoxas_ML_Length[26]);
			if (IsANBPlaying(player_Ptr,OrgRoxas_ML[26]))
			{
				if (Pad("L2",true)) Idle(player_Ptr);
				SeekIdle(player_Ptr);
				SetMSET11(0x18,OrgRoxas_ML[0],OrgRoxas_ML_Length[0]);
				SetMSET11(0x28,OrgRoxas_ML[1],OrgRoxas_ML_Length[1]);
				SetMSET11(0x38,OrgRoxas_ML[1],OrgRoxas_ML_Length[1]);
			}
			
			
			
			//Activate Glide
			if (isIdle&&Pad("R2",true)&&EstAuSol(player_Ptr)) Set3MSET11Now(OrgRoxas_ML[31],OrgRoxas_ML_Length[31]);
			
			IopPlayer();
			if (!SpeedChange) SetSpeed(player_Ptr,1);
			if (!invulnerable) Invulnerability(false);
		}
	}
}
