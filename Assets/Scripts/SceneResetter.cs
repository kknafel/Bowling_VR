using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SceneResetter : MonoBehaviour
{
    public GameObject Ball;

    public GameObject Kegels;
    public GameObject KegelsPrefab;

    private Transform _kegelsSpawnPos;
    private Vector3 _ballSpawnPos;

    public SteamVR_Input_Sources HandType;
    public SteamVR_Action_Boolean GripPressed;
    // Start is called before the first frame update
    void Start()
    {
        _kegelsSpawnPos = Kegels.transform;
        _ballSpawnPos = Ball.transform.position;
    }

    private bool CheckGripPressed()
    {
        return GripPressed.GetState(HandType);
    }

    private void Update()
    {
        if(CheckGripPressed())
        {
            Ball.transform.position = _ballSpawnPos;
            var rb = Ball.GetComponentInChildren<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Destroy(Kegels);
            Kegels = Instantiate(KegelsPrefab, _kegelsSpawnPos);
        }
    }
}
