using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // https://www.youtube.com/watch?v=Tz-2Z0vLLt8
    [SerializeField] float _walkSpeed = 20f;
    [SerializeField] int _runCoef = 2;
    [SerializeField] int _movementForce = 200;
    [SerializeField] Rigidbody _playerRB;
    [SerializeField] float _runCoeffficient;
    [SerializeField] bool _runB;

    // vector de déplacement
    private Vector2 _moveInput;


    void Start()
    {
        // playerRB = GetComponent<Rigidbody>();
        _runB = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // pour appel à interval fixe conseiller pour la phisics et RB
        NewInput_Move();
    }

    void NewInput_Move()
    {
        // https://www.youtube.com/watch?v=XZ2dk7MVtVA
        Vector3 v = new Vector3(_moveInput.x * _walkSpeed, 0, _moveInput.y * _walkSpeed);
        if (_runB) // * 2 si run
            v *= _runCoeffficient;
        print(v.ToString());
        _playerRB.AddForce(v * Time.deltaTime * _movementForce);
    }

    void OldInput_Move()
    {
        float moveSpeed = 10f;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        print(movement.ToString());
        _playerRB.velocity = movement * moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>(); // Send messages: value.Get<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            _runB = true;
        if (ctx.canceled)
            _runB = false;
    }
}