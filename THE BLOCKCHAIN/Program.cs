using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nethereum.JsonRpc.Client;
using Nethereum.Web3;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace THE_BLOCKCHAIN
{

    public class Program
    {
        static string RPC_ENDPOINT = "https://u0u0b40sg7-u0eq4kiwax-rpc.us0-aws.kaleido.io";
        static string USER = "u0mceb4rgg";
        static string PASS = "YvrEw0qnJ3MsgxIrHOVJEsRmf2SKQDouzFtVnanA10k";

        static Nethereum.Hex.HexTypes.HexBigInteger latestBlockNumber;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            // Call an async function to set the latest block number and Wait on it to return
            getLatestBlockNumber().Wait();

            // Print the latest block number once the getLatestBlockNumber() function returns
            System.Diagnostics.Debug.Write("Latest Block: #" + latestBlockNumber.Value + "\n");
        }
        static async Task getLatestBlockNumber()
        {
            // Encode App Credentials as <username>:<password>
            var byteArray = Encoding.ASCII.GetBytes(USER + ":" + PASS);
            AuthenticationHeaderValue auth =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            // Create the RPC Client to talk to the Kaleido RPC endpoint using web3
            IClient client = new RpcClient(new Uri(RPC_ENDPOINT), auth, null, null, null);
            var web3 = new Web3(client);

            //Now we can test the connection by calling some basic function
            // Get the latest block number in the chain
            latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
