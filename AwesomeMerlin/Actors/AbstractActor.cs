using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    public class AbstractActor :  IActor
    {
        public string name;
        private Animation animation;
        private IWorld world;
        private bool shouldBeRemoved;
        private int x;
        private int y;
        private bool physics;

        protected int? defaultX = null;   //? mi povoli tam dať null
        protected int? defaultY = null;


        public AbstractActor() : this(string.Empty)
        {

        }
        public AbstractActor(string name)
        {
            this.name = name;
        }
        public Animation GetAnimation()
        {
            return animation;
        }

        public int GetHeight()
        {
            return animation.GetHeight();

        }

        public string GetName()
        {
            return this.name;
        }

        public int GetWidth()
        {
            return animation.GetWidth();
        }

        public IWorld GetWorld()
        {
            return world;
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public bool IntersectsWithActor(IActor other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                int x_p = this.GetX();
                int y_p = this.GetY();
                int x_e = other.GetX();
                int y_e = other.GetY();

                int height_p = this.GetHeight();
                int width_p = this.GetWidth();

                int height_e = other.GetHeight();
                int width_e = other.GetWidth();

                int height = Math.Max(this.GetHeight(), other.GetHeight());
                int width = Math.Max(this.GetWidth(), other.GetWidth());


                //Rezervy 6 px
                if (y_p + height_p >= y_e && y_p + height_p <= y_e + 6 && x_p + width_p > x_e && x_p < x_e + width_e) // zhora
                {
                    return true;
                }
                if (((y_p + height_p) >= y_e && y_p <= (y_e + height_e)) && ((x_p + width_p) <= x_e + 6) && ((x_p + width_p) >= x_e)) // z ľava
                {
                    return true;
                }
                if (y_p == y_e && x_p == x_e - width_e)
                {
                    return true;
                }
                if (((y_p + height_p) >= y_e && y_p <= (y_e + height_e)) && (x_p <= (x_e + width_e) && (x_p >= (x_e + width_e) - 6))) // z prava
                {
                    return true;
                }


                //if(y_p + height_p < y_e && x_p + width_p == x_e && y_p <= y_e + height_e )
                //{
                //    return true;
                //}
                //if (y_p + height_p < y_e && x_p + width_p == x_e)
                //{
                //    if(y_p >= height_e && x_p + width_p == x_e)//|| y_p + height_p < y_e && x_p == x_e + width_e)

                //        {
                //    return true;
                //}


                //    int yDiff;
                //    int rightDiff;
                //    int leftDiff;

                //    if (Math.Abs(x_p - x_e) <= width_p)
                //    {
                //        yDiff = y_p + this.GetHeight() - y_e;
                //        if (yDiff <= 2 && yDiff >= height)
                //        {
                //            return true;
                //        }
                //        //else if (y_p - this.GetHeight() == y_e)
                //        //{
                //        //     return true;
                //        //}
                //    }


                //    int diff = y_e - y_p;

                //    if (diff > -(other.GetHeight() - 1) && diff < other.GetHeight() - 1)
                //    {
                //        rightDiff = x_p + this.GetWidth() - x_e;
                //        leftDiff = x_e + other.GetWidth() - x_p;
                //        if (rightDiff <= width && rightDiff >= -2) // zprava
                //        {
                //            return true;
                //        }
                //        if (leftDiff <= width && leftDiff >= -2) //zľava
                //        {
                //            return true;
                //        }
                //    }
                return false;
            }
        }

        public bool IsAffectedByPhysics()
        {
            if (this.physics == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OnAddedToWorld(IWorld world)
        {
            this.world = world;
        }

        public bool RemovedFromWorld()
        {
            return shouldBeRemoved;

        }

        public void RemoveFromWorld()
        {
            this.shouldBeRemoved = true;


        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            if (isPhysicsEnabled == true)
            {
                this.physics = true;
            }
            else
            {
                this.physics = false;
            }
        }

        public void SetPosition(int posX, int posY)
        {
            this.x = posX;
            this.y = posY;

            if(defaultX == null)
            {
                defaultX = posX;
            }
            if(defaultY == null)
            {
                defaultY = posY;
            }
        }

        public virtual void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
