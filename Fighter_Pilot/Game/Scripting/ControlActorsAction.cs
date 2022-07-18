using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        int dx = 0;
        int dy = 0;
        int dx2 = 0;
        int dy2 = 0;
        private Point direction = new Point(0, -Constants.CELL_SIZE);
        private Point direction2 = new Point(0, -Constants.CELL_SIZE);
        // private Point direction2 = new Point(0, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public async void Execute(Cast cast, Script script)
        {
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Snake snake = (Snake)cast.GetFirstActor("snake");
            
            

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                
                dy = -Constants.CELL_SIZE;
                dx=0;
                if (keyboardService.IsKeyDown("a"))
                {
                    dx = -Constants.CELL_SIZE;
                }
                else if (keyboardService.IsKeyDown("d"))
                {
                    dx = Constants.CELL_SIZE;
                }
                direction = new Point(dx,dy);
                


            }
            if (keyboardService.IsKeyDown("i"))
            {
                dy2 = -Constants.CELL_SIZE;
                dx2 = 0;
                if (keyboardService.IsKeyDown("j"))
                {
                    dx2 = -Constants.CELL_SIZE;
                }
                else if (keyboardService.IsKeyDown("l"))
                {
                    dx2 = Constants.CELL_SIZE;
                }
                direction2 = new Point(dx2,dy2);
                

                

            }
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                dx = -Constants.CELL_SIZE;
                dy = 0;
                if (keyboardService.IsKeyDown("w"))
                {
                    dy = -Constants.CELL_SIZE;
                }
                else if (keyboardService.IsKeyDown("s"))
                {
                    dy = Constants.CELL_SIZE;
                }
                direction = new Point(dx,dy);
                
                //direction = new Point(-Constants.CELL_SIZE, 0);
                
            }
            if (keyboardService.IsKeyDown("j"))
            {
                dx2 = -Constants.CELL_SIZE;
                dy2 = 0;
                if (keyboardService.IsKeyDown("i"))
                {
                    dy2 = -Constants.CELL_SIZE;
                }
                else if (keyboardService.IsKeyDown("k"))
                {
                    dy2 = Constants.CELL_SIZE;
                }
                direction2 = new Point(dx2,dy2);
                
                
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                dx = Constants.CELL_SIZE;
                dy = 0;
                if (keyboardService.IsKeyDown("w"))
                {
                    dy = -Constants.CELL_SIZE;
                }
                else if (keyboardService.IsKeyDown("s"))
                {
                    dy = Constants.CELL_SIZE;
                }
                direction = new Point(dx,dy);
                
                
            }
            if (keyboardService.IsKeyDown("l"))
            {
                dx2 = Constants.CELL_SIZE;
                dy2 = 0;
                if (keyboardService.IsKeyDown("i"))
                {
                    dy2 = -Constants.CELL_SIZE;
                }
                else if (keyboardService.IsKeyDown("k"))
                {
                    dy2 = Constants.CELL_SIZE;
                }
                direction2 = new Point(dx2,dy2);
                
                
                
            }

            

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                dy = Constants.CELL_SIZE;
                dx = 0;
                if (keyboardService.IsKeyDown("a"))
                {
                    dx = -Constants.CELL_SIZE;
                }
                else if (keyboardService.IsKeyDown("d"))
                {
                    dx = Constants.CELL_SIZE;
                }
                direction = new Point(dx,dy);
                
            }
            if (keyboardService.IsKeyDown("k"))
            {
                dy2 = Constants.CELL_SIZE;
                dx2 = 0;
                if (keyboardService.IsKeyDown("j"))
                {
                    dx2 = -Constants.CELL_SIZE;
                }
                else if (keyboardService.IsKeyDown("l"))
                {
                    dx2 = Constants.CELL_SIZE;
                }
                direction2 = new Point(dx2,dy2);
                
                
            }

            // shoot
            if (keyboardService.IsKeyDown("shift"))
            {
                // direction = new Point(dx,dy);
                snake.Shoot(1, direction);
                
            }
            if (keyboardService.IsKeyDown("space"))
            {
                // direction2 = new Point(dx2,dy2);
                snake2.Shoot(1, direction2);
                
            }
            
            snake.TurnHead(direction);
            snake2.TurnHead(direction2);

            

        }
    }
}