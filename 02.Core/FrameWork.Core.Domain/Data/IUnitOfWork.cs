namespace FrameWork.Core.Domain.Data
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
