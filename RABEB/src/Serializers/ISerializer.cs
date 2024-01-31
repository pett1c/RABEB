namespace RABEB
{
    internal interface ISerializer
    {
        T Deserialize<T>(string data);
        string Serialize(object value);
    }
}
