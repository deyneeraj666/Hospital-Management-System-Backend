using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAndAdministration_API
{
    public static class RandomNumberGeneartor
    {
        
        private static readonly Random _random = new Random();

     
        public static int Generate(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
