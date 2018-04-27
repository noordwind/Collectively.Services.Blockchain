using System.Collections.Generic;
using Newtonsoft.Json;

namespace Collectively.Services.Blockchain.Services.BlockCypher
{
    public class AddressDetails
    {
        public string Address { get; set; }
        [JsonProperty("total_received")]
        public int TotalReceived { get; set; }
        [JsonProperty("total_sent")]
        public int TotalSent { get; set; }
        public int Balance { get; set; }
        [JsonProperty("unconfirmed_balance")]
        public int UnconfirmedBalance { get; set; }
        [JsonProperty("final_balance")]
        public int FinalBalance { get; set; }
        [JsonProperty("n_tx")]
        public int NTx { get; set; }
        [JsonProperty("unconfirmed_n_tx")]
        public int UnconfirmedNTx { get; set; }
        [JsonProperty("final_n_tx")]
        public int FinalNTx { get; set; }
        [JsonProperty("tx_url")]
        public string TxUrl { get; set; }
        public IList<Txref> TxRefs { get; set; }
    }
}