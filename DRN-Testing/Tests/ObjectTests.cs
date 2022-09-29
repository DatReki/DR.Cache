using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRN_Testing.Tests
{
    internal class ObjectTests
    {
        private static string s_keyName = "objectTests";

        [Test, Order(1)]
        public void Add()
        {
            Cache.Set(s_keyName, Data.s_user);
            bool result = Cache.Exists(s_keyName);

            Assert.IsTrue(result);
        }

        [Test, Order(2)]
        public void Update()
        {
            Cache.Update(s_keyName, Data.s_updatedUser);

            bool result = false;
            object getUser = Cache.Get(s_keyName);

            if (getUser != null)
            {
                Data.User checkUser = (Data.User)getUser;
                if (checkUser.FirstName == Data.s_updatedUser.FirstName)
                {
                    result = true;
                }
            }

            Assert.IsTrue(result);
        }

        [Test, Order(3)]
        public void Remove()
        {
            Cache.Remove(s_keyName);
            bool result = Cache.Exists(s_keyName);

            Assert.IsFalse(result);
        }
    }
}
