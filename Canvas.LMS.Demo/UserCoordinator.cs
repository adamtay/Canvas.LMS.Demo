using System;
using Canvas.v1;

namespace Canvas.LMS.Demo
{
    public class UserCoordinator
    {
        private readonly Client _canvasClient;

        public UserCoordinator(Client canvasClient)
        {
            if (canvasClient == null) throw new ArgumentNullException(nameof(canvasClient));
            _canvasClient = canvasClient;
        }

        public void CreateUser()
        {
            
        }
    }
}