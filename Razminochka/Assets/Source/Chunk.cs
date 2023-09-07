using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private List<Transform> _bonuses = new List<Transform>();
    [SerializeField] private List<Transform> _traps = new List<Transform>();
    public Transform _beginLvl;
    public Transform _endLvl;

    private void Start()
    {
        int picker = 0;
        for (int i = 0; i < _bonuses.Count; i++)
        {
            picker = Random.Range(0, _bonuses.Count);
            _bonuses[picker].gameObject.SetActive(true);
            picker = Random.Range(0, _traps.Count);
            _traps[picker].gameObject.SetActive(true);
        }
    }

}
