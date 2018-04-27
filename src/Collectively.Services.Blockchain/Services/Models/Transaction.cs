using System;
using System.Collections.Generic;

namespace Collectively.Services.Blockchain.Services.Models
{
    public class Transaction
    {
        public bool DoubleSpend { get; set; }
        public long BlockHeight { get; set; }
        public DateTime Time { get; set; }
        public string RelayedBy { get; set; }
        public string Hash { get; set; }
        public long Index { get; set; }
        public int Version { get; set; }
        public long Size { get; set; }
    }
}