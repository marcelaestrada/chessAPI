using chessAPI.dataAccess.models;
using chessAPI.models.game;

namespace chessAPI.dataAccess.repositores;

public interface IGameRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addGame(clsNewGame game);
    Task<IEnumerable<clsGameEntityModel<TI, TC>>> getGamesByGame(TI gameId);
    Task<TI> updateGame(clsGame<TI> game);
    Task deleteGame(TI id);
}