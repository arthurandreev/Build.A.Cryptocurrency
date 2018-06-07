using System;
using NBitcoin;
namespace CryptoDosh
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello CryptoDosh!");

            Key privateKey = new Key(); // generates a random private key

            PubKey publicKey = privateKey.PubKey; //one way cryptographic function generates a public key derived from the private key

            Console.WriteLine(publicKey);

            //TestNet is a Bitcoin network for development purposes. Bitcoins on this network worth nothing.
            //70f5804823b296b439c555a127e29b90a61e07294aba7db9815c519683b22894 - TX ID


            //gets your bitcoin address from your public key and the network on which this address should be used.
            Console.WriteLine(publicKey.GetAddress(Network.TestNet));


            //a bitcoin address is made up of a version byte and your public key’s hash bytes. 
            var publicKeyHash = publicKey.Hash;

            Console.WriteLine(publicKeyHash);

            //both of these bytes are concatenated and then encoded into a Base58Check.
            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);

            Console.WriteLine(testNetAddress);

            //there is no such thing as a Bitcoin Address. 
            //internally, the Bitcoin protocol identifies the recipient of Bitcoin by a ScriptPubKey.
            //a ScriptPubKey is a short script that explains what conditions must be met to claim ownership of bitcoins.
            //we generate the ScriptPubKey from the Bitcoin Address.
            //this is a step that all bitcoin clients do to translate the “human friendly” Bitcoin Address to the Blockchain readable address.

            publicKeyHash = new KeyId("14836dbe7f38c5ac3d49e8d790af808a4ee9edcf");

            testNetAddress = publicKeyHash.GetAddress(Network.TestNet);

            Console.WriteLine(testNetAddress.ScriptPubKey);

            //ScriptPubKey appears to have nothing to do with the Bitcoin Address, but it does show the hash of the public key.
            //Bitcoin Addresses are composed of a version byte which identifies the network where to use the address and the hash of a public key.
            //We can go backwards and generate a bitcoin address from the ScriptPubKey and the network identifier.

            var paymentScript = publicKeyHash.ScriptPubKey;
            var sameTestNetAddress = paymentScript.GetDestinationAddress(Network.TestNet);
            Console.WriteLine(testNetAddress == sameTestNetAddress);

            //it is also possible to retrieve the hash from the ScriptPubKey and generate a Bitcoin Address from it:
            var samePublicKeyHash = (KeyId)paymentScript.GetDestination();
            Console.WriteLine(publicKeyHash == samePublicKeyHash); // True
            var sameTestNetAddress2 = new BitcoinPubKeyAddress(samePublicKeyHash, Network.TestNet);
            Console.WriteLine(testNetAddress == sameTestNetAddress2); // True



        }


    }
}
