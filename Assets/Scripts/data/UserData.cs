[System.SerializableAttribute]
public class UserData{

    public enum SCORE_ENUM{
        NON = 0,
        SMALL_STAR = 1,
        SMALL_CLOUD = 5,
        LARGE_CLOUD = 10,
        LARGE_STAR = 20
    }

    public int score;
}