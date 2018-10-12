namespace Chess.Interfaces
{
    using System.Threading.Tasks;
    using Chess.Lib.Monad;
    using Orleans;

    public interface IMatch : IGrainWithStringKey
    {
        Task WakeUp();

        Task JoinAsync(IPlayerCallback player);

        Task<Try<Unit>> Start();

        Task<Try<Unit>> MoveAsync(Option<string> piecePosition, Option<string> newPosition);
    }
}
