using UnityEngine;

public static class PlayerSettings
{
    public static int activePlayers = 2;

    public static string[] names = { "player1", "player2", "player3", "player4" };
    public static bool[] ais = new bool[4];
    public static int[] aiLevel = new int[4];
}
