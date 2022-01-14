using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbSoftwareWebProject.Common
{
    public static class App
    {
        public static ICommon Common = new DefaultCommon(); // Common değişkenin değerini değiştirmediğimiz sürece varsayılan olarak DefaultCommon() dan dönen değeri dönecek
    }
}
