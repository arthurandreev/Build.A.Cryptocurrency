using System;
using NBitcoin;
namespace CryptoDosh
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello CryptoDosh!");

            Key privateKey = new Key(); // generate a random private key

            PubKey publicKey = privateKey.PubKey; //one way cryptographic function generates a public key

            Console.WriteLine(publicKey);

            //TestNet is a Bitcoin network for development purposes. Bitcoins on this network worth nothing.
            //70f5804823b296b439c555a127e29b90a61e07294aba7db9815c519683b22894 - TX ID

            Console.WriteLine(publicKey.GetAddress(Network.TestNet));

            var publicKeyHash = publicKey.Hash;

            Console.WriteLine(publicKeyHash);

            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);

            Console.WriteLine(testNetAddress);

        }


    }
}
