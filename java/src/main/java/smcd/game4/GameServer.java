package smcd.game4;

class GameServer implements ResultProvider {
    private final TennisGame4 game;
    private final ResultProvider nextResult;

    public GameServer(TennisGame4 game, ResultProvider nextResult) {
        this.game = game;
        this.nextResult = nextResult;
    }

    @Override
    public TennisResult getResult() {
        if (game.serverHasWon())
            return new TennisResult("Win for " + game.server, "");
        return this.nextResult.getResult();
    }
}
