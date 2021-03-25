using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorForSprite : MonoBehaviour
{
    public List<Color> TintColors;

    // Start is called before the first frame update
    void Start()
    {
        Color color = TintColors[Random.Range(0, TintColors.Count)];

        GetComponent<SpriteRenderer>().color = color;
    }
}
