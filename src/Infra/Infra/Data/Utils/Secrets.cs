using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json;

namespace Infra.Data.Utils
{
    public class Secrets
    {
        public static T GetSecret<T>(string secretName)
        {
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.SAEast1);

            var request = new GetSecretValueRequest
            {
                SecretId = secretName
            };

            var response = client.GetSecretValueAsync(request).Result;
            if (response.SecretString == null)
                throw new System.Exception($"Secret [{secretName}] not found.");

            var secretObject = JsonConvert.DeserializeObject<T>(response.SecretString);
            return secretObject;
        }
    }
}
