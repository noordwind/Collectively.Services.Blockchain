using System;
using Newtonsoft.Json;

namespace Collectively.Services.Blockchain.Services.BlockCypher
{
    public class Txref
    {
        [JsonProperty("tx_hash")]
        public string TxHash { get; set; }
        [JsonProperty("block_height")]
        public int BlockHeight { get; set; }
        [JsonProperty("tx_input_n")]
        public int TxInputN { get; set; }
        [JsonProperty("tx_output_n")]
        public int TxOutputN { get; set; }
        public int Value { get; set; }
        [JsonProperty("ref_balance")]
        public int RefBalance { get; set; }
        public bool Spent { get; set; }
        public int Confirmations { get; set; }
        public DateTime Confirmed { get; set; }
        [JsonProperty("double_spend")]
        public bool double_spend { get; set; }        
    }
}