using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTwo.Samples.View2MultiModel;

public class ModelFactory : MonoBehaviour
{
    public EnemyModel EnemyInfo;

    public RoleModel RoleInfo;
    
    void Awake()
    {
        EnemyInfo = new EnemyModel();
        RoleInfo = new RoleModel();
    }
}
