using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSimple.SDK.Structs
{
    public struct Color
    {
        public int r;
        public int g;
        public int b;
        public int a;

        public Color(int r, int g, int b, int a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    };
}
