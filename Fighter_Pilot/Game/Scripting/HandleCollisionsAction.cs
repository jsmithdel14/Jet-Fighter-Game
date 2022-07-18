using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;

namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private bool hit = false;
        private bool hit2 = false;
        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                // HandleHeadCollisions(cast);
                HandleBodyCollisions(cast);
                HandleGameOver(cast);
            }
        }

        private void HandleHeadCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head = snake.GetHead();
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head2 = snake2.GetHead();
            Score score = (Score)cast.GetFirstActor("score");
            Score score2 = (Score)cast.GetFirstActor("score2");
            List<Actor> bullets = snake.GetBullets();
            List<Actor> bullets2 = snake2.GetBullets();
            Food food = (Food)cast.GetFirstActor("food");
            List<Actor> temp = new List<Actor>();
            List<Actor> temp2 = new List<Actor>();
            foreach (Actor bullet in bullets){
                
                if (head.GetPosition().Equals(bullet.GetPosition()))
                {
                    
                    food.LosePoints();
                    int points = food.GetPoints();
                    score.AddPoints(points);
                    // temp.Add(bullet);
                    if (score.returnLives() == 0)
                    {
                        isGameOver = true;
                    }
                
                
                    
                }
                
                if (head2.GetPosition().Equals(bullet.GetPosition()))
                {
                    
                    food.LosePoints();
                    int points = food.GetPoints();
                    score2.AddPoints(points);
                    // temp.Add(bullet);
                    if (score2.returnLives() == 0){
                        isGameOver = true;
                    }
                    
                
                
                }
                
            }
            // int list_count = temp.Count; 
            // for (int i=1; i<=list_count; i++)
			// {
            //     bullets.Remove(bullets[i]);
				
			// }
            // if (hit == true)
            // {
            //     bullets.Remove(bullets[index]);
            // }
            foreach (Actor bullet in bullets2){
                if (head2.GetPosition().Equals(bullet.GetPosition()))
                {
                    
                    food.LosePoints();
                    int points = food.GetPoints();
                    score2.AddPoints(points);
                    // temp2.Add(bullet);
                    if (score2.returnLives() == 0){
                        isGameOver = true;
                    }
                
                
                    
                }
                
                if (head.GetPosition().Equals(bullet.GetPosition()))
                {
                    
                    food.LosePoints();
                    int points = food.GetPoints();
                    score.AddPoints(points);
                    // temp2.Add(bullet);
                    if (score.returnLives() == 0){
                        isGameOver = true;
                    }
                
                }
            }
            // int list_count2 = temp2.Count; 
            // for (int i=1; i<=list_count; i++)
			// {
            //     bullets2.Remove(bullets2[i]);
            // }
				
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleBodyCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            List<Actor> body = snake.GetBody();
            List<Actor> body2 = snake2.GetBody();
            Score score = (Score)cast.GetFirstActor("score");
            Score score2 = (Score)cast.GetFirstActor("score2");
            List<Actor> bullets = snake.GetBullets();
            List<Actor> bullets2 = snake2.GetBullets();
            Food food = (Food)cast.GetFirstActor("food");
            List<Actor> temp = new List<Actor>();
            
            foreach (Actor bullet in bullets)
            {
                    foreach(Actor part in body)
                    {
                        if (part.GetPosition().Equals(bullet.GetPosition()) || part.GetPosition().Equals(bullet.GetApprox()))
                        {
                            food.LosePoints();
                            int points = food.GetPoints();
                            score.AddPoints(points);
                            temp.Add(bullet);
                            
                            if (score.returnLives() == 0)
                            {
                                isGameOver = true;
                            }
                        }
                    }
                    
            
                
                    foreach(Actor part in body2)
                    {
                        if (part.GetPosition().Equals(bullet.GetPosition()) || part.GetPosition().Equals(bullet.GetApprox()))
                        {
                            food.LosePoints();
                            int points = food.GetPoints();
                            score2.AddPoints(points);
                            temp.Add(bullet);
                            if (score2.returnLives() == 0)
                            {
                                isGameOver = true;
                            }
                        }
                    }
            }
            bullets.RemoveAll(x => temp.Contains(x));

            foreach (Actor bullet in bullets2)
            {
                    foreach(Actor part in body)
                    {
                        if (part.GetPosition().Equals(bullet.GetPosition()) || part.GetPosition().Equals(bullet.GetApprox()))
                        {
                            food.LosePoints();
                            int points = food.GetPoints();
                            score.AddPoints(points);
                            temp.Add(bullet);
                            
                            if (score.returnLives() == 0)
                            {
                                isGameOver = true;
                            }
                        }
                    }
                    
            
                
                    foreach(Actor part in body2)
                    {
                        if (part.GetPosition().Equals(bullet.GetPosition()) || part.GetPosition().Equals(bullet.GetApprox()))
                        {
                            food.LosePoints();
                            int points = food.GetPoints();
                            score2.AddPoints(points);
                            temp.Add(bullet);
                            if (score2.returnLives() == 0)
                            {
                                isGameOver = true;
                            }
                        }
                    }
            }
            bullets2.RemoveAll(x => temp.Contains(x));
        }    
        //     foreach (Actor segment in body2)
        //     {
        //         foreach (Actor bullet in bullets)
        //         {
        //             if (segment.GetPosition().Equals(bullet.GetPosition()))
        //             {
        //                 food.LosePoints();
        //                 int points = food.GetPoints();
        //                 score2.AddPoints(points);
        //                 //snake2.RemoveBullet(bullet);
        //                 if (score2.returnLives() == 0){
        //                     isGameOver = true;
        //                 }
        //             }
        //         }
        //         foreach (Actor bullet in bullets2)
        //         {
        //             if (segment.GetPosition().Equals(bullet.GetPosition()))
        //             {
        //                 food.LosePoints();
        //                 int points = food.GetPoints();
        //                 score2.AddPoints(points);
        //                 //snake2.RemoveBullet(bullet);
        //                 if (score2.returnLives() == 0){
        //                     isGameOver = true;
        //                 }
        //             }
        //         }
        //     }
            
        // }
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments = snake.GetSegments();
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");
                List<Actor> segments2 = snake2.GetSegments();
                Food food = (Food)cast.GetFirstActor("food");
                List<Actor> bullets = snake.GetBullets();
                List<Actor> bullets2 = snake2.GetBullets();
                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                    //segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor bullet in bullets)
                {
                    bullet.SetColor(Constants.WHITE);
                }
                foreach (Actor bullet in bullets2)
                {
                    bullet.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.WHITE);
                snake.getWin(isGameOver);
                snake2.getWin(isGameOver);
            }
        }
        public bool returnTrue(){
            if (isGameOver == true){
                return true;
            }
            else{
                return false;
            }
        }
        
    }
}