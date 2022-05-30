using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    int rank;
    InputActions controls;
    float moveSpeed = 20.0f;
    public Rigidbody Rb { get; private set; }
    Vector3 force;
    Vector3 lookDir;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Rb = this.gameObject.GetComponent<Rigidbody>();
        controls = new InputActions();
        controls.Enable();
        controls.Player.Move.performed += _ => Move(_.ReadValue<Vector2>());
        controls.Player.Look.performed += _ => Look(_.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {   
        Rb.AddForce(force * moveSpeed, ForceMode.Acceleration);
    }

    public void Move(Vector2 dir)
    {
        force = new Vector3(dir.x, 0, dir.y);
    }

    public void Fire()
    {
        //Will be for ranged combat
    }

    public void Look(Vector2 facing)
    {
        cam.transform.rotation = Quaternion.Euler(facing.y * 0.5f + cam.transform.rotation.eulerAngles.x, facing.x * 0.5f + cam.transform.rotation.eulerAngles.y, 0.0f);
    }
}
