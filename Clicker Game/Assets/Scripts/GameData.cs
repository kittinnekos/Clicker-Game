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
    
    public const int MAX_PRICE_COUNT = 10;
    public const int MAX_BUY_BUTTONS = 2;
    public const int BASE_ADD_SCORE = 5;

    public static bool[] isTap = new bool[9];
    public static int[,] BuyStack = new int[2,3];

    public static int Score = 100;
    public static int cullentBuyButtons = 0;

    public static int [] price = new int [MAX_PRICE_COUNT]
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
