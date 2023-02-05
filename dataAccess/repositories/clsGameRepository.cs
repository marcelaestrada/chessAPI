using chessAPI.dataAccess.common;
using chessAPI.dataAccess.interfaces;
using chessAPI.dataAccess.models;
using chessAPI.models.game;

namespace chessAPI.dataAccess.repositores;

public sealed class clsGameRepository<TI, TC> : clsDataAccess<clsPlayerEntityModel<TI, TC>, TI, TC>, IPlayerRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    public clsGameRepository(IRelationalContext<TC> rkm,
                               ISQLData queries,
                               ILogger<clsGameRepository<TI, TC>> logger) : base(rkm, queries, logger)
    {
    }

    public async Task<TI> addGame(clsNewGame game)
    {
        DateTime started = DateTime.ParseExact(game.started, "dd.M.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        var p = new DynamicParameters();
        p.Add("STARTED", started);
        p.Add("WHITES", game.whites);
        p.Add("BLACKS", game.blacks);
        p.Add("TURN", game.turn);
        p.Add("WINNER", game.winner);
        return await add<TI>(p).ConfigureAwait(false);
    }

    public async Task<TI> updateGame(clsGame<TI> game)
    {
        var p = new DynamicParameters();
        p.Add("STARTED", game.started);
        p.Add("WHITES", game.whites);
        p.Add("BLACKS", game.blacks);
        p.Add("TURN", game.turn);
        p.Add("WINNER", game.winner);
        p.Add("ID", game.id);
        return await add<TI>(p).ConfigureAwait(false);
    }

    public async Task<TI> deleteGame(clsGame<TI> game)
    {
        var p = new DynamicParameters();
        p.Add("ID", game.id);
        return await add<TI>(p).ConfigureAwait(false);
    }

    protected override DynamicParameters fieldsAsParams(clsGameEntityModel<TI, TC> entity)
    {
        DateTime started = DateTime.ParseExact(entity.started, "dd.M.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var p = new DynamicParameters();
        p.Add("ID", entity.id);
        p.Add("STARTED", started);
        p.Add("WHITES", entity.whites);
        p.Add("BLACKS", entity.blacks);
        p.Add("TURN", entity.turn);
        p.Add("WINNER", entity.winner);
        return p;
    }

    protected override DynamicParameters keyAsParams(TI key)
    {
        var p = new DynamicParameters();
        p.Add("ID", key);
        return p;
    }
}