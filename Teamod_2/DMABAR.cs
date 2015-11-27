namespace Teamod_2
{
	public class DMABARReader
	{
		public System.Byte[] DMAbuffer;
		
		public DMABARReader(System.String fileName)
		{
			DMAbuffer=new System.Byte[0];
			try
			{
				DMAbuffer = System.IO.File.ReadAllBytes(fileName);
			}
			catch {}
		}
		
		public System.Int32 getOffset(System.Int32 index)
		{
			if (DMAbuffer.Length<=0x1F+index*0x10) return -1;
			System.Int32 count = System.BitConverter.ToInt32(new System.Byte[] {DMAbuffer[8],DMAbuffer[9],DMAbuffer[10],DMAbuffer[11]},0);
			if (index>=count) return -1;
			return System.BitConverter.ToInt32(new System.Byte[] {DMAbuffer[0x1C+index*0x10],DMAbuffer[0x1D+index*0x10],DMAbuffer[0x1E+index*0x10],DMAbuffer[0x1F+index*0x10]},0);
		}
		
		public System.Byte[] getBuffer(System.Int32 index)
		{
			if (DMAbuffer.Length<=0x1B+index*0x10) return new System.Byte[0];
			System.Int32 count = System.BitConverter.ToInt32(new System.Byte[] {DMAbuffer[8],DMAbuffer[9],DMAbuffer[10],DMAbuffer[11]},0);
			if (index>=count) return new System.Byte[0];
			System.Int32 size = System.BitConverter.ToInt32(new System.Byte[] {DMAbuffer[0x18+index*0x10],DMAbuffer[0x19+index*0x10],DMAbuffer[0x1A+index*0x10],DMAbuffer[0x1B+index*0x10]},0);
			System.Int32 offset = System.BitConverter.ToInt32(new System.Byte[] {DMAbuffer[0x14+index*0x10],DMAbuffer[0x15+index*0x10],DMAbuffer[0x16+index*0x10],DMAbuffer[0x17+index*0x10]},0);
			if (offset+size>DMAbuffer.Length) return new System.Byte[0];
			System.Byte[] output = new System.Byte[size];
			System.Array.Copy(DMAbuffer, offset, output, 0, size);
			return output;
		}
		
		public System.Int32 getCount
		{
			get {
				if (DMAbuffer.Length<=16) return 0;
				System.Int32 count = System.BitConverter.ToInt32(new System.Byte[] {DMAbuffer[8],DMAbuffer[9],DMAbuffer[10],DMAbuffer[11]},0);
				return count;}
		}
	}
	
	public class DMABARMaker
	{
		public System.Collections.Generic.List<System.Int32[]> BARanges;
		public System.Collections.Generic.List<System.String> rangesNames;
		public System.Byte[] DMAbuffer;
		
		public DMABARMaker(System.String fileName)
		{
			try
			{
				DMAbuffer = System.IO.File.ReadAllBytes(fileName);
			}
			catch (System.UnauthorizedAccessException) {return;}
			finally
			{
				BARanges = new System.Collections.Generic.List<System.Int32[]>(0);
				rangesNames = new System.Collections.Generic.List<System.String>(0);
			}
		}
		
		public void addRange(System.Int32 offset, System.Int32 length,System.String name)
		{
			if (rangesNames.Contains(name)) return;
			BARanges.Add(new System.Int32[] {offset,length});
			rangesNames.Add(name.Length < 4 ? name+("    ").Substring(0,4-name.Length) : name.Substring(0,4));
		}
		
		public void removeRange(System.String name)
		{
			if (!rangesNames.Contains(name)) return;
			BARanges.RemoveAt(rangesNames.IndexOf(name));
			rangesNames.RemoveAt(rangesNames.IndexOf(name));
		}
		
		public void Save(System.String fileName)
		{
			System.Int32 bufferLength = 16*(BARanges.Count+1);
			for (System.Int32 i=0;i<BARanges.Count;i++)
				bufferLength+= BARanges[i][1];
			
			System.Byte[] outputBuffer = new System.Byte[bufferLength];
			System.Array.Copy(System.Text.Encoding.ASCII.GetBytes("BARDMA"), 0, outputBuffer, 0, 6);
			System.Array.Copy(System.BitConverter.GetBytes(BARanges.Count), 0, outputBuffer, 8, 4);
			for (System.Int32 i=0;i<BARanges.Count;i++)
			{
				System.Array.Copy(System.Text.Encoding.ASCII.GetBytes(rangesNames[i]), 0, outputBuffer, 0x10+i*0x10, 4);
				System.Int32 currOffset = i==0?0x10+BARanges.Count*0x10:
		                                               System.BitConverter.ToInt32(new System.Byte[] {
		                                                                           	outputBuffer[0x4+i*0x10],
		                                                                           	outputBuffer[0x5+i*0x10],
		                                                                           	outputBuffer[0x6+i*0x10],
		                                                                           	outputBuffer[0x7+i*0x10]},0)+
		                                               System.BitConverter.ToInt32(new System.Byte[] {
		                                                                           	outputBuffer[0x8+i*0x10],
		                                                                           	outputBuffer[0x9+i*0x10],
		                                                                           	outputBuffer[0xA+i*0x10],
		                                                                           	outputBuffer[0xB+i*0x10]},0);
				System.Array.Copy(System.BitConverter.GetBytes(currOffset),0, outputBuffer, 0x14+i*0x10, 4);
				System.Array.Copy(System.BitConverter.GetBytes(BARanges[i][1]), 0, outputBuffer, 0x18+i*0x10, 4);
				System.Array.Copy(System.BitConverter.GetBytes(BARanges[i][0]), 0, outputBuffer, 0x1C+i*0x10, 4);
				System.Byte[] curBuffer = new System.Byte[BARanges[i][1]];
				System.Array.Copy(DMAbuffer,BARanges[i][0],curBuffer,0,BARanges[i][1]);
				System.Array.Copy(curBuffer, 0, outputBuffer, currOffset, curBuffer.Length);
			}
			try
			{
				System.IO.File.WriteAllBytes(fileName,outputBuffer);
			}
			catch (System.UnauthorizedAccessException)
			{
				
			}
		}
	}
}
