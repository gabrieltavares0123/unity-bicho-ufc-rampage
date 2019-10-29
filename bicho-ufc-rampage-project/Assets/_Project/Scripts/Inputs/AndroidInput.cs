
namespace Magrathea.BichoUFCRampage.Inputs
{
    using UnityEngine;

    public class AndroidInput : MonoBehaviour, IInputable
    {
        [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
        [SerializeField] private bool detectTapOnlyAfterRelease = true;
        [SerializeField] private float swipeThreshold = 20f;
        [SerializeField] private float thresholdTimeBetweenTaps = 0.5f;

        private Vector2 fingerDown;
        private Vector2 fingerUp;
        private float _tapsTimer;
        private bool _canTap = false;

        public bool DashInput()
        {
            if (IsHorizontalSwipe() && IsSwipeRight())
            {
                ResetFingers();
                return true;
            }

            return false;
        }

        public bool JumpInput()
        {
            if (IsVerticalSwipe() && IsSwipeLeft())
            {
                ResetFingers();
                return true;
            }

            return false;
        }

        public bool MoveInput()
        {
            if (_canTap)
            {
                _canTap = false;
                return true;
            }

            return false;
        }

        private void Update()
        {
            DetectTouches();
        }


        private void DetectTouches()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUp = touch.position;
                    fingerDown = touch.position;
                    _tapsTimer = Time.time;
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    if (!detectSwipeOnlyAfterRelease)
                    {
                        fingerDown = touch.position;
                    }

                    if (!detectTapOnlyAfterRelease)
                    {
                        if (Time.time - _tapsTimer <= thresholdTimeBetweenTaps)
                        {
                            _canTap = true;
                        }
                        else
                        {
                            _canTap = false;
                        }
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;

                    if (Time.time - _tapsTimer <= thresholdTimeBetweenTaps)
                    {
                        _canTap = true;
                    }
                    else
                    {
                        _canTap = false;
                    }
                }
            }
        }

        private bool IsSwipeDown()
        {
            return fingerDown.y - fingerUp.y < 0;
        }

        private bool IsSwipeUp()
        {
            return fingerDown.y - fingerUp.y > 0;
        }

        private bool IsVerticalSwipe()
        {
            return VerticalMove() > swipeThreshold && VerticalMove() > HorizontalValMove();
        }

        private bool IsHorizontalSwipe()
        {
            return HorizontalValMove() > swipeThreshold && HorizontalValMove() > VerticalMove();
        }

        private bool IsSwipeRight()
        {
            return fingerDown.x - fingerUp.x > 0;
        }

        private bool IsSwipeLeft()
        {
            return fingerDown.x - fingerUp.x < 0;
        }

        private void ResetFingers()
        {
            fingerUp = fingerDown;
        }

        float VerticalMove()
        {
            return Mathf.Abs(fingerDown.y - fingerUp.y);
        }

        float HorizontalValMove()
        {
            return Mathf.Abs(fingerDown.x - fingerUp.x);
        }
   }
}