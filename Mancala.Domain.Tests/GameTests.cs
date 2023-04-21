using Mancala.Domain.Tests.Repositories;

namespace Mancala.Domain.Tests
{
    public class GameTests
    {
        private Game? _sut;

        private static Game CreateSut()
        {
            var gameRepository = new MemoryGameRepository();
            return gameRepository.GetById("game1");
        }

        [Fact]
        public void CanCreateGame()
        {
            _sut = CreateSut();

            Assert.NotNull(_sut);
        }

        [Fact]
        public void SetupGameHasCorrectNumberOfTotalStones()
        {
            _sut = CreateSut();

            _sut.Setup();

            Assert.Equal(48, _sut.Board.TotalStones);
        }
    }
}