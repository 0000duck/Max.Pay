using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Max.Common.Utils.Encrypt
{
    public class RSAUtils
    {
        public static string RSAEncrypt(string content, string publickey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;

            string key = string.Format(@"<RSAKeyValue><Modulus>{0}</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", publickey);

            rsa.FromXmlString(key);

            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);
        }

        public static byte[] RSAEncryptByte(string content, string publickey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string key = string.Format(@"<RSAKeyValue><Modulus>{0}</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", publickey);

            rsa.FromXmlString(key);

            return rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);
        }

        public static string DecryptString(string content, string privateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            byte[] cipherbytes;

            string key = string.Format(@"<RSAKeyValue><Modulus>{0}</Modulus><Exponent>AQAB</Exponent><P>/hf2dnK7rNfl3lbqghWcpFdu778hUpIEBixCDL5WiBtpkZdpSw90aERmHJYaW2RGvGRi6zSftLh00KHsPcNUMw==</P><Q>6Cn/jOLrPapDTEp1Fkq+uz++1Do0eeX7HYqi9rY29CqShzCeI7LEYOoSwYuAJ3xA/DuCdQENPSoJ9KFbO4Wsow==</Q><DP>ga1rHIJro8e/yhxjrKYo/nqc5ICQGhrpMNlPkD9n3CjZVPOISkWF7FzUHEzDANeJfkZhcZa21z24aG3rKo5Qnw==</DP><DQ>MNGsCB8rYlMsRZ2ek2pyQwO7h/sZT8y5ilO9wu08Dwnot/7UMiOEQfDWstY3w5XQQHnvC9WFyCfP4h4QBissyw==</DQ><InverseQ>EG02S7SADhH1EVT9DD0Z62Y0uY7gIYvxX/uq+IzKSCwB8M2G7Qv9xgZQaQlLpCaeKbux3Y59hHM+KpamGL19Kg==</InverseQ><D>vmaYHEbPAgOJvaEXQl+t8DQKFT1fudEysTy31LTyXjGu6XiltXXHUuZaa2IPyHgBz0Nd7znwsW/S44iql0Fen1kzKioEL3svANui63O3o5xdDeExVM6zOf1wUUh/oldovPweChyoAdMtUzgvCbJk1sYDJf++Nr0FeNW1RB1XG30=</D></RSAKeyValue>", privateKey);

            rsa.FromXmlString(key);

            cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }
    }
}
