using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class UserNameException:Exception
    {
        
        public UserNameException(string username):
            base(string.Format($"invalid UserName {username}"))
        {
             
        }
    }
}
