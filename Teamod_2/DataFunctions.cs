using System;

namespace Teamod_2
{
	public partial class MainForm
	{
		//Trim a byte array
		byte[] SubArray(byte[] data, long index, long length)
		{
			byte[] result = new byte[length];
			Array.Copy(data, index, result, 0, length);
			return result;
		}
		
		//Combine two bytes array
		byte[] Combine(byte[] a, byte[] b)
		{
			byte[] c = new byte[a.Length + b.Length];
			System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
			System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
			return c;
		}
		
		//Search a byte array in another byte array
		public int SearchBytes(byte[] input, byte[] needle)
		{
			var len = needle.Length;
			var limit = input.Length - len;
			for(var i = 0; i<=limit; i++)
			{
				var k = 0;
				for(; k<len; k++)
					if(needle[k] != input[i+k]) break;
				if(k == len) return i;
			}
			return -1;
		}
		
		//Make a som without exception
		int Som(int entree1,int entree2)
		{
			int somme = 0;
			try {somme = entree1+entree2;} catch {Console.WriteLine("Pointer destination erroned, overflow occured: "+entree1.ToString()+" ("+entree1.ToString("X")+") + "+entree2.ToString()+" ("+entree2.ToString("X"));}
			return somme;
		}
	}
}
