using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Teamod_2
{
	public partial class MainForm
	{
		Process PCSX2;
		IntPtr PCSX2_Id;
		
		//Handle PCSX2
		[DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
		static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
		
		//Read from PCSX2
		[DllImport("kernel32.dll", SetLastError = false)]
		static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int BytesRead);
		
		//Write to PCSX2
		[DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
		static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, [Out] int lpNumberOfBytesWritten);
		
		//Search PCSX2 Process
		void SeekPCSX2(System.Windows.Forms.Label found_info)
		{
			try
			{
				Process.GetProcessById(PCSX2.Id);
				if (found_info!=null) found_info.Text = LanguageStrings[1]+" ["+PCSX2.ProcessName+"]";
			}
			catch
			{
				PCSX2_Id = (IntPtr)0;
				if (found_info!=null) found_info.Text = LanguageStrings[0];
				foreach (Process IsPCSX2 in Process.GetProcesses())
					if (IsPCSX2.ProcessName.Contains("pcsx2"))
				{
					PCSX2 = IsPCSX2;
					PCSX2_Id = OpenProcess(0x001F0FFF, true, PCSX2.Id);
					SeekPCSX2(found_info);
				}
			}
		}
		
		//Read Bytes from PCSX2 RAM
		public byte[] ReadBytes(int address, int array_length)
		{
			var buffer = new byte[array_length];
			int BytesRead = 0;
			ReadProcessMemory(PCSX2_Id, new IntPtr(address), buffer, array_length, out BytesRead);
			return buffer;
		}
		
		//Write Bytes to PCSX2 RAM
		void WriteBytes(int address, byte[] ValueToWrite)
		{
			bool abort = false;
			while (IsTitlePassed&&ReadInt32(0x21C94008) != 0x2E32484B)
				abort = true;
			if (abort)
			{
				firstMoveLoaded=0;
				return;
			}
			WriteProcessMemory(PCSX2_Id, (IntPtr)address, ValueToWrite, ValueToWrite.Length,0);
		}
		
		//Read Integer32 from PCSX2 RAM
		int ReadInt32(int address)
		{
			return BitConverter.ToInt32(ReadBytes(address,4),0);
		}
		
		//Read Integer32 from PCSX2 RAM
		ushort ReadUShort(int address)
		{
			return BitConverter.ToUInt16(ReadBytes(address,2),0);
		}
		
		//Read Integer16 from PCSX2 RAM
		short ReadInt16(int address)
		{
			return BitConverter.ToInt16(ReadBytes(address,2),0);
		}
		
		//Read Float from PCSX2 RAM
		float ReadFloat(int address)
		{
			return BitConverter.ToSingle(ReadBytes(address,4),0);
		}
		
		//Write Float to PCSX2 RAM
		void WriteFloat(int address, float valeur)
		{
			WriteBytes(address,BitConverter.GetBytes(valeur));
		}
		
		//Read String from PCSX2 RAM
		string ReadString(int address, int length)
		{
			byte[] buffer = ReadBytes(address,length);
			int auto_length = 0;
			while (IsTitlePassed&&auto_length<buffer.Length&&buffer[auto_length]!=0) {auto_length++;}
			return System.Text.Encoding.ASCII.GetString(SubArray(buffer,0,auto_length));
		}
		
		//Write Integer32 to PCSX2 RAM
		void WriteInteger(int address, int ValueToWrite)
		{
			WriteBytes(address, BitConverter.GetBytes(ValueToWrite));
		}
		
		//Write Integer16 to PCSX2 RAM
		void WriteInteger(int address, short ValueToWrite)
		{
			WriteBytes(address, BitConverter.GetBytes(ValueToWrite));
		}
		
		//Write Integer16 to PCSX2 RAM
		void WriteInteger(int address, byte ValueToWrite)
		{
			WriteBytes(address, new byte[] {ValueToWrite});
		}
		
		//Write string to PCSX2 RAM
		void WriteString(int address, string ValueToWrite)
		{
			WriteBytes(address, Encoding.ASCII.GetBytes(ValueToWrite+"\x0"));
		}
		
		//Get a pointer som
		int Pointer(int address, int offset)
		{
			return Som(ReadInt32(address),offset);
		}
	}
}
