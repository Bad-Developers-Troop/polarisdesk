using System;

namespace PolarisDesk.DataAccessLayer
{

    public static class DbInitializer
    {
        public static void Initialize(PolarisDeskContext context)
        {
            context.Database.EnsureCreated();

            //ADD DB INIT FUNCTION

        }
    }

}