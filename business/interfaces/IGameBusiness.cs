using chessAPI.models.game;

namespace chessAPI.business.interfaces;

public interface IGameBusiness<TI>
    where TI : struct, IEquatable<TI>
{
    Task<clsGame<TI>> addGame(clsNewGame newGame);
    Task<clsGame<TI>> updateGame(clsNewGame newGame);
    Task<clsGame<TI>> getGames();
    Task<clsGame<TI>> deleteGame(clsGame<TI> game);

}