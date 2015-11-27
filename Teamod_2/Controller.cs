using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		bool padOk = true;
		int[] padAddresses = new int[] {0x24057F75,0x24057F74,0x24057F72,0x24057F73,
					0x24057F77,0x24057F78,0x24057F76,0x24057F79,0x24057F7B,0x24057F7D,
					0x24057F7A,0x24057F7C};
		public bool Pad(string name, bool loop)
		{
			bool padPressed = false;
			int index = 0;
			switch (name)
			{
				case "Down":
					index = 0;
				break;
				case "Up":
					index = 1;
				break;
				case "Right":
					index = 2;
				break;
				case "Left":
					index = 3;
				break;
				case "Cross":
					index = 4;
				break;
				case "Circle":
					index = 5;
				break;
				case "Triangle":
					index = 6;
				break;
				case "Square":
					index = 7;
				break;
				case "R1":
					index = 8;
				break;
				case "R2":
					index = 9;
				break;
				case "L1":
					index = 10;
				break;
				case "L2":
					index = 11;
				break;
			}
			
			if (ReadBytes(padAddresses[index],1)[0]>0)
			{
				if (loop||padOk)
				{
					padPressed = true;
					padOk=false;
				}
			}
			
			return padPressed;
		}
	}
}
