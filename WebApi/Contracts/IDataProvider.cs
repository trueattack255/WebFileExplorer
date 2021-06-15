using WebApi.Args;

namespace WebApi.Contracts
{
    public interface IDataProvider<out T>
    {
        T GetData(FSBaseInfoArgs args);
    }
}