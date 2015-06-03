﻿using Chess.Game;
using Chess.Game.Extensions;
using Chess.Game.Pieces;
using Chess.Game.Validations.PawnValidations;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Chess.Test.Validations.PawnValidations
{
    [TestFixture]
    public class HasPieceValidateTests
    {
        private HasPieceValidate _validate;
        private Mock<Chessboard> _chessboard;

        [SetUp]
        public void Setup()
        {
            _chessboard = new Mock<Chessboard>();

            var pawn = new Pawn(It.IsAny<int>(), "b7".ToPosition(), _chessboard.Object);
            _validate = new HasPieceValidate(pawn);
        }

        [TestCase("a6")]
        [TestCase("c6")]
        public void IsValid_DadoUmaPosicaoInvalida_DeveRetornarFalse(string newPosition)
        {
            var isValid = _validate.IsValid(newPosition.ToPosition());

            isValid.Should().BeFalse();
        }

        [TestCase("a6")]
        [TestCase("c6")]
        public void IsValid_DadoUmaPosicaoValida_DeveRetornarTrue(string newPosition)
        {
            _chessboard
                .Setup(c => c.GetPiece(It.IsAny<Position>()))
                .Returns(new Pawn(It.IsAny<int>(), newPosition.ToPosition(), _chessboard.Object));

            var isValid = _validate.IsValid(newPosition.ToPosition());

            isValid.Should().BeTrue();
        }
    }
}