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
    public static bool[] isTap = new bool[9];
    public static int Score = 0;
}
