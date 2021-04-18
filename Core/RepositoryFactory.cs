using System;
using System.Collections.Generic;


namespace HelloInWorld.Core
{
    public class RepositoryFactory<T> where T: IItemRepository, new()
    {
        private static Lazy<T> instance = new Lazy<T>(()=>new T());
        public static T GetRepository()=>instance.Value;
    } 
}