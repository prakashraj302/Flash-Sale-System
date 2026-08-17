
using System.Net;

public class Miantance
{
    public int Maxnonoverlap(int[][] interval)
    {
        Array.Sort(interval,(a,b)=> a[1].CompareTo(b[1]));
        int count = 0;
        int lastendTime= int.MinValue;
        foreach (var intervals in interval)
        {
            int start = intervals[0];
            int end = intervals[1];

            if (start > lastendTime)
            {
                count++;
                lastendTime = end;
            }
        }
        return count;
    }
}
public class program
{
    public static void Main(string[] args)
    {
        int[][] intervals = new int[][]
        {
            new int[] {900,1030},
            new int[] {1000,1100},
            new int[] {1030,1130 },
            new int[] {1100,1200 }
        };

        Miantance call = new Miantance();
        int result = call.Maxnonoverlap(intervals);
        Console.WriteLine(result);
    }
}