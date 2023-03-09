using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DapperManager : MonoBehaviour
{
    /// 
    /// dapper is used to connect fmod to unity using an invoke system which triggers functions by marker names
    /// there is one already a function in the sister class, DapperReceiver, which already triggers whenever a 
    /// beat is fired. There is also one named ExampleMarker. Any class which inherits from the DapperReceiver
    /// Class will automatically be added to this one, and all marker calls will be called properly
    /// 

    [HideInInspector] internal static DapperManager instance;
    private void Awake() => instance = this;

    // our receivers
    [HideInInspector] public List<DapperReceiver> dapperReceivers = new List<DapperReceiver>();

    // our call function
    public void DapperPost(string function)
    {
        foreach(DapperReceiver receiver in dapperReceivers)
        {
            if (receiver != null)
            receiver.Invoke(function, 0);
        }
    }
}
