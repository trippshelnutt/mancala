namespace Mancala.Domain.Tests;

public class BoardTests
{
    private Board? _sut;

    private static Board CreateSut()
    {
        return Board.CreateBoard();
    }

    [Fact]
    public void CanCreateBoard()
    {
        _sut = CreateSut();

        Assert.NotNull(_sut);
    }

    [Fact]
    public void BoardHas14Pits()
    {
        _sut = CreateSut();

        Assert.Equal(14, _sut.PitMap.Count);
    }

    [Fact]
    public void BoardHasOneStoreOnEitherEndOfTheBoard()
    {
        _sut = CreateSut();

        Assert.True(_sut.PitMap[0].IsStore);
        Assert.True(_sut.PitMap[7].IsStore);
    }

    [Fact]
    public void BoardHas6PlayPitsForPlayer1()
    {
        _sut = CreateSut();

        Assert.Equal(6, _sut.PitMap.Values.Count(p => p is { IsPlay: true, IsPlayer1: true }));
    }

    [Fact]
    public void BoardHas6PlayPitsForPlayer2()
    {
        _sut = CreateSut();

        Assert.Equal(6, _sut.PitMap.Values.Count(p => p is { IsPlay: true, IsPlayer2: true }));
    }

    [Fact]
    public void BoardHas48StonesAfterSetup()
    {
        _sut = CreateSut();

        _sut.Setup();

        Assert.Equal(48, _sut.TotalStones);
    }

    [Fact]
    public void Player1ScoreIs0AfterSetup()
    {
        _sut = CreateSut();

        _sut.Setup();

        Assert.Equal(0, _sut.GetStonesForPlayer1());
    }

    [Fact]
    public void Player2ScoreIs0AfterSetup()
    {
        _sut = CreateSut();

        _sut.Setup();

        Assert.Equal(0, _sut.GetStonesForPlayer2());
    }

    [Fact]
    public void BoardHas6ValidPlaysForPlayer1AfterSetup()
    {
        _sut = CreateSut();

        _sut.Setup();

        Assert.Equal(6, _sut.GetPlaysForPlayer1().Value.Count());
    }

    [Fact]
    public void BoardHas6ValidPlaysForPlayer2AfterSetup()
    {
        _sut = CreateSut();

        _sut.Setup();

        Assert.Equal(6, _sut.GetPlaysForPlayer2().Value.Count());
    }
}