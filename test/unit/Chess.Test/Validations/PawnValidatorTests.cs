﻿namespace Chess.Test.Validations
{
    using Chess.Entities;
    using Chess.Lib.Validations;
    using Chess.Lib.Validations.PawnValidations;

    using Moq;

    using Xunit;

    public class PawnValidatorTests
    {
        private readonly Mock<FileAndRankLimitValidate> fileAndRankLimitValidateMock;

        public PawnValidatorTests()
        {
            this.fileAndRankLimitValidateMock = new Mock<FileAndRankLimitValidate>();

            var validator = new PawnValidator(this.fileAndRankLimitValidateMock.Object);
            validator.Validate(It.IsAny<Position>());
        }

        [Fact]
        public void ValidateDeveChamarFileAndRankLimitValidateSetNextValidateUmaVez() => this.fileAndRankLimitValidateMock
            .Verify(v => v.SetNextValidate(It.IsAny<Validate>()), Times.Once);

        [Fact]
        public void ValidateDeveChamarFileAndRankLimitValidateIsValidUmaVez() => this.fileAndRankLimitValidateMock
            .Verify(v => v.IsValid(It.IsAny<Position>()), Times.Once);
    }
}
