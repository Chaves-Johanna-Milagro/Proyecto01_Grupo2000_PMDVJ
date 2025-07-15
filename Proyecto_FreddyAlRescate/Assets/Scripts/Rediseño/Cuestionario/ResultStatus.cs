using UnityEngine;

public static class ResultStatus
{
   public static int Correct;
   public static int Incorrect;

    public static int GetCorrects()
    {
        return Correct;
    }
    public static int GetIncorrects()
    {
        return Incorrect;
    }
}
