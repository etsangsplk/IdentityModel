using System;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Parameters;
using ScottBrady.IdentityModel.Crypto;
using ScottBrady.IdentityModel.Tokens;

namespace ScottBrady.IdentityModel.Samples.AspNetCore
{
    public class SampleOptions
    {
        private EncryptingCredentials encryptingCredentials;

        public EncryptingCredentials BrancaEncryptingCredentials
        {
            get
            {
                if (encryptingCredentials == null)
                {
                    var key = new byte[32];
                    RandomNumberGenerator.Create().GetBytes(key);

                    encryptingCredentials = new EncryptingCredentials(
                        new SymmetricSecurityKey(key),
                        ExtendedSecurityAlgorithms.XChaCha20Poly1305);
                }
                
                return encryptingCredentials;
            }
        }
        
        public RsaSecurityKey PasetoV1PrivateKey = new RsaSecurityKey(RSA.Create());
        public RsaSecurityKey PasetoV1PublicKey => new RsaSecurityKey(RSA.Create(PasetoV1PrivateKey.Rsa.ExportParameters(false)));

        public EdDsaSecurityKey PasetoV2PublicKey = new EdDsaSecurityKey(
            new Ed25519PublicKeyParameters(
                Convert.FromBase64String("doaS7QILHBdnPULlgs1fX0MWpd1wak14r1yT6ae/b4M="), 0));
        
        public EdDsaSecurityKey PasetoV2PrivateKey= new EdDsaSecurityKey(
            new Ed25519PrivateKeyParameters(
                Convert.FromBase64String("TYXei5+8Qd2ZqKIlEuJJ3S50WYuocFTrqK+3/gHVH9B2hpLtAgscF2c9QuWCzV9fQxal3XBqTXivXJPpp79vgw=="), 0));
    }
}