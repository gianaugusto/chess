namespace Chess.Interfaces
{
    using System.Threading.Tasks;
    using Chess.Models;
    using Orleans;

    public interface IPlayerCallback : IGrainObserver
    {
        void GameChanged(Chessboard chessboard, IBoard board);

        void YourMove(IBoard board);
    }
}
