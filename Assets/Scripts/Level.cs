using UnityEngine;
using System.Collections;


[CreateAssetMenu(menuName = "Snake-2D/New Level")]
public class Level : ScriptableObject
{
    public int totalFoodNo;

    public int getFoodNo()
    {
        return totalFoodNo;
    }
}