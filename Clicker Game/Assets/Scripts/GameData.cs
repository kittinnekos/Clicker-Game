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

    private const int BASE_PRICE = 10;
    
    public const int MAX_TAP_STASUS_NUM = 9; // タップする物の種類
    public const int COUNT_STOP_SCORE = 999999999; // スコアのカウント上限
    public const int MAX_PRICE_COUNT = 10;// 購入上限
    public const int MAX_SCORE_DIGIT = 9; // スコアの最大桁数
    public const int BASE_ADD_SCORE = 80; // 基本の一定時間に追加するスコア
    public const int MAX_SHIFT_BUY_BUTTONS = 2; // 購入ボタンを切り替える最大回数
    public const int BUY_BUTTON_NUM = 3; // 購入ボタンの種類
    public const int MAX_STAGE_NUM = 4; // 最大ステージ数
    public const int MAX_SPAWN_ENEMY = 10; // 敵の出現する最大数
    public const int ENEMY_NUM = 2; // ステージごとの敵の出現する種類
    public const int SPAWN_FRIEND_NUM = 5; // 味方の出現する種類

    public static bool[] isTap = new bool[MAX_TAP_STASUS_NUM];
    public static int[,] BuyStack = new int[MAX_SHIFT_BUY_BUTTONS,BUY_BUTTON_NUM]; // 購入履歴　要素数[2,3]

    public static int Score = 1000000;
    public static int AddTapScore = 1;

    public static int currentStage = 0;
    public static int currentBuyButtons = 0; // 今の購入ボタン

    public static bool isRestartButtonTap = false;

    // ステージと出現する惑星、ドラゴン、ボス、敵を切り替えるフラグ
    public static bool ChangeStageFlag = false;
    public static bool ChangePlanetFlag = false, ChangeDragonFlag = false, ChangeBossFlag = false, ChangeEnemyFlag = false; 

    /*サウンド関係変数*/
    public static float SEVolume = 0.5f;
    // ステージを切り替えたときの音を鳴らすフラグ
    public static bool ChangeStageSoundFlag = false;

    // 購入した時だけ音を鳴らす
    public static bool isBuySound = false;

    // 一定時間経過で音を鳴らす
    public static bool isAddScorePeriodicallySound = false;

    public static int [] price = new int [MAX_PRICE_COUNT] // 値段　要素数[10]
    {BASE_PRICE,
     BASE_PRICE * 10,
     BASE_PRICE * 12,
     BASE_PRICE * 14,
     BASE_PRICE * 20,
     BASE_PRICE * 32,
     BASE_PRICE * 64,
     BASE_PRICE * 128,
     BASE_PRICE * 256,
     BASE_PRICE * 512,
     };

}
