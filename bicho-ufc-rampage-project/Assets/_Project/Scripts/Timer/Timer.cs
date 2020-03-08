namespace Magrathea.bufcr.Timer
{
    using Magrathea.bufcr.Core;
    using UnityEngine;

    /// <summary>
    /// Componente que controla o cronômetro.
    /// </summary>
    [RequireComponent(typeof(TimerDrawer))]
    public class Timer : MonoBehaviour, IStartTimer, IStopTimer, IResetTimer
    {
        //Acesso ao cronômetro para componentes externos.
        public float Clock
        {
            get => _timer;
        }

        private float _timer = 0;//Contador de tempo.
        private bool _isClockActive = false;//Flag para saber se o relógio está ativado ou não.

        private IDrawClock _timerDrawer;//Compoente que seta o relógio na UI.
        private ILevelStarter _levelStarter;//Componente que notifica quando a fase incia.
        private ILevelFinisher _levelFinisher;//Componente que notifica quando a fase acaba.

        private void Awake()
        {
            _timerDrawer = FindObjectOfType<TimerDrawer>();
        }

        private void OnEnable()
        {
            //Increve nos eventos que notificam o início e o fim da fase.
            LevelManager.OnStartLevel += StartClock;
            LevelManager.OnFinishLevel += StopClock;
        }

        private void OnDisable()
        {
            //Remove dos eventos que notificam sobre o início e fim da fase.
            LevelManager.OnStartLevel -= StartClock;
            LevelManager.OnFinishLevel -= StopClock;
        }

        private void Update()
        {
            //Conta o tempo caso o cronômetro esteja iniciado.
            if (_isClockActive)
            {
                _timer += Time.deltaTime;
                _timerDrawer.Draw(_timer);
            }
        }

        /// <summary>
        /// Inicia o cronômetro.
        /// </summary>
        public void StartClock()
        {
            _isClockActive = true;
            ResetTimer();
        }

        /// <summary>
        /// Pára o cronômetro.
        /// </summary>
        public void StopClock()
        {
            _isClockActive = false;
        }

        /// <summary>
        /// Reseta o cronômetro.
        /// </summary>
        public void ResetTimer()
        {
            _timer = 0;
        }
    }
}