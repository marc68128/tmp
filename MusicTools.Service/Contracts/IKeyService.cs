using MusicTools.Domain.Enum;

namespace MusicTools.Service.Contracts
{
    public interface IKeyService
    {
        Key GetNextKey(Key key);
        Key GetPreviousKey(Key key);
        Key GetByIntervalNumber(Key startKey, IntervalNumber intervalNumber);
        int GetHalfStepCountBetweenTwoKey(Key k1, Key k2);
    }
}