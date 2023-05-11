namespace DesignPrinciples.Structural
{
    //The Proxy design pattern provides a surrogate or placeholder for another object to control access to it.
    //Proxies delegate all of the real work to some other object. Each proxy method should, in the end, refer to a service object unless the proxy is a subclass of a service.

    //Subject
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    //RealSubject
    public class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

    //Proxy
    public class MathProxy : IMath
    {
        private Math math = new Math();

        public double Add(double x, double y) { return math.Add(x, y); }

        public double Sub(double x, double y) { return math.Sub(x, y); }

        public double Mul(double x, double y) { return math.Mul(x, y); }

        public double Div(double x, double y) { return math.Div(x, y); }
    }
}
