using MusicTools.Domain.Enum;

namespace MusicTools.Service.Contracts
{
    public interface IKeyService
    {
        Key GetNextKey(Key key);
        Key GetPreviousKey(Key key);
        int GetHalfStepCountBetweenTwoKey(Key k1, Key k2);
    }
}