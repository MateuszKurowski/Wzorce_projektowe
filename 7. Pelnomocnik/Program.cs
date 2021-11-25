using System;
using System.Text;

public interface IClient
{
    string GetData();
}

public class RealClient : IClient
{
    readonly string _data;

    public RealClient()
    {
        Console.WriteLine("RealClient: Initialized");
        _data = "WSEI data";
    }

    public string GetData() => _data;
}

public class ProxyClient : IClient
{
    RealClient _client = null;
    readonly bool _authenticated = false;
    readonly string _pass = "dobrehaslo";

    public ProxyClient(string password)
    {
        if (password == _pass)
        {
            _authenticated = true;
            Console.WriteLine("ProxyClient: Initialized");
        }
        else
        {
            _authenticated = false;
            Console.WriteLine("ProxyClient: Access denied");
        }
    }

    public string GetData()
    {
        string result = string.Empty;
        if (_authenticated)
        {
            _client = new RealClient();
            result = $"Data from Proxy Client = {_client.GetData()}";
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        ProxyClient proxy1 = new ProxyClient("zlehaslo");
        Console.WriteLine(proxy1.GetData());

        ProxyClient proxy2 = new ProxyClient("dobrehaslo");
        Console.WriteLine(proxy2.GetData());
    }
}