namespace Mancala.Domain.Tests;

public class GameTests
{
    private const string GameHasNotStartedError = "Game has not started.";
    private const string NotYourTurnError = "Not your turn!";
    private const string YouAreNotInThisGameError = "You are not in this game.";

    private Game? _sut;

    private static Game CreateSut()
    {
        var playerId1 = PlayerId.GetRandomPlayerId();
        var playerId2 = PlayerId.GetRandomPlayerId();

        return Game.CreateGame(playerId1, playerId2);
    }

    [Fact]
    public void CanCreateGame()
    {
        _sut = CreateSut();

        Assert.NotNull(_sut);
    }

    [Fact]
    public void GameHas48StonesAfterSetup()
    {
        _sut = CreateSut();

        _sut.Setup();

        Assert.Equal(48, _sut.TotalStones);
        Assert.Equal(0, _sut.Player1Stones);
        Assert.Equal(0, _sut.Player2Stones);
    }

    [Fact]
    public void Player1IsCurrentPlayerAfterSetup()
    {
        _sut = CreateSut();

        _sut.Setup();

        Assert.Equal(_sut.PlayerId1, _sut.CurrentPlayerId.Value);
    }

    [Fact]
    public void GetPlaysReturnsErrorIfGameHasNotStarted()
    {
        _sut = CreateSut();

        var result = _sut.GetPlays(_sut.PlayerId1);

        Assert.True(result.IsFailure);
        Assert.Equal(GameHasNotStartedError, result.Error);
    }

    [Fact]
    public void GetPlaysReturnsPitsForCurrentPlayer()
    {
        _sut = CreateSut();
        _sut.Setup();

        var result = _sut.GetPlays(_sut.PlayerId1);

        Assert.True(result.IsSuccess);
        Assert.Equal(6, result.Value.Count());
        Assert.True(result.Value.All(p => p.IsPlayer1));
    }

    [Fact]
    public void GetPlaysReturnsErrorForOtherPlayer()
    {
        _sut = CreateSut();
        _sut.Setup();

        var result = _sut.GetPlays(_sut.PlayerId2);

        Assert.True(result.IsFailure);
        Assert.Equal(NotYourTurnError, result.Error);
    }

    [Fact]
    public void GetPlaysReturnsErrorForUnknownPlayer()
    {
        var otherPlayerId = PlayerId.GetRandomPlayerId();
        _sut = CreateSut();
        _sut.Setup();

        var result = _sut.GetPlays(otherPlayerId);

        Assert.True(result.IsFailure);
        Assert.Equal(YouAreNotInThisGameError, result.Error);
    }

    [Fact]
    public void PlayMovesToPlayer2AfterPlayer1Moves()
    {
        _sut = CreateSut();
        _sut.Setup();
        var plays = _sut.GetPlays(_sut.PlayerId1);

        var result = _sut.MakePlay(_sut.PlayerId1, plays.Value.First());

        Assert.Equal(_sut.PlayerId2, result.Value);
    }

    [Fact]
    public void PlayMovesToPlayer1AfterPlayer2Moves()
    {
        _sut = CreateSut();
        _sut.Setup();
        var plays = _sut.GetPlays(_sut.PlayerId1);
        _ = _sut.MakePlay(_sut.PlayerId1, plays.Value.First());
        plays = _sut.GetPlays(_sut.PlayerId2);

        var result = _sut.MakePlay(_sut.PlayerId2, plays.Value.First());

        Assert.Equal(_sut.PlayerId1, result.Value);
    }
}