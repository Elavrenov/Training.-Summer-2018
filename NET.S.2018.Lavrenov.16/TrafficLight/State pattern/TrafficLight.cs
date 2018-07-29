namespace TrafficLight
{
    /// <summary>
    /// Simulate traffic light
    /// </summary>
    public class TrafficLight
    {
        #region Const

        private const int Timeout = 20;

        #endregion

        #region Fields

        private IState _yellowState;
        private IState _greenState;

        private IState _state;

        #endregion

        #region ctor

        public TrafficLight()
        {
            IState redState = new RedState(this);
            _yellowState = new YellowState(this);
            _greenState = new GreenState(this);
            _state = redState;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Simulate timeout
        /// </summary>
        public void TimeOut()
        {
            _state.TimeisOut(Timeout);
        }

        /// <summary>
        /// Method change state
        /// </summary>
        /// <param name="state"></param>
        public void SetState(IState state)
        {
            _state = state;
        }

        #endregion

    }
}
