﻿using System;
using System.IO;
using System.Net;
using System.Text;

namespace common
{
    public class NReader : BinaryReader
    {
        public NReader(Stream s) : base(s, Encoding.UTF8) { }

        public string ReadNullTerminatedString()
        {
            StringBuilder ret = new StringBuilder();
            byte b = ReadByte();
            while (b != 0)
            {
                ret.Append((char)b);
                b = ReadByte();
            }
            return ret.ToString();
        }

        public string ReadUTF()
        {
            return Encoding.UTF8.GetString(ReadBytes(ReadInt16()));
        }

        public string Read32UTF()
        {
            return Encoding.UTF8.GetString(ReadBytes(ReadInt32()));
        }
    }
}