﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P2P
{
    [DataContract]
    public class Block
    {
        [DataMember]
        private int index;
        [DataMember]
        private DateTime timeStamp;
        [DataMember]
        private string previousHash;
        [DataMember]
        private string hash;
        [DataMember]
        private string data;

        public Block(DateTime timeStamp, string previousHash, string data)
        {
            index = 0;
            this.timeStamp = timeStamp;
            this.previousHash = previousHash;
            this.data = data;
            hash = CalculateHash();
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(timeStamp + previousHash + data);
            byte[] outputBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);

        }

        public int GetIndex()
        {
            return index;
        }

        public void SetIndex(int index)
        {
            this.index = index;
        }

        public DateTime GetTimeStamp()
        {
            return timeStamp;
        }

        public string GetPreviousHash()
        {
            return previousHash;
        }

        public void SetPreviousHash(string previousHash)
        {
            this.previousHash = previousHash;
        }

        public string GetHash()
        {
            return hash;
        }

        public void SetHash(string hash)
        {
            this.hash = hash;
        }

        public string GetData()
        {
            return data;
        }

        public void SetData(string data)
        {
            this.data = data;
        }
    }
}
