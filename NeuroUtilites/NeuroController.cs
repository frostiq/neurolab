using System;
using Encog.Engine.Network.Activation;
using Encog.MathUtil.Matrices;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;

namespace NeuroUtilities
{
    public class NeuroController
    {
        private BasicNetwork network = BuildNetwork();

        public double Compute(double left, double right)
        {
            var input = new[] { left, right };
            input = Normalize(input);
            var output = new double[1];
            network.Compute(input, output);
            return output[0];
        }

        private double[] Normalize(double[] data)
        {
            var temp = Matrix.CreateColumnMatrix(data);
            var length = MatrixMath.VectorLength(temp);
            if (Math.Abs(length) > 1E-8)
            {
                temp = MatrixMath.Divide(temp, length); 
            }

            return temp.ToPackedArray();
        }

        private static BasicNetwork BuildNetwork()
        {
            var network = new BasicNetwork();

            network.AddLayer(new BasicLayer(new ActivationLinear(), false, 2));
            network.AddLayer(new BasicLayer(new ActivationLinear(), false, 1));
            network.Structure.FinalizeStructure();
            
            network.AddWeight(0, 0, 0, 1.0);
            network.AddWeight(0, 1, 0, -1.0);

            return network;
        }
    }
}
