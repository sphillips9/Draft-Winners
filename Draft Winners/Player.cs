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

        public enum Positions {QB, RB, WR, TE, DST, C, LW, RW, D, G, INVALID}
    }
}
