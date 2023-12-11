namespace MeetupDotnet8CS.Keyed
{
    public interface IMathCompute
    {
        public int DoCompute(int a,int b);
    }




    public class Addition : IMathCompute
    {
        public int DoCompute(int a, int b) => a + b;
    }

    public class Multiplication : IMathCompute
    {
        public int DoCompute(int a, int b) => a * b;
    }


}
