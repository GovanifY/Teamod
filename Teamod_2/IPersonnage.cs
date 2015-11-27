using System;
using System.Drawing;

namespace Teamod_2
{
	public class IPersonnage
	{
		string name;
		string mdlx;
		string mset;
		short digit;
		Bitmap image;
		bool available;
		byte[][] barString;
		
		public IPersonnage(string nameArg, string mdlxArg, string msetArg, short digitArg, Bitmap imageArg, byte[][] barStringArg, bool availableArg)
		{
			this.name = nameArg;
			this.mdlx = mdlxArg;
			this.mset = msetArg;
			this.digit = digitArg;
			this.image = imageArg;
			this.barString = barStringArg;
			this.available = availableArg;
		}
		
		public string getName()
		{
			return this.name;
		}
		
		public string getMdlxName()
		{
			return this.mdlx;
		}
		
		public string getMsetName()
		{
			return this.mset;
		}
		
		public short getDigit()
		{
			return this.digit;
		}
		
		public Bitmap getImage()
		{
			return this.image;
		}
		
		public bool isAvailable()
		{
			return this.available;
		}
		
		public byte[] getBarString(byte index)
		{
			return barString[index];
		}
	}
}
