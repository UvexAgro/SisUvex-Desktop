﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex
{
    public static class Crc16
    {
        #region static members
        private const ushort polynomial = 0xA001;
        private static ushort[] table = new ushort[256];
        static Crc16()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; i++)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j<8; j++)
                {
                    if (0 != ((value ^ temp) & 0x0001))
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
        #endregion
        public static ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }
    }
                   
    
}
