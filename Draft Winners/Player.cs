using System;

namespace Draft_Winners
{
    public class Player
    {
        Positions mPosition;
        String mName;
        int mID;
        int mSalary;
        double mAvgFantasyPoints;
        double mDollarsPerPoint;

        public Player(Positions pos, String name, int ID, int Salary, double points)
        {
            mPosition = pos;
            mName = name;
            mID = ID;
            mSalary = Salary;
            mAvgFantasyPoints = points;

            if (mAvgFantasyPoints > 0)
            {
                mDollarsPerPoint = (mSalary / mAvgFantasyPoints);
            }
            else
            {
                mDollarsPerPoint = 0;
            }
        }

        public Positions getPosition()
        {
            return mPosition;
        }

        public String getName()
        {
            return mName;
        }

        public int getID()
        {
            return mID;
        }

        public int getSalary()
        {
            return mSalary;
        }

        public double getFantasyPoints()
        {
            return mAvgFantasyPoints;
        }

        public double getDollarsPerPoint()
        {
            return mDollarsPerPoint;
        }

        public String toString()
        {
            return mPosition + ", " + mName + ", " + mSalary + ", " + mAvgFantasyPoints;
        }

        public String toStringWithDollars()
        {
            if (mDollarsPerPoint == 0)
            {
                return mPosition + ", " + mName + ", " + "No Calculable Value";
            }

            return mPosition + ", " + mName + ", " + mSalary + ", " + Math.Round(mDollarsPerPoint, 2);
        }

        public override Boolean Equals(System.Object obj)
        {
            return mID == ((Player)obj).mID;
        }

        public override int GetHashCode()
        {
            return -1;
        }

        public static Player.Positions convertToEnum(String playerPosition)
        {
            if (playerPosition == Player.Positions.QB.ToString())
            {
                return Player.Positions.QB;
            }
            else if (playerPosition == Player.Positions.RB.ToString())
            {
                return Player.Positions.RB;
            }
            else if (playerPosition == Player.Positions.DST.ToString())
            {
                return Player.Positions.DST;
            }
            else if (playerPosition == Player.Positions.TE.ToString())
            {
                return Player.Positions.TE;
            }
            else if (playerPosition == Player.Positions.WR.ToString())
            {
                return Player.Positions.WR;
            }
            else if (playerPosition == Player.Positions.C.ToString())
            {
                return Player.Positions.C;
            }
            else if (playerPosition == Player.Positions.RW.ToString())
            {
                return Player.Positions.RW;
            }
            else if (playerPosition == Player.Positions.LW.ToString())
            {
                return Player.Positions.LW;
            }
            else if (playerPosition == Player.Positions.D.ToString())
            {
                return Player.Positions.D;
            }
            else if (playerPosition == Player.Positions.G.ToString())
            {
                return Player.Positions.G;
            }
            else if (playerPosition == Player.Positions.F.ToString())
            {
                return Player.Positions.F;
            }

            return Player.Positions.INVALID;
        }

        public enum Positions {QB, RB, WR, TE, DST, C, LW, RW, D, G, F, INVALID}
    }
}
