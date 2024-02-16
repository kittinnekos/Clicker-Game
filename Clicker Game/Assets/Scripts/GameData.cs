public static class GameData
{
    public enum TapStatus{
        start = 0,
        dragon = 1,
        boss = 2,
        enemy = 3,
        selectButtonRight = 4,
        selectButtonLeft = 5,
        buyButtonUp = 6,
        buyButtonCenter = 7,
        buyButtonDown = 8,
    }

    private const int BASE_PRICE = 1;
    
    public const int COUNT_STOP_SCORE = 999999999; // スコアのカウント上限
    public const int MAX_PRICE_COUNT = 10;// 購入上限
    public const int MAX_SCORE_DIGIT = 9; // スコアの最大桁数
    public const int BASE_ADD_SCORE = 5; // 基本の一定時間に追加するスコア
    public const int MAX_SHIFT_BUY_BUTTONS = 2; // 購入ボタンを切り替える最大回数
    public const int MAX_STAGE_NUM = 4; // 最大ステージ数
    public const int MAX_SPAWN_ENEMY = 10; // 敵の出現する最大数
    public const int ENEMY_NUM = 2; // ステージごとの敵の出現する種類


    public static bool[] isTap = new bool[9];
    public static int[,] BuyStack = new int[2,3]; // 購入履歴

    public static int Score = 1000000000;
    public static int AddTapScore = 1;

    public static int currentStage = 0;
    public static int currentBuyButtons = 0; // 今の購入ボタン

    // ステージと出現する惑星、ドラゴン、ボス、敵を切り替えるフラグ
    public static bool ChangeStageFlag = false;
    public static bool ChangePlanetFlag = false, ChangeDragonFlag = false, ChangeBossFlag = false, ChangeEnemyFlag = false; 

    public static int [] price = new int [MAX_PRICE_COUNT] // 値段
    {BASE_PRICE,
     BASE_PRICE + 1,
     BASE_PRICE + 2,
     BASE_PRICE + 3,
     BASE_PRICE + 4,
     BASE_PRICE + 5,
     BASE_PRICE + 6,
     BASE_PRICE + 7,
     BASE_PRICE + 8,
     BASE_PRICE + 9,
     };

}
