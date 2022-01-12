using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeMerlin.Commands;
using AwesomeMerlin.Enum;
using AwesomeMerlin.Spell;
using AwesomeMerlin.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
//using Merlin2d.Game.Actors;
//using Merlin2d.Game;
//using Merlin2d.Game.Actors;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{

    public class Player : AbstractCharacter, IMovable, IWizard
    {
        private Move moveLeft;
        private Move moveRight;
        private Move moveDown;
        private Jump moveUp;
        private ISpellDirector director;
        private int mana = 300;
        private int maxMana = 300;
        
        private Box box;
        private IWorld world;
        private int hp;
        private int manas;
        private string smanas;
        private string shp;
        private int hack = 2;
        
        // int counter = 0;
        // private IActor actor;
        // private IWorld world;
        // private int y = 500;


        Animation animation;
        
        private bool lift = false;
        public Player()
        {
            animation = new Animation("resources/player.png", 28, 47);
            director = new SpellDirector(this);

            this.SetAnimation(animation);
            //this.SetPosition(200, 500);
            animation.Start();
            SetPhysics(true);
            moveLeft = new Move(this, -1, 0);
            moveRight = new Move(this, 1, 0);
            moveUp = new Jump(this, 4, 0, -1);
            moveDown = new Move(this, 0, 1);
        }

        public void Cast(ISpell spell)
        {
            throw new NotImplementedException();
        }

        public void ChangeMana(int delta)
        {
            mana += delta;
            if (mana > maxMana) // nemôže prekročiť viac  ako je jeho maximalna hodnota
            {
                mana = maxMana;
            }
            if (mana < 0) // a taktiež nemože byť záporná
            {
                mana = 0;
            }
        }

        public int GetMana()
        {
            return mana;
        }

        public override void Update()
        {
            
            IActor skeleton = GetWorld().GetActors().Find(a => a.GetName() == "skeleton");
            //IActor skel = GetWorld().GetActors().Find(a => a.GetName() == "skel");
            IActor box = GetWorld().GetActors().Find(a => a.GetName() == "box");
            hp = GetHealth();
            shp = hp.ToString();
            manas = GetMana();
            smanas = manas.ToString();
            Message message = new Message(shp, GetX() + 10, GetY() - 15, 11, Color.Red, (MessageDuration)2);
            Message messages = new Message(smanas, GetX() + 10, GetY() - 30, 11, Color.Blue, (MessageDuration)2);
            GetWorld().AddMessage(message);
            GetWorld().AddMessage(messages);

            if (GetWorld().GetActors().Find(a => a.GetName() == "skeleton") == null) // ak sa nenachádza v mape žiaden skeleton
            {
                world = GetWorld(); // znova si musim zavolať svet
                world.SetEndCondition(world => MapStatus.Finished);
            }


            if (this.IntersectsWithActor(skeleton))
            {
                this.SetPosition(defaultX.Value, defaultY.Value);
                this.ChangeHealth(-50);
            }








            if (this.GetHealth() == 0)
            {
                this.Die();
            }
            if (state == false)
            {
                animation.Stop();
                world = GetWorld();
                world.SetEndCondition(world => MapStatus.Failed);
            }
            //if (GetWorld().GetActors().Find(a => a.GetName() == "skeleton") == null) // ak sa nenachádza v mape žiaden skeleton
            //{
            //    world = GetWorld(); // znova si musim zavolať svet
            //    world.SetEndCondition(world => MapStatus.Finished);
            //}

            if (this.IntersectsWithActor(box) && GetWorld().IntersectWithWall(box))
            {
                //int x_p = this.GetX();
                //int y_p = this.GetY();
                //int x_e = box.GetX();
                //int y_e = box.GetY();


                ////Intersect from side -------
                //int diff = y_e - y_p;

                //if (diff > -(GetHeight() - 1) && diff < this.GetHeight() - 1)
                //{
                //    if (GetX() < this.GetX())
                //    {
                //        SetPosition(GetX() - 1, GetY());
                //    }
                //    else
                //    {
                //        SetPosition(GetX() + 1, GetY());
                //    }
                //}
            }

            if (Input.GetInstance().IsKeyDown(Input.Key.UP))
            {
                animation.Start();
                moveUp.Execute();
                this.lift = true;



            }
            if (this.lift == true)
            {
                this.SetPosition(this.GetX(), this.GetY() + 1);
                if (this.GetWorld().IntersectWithWall(this))
                {
                    this.SetPosition(this.GetX(), this.GetY() - 1);
                    this.lift = false;
                }
            }


            if (Input.GetInstance().IsKeyDown(Input.Key.DOWN))
            {
                animation.Start();
                moveDown.Execute();


            }
            if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {

                moveRight.Execute();
                if (Direction == ActorOrientation.FacingLeft)
                {
                    animation.FlipAnimation();

                }
                Direction = ActorOrientation.FacingRight;
                animation.Start();

            }
            else
            {
                animation.Stop();
            }
            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {
                animation.Start();
                if (Direction == ActorOrientation.FacingRight)
                {
                    animation.FlipAnimation();
                }
                Direction = ActorOrientation.FacingLeft;

                moveLeft.Execute();

            }
            if (Input.GetInstance().IsKeyPressed(Input.Key.Q))
            {
                ISpell spell = director.Build("Fireball");

                if (manas >= spell.GetCost())
                {
                    spell.Cast();
                    ChangeMana(-spell.GetCost());
                }
            }
            if (Input.GetInstance().IsKeyPressed(Input.Key.R))
            {
                ISpell spell = director.Build("Frostball");

                if (manas >= spell.GetCost())
                {
                    spell.Cast();
                    ChangeMana(-spell.GetCost());
                }
            }
            
        }
    }
}
