using Mancala.Domain.Tests.Repositories;

namespace Mancala.Domain.Tests;

public class GameTests
{
    private const string GameHasNotStartedError = "Game has not started.";
    private const string NotYourTurnError = "Not your turn!";
    private const string YouAreNotInThisGameError = "You are not in this game.";

    private static readonly GameId GameId = new("game1");
    private static readonly PlayerId PlayerId1 = new(12);
    private static readonly PlayerId PlayerId2 = new(34);
    private static readonly PlayerId OtherPlayerId = new(77);

    private Game _sut = null!;

    private static Game CreateSut()
    {
        var gameRepository = new MemoryGameRepository();

        var maybeGame = gameRepository.GetById(GameId);

        if (maybeGame.HasNoValue)
        {
            throw new Exception("Unable to create game.");
        }

        return maybeGame.Value;
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

        Assert.Equal(48, _sut.TotalStones);
        Assert.Equal(0, _sut.Player1Stones);
        Assert.Equal(0, _sut.Player2Stones);
    }

    [Fact]
    public void GetPlaysReturnsErrorIfGameHasNotStarted()
    {
        _sut = CreateSut();

        var result = _sut.GetPlays(PlayerId1);

        Assert.True(result.IsFailure);
        Assert.Equal(GameHasNotStartedError, result.Error);
    }

    [Fact]
    public void GetPlaysReturnsPitsForCurrentPlayer()
    {
        _sut = CreateSut();
        _sut.Setup();

        var result = _sut.GetPlays(PlayerId1);

        Assert.True(result.IsSuccess);
        Assert.Equal(PitId.Player1PlayPitIds, result.Value);
    }

    [Fact]
    public void GetPlaysReturnsErrorForOtherPlayer()
    {
        _sut = CreateSut();
        _sut.Setup();

        var result = _sut.GetPlays(PlayerId2);

        Assert.True(result.IsFailure);
        Assert.Equal(NotYourTurnError, result.Error);
    }

    [Fact]
    public void GetPlaysReturnsErrorForUnknownPlayer()
    {
        _sut = CreateSut();
        _sut.Setup();

        var result = _sut.GetPlays(OtherPlayerId);

        Assert.True(result.IsFailure);
        Assert.Equal(YouAreNotInThisGameError, result.Error);
    }
}