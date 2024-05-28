using UnityEngine;

public class ChanceGenerator 
{
    private static int _maxChance = 100;

    public static bool CheckChance(int chance)
    {
        int randomNumber = Random.Range(0, _maxChance);

        return randomNumber < chance;
    }
}