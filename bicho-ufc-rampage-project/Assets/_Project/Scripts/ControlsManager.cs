using Magrathea.BichoUFCRampage.Controls;
using Magrathea.BichoUFCRampage.Inputs;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour {

	public ControleDeScore controladorDeScore;
	public Text textoDash;

	private bool proxBotao = true;
	private bool parar = false;
	private bool dash = false;

    [SerializeField] private float rightSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform leftChecker;
    [SerializeField] private Transform rightChecker;

    private IMovableRight _rightMover;
    private IJumpable _jumpper;
    private IGroundable _groundChecker;
    private IInputManager _inputManager;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    void Awake () {
		_rigidbody = GetComponent <Rigidbody2D> ();
		_animator = GetComponent <Animator> ();
		textoDash.enabled = false;

        _rightMover = GetComponent<RightMover>();
        _jumpper = GetComponent<Jumpper>();
        _groundChecker = GetComponent<GroundChecker>();
        _inputManager = GetComponent<InputManager>();

        _rightMover.Speed = rightSpeed;
        _jumpper.Force = jumpForce;
        _groundChecker.Layer = groundLayer;
        _groundChecker.LeftChecker = leftChecker;
        _groundChecker.RightChecker = rightChecker;
    }

    void Update () {
        _animator.SetFloat("Correndo", Mathf.Abs(_rigidbody.velocity.x));

        if (_inputManager.Inputs.MoveInput() && _groundChecker.IsGrounded()) {
            _rightMover.GoRight();
		}

        if (_inputManager.Inputs.JumpInput() && _groundChecker.IsGrounded()) {
            _jumpper.JumpNow();
        }
    }
		
	void Dash () {
		this.dash = true;
		textoDash.enabled = dash;
		Debug.Log ("Dash habilitado");
	}

	void Parar () {
		this.parar = true;
		textoDash.enabled = false;
	}

	void Bater () {
		this._animator.SetTrigger ("Bater");
		Vector3 vx = Vector3.zero;
		this._rigidbody.velocity = vx;
		//vx.x = -velocidadePersonagem.x;
		this._rigidbody.velocity = vx;
	}
}
