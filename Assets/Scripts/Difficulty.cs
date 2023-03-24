using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
   [SerializeField]private static float SecondsToMaxDificulty = 60;

   public static float GetDificultyPercent()
   {
      return Mathf.Clamp01(Time.time / SecondsToMaxDificulty);
   }
}
