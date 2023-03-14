using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // https://www.youtube.com/watch?v=Tz-2Z0vLLt8
    [SerializeField] float _walkSpeed = 8f;
    [SerializeField] float _runCoeffficient = 2f;
    [SerializeField] bool _runB = false;
    [SerializeField] Rigidbody _playerRB;

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
        // OldInput_Move();
    }

    void NewInput_Move()
    {
        // https://www.youtube.com/watch?v=XZ2dk7MVtVA
        // force, collision et velocity pas applicable si isKenetic coché
        Vector3 v = new Vector3(_moveInput.x, 0, _moveInput.y) * _walkSpeed;
        if (_runB) // * 2 si run
            // _playerRB.AddForce(v * Time.deltaTime * _movementForce);
            _playerRB.velocity = transform.TransformDirection(v) * _runCoeffficient;
        // Time.deltaTime abérant pour la velocity
        else _playerRB.velocity = v;
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