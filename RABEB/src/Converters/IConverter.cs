namespace RABEB
{
    internal interface IConverter<in TFrom, out TTo>
    {
        TTo Convert(TFrom obj);
    }
}
