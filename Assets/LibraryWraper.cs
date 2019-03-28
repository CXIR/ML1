
using System;
using System.Runtime.InteropServices;

public static class LibraryWraper
{
    [DllImport("libtest")]
    public static extern int Return42(int valuesByModel);

    [DllImport("libtest")]
    public static extern IntPtr Initialize(int valuesByModel);

    [DllImport("libtest")]
    public static extern void Train(IntPtr w, double[] inputs, int valuesUsedByModel, int modelsTested, double[] valuesExpected, double learningStep, int iteration);

    [DllImport("libtest")]
    public static extern int Predict(IntPtr w, double[] inputs, int valuesUsedByModel);

    [DllImport("libtest")]
    public static extern double LinearRegression(double[] xValues, double[] yValues, int numberOfParam, int numberOfObject);
	
	[DllImport("libtest")]
    public static extern double PredictLinear(IntPtr w, double[] inputs, int valuesUsedByModel);
}
