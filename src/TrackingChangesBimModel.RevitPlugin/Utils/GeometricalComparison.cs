namespace TrackingChangesBimModel.RevitPlugin.Utils;

internal static class GeometricalComparison
{
    public static bool IsZero(double a,double tolerance)
    {
        return tolerance > Math.Abs(a);
    }

    public static bool IsZero(double a)
    {
        return IsZero(a, Constants.Eps);
    }

    public static bool IsEqual(double a, double b)
    {
        return IsZero(b - a);
    }

    public static int Compare(double a, double b)
    {
        return IsEqual(a, b) ? 0 : (a < b ? -1 : 1);
    }

    public static int Compare(XYZ p, XYZ q)
    {
        int d = Compare(p.X, q.X);

        if (0 == d)
        {
            d = Compare(p.Y, q.Y);

            if (0 == d)
            {
                d = Compare(p.Z, q.Z);
            }
        }
        return d;
    }
}
