using UnityEngine;
using System.Collections.Generic;

public class WeightedNumberGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct WeightedValue
    {
        public int value;
        public float weight;
    }

    public List<WeightedValue> weightedValues;

    public int GenerateWeightedNumber()
    {
        if (weightedValues == null || weightedValues.Count == 0)
        {
            Debug.LogError("WeightedValues list is empty or not initialized.");
            return -1;
        }

        float totalWeight = 0;

        foreach (WeightedValue weightedValue in weightedValues)
        {
            totalWeight += weightedValue.weight;
        }

        float randomValue = Random.Range(0, totalWeight);
        float weightSum = 0;

        foreach (WeightedValue weightedValue in weightedValues)
        {
            weightSum += weightedValue.weight;

            if (randomValue <= weightSum)
            {
                return weightedValue.value;
            }
        }

        // This code should never be reached, but return -1 if it is.
        Debug.LogError("Weighted number generation failed.");
        return -1;
    }
}