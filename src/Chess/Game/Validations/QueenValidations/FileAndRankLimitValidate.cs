﻿using System;
using Chess.Game.Pieces;

namespace Chess.Game.Validations.QueenValidations
{
    internal class FileAndRankLimitValidate : Validate
    {
        protected FileAndRankLimitValidate() { }

        public FileAndRankLimitValidate(Queen queen)
            : base(queen)
        { }

        protected override bool IsValidRule(Position newPosition)
        {
            var fileMoved = Math.Abs(Piece.Position.File - newPosition.File);
            var rankMoved = Math.Abs(Piece.Position.Rank - newPosition.Rank);

            if (fileMoved > 0 && rankMoved > 0)
            {
                return fileMoved.Equals(rankMoved);
            }

            return true;
        }
    }
}