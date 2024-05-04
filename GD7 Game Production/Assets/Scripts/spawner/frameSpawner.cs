using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    ItemFrame[] frames;
    [SerializeField]
    GameObject summon;

    bool correctTriggered = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!correctTriggered) {
            int correctAmount = 0;
            foreach (var frame in frames)
            {
                if (frame.GetCorrect())
                {
                    correctAmount++;
                }
            }
            if (correctAmount == frames.Length)
            {
                foreach (var frame in frames) {
                    frame.SetLock(true);
                }
                correctTriggered = true;
                summon.SetActive(true);
            }
        }
        
    }
}
