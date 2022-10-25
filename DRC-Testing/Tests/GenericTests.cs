using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRN_Testing.Tests
{
    internal class GenericTests
    {
        private static string s_keyName = "genericTests";

        [Test, Order(1)]
        public void Add()
        {
            Cache.Set<Data.User>(s_keyName, Data.s_user);
            bool result = Cache.Exists<Data.User>(s_keyName);

            Assert.IsTrue(result);
        }

        [Test, Order(2)]
        public void Update()
        {
            Cache.Update<Data.User>(s_keyName, Data.s_updatedUser);

            bool result = false;
            Data.User getUser = Cache.Get<Data.User>(s_keyName);

            if (getUser.FirstName == Data.s_updatedUser.FirstName)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [Test, Order(3)]
        public void Remove()
        {
            Cache.Remove(s_keyName);
            bool result = Cache.Exists<Data.User>(s_keyName);

            Assert.IsFalse(result);
        }
    }
}
