public class DisjointSet
{
    private int[] representatives;
    private int[] rank;

    public DisjointSet(int size)
    {
        this.representatives = new int[size];
        this.rank = new int[size];

        for (int i = 0; i < size; i++)
        {
            this.representatives[i] = i;
            this.rank[i] = 0;
        }
    }

    public int FindRepresentative(int num)
    {
        if (this.representatives[num] == num)
        {
            return num;
        }
        int result = this.FindRepresentative(this.representatives[num]);
        this.representatives[num] = result;
        return result;
    }

    public bool Union(int num1, int num2)
    {
        int Num1Rep = this.FindRepresentative(num1);
        int Num2Rep = this.FindRepresentative(num2);
        if (Num1Rep == Num2Rep)
        {
            return true;
        }
        int Num1Rank = this.rank[Num1Rep];
        int Num2Rank = this.rank[Num2Rep];

        if (Num1Rank < Num2Rank)
        {
            this.representatives[Num1Rep] = Num2Rep;
            return true;
        }
        else if (Num1Rank > Num2Rank)
        {
            this.representatives[Num2Rep] = Num1Rep;
            return true;
        }
        else
        {
            this.representatives[Num1Rep] = Num2Rep;
            this.rank[Num2Rep]++;
            return true;
        }
    }


}