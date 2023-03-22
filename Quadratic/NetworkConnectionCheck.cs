namespace Quadratic;

using System.Net.NetworkInformation;

public class NetworkConnectionCheck
{
    public static bool IsInternetAvailable()
    {
        if (NetworkInterface.GetIsNetworkAvailable())
        {
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send("8.8.8.8", 1000); // Google DNS server
                if (reply != null && reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Exception occurred, handle appropriately
            }
        }
        return false;
    }
}