using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace RABEB
{
    internal static class ConsoleHelper
    {
        private const short _defaultConsoleAttributes = (short)ConsoleColor.Gray | ((short)ConsoleColor.Black << 4);
        private const int _enableVirtualTerminalProcessing = 4;
        private const int _stdOutputHandle = -11;

        private static readonly IntPtr _hConsoleOutput;

        static ConsoleHelper() 
        {
            _hConsoleOutput = GetStdHandle(_stdOutputHandle);
        }

        public static IBuffer<char> GetConsoleBuffer()
        {
            char[,] charBuffer;
            GetConsoleBuffer(out charBuffer);
            return new Buffer<char>(charBuffer);
        }

        public static void HideCursor() 
        {
            Console.CursorVisible = false;
        }

        public static ConsoleKey? ReadKeyWhileAvailableOrGetNull()
        {
            ConsoleKey? key = null;

            while (Console.KeyAvailable)
            {
                key = Console.ReadKey(true).Key;
            }

            return key;
        }

        public static void SetConsoleBuffer(IBuffer<char> buffer) 
        {
            SetConsoleBuffer(buffer.ToArray());
        }

        private static void GetConsoleBuffer(out char[,] charBuffer)
        {
            char[] flatCharBuffer;
            int height;
            int width;

            GetConsoleBuffer(out flatCharBuffer, out height, out width);
            charBuffer = ArrayHelper.To2dArray(flatCharBuffer, height, width);
        }

        private static void GetConsoleBuffer(out char[] charBuffer, out int height, out int width)
        {
            CharInfo[] charInfoBuffer = new CharInfo[Console.BufferHeight * Console.BufferHeight];
            Coord dwBufferSize = new Coord()
            {
                X = (short)Console.BufferWidth,
                Y = (short)Console.BufferHeight
            };
            Coord dwBufferCoord = new Coord()
            {
                X = 0,
                Y = 0
            };
            SmallRect readRegion = new SmallRect()
            {
                Left = dwBufferCoord.X,
                Top = dwBufferCoord.Y,
                Right = dwBufferSize.X,
                Bottom = dwBufferSize.Y
            };

            ReadConsoleOutputW(
                _hConsoleOutput,
                out charInfoBuffer,
                dwBufferSize,
                dwBufferCoord,
                ref readRegion
            );

            charBuffer = charInfoBuffer.Select(_charInfo => _charInfo.UnicodeChar).ToArray();
            height = dwBufferSize.Y;
            width = dwBufferSize.X;
        }

        private static void SetConsoleBuffer(char[,] charBuffer) 
        {
            int height = charBuffer.GetLength(0);
            int width = charBuffer.GetLength(1);

            SetConsoleBuffer(charBuffer.Flatten<char>(), height, width);
        }

        private static void SetConsoleBuffer(char[] charBuffer, int height, int width) 
        {
            CharInfo[] charInfoBuffer = charBuffer.Select(_char => 
            {
                CharInfo _charInfo = new CharInfo()
                {
                    UnicodeChar = _char,
                    Attributes = _defaultConsoleAttributes
                };
                return _charInfo;

            }).ToArray();
            Coord dwBufferSize = new Coord()
            {
                X = (short)width,
                Y = (short)height
            };
            Coord dwBufferCoord = new Coord()
            {
                X = 0,
                Y = 0
            };
            SmallRect writeRegion = new SmallRect()
            {
                Left = dwBufferCoord.X,
                Top = dwBufferCoord.Y,
                Right = dwBufferSize.X,
                Bottom = dwBufferSize.Y
            };

            WriteConsoleOutputW(
                _hConsoleOutput, 
                charInfoBuffer, 
                dwBufferSize,
                dwBufferCoord,
                ref writeRegion
            );
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadConsoleOutputW(IntPtr hConsoleOutput,
                                                      out CharInfo[] buffer,
                                                      Coord dwBufferSize,
                                                      Coord dwBufferCoord,
                                                      ref SmallRect readRegion);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WriteConsoleOutputW(IntPtr hConsoleOutput,
                                                       CharInfo[] buffer,
                                                       Coord dwBufferSize,
                                                       Coord dwBufferCoord,
                                                       ref SmallRect writeRegion);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CharInfo
        {
            public char UnicodeChar;
            public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Coord
        {
            public short X;
            public short Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }
    }
}
