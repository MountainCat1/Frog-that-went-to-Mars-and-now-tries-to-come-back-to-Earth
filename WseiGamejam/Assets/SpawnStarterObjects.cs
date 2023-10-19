using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStarterObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject ScopePrefab;

    void Start()
    {
        var Scope = Instantiate(ScopePrefab, Vector3.zero, Quaternion.identity);
        Scope.GetComponent<Scope>().Init(GetComponent<PlayerInputMediator>());
    }

}
