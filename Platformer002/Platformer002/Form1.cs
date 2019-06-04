using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//-version 0.7
namespace Platformer002
{
    public partial class Form1 : Form
    {
        string gameName = "Beware of the Red Rectangles";
        int frames_done = 0;
        bool game_is_over = false;
        int score = 0;
        int gravity = 20;
        long timeStart = DateTime.Now.Ticks;
        long deltaTime = 0;
        long timeLastFrame = 0;
        float deltaTimeRatio = 0;

        int jumpSpeed = 80;
        int jumpOffset = 5;

        int gravityMultiplier = 1;

        float playerXVelocity = 0.0f;
        float playerInitXVelocity = 40.0f;
        float playerMaxXVelocity = 40.0f;

        float playerYVelocity = 0.0f;
        float playerInitYVelocity = 200.0f;
        float playerMaxYVelocity = 200.0f;

        float playerXCoefFriction = .6f;
        float playerXAcceleration = 40f;

        int levelsToWin = 20;
        
        Rectangle playerBoundingBox = new Rectangle();
        List<PictureBox> groundBoxes = new List<PictureBox>();

        int level = 0;

        //coins variables
        List<Coin> cList = new List<Coin>();
        Queue<Coin> CoinsAway = new Queue<Coin>();
        int collectCoinsToWin = 0;
        int coinsCollected = 0;
        int coinHeight = 30;

        // generated platforms variables
        List<Platform> platformsList = new List<Platform>();
        Queue<Platform> PlatformsAway = new Queue<Platform>();

        //monster variables
        List<Monster> MovingMonstersList = new List<Monster>();
        Queue<Monster> MonstersAway = new Queue<Monster>();
        int addMonsterEveryLevels = 4;

        public Form1()
        {
            InitializeComponent();
            InitializeGroundList();

            playerBoundingBox.X = pbPlayer.Left;
            playerBoundingBox.Y = pbPlayer.Top;
            playerBoundingBox.Width = pbPlayer.Bounds.Width;
            playerBoundingBox.Height = pbPlayer.Bounds.Height;
        }

        private void InitializeGroundList()
        {
            groundBoxes.Add(ceiling);
            groundBoxes.Add(floor);
            groundBoxes.Add(leftwall0);
            groundBoxes.Add(leftwall1);
            groundBoxes.Add(leftwall2);
            groundBoxes.Add(rightwall0);
            groundBoxes.Add(rightwall1);
            groundBoxes.Add(rightwall2);
        }

        private void applyGravity()
        {
            playerYVelocity = Clamp( - playerMaxYVelocity, playerMaxYVelocity, (playerYVelocity  + (gravity * gravityMultiplier * deltaTimeRatio)));
        }

        private bool collistionWithGroundDetectionAndCorrection()
        {
            bool collistionDetected = false;
            List<Rectangle> intersectionBoxes = new List<Rectangle>();
            foreach (PictureBox groundBpx in groundBoxes)
            {
                if (playerBoundingBox.IntersectsWith(groundBpx.Bounds))
                {
                    Rectangle intersectionBox = Rectangle.Intersect(playerBoundingBox, groundBpx.Bounds);
                    if (!intersectionBox.IsEmpty)
                    {
                        collistionDetected = true;
                        intersectionBoxes.Add(intersectionBox);
                    }
                }
            }
            if (collistionDetected)
            {

                int moveUP = 0;
                int moveDOWN = 0;
                int moveLEFT = 0;
                int moveRIGHT = 0;
                foreach (Rectangle intersectionBox in intersectionBoxes)
                {
                    if (intersectionBox.Width > intersectionBox.Height)
                    {
                        // horizontal
                        playerYVelocity = 0;
                        if (intersectionBox.Y < (playerBoundingBox.Y + playerBoundingBox.Height/2))
                        {
                            // bottom
                            moveUP = Math.Max(moveUP, intersectionBox.Height);
                        } else {
                            // up
                            moveDOWN = Math.Max(moveDOWN, intersectionBox.Height);
                        }

                    } else {
                        // vertical
                        playerXVelocity = 0;
                        if (intersectionBox.X < (playerBoundingBox.X + playerBoundingBox.Width/2))
                        {
                            // Left
                            moveLEFT = Math.Max(moveLEFT, intersectionBox.Width);
                        } else {
                            // Right
                            moveRIGHT = Math.Max(moveRIGHT, intersectionBox.Width);
                        }

                    }
                }
                playerBoundingBox.X +=moveLEFT;
                playerBoundingBox.X -=moveRIGHT;

                playerBoundingBox.Y +=moveUP;
                playerBoundingBox.Y -=moveDOWN;
            }
            return true;
        }

        private void jump()
        {
            if (checkForGroundOrCeiling()) 
            {
                playerBoundingBox.Y -= jumpOffset*gravityMultiplier;
                playerYVelocity-=jumpSpeed*gravityMultiplier;
            }
        }

        private bool checkForGroundOrCeiling()
        {
            Rectangle boxUnderFeet = new Rectangle();
            boxUnderFeet.X = pbPlayer.Bounds.X;
            boxUnderFeet.Width = pbPlayer.Bounds.Width;
            boxUnderFeet.Height = 2;
            if (gravityMultiplier>0)
            {
                boxUnderFeet.Y = pbPlayer.Bounds.Y + pbPlayer.Bounds.Height;
            } else {
                boxUnderFeet.Y = pbPlayer.Bounds.Y -boxUnderFeet.Height;
            }

            foreach (PictureBox groundBpx in groundBoxes)
            {
                if (boxUnderFeet.IntersectsWith(groundBpx.Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        private void tmrRight_Tick(object sender, EventArgs e)
        {
            playerXVelocity = Clamp( - playerMaxXVelocity, playerMaxXVelocity, (playerXVelocity + (playerXAcceleration * deltaTimeRatio)));
        }

        private void tmrLeft_Tick(object sender, EventArgs e)
        {
            playerXVelocity = Clamp(- playerMaxXVelocity, playerMaxXVelocity, (playerXVelocity - (playerXAcceleration * deltaTimeRatio)));
        }

        private void applyFrictionToXSpeed()
        {
            playerXVelocity = Clamp( - playerMaxXVelocity, playerMaxXVelocity, ((playerXVelocity *(1- playerXCoefFriction*deltaTimeRatio))));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W || e.KeyCode == Keys.Space)
            {
                jump();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                tmrRight.Start();
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                tmrLeft.Start();
            }
            else if (e.KeyCode == Keys.Q)
            {
                gravityMultiplier = - gravityMultiplier ;
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                playerMaxXVelocity*=2;
            }
            else if (e.KeyCode == Keys.R && game_is_over)
            {
                RestartGame();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                tmrRight.Stop();
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                tmrLeft.Stop();
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                playerMaxXVelocity= playerInitXVelocity;
            }
        }

        private void generatePlatforms(int numPlatforms)
        {
            var rand = new System.Random();
            Platform platform;

            for (int i = 0; i < numPlatforms; ++i)
            {
                if (PlatformsAway.Count == 0)
                {
                    platform = new Platform();
                    platform.drawTo(this);
                    groundBoxes.Add(platform.getPictureBox());
                    platformsList.Add(platform);
                }
                else {
                    platform = PlatformsAway.Dequeue();
                    platformsList.Add(platform);
                }
                var Xlevel = rand.Next(0,5);
                var Ylevel = rand.Next(0,3);
                platform.setPos(Xlevel *110 + 105 , Ylevel * 120 + 100);
            }
        }

        private void generateCoinsForPlatforms()
        {
            Coin coin;
            var rand = new System.Random();
            //Console.WriteLine("Coins NEEDED " + collectCoinsToWin);
            //Console.WriteLine("Coins COLLECTED " + coinsCollected);

            foreach (Platform platform in platformsList)
            {
                var Ylevel = rand.Next(0,2);

                if (Ylevel == 0){
                    Ylevel = platform.getBounds().Y - coinHeight;
                } else {
                    Ylevel = platform.getBounds().Y + coinHeight + platform.getBounds().Height;
                }
                
                for (int i = 0; i < 3; ++i)
                {
                    if (CoinsAway.Count == 0)
                    {
                        // Console.WriteLine("GENERATING NEW COIN");
                        coin = new Coin();
                        coin.drawTo(this);
                        cList.Add(coin);
                    }
                    else {
                        coin = CoinsAway.Dequeue();
                        // Console.WriteLine("coins in pool left "+ CoinsAway.Count);
                    }

                    coin.setPos(platform.getBounds().X + 25 + 35*i, Ylevel);
                    collectCoinsToWin+=1;
                    //Console.WriteLine(collectCoinsToWin);
                }
            }
            //Console.WriteLine("Coins NEEDED " + collectCoinsToWin);
            //Console.WriteLine("Coins COLLECTED " + coinsCollected);
        }

        private void generateMonster(int numMonsters)
        {
            var rand = new System.Random();
            Monster monster;
            Console.WriteLine("GENERATING MOSTERS: " + numMonsters);

            for (int i = 0; i < numMonsters; ++i)
            {
                if (MonstersAway.Count == 0)
                {
                    monster = new Monster();
                    monster.drawTo(this);
                    MovingMonstersList.Add(monster);
                }
                else {
                    monster = MonstersAway.Dequeue();
                }
                // var Xlevel = rand.Next(0,5);
                int speedVector = (int)((float)(rand.Next(1,3)/2 - 0.5)*2);
                int speed = rand.Next(10,20) * speedVector;
                var Ylevel = rand.Next(0,3);
                monster.Speed = speed;
                // Console.WriteLine(speedVector);
                int first_limit = rand.Next(1,8);
                int second_limit = rand.Next(1,8);
                if (first_limit == second_limit ) {
                    if (first_limit == 7){
                        first_limit-=1;
                    } else {
                        first_limit+=1;
                    }
                }
                monster.LeftLimit = Math.Min(first_limit, second_limit) * 100;
                monster.RightLimit = Math.Max(first_limit, second_limit) * 100;
                monster.setPos(400 , Ylevel * 120 + 80);
            }  
        }

        private void removeCoinsFromLevel()
        {
            Rectangle ScreenRectangle = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            foreach (Coin c in cList)
            {
                if (ScreenRectangle.IntersectsWith(c.getBounds()))
                {
                    c.setPos(1001, 1001);
                    CoinsAway.Enqueue(c);
                }
            }
        }

        private void RestartGame()
        {
            EndLevel();
            level = 1;
            CreateNewLevel();
            game_is_over = false;
            lblLost.Visible = false;
            score = 0;
        }

        private void CreateNewLevel()
        {
            generatePlatforms(level+1);
            generateCoinsForPlatforms();
            generateMonster(level  / addMonsterEveryLevels);
        }

        private void CreateZeroLevel()
        {
            if (level == 0)
            {
                lblTurorial.Text = "Welcome to " + gameName + "\r\n\r\n" +
                    "Move with WASD or Arrows\r\n" +
                    "Jump with [Space]\r\n" +
                    "[Q] - reverse the gravity\r\n" +
                    "[Shift] to speed up\r\n" +
                    "Collect coins to go next level\r\n" +
                    levelsToWin + " levels to win";
                lblTurorial.Location = new Point(46, 34);
            }

            Platform platform;
            platform = new Platform();
            platform.drawTo(this);
            groundBoxes.Add(platform.getPictureBox());
            platformsList.Add(platform);
            platform.setPos(545 , 100);

            generateCoinsForPlatforms();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (level == 0){
                CreateZeroLevel();
            }
            else {
                CreateNewLevel();
            }
        }

        private void cleanupLevel()
        {
            List<Platform> platformsListTemp = new List<Platform>();

            foreach (Platform platform in platformsList)
            {
                platform.setPos(1000,1000);
                PlatformsAway.Enqueue(platform);
                platformsListTemp.Add(platform);
            }
            foreach (Platform platform in platformsListTemp)
            {
                platformsList.Remove(platform);
                // Console.WriteLine("REMOVE PLATFORM FROM LIST");
            }

            removeCoinsFromLevel();
            foreach (Monster monster in MovingMonstersList)
            {
                monster.setPos(1000,1000);
                MonstersAway.Enqueue(monster);
            }

            rightwall0.Top=0;
        }

        private float Clamp(float min, float max, float val)
        {
            if(val < min)
            {
                return min;
            }
            if(val > max)
            {
                return max;
            }
            return val;
        }

        private void CheckForCoins()
        {
            foreach (Coin c in cList)
            {
                if (pbPlayer.Bounds.IntersectsWith(c.getBounds()))
                {
                    // Console.WriteLine("coins collected: " +coinsCollected + ", NEED: " + collectCoinsToWin);
                    c.setPos(1001, 1001);
                    CoinsAway.Enqueue(c);
                    score += 10;
                    coinsCollected+=1;
                    lblScore.Text = "Level: " + level + "  Score: " + score;
                    if (coinsCollected >= collectCoinsToWin)
                    {
                        // Console.WriteLine("FOOR");
                        rightwall0.Top=1000;
                    }
                }
            }
        }

        private void CheckForDoor()
        {
            if (pbPlayer.Bounds.IntersectsWith(nextLevelDoor.Bounds))
            {
                if (level <= levelsToWin)
                {
                    EndLevel();
                    CreateNewLevel();
                }
                else {
                    GameOver(true);
                }
            }
        }

        private void CheckForMonsters()
        {
            foreach (Monster monster in MovingMonstersList)
            {
                if (pbPlayer.Bounds.IntersectsWith(monster.getBounds()))
                {
                    GameOver(false);
                }
            }
        }

        private void GameOver(bool winner)
        {
            if (winner)
            {
                lblWon.Visible = true;
            }
            else {
                lblLost.Visible = true;
            }

            tmrRight.Stop();
            tmrLeft.Stop();
            game_is_over = true;
        }

        private void moveStuffToNewLevel()
        {
            pbPlayer.Top = 264;
            pbPlayer.Left = 31;

            playerBoundingBox.X = pbPlayer.Left;
            playerBoundingBox.Y = pbPlayer.Top;

            playerXVelocity = 0;
            playerYVelocity = 0;

        }

        private void EndLevel()
        {
                cleanupLevel();

                if (level == 0){
                    lblTurorial.Visible = false;
                }
                moveStuffToNewLevel();

                collectCoinsToWin = 0;
                coinsCollected = 0;
                level++;
                lblScore.Text = "Level: " + level + "  Score: " + score;
        }

        private void move_character()
        {
            playerBoundingBox.X +=(int)(playerXVelocity* deltaTimeRatio);
            playerBoundingBox.Y +=(int)(playerYVelocity* deltaTimeRatio);
        }

        private void move_mosters()
        {
            foreach (Monster monster in MovingMonstersList)
            {
                // Console.WriteLine(monster.Speed);
                if (monster.getBounds().X > monster.RightLimit)
                {
                    monster.Speed = - Math.Abs(monster.Speed);
                }
                if (monster.getBounds().X < monster.LeftLimit)
                {
                    monster.Speed = Math.Abs(monster.Speed);   
                }
                monster.moveX((int)(monster.getBounds().X + monster.Speed * deltaTimeRatio));
            }
        }



        private void tmrGameLoop_Tick(object sender, EventArgs e)
        {
            deltaTime = DateTime.Now.Ticks - timeLastFrame;
            deltaTimeRatio = deltaTime * .000001f;

            if (frames_done > 60 && !game_is_over)
            {
                // apply gravity
                    applyGravity();
                // change character speed based on the friction
                    applyFrictionToXSpeed();

                // move characters bounding box based on the velocity
                    move_character();
                // move monsters
                    move_mosters();

                // do collistion detection with walls and correct bounding box position if detected
                    collistionWithGroundDetectionAndCorrection();

                // move character based on the bounding box
                    pbPlayer.Left = (int)playerBoundingBox.X;
                    pbPlayer.Top = (int)playerBoundingBox.Y;


                // do collistion detection with interactible objects, activat action if any
                CheckForCoins();
                CheckForDoor();
                CheckForMonsters();
            }

            timeLastFrame = DateTime.Now.Ticks;
            frames_done+=1;
        }
    }
}
