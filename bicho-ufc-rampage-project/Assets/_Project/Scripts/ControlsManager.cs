using Magrathea.BichoUFCRampage.Controls;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour {

	public Vector2 velocidadePersonagem;// Força de movimento em X e Y
	public Vector2 velocidadeDash;// velocidades do dash em x e y
	public float velocidadeMaximaX;// Velocidade máxima no eixo X
	public LayerMask layerMask;// Layers em que o boneco reage
	public bool moverNoAr = false;// Se é possível mover pro lado durante o pulo
	public ControleDeScore controladorDeScore;// usado para contar pontos para quando o jogador aperta "A" ou "D" alternado
	public Text textoDash;
	public Transform groundCheck, groundCheck1;// Objeto que ajuda a checar se o boneco está no chão

	private bool podePular = false;// Controla se o bonco está no chão. se estiver pode pular
	private Rigidbody2D rb2d;
	private bool proxBotao = true;// Controla a alternância entre os botões de entrada
	private Animator anim;// Controle de animação do personagem
	private bool parar = false;
	private bool dash = false;
	private bool a = false, d = false, p = false;

    [SerializeField] private float rightSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform leftChecker;
    [SerializeField] private Transform rightChecker;
    private IMovableRight _rightMover;
    private IJumpable _jumpper;
    private IGroundable _groundChecker;

	void Awake () {
		this.rb2d = GetComponent <Rigidbody2D> ();
		this.anim = GetComponent <Animator> ();
		textoDash.enabled = false;

        _rightMover = GetComponent<RightMover>();
        _rightMover.Speed = rightSpeed;
        _jumpper = GetComponent<Jumpper>();
        _jumpper.Force = jumpForce;
        _groundChecker = GetComponent<GroundChecker>();
        _groundChecker.Layer = groundLayer;
        _groundChecker.LeftChecker = leftChecker;
        _groundChecker.RightChecker = rightChecker;
	}

	/*
	 * No Update apenas verificamos se os botões foram apertados. Como o Update tem mais frames,
	 * isso faz com que as chances de detectar se um botão foi pressionado maiores e torna o jogo 
	 * mais confortável.
	*/
	void Update () {
        // Detecta se pode pular
        this.podePular = _groundChecker.IsGrounded();

		if (Input.GetKeyDown (KeyCode.A) && this.proxBotao) {
			this.a = true;
			this.proxBotao = false;
		} else if (Input.GetKeyDown (KeyCode.D) && !this.proxBotao) {
			this.d = true;
			this.proxBotao = true;
		} 

		if (Input.GetKeyDown (KeyCode.Space) && this.podePular) {
				this.p = true;
		}
	}

	void FixedUpdate () {
		// Desnecessário depois do GroundChecker
		this.anim.SetFloat ("Correndo", Mathf.Abs (this.rb2d.velocity.x));

		if (!this.parar) {
			// Detecta se os botões estão sendo apertados
			// proxBotão obriga o jogador a apertar os botões alternadamente
			if (this.a) {
				_rightMover.GoRight();
				this.a = false;
                this.proxBotao = !this.proxBotao;
            } else if (this.d) {
                _rightMover.GoRight();
                this.d = false;
                this.proxBotao = !this.proxBotao;
            } 

			// Pulo
			if (this.p) {
				if (this.podePular) {
					_jumpper.JumpNow();
					this.p = false;
				}
			}
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
		this.anim.SetTrigger ("Bater");
		Vector3 vx = Vector3.zero;
		this.rb2d.velocity = vx;
		vx.x = -velocidadePersonagem.x;
		this.rb2d.velocity = vx;
	}
}
