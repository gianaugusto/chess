namespace Chess.Client
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Chess.Client.Infra.Extensions;
    using Chess.Interfaces;
    using Chess.Lib.Exceptions;
    using Chess.Lib.Extensions;
    using Chess.Models;
    using Orleans;
    using static Chess.Client.Infra.UI.Reader;
    using static Chess.Client.Infra.UI.Writer;
    using static System.Threading.Thread;

    internal class PlayerCallback : IPlayerCallback
    {
        public void GameChanged(Chessboard chessboard, IMatch board) => chessboard.Draw();

        public void YourMove(IMatch board)
        {
            ClearOption();

            var (file, rank) = RequestOption("   NEXT MOVE -> piece ");
            var piecePosition = new string(new[] { file, rank });

            var (newFile, newRank) = RequestOption(" move for ");
            var newPosition = new string(new[] { newFile, newRank });

            try
            {
                board.MoveAsync(piecePosition, newPosition);
            }
            catch (ChessException exception)
            {
                WriteError(exception.Message);
            }
            finally
            {
                ClearOption();
            }

            void ClearOption()
            {
                SetCursor(top: 22);

                for (var i = 0; i < 40; i++)
                {
                    WriteValue(' ');
                }

                SetCursor(top: 22);
            }
        }

        private static (char, char) RequestOption(string text)
        {
            text.ForEach(letter =>
            {
                Sleep(60);
                WriteValue(letter);
            });

            var files = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            var ranks = new[] { '1', '2', '3', '4', '5', '6', '7', '8' };

            var file = ReadOption(files.Contains, "Insert between a and h")();
            var rank = ReadOption(ranks.Contains, "Insert between 8 and 1")();

            return (file, rank);

            Func<char> ReadOption(Func<char, bool> condition, string invalidMessage) => () =>
            {
                bool valid;
                char option;

                do
                {
                    option = ReadChar();
                    valid = condition(option);

                    if (!valid)
                    {
                        WriteError(invalidMessage);
                    }
                }
                while (!valid);

                return option;
            };
        }
    }
}
