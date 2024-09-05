using System;
using System.Collections.Generic;
using Color = System.Drawing.Color;

namespace ColorUtility
{
    public static class ColorControls
    {
        public static List<Color> GetColorGradient(Color from, Color to, int totalNumberOfColors)
        {
            List<Color> list = new List<Color>();
            if (totalNumberOfColors < 2)
            {
                throw new ArgumentException("Gradient cannot have less than two colors.", "totalNumberOfColors");
            }
            double num = to.A - from.A;
            double num2 = to.R - from.R;
            double num3 = to.G - from.G;
            double num4 = to.B - from.B;
            int num5 = totalNumberOfColors - 1;
            double stepC2 = num / (double)num5;
            double stepC3 = num2 / (double)num5;
            double stepC4 = num3 / (double)num5;
            double stepC5 = num4 / (double)num5;
            list.Add(from);
            int i = 1;
            while (i < num5)
            {
                list.Add(Color.FromArgb(c(from.A, stepC2), c(from.R, stepC3), c(from.G, stepC4), c(from.B, stepC5)));
                int num6 = i + 1;
                i = num6;
            }
            list.Add(to);
            return list;
            int c(int fromC, double stepC)
            {
                return (int)Math.Round((double)fromC + stepC * (double)i);
            }
        }
    }
}
