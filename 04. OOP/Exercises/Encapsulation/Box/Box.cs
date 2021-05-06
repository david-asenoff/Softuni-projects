using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        private decimal Length
        {
            get => this.length;
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Length"+Exception.CanNotBeZeroOrNegative);
                }
                this.length = value;
            }
        }
        private decimal Width
        {
            get => this.width;
        
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width" + Exception.CanNotBeZeroOrNegative);
                }
                this.width = value;
            }
        }
        private decimal Height
        {
            get => this.height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height" + Exception.CanNotBeZeroOrNegative);
                }

                this.height = value;
            }
        }

        public Box(decimal length, decimal width, decimal height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        //surface area, lateral surface area and its volume

        public decimal SurfaceArea()
        {
            decimal surfaceArea = 2 * Length * Width +
                                 LateralSurfaceArea();
            return surfaceArea;
        }
        public decimal LateralSurfaceArea()
        {
            decimal lateralSurfaceArea = 2 * Length * Height +
                                 2 * Width * Height;
            return lateralSurfaceArea;
        }
        public decimal Volume()
        {
            decimal volume = this.Length * this.Width * this.Height;
            return volume;
        }
    }
}
