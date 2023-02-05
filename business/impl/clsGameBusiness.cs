using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.game;

namespace chessAPI.business.impl;

public sealed class clsGameBusiness<TI, TC> : IGameBusiness<TI>
    where TI : struct, IEquatable<TI>
    where TC : struct
{
    internal readonly IGameRepository<TI, TC> gameRepository;

    public clsGameBusiness(IGameRepository<TI, TC> gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    public async Task<clsGame<TI>> addGame(clsNewGame newGame)
    {
        var x = await gameRepository.addGame(newGame).ConfigureAwait(false);
        return new clsGame<TI>(x, newGame.started, newGame.whites, newGame.blacks, newGame.turn, newGame.winner);
    }

    public Task<clsGame<TI>> deleteGame(clsGame<TI> game)
    {
        throw new NotImplementedException();
    }

    public async void getGames(TI gameId)
    {
        var x = await gameRepository.getGamesByGame(gameId).ConfigureAwait(false);
    }

    public Task<clsGame<TI>> getGames()
    {
        throw new NotImplementedException();
    }

    public async Task<clsGame<TI>> updateGame(clsNewGame newGame)
    {
        var x = await gameRepository.updateGame(game).ConfigureAwait(false);
        return new clsGame<TI>(x, game.started, game.whites, game.blacks, game.turn, game.winner);
    }
}