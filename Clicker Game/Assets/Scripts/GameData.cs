public static class GameData
{
    public enum TapStatus{
        start = 0,
        dragon = 1,
        selectButtonRight = 2,
        selectButtonLeft = 3,
        buyButtonUp = 4,
        buyButtonCenter = 5,
        buyButtonDown = 6,

    }
    public static bool[] isTap = new bool[7];
}
