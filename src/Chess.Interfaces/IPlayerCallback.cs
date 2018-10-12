namespace Chess.Interfaces
{
    using System.Threading.Tasks;
    using Chess.Models;
    using Orleans;

    public interface IPlayerCallback : IGrainObserver
    {
        void GameChanged(Chessboard chessboard, IMatch board);

        void YourMove(IMatch board);
    }
}
