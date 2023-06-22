package smcd.game4;

import smcd.TennisGame;

public class TennisGame4 implements TennisGame {

    int serverScore;
    int receiverScore;
    String server;
    String receiver;

    public TennisGame4(String player1, String player2) {
        this.server = player1;
        this.receiver = player2;
    }

    @java.lang.Override
    public void wonPoint(String playerName) {
        if (server.equals(playerName))
            this.serverScore += 1;
        else
            this.receiverScore += 1;
    }

    @java.lang.Override
    public String getScore() {
        TennisResult result = new Deuce(
                this, new GameServer(
                        this, new GameReceiver(
                                this, new AdvantageServer(
                                        this, new AdvantageReceiver(this))))).getResult();
        return result.format();
    }

    boolean receiverHasAdvantage() {
        return receiverScore >= 4 && (receiverScore - serverScore) == 1;
    }

    boolean serverHasAdvantage() {
        return serverScore >= 4 && (serverScore - receiverScore) == 1;
    }

    boolean receiverHasWon() {
        return receiverScore >= 4 && (receiverScore - serverScore) >= 2;
    }

    boolean serverHasWon() {
        return serverScore >= 4 && (serverScore - receiverScore) >= 2;
    }

    boolean isDeuce() {
        return serverScore >= 3 && receiverScore >= 3 && (serverScore == receiverScore);
    }

}

