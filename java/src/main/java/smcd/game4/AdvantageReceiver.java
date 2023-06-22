package smcd.game4;

class AdvantageReceiver implements ResultProvider {

    private final TennisGame4 game;
    private final ResultProvider nextResult;

    public AdvantageReceiver(TennisGame4 game) {
        this.game = game;
        this.nextResult = new DefaultResult(game);
    }

    @Override
    public TennisResult getResult() {
        if (game.receiverHasAdvantage())
            return new TennisResult("Advantage " + game.receiver, "");
        return this.nextResult.getResult();
    }
}
