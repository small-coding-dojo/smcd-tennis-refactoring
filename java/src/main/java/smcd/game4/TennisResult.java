package smcd.game4;

public class TennisResult {
    String serverScore;
    String receiverScore;

    public TennisResult(String serverScore, String receiverScore) {
        this.serverScore = serverScore;
        this.receiverScore = receiverScore;
    }

    public String format() {
        if ("".equals(this.receiverScore))
            return this.serverScore;
        if (serverScore.equals(receiverScore))
            return serverScore + "-All";
        return this.serverScore + "-" + this.receiverScore;
    }
}
