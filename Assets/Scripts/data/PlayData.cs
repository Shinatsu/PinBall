[System.SerializableAttribute]
public class PlayData{
    private static readonly PlayData _instance = new PlayData ();

    public static PlayData Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayData(){
        init ();
    }

    private void init(){
        userData = new UserData();
        userData.score = 0;
    }


    //メンバ
    public UserData userData;
}