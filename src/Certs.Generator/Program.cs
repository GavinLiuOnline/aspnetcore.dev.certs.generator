using Microsoft.AspNetCore.Certificates.Generation;

namespace Certs.Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string defalutSavePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "localhost.pem");
            var certificateManager = CertificateManager.Instance;
            var nowTime = DateTimeOffset.UtcNow;
             var expirationTime = DateTimeOffset.UtcNow.AddYears(10);
            Console.WriteLine($"Input file save path:(defalut exe path,{defalutSavePath})");
            var path = Console.ReadLine();
            path = string.IsNullOrEmpty(path) ? defalutSavePath : Path.GetFullPath(path);
            Console.WriteLine($"Do you need to set a password to manage the certificate? (defalut no)[eg:yes/no]");
            var needPassword = Console.ReadLine().ToLower().Contains("yes") ? true : false;
            var password = "";
            if (needPassword)
            {
                Console.WriteLine($"Input your passwrod:");
                password = Console.ReadLine();
            }
            int count = 0;
            while (count >= 0)
            {
                string otherName = count > 0 ? "an other" : "a";
                Console.WriteLine($"Do you need to add {otherName} dns name? (defalut no)[eg:yes/no]");
                var needAddDnsName = Console.ReadLine().ToLower().Contains("yes") ? true : false;
                if (!needAddDnsName)
                    break;
                Console.WriteLine($"Please enter the dns name: [eg:localhost/bing.com]");
                var dnsName = Console.ReadLine();
                certificateManager.LocalhostHttpsDnsNames.Add(dnsName);
                count++;
            }
            Console.WriteLine($"Do you need to install the certificate right away? (defalut no)[eg:yes/no]");
            var trust = Console.ReadLine().ToLower().Contains("yes")?true:false;
            certificateManager.EnsureAspNetCoreHttpsDevelopmentCertificate(nowTime, expirationTime, path, trust, needPassword, password, CertificateKeyExportFormat.Pem);
            Console.WriteLine($"Done, enter any key to exit.");
            Console.ReadLine();
        }
    }
}
