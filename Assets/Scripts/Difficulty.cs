using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
   private static float SecondsToMaxDificulty = 60;
   private static float levelStartTime;
   public static float GetDificultyPercent()
   {
      return Mathf.Clamp01(levelStartTime / SecondsToMaxDificulty);
   }

   public static void SetLevelStartTime()
   {
      levelStartTime = Time.time;
   }
}
