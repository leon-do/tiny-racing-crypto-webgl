using System;
using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Tiny;

namespace Unity.Tiny.GameSave
{
	static public class GameSaveNativeCalls
    {
    	private const string DLL = "lib_unity_tiny_gamesave_web";

        [DllImport(DLL, EntryPoint = "js_gamesave_init", CharSet = CharSet.Ansi)]
        public static extern unsafe void js_gamesave_init();
        
        [DllImport(DLL, EntryPoint = "js_gamesave_writeToDisk", CharSet = CharSet.Ansi)]
        public static extern unsafe bool js_gamesave_writeToDisk([MarshalAs(UnmanagedType.LPStr)] string gameSaveName, byte* buffer, int bufferLength);

        [DllImport(DLL, EntryPoint = "js_gamesave_asyncReadFromDisk", CharSet = CharSet.Ansi)]
        public static extern unsafe bool js_gamesave_asyncReadFromDisk([MarshalAs(UnmanagedType.LPStr)] string gameSaveName);

        [DllImport(DLL, EntryPoint = "js_gamesave_getLength", CharSet = CharSet.Ansi)]
        public static extern unsafe bool js_gamesave_getLength([MarshalAs(UnmanagedType.LPStr)] string gameSaveName, int* length);

        [DllImport(DLL, EntryPoint = "js_gamesave_pullCompletedReadBuffer", CharSet = CharSet.Ansi)]
        public static extern unsafe bool js_gamesave_pullCompletedReadBuffer([MarshalAs(UnmanagedType.LPStr)] string gameSaveName, byte* buffer, int bufferLength);

        public static void Init()
        {
            js_gamesave_init();
        }

        public static void Shutdown()
        {

        }

        public static unsafe bool WriteToDisk(FixedString128 gameSaveFilePath, MemoryBinaryWriter writer)
        {
            string gameSaveFilePathString = gameSaveFilePath.ToString();         
            return js_gamesave_writeToDisk(gameSaveFilePathString, (byte*)writer.Data, (int)writer.Length);
        }

        public static unsafe bool ReadFromDisk(FixedString128 gameSaveFilePath)
        {
            string gameSaveFilePathString = gameSaveFilePath.ToString();         
            return js_gamesave_asyncReadFromDisk(gameSaveFilePathString);
        }

        public static unsafe bool GetLength(FixedString128 gameSaveFilePath, int* length)
        {
            string gameSaveFilePathString = gameSaveFilePath.ToString();
            return js_gamesave_getLength(gameSaveFilePathString, length);
        }

        public static unsafe bool PullCompletedReadBuffer(FixedString128 gameSaveFilePath, byte* buffer, int bufferLength)
        {
            string gameSaveFilePathString = gameSaveFilePath.ToString();
            return js_gamesave_pullCompletedReadBuffer(gameSaveFilePathString, buffer, bufferLength);
        }
    }
}